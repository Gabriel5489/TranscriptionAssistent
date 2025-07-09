using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace TranscriptionAssistent
{
    public partial class frmTranslator : Form
    {
        private string _tituloCapitulo = string.Empty;

        FolderBrowserDialog directoryDialog;
        public frmTranslator()
        {
            InitializeComponent();
            this.AutoSize = true;
            this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cmbTipoGlobo.SelectedIndex = 0;
            cmbProyecto.SelectedIndex = 0;
            directoryDialog = new FolderBrowserDialog();
        }

        private void rtxtTextoCopiado_MouseHover(object sender, EventArgs e)
        {
            if (chkPortapapeles.Checked) CopiarTextoPortapapeles();
        }

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

            if (rtxtTextoCopiado.Text != textoSinSaltos)
            {
                rtxtTextoCopiado.Text = textoSinSaltos;

                rtxtTextoCopiado.SelectionStart = rtxtTextoCopiado.Text.Length;
                rtxtTextoCopiado.SelectionLength = 0;
            }
        }

        private void btnDirectorio_Click(object sender, EventArgs e)
        {
            if (directoryDialog.ShowDialog() == DialogResult.OK)
            {
                txtDirectorio.Text = directoryDialog.SelectedPath;
            }
        }

        private void btnAddTexto_Click(object sender, EventArgs e)
        {
            AgregarLinea();
        }

        private void AgregarLinea()
        {
            if (!ValidarTituloDirectorio() || rtxtTextoCopiado.Text == string.Empty) return;

            _tituloCapitulo = cmbProyecto.Text + " Capítulo " + txtCapitulo.Text.Trim() + ".txt";

            txtCapitulo.Enabled = false;
            string textoTranscripcion = rtxtTextoCopiado.Text.Trim().Replace("\r\n", string.Empty).Replace("\n", string.Empty);
            using (StreamWriter writer = new StreamWriter(txtDirectorio.Text + "\\" + _tituloCapitulo, true))
            {
                switch (cmbTipoGlobo.Text)
                {
                    case "Dialogo":
                        writer.WriteLine($"-{textoTranscripcion}");
                        break;
                    case "Gritos":
                        writer.WriteLine($">{textoTranscripcion}");
                        break;
                    case "Pensamiento":
                        writer.WriteLine($"_{textoTranscripcion}");
                        break;
                    case "Narración/Rectángulo":
                        writer.WriteLine($"[{textoTranscripcion}");
                        break;
                    case "Fuera de globo":
                        writer.WriteLine($"]{textoTranscripcion}");
                        break;
                    case "Nota de Traductor":
                        writer.WriteLine($"N/T:{textoTranscripcion}");
                        break;
                    default:
                        break;
                }
            }
            rtxtTextoCopiado.Clear();
            cmbProyecto.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("¿Deseas realizar otro capítulo del mismo proyecto?", "Finalizar Capítulo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
            MessageBox.Show("Capítulo guardado correctamente en " + txtDirectorio.Text + "\\" + _tituloCapitulo, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rtxtTextoCopiado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el pitido del sistema
                AgregarLinea();
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
                }
            }
        }

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

        private void rtxtTextoCopiado_TextChanged(object sender, EventArgs e)
        {
            rtxtTextoCopiado.Text = rtxtTextoCopiado.Text.Trim().Replace("\r\n", string.Empty).Replace("\n", string.Empty);
            rtxtTextoCopiado.SelectionStart = rtxtTextoCopiado.Text.Length;
            rtxtTextoCopiado.SelectionLength = 0;
        }
    }
}
