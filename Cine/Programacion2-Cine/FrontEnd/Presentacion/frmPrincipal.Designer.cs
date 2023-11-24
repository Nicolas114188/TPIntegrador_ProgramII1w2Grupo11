namespace FrontEnd
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            button1 = new Button();
            panel1 = new Panel();
            label3 = new Label();
            btnEntrar = new Button();
            txt_contra = new TextBox();
            txt_usuario = new TextBox();
            label2 = new Label();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            peliculasToolStripMenuItem = new ToolStripMenuItem();
            nuevaToolStripMenuItem = new ToolStripMenuItem();
            buscarToolStripMenuItem = new ToolStripMenuItem();
            entradasToolStripMenuItem = new ToolStripMenuItem();
            nuevaToolStripMenuItem1 = new ToolStripMenuItem();
            reporteToolStripMenuItem = new ToolStripMenuItem();
            generarUnReporteToolStripMenuItem = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            integrantesToolStripMenuItem = new ToolStripMenuItem();
            label4 = new Label();
            panel1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(520, 395);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(101, 28);
            button1.TabIndex = 0;
            button1.Text = "Salir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSkyBlue;
            panel1.BackgroundImageLayout = ImageLayout.Center;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnEntrar);
            panel1.Controls.Add(txt_contra);
            panel1.Controls.Add(txt_usuario);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(103, 137);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(424, 190);
            panel1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(143, 12);
            label3.Name = "label3";
            label3.Size = new Size(112, 21);
            label3.TabIndex = 5;
            label3.Text = "Iniciar Sesion";
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(237, 131);
            btnEntrar.Margin = new Padding(3, 2, 3, 2);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(97, 32);
            btnEntrar.TabIndex = 4;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += button2_Click;
            // 
            // txt_contra
            // 
            txt_contra.Location = new Point(157, 95);
            txt_contra.Margin = new Padding(3, 2, 3, 2);
            txt_contra.Name = "txt_contra";
            txt_contra.Size = new Size(178, 23);
            txt_contra.TabIndex = 3;
            // 
            // txt_usuario
            // 
            txt_usuario.Location = new Point(157, 49);
            txt_usuario.Margin = new Padding(3, 2, 3, 2);
            txt_usuario.Name = "txt_usuario";
            txt_usuario.Size = new Size(178, 23);
            txt_usuario.TabIndex = 2;
            txt_usuario.TextChanged += txt_usuario_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(52, 97);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(52, 50);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.WhiteSmoke;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { peliculasToolStripMenuItem, entradasToolStripMenuItem, reporteToolStripMenuItem, acercaDeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(633, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // peliculasToolStripMenuItem
            // 
            peliculasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevaToolStripMenuItem, buscarToolStripMenuItem });
            peliculasToolStripMenuItem.Name = "peliculasToolStripMenuItem";
            peliculasToolStripMenuItem.Size = new Size(60, 20);
            peliculasToolStripMenuItem.Text = "Soporte";
            // 
            // nuevaToolStripMenuItem
            // 
            nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            nuevaToolStripMenuItem.Size = new Size(147, 22);
            nuevaToolStripMenuItem.Text = "Ver Peliculas";
            nuevaToolStripMenuItem.Click += nuevaToolStripMenuItem_Click;
            // 
            // buscarToolStripMenuItem
            // 
            buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            buscarToolStripMenuItem.Size = new Size(147, 22);
            buscarToolStripMenuItem.Text = "Ver Funciones";
            buscarToolStripMenuItem.Click += buscarToolStripMenuItem_Click;
            // 
            // entradasToolStripMenuItem
            // 
            entradasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevaToolStripMenuItem1 });
            entradasToolStripMenuItem.Name = "entradasToolStripMenuItem";
            entradasToolStripMenuItem.Size = new Size(81, 20);
            entradasToolStripMenuItem.Text = "Transaccion";
            // 
            // nuevaToolStripMenuItem1
            // 
            nuevaToolStripMenuItem1.Name = "nuevaToolStripMenuItem1";
            nuevaToolStripMenuItem1.Size = new Size(110, 22);
            nuevaToolStripMenuItem1.Text = "Vender";
            nuevaToolStripMenuItem1.Click += nuevaToolStripMenuItem1_Click;
            // 
            // reporteToolStripMenuItem
            // 
            reporteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generarUnReporteToolStripMenuItem });
            reporteToolStripMenuItem.Name = "reporteToolStripMenuItem";
            reporteToolStripMenuItem.Size = new Size(60, 20);
            reporteToolStripMenuItem.Text = "Reporte";
            // 
            // generarUnReporteToolStripMenuItem
            // 
            generarUnReporteToolStripMenuItem.Name = "generarUnReporteToolStripMenuItem";
            generarUnReporteToolStripMenuItem.Size = new Size(176, 22);
            generarUnReporteToolStripMenuItem.Text = "Generar un Reporte";
            generarUnReporteToolStripMenuItem.Click += generarUnReporteToolStripMenuItem_Click;
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { integrantesToolStripMenuItem });
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(71, 20);
            acercaDeToolStripMenuItem.Text = "Acerca de";
            acercaDeToolStripMenuItem.Click += acercaDeToolStripMenuItem_Click;
            // 
            // integrantesToolStripMenuItem
            // 
            integrantesToolStripMenuItem.Name = "integrantesToolStripMenuItem";
            integrantesToolStripMenuItem.Size = new Size(133, 22);
            integrantesToolStripMenuItem.Text = "Integrantes";
            integrantesToolStripMenuItem.Click += integrantesToolStripMenuItem_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(203, 190);
            label4.Name = "label4";
            label4.Size = new Size(230, 50);
            label4.TabIndex = 3;
            label4.Text = "Bienvenido!";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(633, 434);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            Controls.Add(label4);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "frmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cine";
            Load += frmPrincipal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private MenuStrip menuStrip1;
        private Button btnEntrar;
        private TextBox txt_contra;
        private TextBox txt_usuario;
        private Label label2;
        private Label label1;
        private ToolStripMenuItem peliculasToolStripMenuItem;
        private ToolStripMenuItem nuevaToolStripMenuItem;
        private ToolStripMenuItem buscarToolStripMenuItem;
        private ToolStripMenuItem entradasToolStripMenuItem;
        private ToolStripMenuItem nuevaToolStripMenuItem1;
        private Label label3;
        private ToolStripMenuItem reporteToolStripMenuItem;
        private ToolStripMenuItem generarUnReporteToolStripMenuItem;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private ToolStripMenuItem integrantesToolStripMenuItem;
        private Label label4;
    }
}