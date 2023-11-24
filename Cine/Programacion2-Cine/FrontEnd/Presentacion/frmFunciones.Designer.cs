namespace FrontEnd
{
    partial class frmFunciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFunciones));
            btnSalir = new Button();
            label1 = new Label();
            lstPeliculasEnCartelera = new ListBox();
            btnGrabar = new Button();
            btnNuevo = new Button();
            lblFecha = new Label();
            lblHorario = new Label();
            lblPrecio = new Label();
            dtpFecha = new DateTimePicker();
            txtPrecio = new TextBox();
            cboHorario = new ComboBox();
            cboPeliculasActivas = new ComboBox();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(464, 321);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(86, 35);
            btnSalir.TabIndex = 11;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(63, 62);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 1;
            label1.Text = "Pelicula";
            // 
            // lstPeliculasEnCartelera
            // 
            lstPeliculasEnCartelera.FormattingEnabled = true;
            lstPeliculasEnCartelera.ItemHeight = 15;
            lstPeliculasEnCartelera.Location = new Point(364, 48);
            lstPeliculasEnCartelera.Name = "lstPeliculasEnCartelera";
            lstPeliculasEnCartelera.Size = new Size(190, 244);
            lstPeliculasEnCartelera.TabIndex = 5;
            lstPeliculasEnCartelera.SelectedIndexChanged += lstPeliculasEnCartelera_SelectedIndexChanged;
            // 
            // btnGrabar
            // 
            btnGrabar.Location = new Point(140, 321);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(85, 35);
            btnGrabar.TabIndex = 10;
            btnGrabar.Text = "Grabar";
            btnGrabar.UseVisualStyleBackColor = true;
            btnGrabar.Click += btnGrabar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(48, 321);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(79, 35);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.BackColor = Color.Transparent;
            lblFecha.Location = new Point(63, 106);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 5;
            lblFecha.Text = "Fecha";
            // 
            // lblHorario
            // 
            lblHorario.AutoSize = true;
            lblHorario.BackColor = Color.Transparent;
            lblHorario.Location = new Point(63, 149);
            lblHorario.Name = "lblHorario";
            lblHorario.Size = new Size(47, 15);
            lblHorario.TabIndex = 6;
            lblHorario.Text = "Horario";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.BackColor = Color.Transparent;
            lblPrecio.Location = new Point(63, 195);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(40, 15);
            lblPrecio.TabIndex = 7;
            lblPrecio.Text = "Precio";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(128, 100);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(97, 23);
            dtpFecha.TabIndex = 2;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(125, 192);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 4;
            // 
            // cboHorario
            // 
            cboHorario.DropDownStyle = ComboBoxStyle.DropDownList;
            cboHorario.FormattingEnabled = true;
            cboHorario.Location = new Point(125, 149);
            cboHorario.Name = "cboHorario";
            cboHorario.Size = new Size(121, 23);
            cboHorario.TabIndex = 3;
            // 
            // cboPeliculasActivas
            // 
            cboPeliculasActivas.Enabled = false;
            cboPeliculasActivas.FormattingEnabled = true;
            cboPeliculasActivas.Location = new Point(128, 59);
            cboPeliculasActivas.Name = "cboPeliculasActivas";
            cboPeliculasActivas.Size = new Size(213, 23);
            cboPeliculasActivas.TabIndex = 1;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(364, 321);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(79, 35);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmFunciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(604, 402);
            ControlBox = false;
            Controls.Add(btnCancelar);
            Controls.Add(cboPeliculasActivas);
            Controls.Add(cboHorario);
            Controls.Add(txtPrecio);
            Controls.Add(dtpFecha);
            Controls.Add(lblPrecio);
            Controls.Add(lblHorario);
            Controls.Add(lblFecha);
            Controls.Add(btnNuevo);
            Controls.Add(btnGrabar);
            Controls.Add(lstPeliculasEnCartelera);
            Controls.Add(label1);
            Controls.Add(btnSalir);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmFunciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Funciones";
            Load += frmFunciones_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalir;
        private Label label1;
        private ListBox lstPeliculasEnCartelera;
        private Button btnGrabar;
        private Button btnNuevo;
        private Label lblFecha;
        private Label lblHorario;
        private Label lblPrecio;
        private DateTimePicker dtpFecha;
        private TextBox txtPrecio;
        private ComboBox cboHorario;
        private ComboBox cboPeliculasActivas;
        private Button btnCancelar;
    }
}