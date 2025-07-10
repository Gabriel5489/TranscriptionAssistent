using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace TranscriptionAssistent
{
    public partial class frmTranslator : Form
    {
        private string _tituloCapitulo = string.Empty;

        private bool IsEdition = false;
        public frmTranslator()
        {
            InitializeComponent();
            txtDirectorio.Text = Settings.Default.LatestFolderPath;
            this.AutoSize = true;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbTipoGlobo.SelectedIndex = 0;
            cmbProyecto.SelectedIndex = 0;
        }


        #region "Funciones para la aplicación"

        //Función para validar que el directorio y el título del capítulo no estén vacíos.
        private bool ValidarTituloDirectorio()
        {
            if (txtDirectorio.Text == string.Empty || txtCapitulo.Text == string.Empty)
            {
                MessageBox.Show("Por favor, seleccione un directorio para guardar el archivo y asigna el capítulo del proyecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (rtxtTextoCopiado.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Por favor, añade un texto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void CopiarTextoPortapapeles()
        {
            string textoCopiado = Clipboard.GetText();
            string textoSinSaltos = textoCopiado.Replace("\r\n", string.Empty).Replace("\n", string.Empty);

            rtxtTextoCopiado.Text += textoSinSaltos;

            rtxtTextoCopiado.SelectionStart = rtxtTextoCopiado.Text.Length;
            rtxtTextoCopiado.SelectionLength = 0;
        }

        //Función para agregar una línea al archivo de texto.
        private void AgregarLinea()
        {
            string directorioGuardado = _tituloCapitulo;
            if (!IsEdition)
            {
                if (!ValidarTituloDirectorio() || rtxtTextoCopiado.Text == string.Empty) return;
                _tituloCapitulo = cmbProyecto.Text + " Capítulo " + txtCapitulo.Text.Trim() + ".txt";
                directorioGuardado = txtDirectorio.Text + "\\" + _tituloCapitulo;
                txtCapitulo.Enabled = false;
            }
            else if(rtxtTextoCopiado.Text == string.Empty)
            {
                return;
            }


            string textoTranscripcion = rtxtTextoCopiado.Text.Trim().Replace("\r\n", string.Empty).Replace("\n", string.Empty);
            using (StreamWriter writer = new StreamWriter(directorioGuardado, true))
            {
                GuardarDataGrid();
                string vineta = cmbTipoGlobo.Text.IndexOf("Nota de Traductor") > -1 ? "N/T: " : cmbTipoGlobo.Text.Substring(0, 1);
                writer.WriteLine($"{vineta}{textoTranscripcion}");
                writer.Close();
                CargarArchivo(directorioGuardado, vineta);
            }

            rtxtTextoCopiado.Clear();
            cmbProyecto.Enabled = false;
        }

        //Función para cargar el archivo de texto en el DataGridView y entrar en el modo edición.
        private void CargarArchivo(string path, string vineta = "")
        {
            StreamReader reader = new StreamReader(path);
            List<string> lineasArchivo = reader.ReadToEnd().Replace("\r", "").Split("\n").ToList();
            lineasArchivo.RemoveAll(x => x == "");
            dgvPreview.Rows.Clear();
            foreach (string linea in lineasArchivo)
            {
                int indexLinea = linea.IndexOf("N/T: ");
                if (indexLinea > -1 && indexLinea == 0) vineta = "N/T: ";
                DataGridViewRow row = dgvPreview.Rows[dgvPreview.Rows.Add()];
                row.Cells[0].Value = vineta != "N/T: " ? linea.Substring(0, 1) : vineta;
                row.Cells[1].Value = vineta == "N/T: " ? linea.Substring(5) : linea.Substring(1);
            }
            dgvPreview.CurrentCell = dgvPreview.Rows[dgvPreview.Rows.Count - 1].Cells[0];
            reader.Close();
        }

        //Función para sobreescribir o guardar el contenido del DataGridView en un archivo de texto.
        private void GuardarDataGrid()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_tituloCapitulo))
                {
                    foreach (DataGridViewRow row in dgvPreview.Rows)
                    {
                        writer.WriteLine($"{row.Cells[0].Value}{row.Cells[1].Value}");
                    }
                    writer.Close();
                    dgvPreview.CurrentCell = dgvPreview.Rows[dgvPreview.Rows.Count - 1].Cells[0];
                    dgvPreview.Rows[dgvPreview.Rows.Count - 1].Selected = true;
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        #endregion

        #region "Eventos de los controles"
        private void rtxtTextoCopiado_MouseHover(object sender, EventArgs e)
        {
            if (chkPortapapeles.Checked) CopiarTextoPortapapeles();
        }

        //Evento para el botón que permite seleccionar el directorio
        private void btnDirectorio_Click(object sender, EventArgs e)
        {
            if (fbdDirectorio.ShowDialog() == DialogResult.OK)
            {
                GuardarDataGrid();
                dgvPreview.Rows.Clear();
                txtCapitulo.Enabled = true;
                txtCapitulo.Clear();
                cmbProyecto.Enabled = true;

                txtDirectorio.Text = fbdDirectorio.SelectedPath;
                Settings.Default.LatestFolderPath = fbdDirectorio.SelectedPath;
                Settings.Default.Save();
            }
        }

        //Evento para el botón que permite cargar un archivo de texto existente.
        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            ofdCargaArchivo.Filter = "Text Files | *.txt";
            ofdCargaArchivo.Multiselect = false;
            ofdCargaArchivo.Title = "Cargar Archivo de Texto";
            if (ofdCargaArchivo.ShowDialog() == DialogResult.OK)
            {

                string path = ofdCargaArchivo.FileName;
                if (File.Exists(path))
                {
                    try
                    {
                        CargarArchivo(path);
                        IsEdition = true;
                        _tituloCapitulo = path;
                        txtDirectorio.Text = Path.GetDirectoryName(path);
                        lblArchivoEditando.Text = "Archivo editando: " + Path.GetFileName(path);
                        lblArchivoEditando.Visible = true;
                        cmbProyecto.Enabled = false;
                        txtCapitulo.Enabled = false;
                        btnDirectorio.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El texto del archivo no contiene un formato adecuado.");
                    }
                }
                else
                {
                    MessageBox.Show("El archivo seleccionado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Evento para el botón que permite agregar texto al archivo.
        private void btnAddTexto_Click(object sender, EventArgs e)
        {
            AgregarLinea();
        }

        //Evento para el botón que permite guardar el capítulo activo e iniciar otro.
        private void btnSave_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("¿Realmente deseas finlaizar el capítulo?", "Finalizar Capítulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No)
            {
                return;
            }
            respuesta = DialogResult.No;
            if (!IsEdition)
            {
                respuesta = MessageBox.Show("¿Deseas realizar otro capítulo del mismo proyecto?", "Finalizar Capítulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }


            if (respuesta == DialogResult.No)
            {
                cmbProyecto.Enabled = true;
                txtCapitulo.Clear();
            }
            else
            {
                txtCapitulo.Text = Convert.ToDouble(txtCapitulo.Text) + 1 + "";
            }

            txtCapitulo.Enabled = true;
            string directorio = !IsEdition ? txtDirectorio.Text + "\\" + _tituloCapitulo : _tituloCapitulo;
            GuardarDataGrid();
            MessageBox.Show("Capítulo guardado correctamente en " + directorio, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            IsEdition = false;
            _tituloCapitulo = string.Empty;
            btnDirectorio.Enabled = true;
            dgvPreview.Rows.Clear();
        }

        //Eventos para los atajos de la caja de texto editable.
        private void rtxtTextoCopiado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                AgregarLinea();
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                CopiarTextoPortapapeles();
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        cmbTipoGlobo.SelectedIndex = 0;
                        break;
                    case Keys.F2:
                        cmbTipoGlobo.SelectedIndex = 1;
                        break;
                    case Keys.F3:
                        cmbTipoGlobo.SelectedIndex = 2;
                        break;
                    case Keys.F4:
                        cmbTipoGlobo.SelectedIndex = 3;
                        break;
                    case Keys.F5:
                        cmbTipoGlobo.SelectedIndex = 4;
                        break;
                    case Keys.F6:
                        cmbTipoGlobo.SelectedIndex = 5;
                        break;
                    case Keys.F7:
                        cmbTipoGlobo.SelectedIndex = 6;
                        break;
                }
            }
        }

        //Evento para validar que el texto del capítulo sea un número entero o decimal.
        private void txtCapitulo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            var texto = txtCapitulo.Text.IndexOf('.');
            if (e.KeyChar == '.' && txtCapitulo.Text.IndexOf('.') == -1)
            {
                e.Handled = false;
            }

        }

        //Evento para validar que el texto pegado o escrito evite los saltos de linea.
        private void rtxtTextoCopiado_TextChanged(object sender, EventArgs e)
        {

        }

        #endregion

        private void dgvPreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se hizo clic en el botón correcto
            if (dgvPreview.Columns[e.ColumnIndex].Name == "cdgvEliminar" && e.RowIndex >= 0)
            {
                var respuesta = MessageBox.Show("¿Estás seguro de eliminar esta fila?", "Eliminación de fila", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    dgvPreview.Rows.RemoveAt(e.RowIndex);
                    GuardarDataGrid();
                }
            }
        }

        private void dgvPreview_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (dgvPreview.Columns[e.ColumnIndex].Name == "cdgvEliminar" && e.RowIndex >= 0)
                {
                    cdgvEliminar.Image = Properties.Resources.icons8_eliminar_color_310_hover;
                }

            }
            catch (Exception ex)
            {
                //
            }
        }

        private void dgvPreview_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPreview.Columns[e.ColumnIndex].Name == "cdgvEliminar" && e.RowIndex >= 0)
                {
                    cdgvEliminar.Image = Properties.Resources.icons8_eliminar_color_310;
                }
            }
            catch
            {
                //
            }
        }

        private void btnDirectorio_MouseHover(object sender, EventArgs e)
        {
            if (IsEdition)
                tipBtnDirectorio.SetToolTip(btnDirectorio, "Para poder seleccionar un directorio primero termina el capítulo.");
        }

        private void frmTranslator_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardarDataGrid();
        }

        private void dgvPreview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GuardarDataGrid();
        }
    }
}
