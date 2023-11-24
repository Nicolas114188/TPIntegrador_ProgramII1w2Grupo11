using BackEnd.Entidades;
using BackEnd.Servicios;
using BackEnd.Servicios.Implementacion;
using BackEnd.Servicios.Interfaz;
using FrontEnd.Http;
using FrontEnd.Presentacion;
using FrontEnd.Reporte;
using Newtonsoft.Json;

namespace FrontEnd
{
    public partial class frmPrincipal : Form
    {
        FabricaServicios fabrica = null;
        public frmPrincipal(FabricaServicios fabrica)
        {
            InitializeComponent();
            this.fabrica = fabrica;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?", "SALIENDO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            txt_contra.UseSystemPasswordChar = true;
            menuStrip1.Enabled = false;
            txt_usuario.Focus();
        }

        private async Task LoginCheck(string u, string p)
        {
            string url = $"https://localhost:7132/api/Login?user={u}&password={p}";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            string check = JsonConvert.DeserializeObject<string>(result);

            if (check == "true")
            {
                menuStrip1.Enabled = true;
                MessageBox.Show("Bienvenido");
                panel1.Visible = false;
            }
            else
            {
                MessageBox.Show("Datos Incorrectos");
                txt_contra.Text = string.Empty;
                txt_usuario.Text = string.Empty;
                txt_usuario.Focus();
            }
        }


        private async void button2_Click(object sender, EventArgs e)
        {
            await LoginCheck(txt_usuario.Text, txt_contra.Text);
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM ventana = new ABM(fabrica);
            ventana.ShowDialog();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFunciones ventana = new frmFunciones();
            ventana.ShowDialog();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void nuevaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTiket ventana = new frmTiket();
            ventana.ShowDialog();
        }

        private void generarUnReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporte ventana = new frmReporte();
            ventana.ShowDialog();
        }

        private void integrantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Acercade ventana = new Acercade();
            ventana.ShowDialog();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txt_usuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}