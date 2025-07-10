namespace TranscriptionAssistent
{
    partial class frmTranslator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTranslator));
            rtxtTextoCopiado = new RichTextBox();
            cmbTipoGlobo = new ComboBox();
            btnAddTexto = new Button();
            fbdDirectorio = new FolderBrowserDialog();
            txtDirectorio = new TextBox();
            btnDirectorio = new Button();
            chkPortapapeles = new CheckBox();
            label1 = new Label();
            btnSave = new Button();
            cmbProyecto = new ComboBox();
            txtCapitulo = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            dgvPreview = new DataGridView();
            cdgvVineta = new DataGridViewTextBoxColumn();
            cdgvTexto = new DataGridViewTextBoxColumn();
            cdgvEliminar = new DataGridViewImageColumn();
            ofdCargaArchivo = new OpenFileDialog();
            btnCargarArchivo = new Button();
            lblArchivoEditando = new Label();
            tipBtnDirectorio = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgvPreview).BeginInit();
            SuspendLayout();
            // 
            // rtxtTextoCopiado
            // 
            rtxtTextoCopiado.Location = new Point(29, 254);
            rtxtTextoCopiado.Name = "rtxtTextoCopiado";
            rtxtTextoCopiado.Size = new Size(351, 159);
            rtxtTextoCopiado.TabIndex = 0;
            rtxtTextoCopiado.Text = "";
            rtxtTextoCopiado.TextChanged += rtxtTextoCopiado_TextChanged;
            rtxtTextoCopiado.KeyDown += rtxtTextoCopiado_KeyDown;
            rtxtTextoCopiado.MouseHover += rtxtTextoCopiado_MouseHover;
            // 
            // cmbTipoGlobo
            // 
            cmbTipoGlobo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoGlobo.FormattingEnabled = true;
            cmbTipoGlobo.Items.AddRange(new object[] { "- Dialogo", "> Gritos", "_ Pensamiento", "[ Narración/Rectángulo", "] Fuera de globo", "N/T: Nota de Traductor", "* Título" });
            cmbTipoGlobo.Location = new Point(29, 225);
            cmbTipoGlobo.Name = "cmbTipoGlobo";
            cmbTipoGlobo.Size = new Size(231, 23);
            cmbTipoGlobo.TabIndex = 1;
            // 
            // btnAddTexto
            // 
            btnAddTexto.Location = new Point(405, 254);
            btnAddTexto.Name = "btnAddTexto";
            btnAddTexto.Size = new Size(175, 65);
            btnAddTexto.TabIndex = 2;
            btnAddTexto.Text = "Añadir Linea";
            btnAddTexto.UseVisualStyleBackColor = true;
            btnAddTexto.Click += btnAddTexto_Click;
            // 
            // txtDirectorio
            // 
            txtDirectorio.Enabled = false;
            txtDirectorio.Location = new Point(29, 42);
            txtDirectorio.Name = "txtDirectorio";
            txtDirectorio.Size = new Size(351, 23);
            txtDirectorio.TabIndex = 3;
            // 
            // btnDirectorio
            // 
            btnDirectorio.Location = new Point(405, 41);
            btnDirectorio.Name = "btnDirectorio";
            btnDirectorio.Size = new Size(31, 23);
            btnDirectorio.TabIndex = 4;
            btnDirectorio.Text = "...";
            btnDirectorio.UseVisualStyleBackColor = true;
            btnDirectorio.Click += btnDirectorio_Click;
            btnDirectorio.MouseHover += btnDirectorio_MouseHover;
            // 
            // chkPortapapeles
            // 
            chkPortapapeles.AutoSize = true;
            chkPortapapeles.Location = new Point(286, 227);
            chkPortapapeles.Name = "chkPortapapeles";
            chkPortapapeles.Size = new Size(289, 19);
            chkPortapapeles.TabIndex = 5;
            chkPortapapeles.Text = "Copiar automaticamente el texto del portapapeles";
            chkPortapapeles.UseVisualStyleBackColor = true;
            chkPortapapeles.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(29, 17);
            label1.Name = "label1";
            label1.Size = new Size(348, 21);
            label1.TabIndex = 6;
            label1.Text = "Selecciona el directorio donde guardar el archivo";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(405, 341);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(175, 72);
            btnSave.TabIndex = 9;
            btnSave.Text = "Terminar capítulo";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // cmbProyecto
            // 
            cmbProyecto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProyecto.FormattingEnabled = true;
            cmbProyecto.Items.AddRange(new object[] { "The All-Devouring Whale", "Zombie World", "List of the Villains", "Thange Ga", "The Barrens", "Babel", "Periodo Cretaceo" });
            cmbProyecto.Location = new Point(29, 97);
            cmbProyecto.Name = "cmbProyecto";
            cmbProyecto.Size = new Size(171, 23);
            cmbProyecto.TabIndex = 10;
            // 
            // txtCapitulo
            // 
            txtCapitulo.Location = new Point(280, 95);
            txtCapitulo.Name = "txtCapitulo";
            txtCapitulo.PlaceholderText = "Ej. 10, 10.1";
            txtCapitulo.Size = new Size(100, 23);
            txtCapitulo.TabIndex = 11;
            txtCapitulo.KeyPress += txtCapitulo_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(206, 95);
            label2.Name = "label2";
            label2.Size = new Size(68, 21);
            label2.TabIndex = 12;
            label2.Text = "Capítulo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(29, 73);
            label3.Name = "label3";
            label3.Size = new Size(71, 21);
            label3.TabIndex = 13;
            label3.Text = "Proyecto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(29, 201);
            label4.Name = "label4";
            label4.Size = new Size(105, 21);
            label4.TabIndex = 14;
            label4.Text = "Tipo de globo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(455, 17);
            label5.Name = "label5";
            label5.Size = new Size(58, 21);
            label5.TabIndex = 15;
            label5.Text = "Atajos";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(455, 42);
            label6.Name = "label6";
            label6.Size = new Size(167, 19);
            label6.TabIndex = 16;
            label6.Text = "Ctrl+Enter = Añadir Linea";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(455, 73);
            label7.Name = "label7";
            label7.Size = new Size(95, 19);
            label7.TabIndex = 17;
            label7.Text = "F1 = Dialogos";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F);
            label8.Location = new Point(455, 92);
            label8.Name = "label8";
            label8.Size = new Size(79, 19);
            label8.TabIndex = 18;
            label8.Text = "F2 = Gritos";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.Location = new Point(455, 111);
            label9.Name = "label9";
            label9.Size = new Size(126, 19);
            label9.TabIndex = 19;
            label9.Text = "F3 = Pensamientos";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F);
            label10.Location = new Point(455, 130);
            label10.Name = "label10";
            label10.Size = new Size(174, 19);
            label10.TabIndex = 20;
            label10.Text = "F4 = Narración/Rectángulo";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 10F);
            label11.Location = new Point(455, 149);
            label11.Name = "label11";
            label11.Size = new Size(134, 19);
            label11.TabIndex = 21;
            label11.Text = "F5 = Fuera de globo";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F);
            label12.Location = new Point(455, 168);
            label12.Name = "label12";
            label12.Size = new Size(153, 19);
            label12.TabIndex = 22;
            label12.Text = "F6 = Nota de Traductor";
            // 
            // dgvPreview
            // 
            dgvPreview.AllowUserToAddRows = false;
            dgvPreview.AllowUserToDeleteRows = false;
            dgvPreview.BackgroundColor = SystemColors.ControlLight;
            dgvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPreview.Columns.AddRange(new DataGridViewColumn[] { cdgvVineta, cdgvTexto, cdgvEliminar });
            dgvPreview.Location = new Point(29, 488);
            dgvPreview.MultiSelect = false;
            dgvPreview.Name = "dgvPreview";
            dgvPreview.Size = new Size(552, 264);
            dgvPreview.TabIndex = 24;
            dgvPreview.CellContentClick += dgvPreview_CellContentClick;
            dgvPreview.CellEndEdit += dgvPreview_CellEndEdit;
            dgvPreview.CellMouseEnter += dgvPreview_CellMouseEnter;
            dgvPreview.CellMouseLeave += dgvPreview_CellMouseLeave;
            // 
            // cdgvVineta
            // 
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            cdgvVineta.DefaultCellStyle = dataGridViewCellStyle1;
            cdgvVineta.HeaderText = "Viñeta";
            cdgvVineta.Name = "cdgvVineta";
            cdgvVineta.Width = 50;
            // 
            // cdgvTexto
            // 
            cdgvTexto.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            cdgvTexto.HeaderText = "Texto";
            cdgvTexto.Name = "cdgvTexto";
            cdgvTexto.Width = 60;
            // 
            // cdgvEliminar
            // 
            cdgvEliminar.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            cdgvEliminar.HeaderText = "";
            cdgvEliminar.Image = Properties.Resources.icons8_eliminar_color_310;
            cdgvEliminar.ImageLayout = DataGridViewImageCellLayout.Stretch;
            cdgvEliminar.MinimumWidth = 30;
            cdgvEliminar.Name = "cdgvEliminar";
            cdgvEliminar.ReadOnly = true;
            cdgvEliminar.Resizable = DataGridViewTriState.False;
            cdgvEliminar.ToolTipText = "Eliminar Fila";
            cdgvEliminar.Width = 30;
            // 
            // btnCargarArchivo
            // 
            btnCargarArchivo.Location = new Point(405, 419);
            btnCargarArchivo.Name = "btnCargarArchivo";
            btnCargarArchivo.Size = new Size(175, 34);
            btnCargarArchivo.TabIndex = 25;
            btnCargarArchivo.Text = "Cargar Archivo";
            btnCargarArchivo.UseVisualStyleBackColor = true;
            btnCargarArchivo.Click += btnCargarArchivo_Click;
            // 
            // lblArchivoEditando
            // 
            lblArchivoEditando.AutoSize = true;
            lblArchivoEditando.Font = new Font("Segoe UI", 12F);
            lblArchivoEditando.Location = new Point(29, 459);
            lblArchivoEditando.Name = "lblArchivoEditando";
            lblArchivoEditando.Size = new Size(131, 21);
            lblArchivoEditando.TabIndex = 26;
            lblArchivoEditando.Text = "Archivo editando:";
            lblArchivoEditando.Visible = false;
            // 
            // frmTranslator
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(661, 764);
            Controls.Add(lblArchivoEditando);
            Controls.Add(btnCargarArchivo);
            Controls.Add(dgvPreview);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtCapitulo);
            Controls.Add(cmbProyecto);
            Controls.Add(btnSave);
            Controls.Add(label1);
            Controls.Add(chkPortapapeles);
            Controls.Add(btnDirectorio);
            Controls.Add(txtDirectorio);
            Controls.Add(btnAddTexto);
            Controls.Add(cmbTipoGlobo);
            Controls.Add(rtxtTextoCopiado);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimumSize = new Size(661, 582);
            Name = "frmTranslator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Transcription Assistant";
            FormClosing += frmTranslator_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtxtTextoCopiado;
        private ComboBox cmbTipoGlobo;
        private Button btnAddTexto;
        private FolderBrowserDialog fbdDirectorio;
        private TextBox txtDirectorio;
        private Button btnDirectorio;
        private CheckBox chkPortapapeles;
        private Label label1;
        private Button btnSave;
        private ComboBox cmbProyecto;
        private TextBox txtCapitulo;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private DataGridView dgvPreview;
        private OpenFileDialog ofdCargaArchivo;
        private Button btnCargarArchivo;
        private Label lblArchivoEditando;
        private ToolTip tipBtnDirectorio;
        private DataGridViewTextBoxColumn cdgvVineta;
        private DataGridViewTextBoxColumn cdgvTexto;
        private DataGridViewImageColumn cdgvEliminar;
    }
}
