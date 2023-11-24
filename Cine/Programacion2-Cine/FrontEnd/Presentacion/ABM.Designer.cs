namespace FrontEnd
{
    partial class ABM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABM));
            cboGenero = new ComboBox();
            button1 = new Button();
            lblGenero = new Label();
            lblTitulo = new Label();
            btnGrabar = new Button();
            txtTitulo = new TextBox();
            lblIdioma = new Label();
            lblDuracíon = new Label();
            lstPeliculas = new ListBox();
            txtDuracion = new TextBox();
            cboIdioma = new ComboBox();
            btnNuevo = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnCancelar = new Button();
            lblMinutos = new Label();
            SuspendLayout();
            // 
            // cboGenero
            // 
            cboGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGenero.Enabled = false;
            cboGenero.FormattingEnabled = true;
            cboGenero.Location = new Point(147, 92);
            cboGenero.Margin = new Padding(3, 2, 3, 2);
            cboGenero.Name = "cboGenero";
            cboGenero.Size = new Size(133, 23);
            cboGenero.TabIndex = 2;
            cboGenero.SelectedIndexChanged += cboGenero_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(643, 357);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(103, 30);
            button1.TabIndex = 11;
            button1.Text = "Salir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.BackColor = Color.Transparent;
            lblGenero.Location = new Point(77, 94);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(45, 15);
            lblGenero.TabIndex = 3;
            lblGenero.Text = "Genero";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Location = new Point(77, 52);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(37, 15);
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = "Título";
            // 
            // btnGrabar
            // 
            btnGrabar.Enabled = false;
            btnGrabar.Location = new Point(538, 357);
            btnGrabar.Margin = new Padding(3, 2, 3, 2);
            btnGrabar.Name = "btnGrabar";
            btnGrabar.Size = new Size(99, 30);
            btnGrabar.TabIndex = 10;
            btnGrabar.Text = "Grabar";
            btnGrabar.UseVisualStyleBackColor = true;
            btnGrabar.Click += button2_Click;
            // 
            // txtTitulo
            // 
            txtTitulo.Enabled = false;
            txtTitulo.Location = new Point(147, 49);
            txtTitulo.Margin = new Padding(3, 2, 3, 2);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(309, 23);
            txtTitulo.TabIndex = 1;
            // 
            // lblIdioma
            // 
            lblIdioma.AutoSize = true;
            lblIdioma.BackColor = Color.Transparent;
            lblIdioma.Location = new Point(77, 182);
            lblIdioma.Name = "lblIdioma";
            lblIdioma.Size = new Size(44, 15);
            lblIdioma.TabIndex = 8;
            lblIdioma.Text = "Idioma";
            // 
            // lblDuracíon
            // 
            lblDuracíon.AutoSize = true;
            lblDuracíon.BackColor = Color.Transparent;
            lblDuracíon.Location = new Point(77, 137);
            lblDuracíon.Name = "lblDuracíon";
            lblDuracíon.Size = new Size(55, 15);
            lblDuracíon.TabIndex = 9;
            lblDuracíon.Text = "Duracíon";
            // 
            // lstPeliculas
            // 
            lstPeliculas.Enabled = false;
            lstPeliculas.FormattingEnabled = true;
            lstPeliculas.ItemHeight = 15;
            lstPeliculas.Location = new Point(530, 38);
            lstPeliculas.Margin = new Padding(3, 2, 3, 2);
            lstPeliculas.Name = "lstPeliculas";
            lstPeliculas.Size = new Size(217, 244);
            lstPeliculas.TabIndex = 5;
            lstPeliculas.SelectedIndexChanged += lstPeliculas_SelectedIndexChanged;
            // 
            // txtDuracion
            // 
            txtDuracion.Enabled = false;
            txtDuracion.Location = new Point(147, 133);
            txtDuracion.Margin = new Padding(3, 2, 3, 2);
            txtDuracion.Name = "txtDuracion";
            txtDuracion.Size = new Size(26, 23);
            txtDuracion.TabIndex = 3;
            // 
            // cboIdioma
            // 
            cboIdioma.DropDownStyle = ComboBoxStyle.DropDownList;
            cboIdioma.Enabled = false;
            cboIdioma.FormattingEnabled = true;
            cboIdioma.Location = new Point(147, 179);
            cboIdioma.Margin = new Padding(3, 2, 3, 2);
            cboIdioma.Name = "cboIdioma";
            cboIdioma.Size = new Size(133, 23);
            cboIdioma.TabIndex = 4;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(77, 357);
            btnNuevo.Margin = new Padding(3, 2, 3, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(96, 30);
            btnNuevo.TabIndex = 6;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(178, 357);
            btnEditar.Margin = new Padding(3, 2, 3, 2);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(96, 30);
            btnEditar.TabIndex = 7;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Enabled = false;
            btnEliminar.Location = new Point(280, 357);
            btnEliminar.Margin = new Padding(3, 2, 3, 2);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(95, 30);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(436, 357);
            btnCancelar.Margin = new Padding(3, 2, 3, 2);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(96, 30);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblMinutos
            // 
            lblMinutos.AutoSize = true;
            lblMinutos.BackColor = Color.Transparent;
            lblMinutos.Location = new Point(174, 137);
            lblMinutos.Name = "lblMinutos";
            lblMinutos.Size = new Size(51, 15);
            lblMinutos.TabIndex = 22;
            lblMinutos.Text = "minutos";
            // 
            // ABM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(799, 405);
            ControlBox = false;
            Controls.Add(lblMinutos);
            Controls.Add(btnCancelar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnNuevo);
            Controls.Add(cboIdioma);
            Controls.Add(txtDuracion);
            Controls.Add(lstPeliculas);
            Controls.Add(lblDuracíon);
            Controls.Add(lblIdioma);
            Controls.Add(txtTitulo);
            Controls.Add(btnGrabar);
            Controls.Add(lblTitulo);
            Controls.Add(lblGenero);
            Controls.Add(button1);
            Controls.Add(cboGenero);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "ABM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Películas";
            Load += ABM_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboGenero;
        private Button button1;
        private Label lblGenero;
        private Label lblTitulo;
        private Button btnGrabar;
        private TextBox txtTitulo;
        private Label lblIdioma;
        private Label lblDuracíon;
        private ListBox lstPeliculas;
        private TextBox txtDuracion;
        private ComboBox cboIdioma;
        private Button btnNuevo;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnCancelar;
        private Label lblMinutos;
    }
}