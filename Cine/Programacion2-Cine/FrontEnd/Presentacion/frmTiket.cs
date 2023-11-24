using BackEnd.Entidades;
using FrontEnd.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Gaming.Input.ForceFeedback;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FrontEnd
{

    public partial class frmTiket : Form
    {
        List<Funcion> lFunciones;
        Ticket ticket;
        public frmTiket()
        {
            InitializeComponent();
            ticket = new Ticket();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmTiket_Load(object sender, EventArgs e)
        {

        }

        private void dgvButaca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea saliendo?", "SALIENDO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private async void frmTiket_Load_1(object sender, EventArgs e)
        {
            await CargarComboFuncion();
            await CargarComboTipoPago();
            await CargarComboTipoCliente();
            cboFunciones.SelectedIndex = 0;
            txtDescuento.Text = 0.ToString();
        }

        private async Task CargarComboButacas(int i)
        {
            List<Butaca> lButacas = new List<Butaca>();
            List<int> lFull = new List<int>();

            for (int j = 0; j < 32; j++)
            {
                lFull.Add(j + 1);
            }
            string url = $"https://localhost:7132/api/Butaca?i={i}";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            lButacas = JsonConvert.DeserializeObject<List<Butaca>>(result);

            if (lButacas != null)
            {
                foreach (Butaca b in lButacas)
                {
                    lFull.Remove(b.Numero);
                }
            }
            cboButaca.DataSource = lFull;
            cboButaca.SelectedIndex = -1;
        }

        private async Task CargarComboTipoCliente()
        {
            string url = "https://localhost:7132/tipoCliente";
            var result = await ClientSingleton.GetInstance().GetAsync(url);

            List<TipoCliente> lCliente = JsonConvert.DeserializeObject<List<TipoCliente>>(result);
            cboCliente.DataSource = lCliente;
            cboCliente.ValueMember = "TipoNro";
            cboCliente.DisplayMember = "ClienteNombre";
            cboCliente.SelectedIndex = -1;
        }

        private async Task CargarComboTipoPago()
        {
            string url = "https://localhost:7132/formaPago";
            var result = await ClientSingleton.GetInstance().GetAsync(url);

            List<FormaPago> lFormaPago = JsonConvert.DeserializeObject<List<FormaPago>>(result);
            cboTipoPago.DataSource = lFormaPago;
            cboTipoPago.ValueMember = "IdFormaPago";
            cboTipoPago.DisplayMember = "NombrePago";
            cboTipoPago.SelectedIndex = -1;
        }


        private async Task CargarComboFuncion()
        {
            string url = "https://localhost:7132/api/Funcion";
            var result = await ClientSingleton.GetInstance().GetAsync(url);

            lFunciones = JsonConvert.DeserializeObject<List<Funcion>>(result);
            cboFunciones.DataSource = lFunciones;
            cboFunciones.ValueMember = "FuncionNro";
            cboFunciones.DisplayMember = "NombrePelicula";
            cboFunciones.SelectedIndex = 0;

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        private void CalcularSubTotal()
        {
            double suma = 0;
            foreach (Butaca butaca in ticket.listBuataca)
            {
                suma += butaca.Precio;
            }

            txtSubTotal.Text = suma.ToString();
        }

        private void CalcularTotal()
        {
            double suma = 0;
            foreach (DataGridViewRow dg in dgvButaca.Rows)
            {
                suma += Convert.ToInt32(dg.Cells[3].Value) - Convert.ToInt32(dg.Cells[3].Value) * Convert.ToInt32(dg.Cells[4].Value) / 100;
            }

            txtTotal.Text = suma.ToString();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

        }

        private void cboButaca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void cboFunciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFunciones.SelectedIndex >= 0)
            {
                Funcion f = (Funcion)cboFunciones.SelectedItem;
                await CargarComboButacas(f.FuncionNro);
                ActualizarDatos(f);
                dtpFechaActual.Value = f.FechaFuncion;
                cboTipoPago.SelectedIndex = -1;
                cboCliente.SelectedIndex = -1;
                txtDescuento.Text = 0.ToString();
            }
            else
            {
                dtpFechaActual.Value = DateTime.Today;
                cboTipoPago.SelectedIndex = -1;
                cboCliente.SelectedIndex = -1;
                txtDescuento.Text = 0.ToString();
            }
        }

        private void ActualizarDatos(Funcion f)
        {
            txtTurno.Text = f.Horario.Hora.ToString();
            txtPrecio.Text = f.Precio.ToString();
            dtpFechaActual.Value = f.FechaFuncion;
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            if (cboFunciones.SelectedIndex == -1)
            {
                MessageBox.Show("Se debe seleccionar una funcion", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboFunciones.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("Se ingreso un precio incorrecto", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPrecio.Focus();
                return;
            }

            if (cboTipoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Se debe seleccionar una forma de pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTipoPago.Focus();
                return;
            }

            if (cboCliente.SelectedIndex == -1)
            {
                MessageBox.Show("Se debe seleccionar un cliente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboCliente.Focus();
                return;
            }

            if (cboButaca.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una butaca", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboButaca.Focus();
                return;
            }

            if (String.IsNullOrEmpty(txtDescuento.Text))
            {
                MessageBox.Show("Ingrese un valor entero entre 0 y 100", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescuento.Focus();
                return;
            }

            if (dtpFechaActual.Value < DateTime.Today)
            {
                MessageBox.Show("La fecha de la funcion seleccionada caducado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboFunciones.Focus();
                return;
            }

            try
            {
                int n = Convert.ToInt32(txtDescuento.Text);
                if (0 > n || 100 < n)
                {
                    MessageBox.Show("Ingrese un valor entero entre 0 y 100", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescuento.Focus();
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un valor entero entre 0 y 100", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescuento.Focus();
                return;
            }

            foreach (DataGridViewRow row in dgvButaca.Rows)
            {
                if (row.Cells[2].Value != null && row.Cells[2].Value.ToString().Equals(cboButaca.Text.ToString()))
                {
                    MessageBox.Show("Esta butaca ya está seleccionada...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            Butaca butaca = new Butaca();
            butaca.Numero = Convert.ToInt32(cboButaca.Text);
            butaca.Precio = Convert.ToDouble(txtPrecio.Text);
            butaca.Estado = true;
            butaca.Cliente = (TipoCliente)cboCliente.SelectedItem;
            butaca.Funcion = (Funcion)cboFunciones.SelectedItem;
            butaca.Descuento = Convert.ToInt32(txtDescuento.Text);

            Sala sala = new Sala();
            sala.SalaNro = 1;
            butaca.Sala = new Sala();
            butaca.Sala.SalaNro = sala.SalaNro;

            ticket.AgregarButaca(butaca);
            dgvButaca.Rows.Add(new object[] { butaca.Funcion.Pelicula.Titulo, txtTurno.Text, butaca.Numero, butaca.Precio, butaca.Descuento, "Quitar" });
            CalcularSubTotal();
            CalcularTotal();
            cboFunciones.Enabled = false;
            btnPagar.Enabled = true;
        }

        private async void btnPagar_Click_1(object sender, EventArgs e)
        {
            if (dgvButaca.Rows.Count == 0)
            {
                MessageBox.Show("Error... No tiene butaca confirmadas", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ticket.fecha_ticket = dtpFechaActual.Value;
            ticket.Pagado = true;
            ticket.FormaPago = new FormaPago();
            ticket.FormaPago.IdFormaPago = Convert.ToInt32(cboTipoPago.SelectedValue);
            if (await GrabarTicket(ticket))
            {
                MessageBox.Show("La Operacion se realizo con exito", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Clean();
                ticket.VaciarButacas();
                btnPagar.Enabled = false;
                return;

            }
            else
            {
                MessageBox.Show("Error al querer gestionar la operacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }

        private void Clean()
        {
            txtDescuento.Text = string.Empty;
            cboCliente.SelectedIndex = -1;
            cboTipoPago.SelectedIndex = -1;
            cboButaca.SelectedIndex = -1;
            cboFunciones.Enabled = true;
            cboFunciones.SelectedIndex = -1;
            dgvButaca.Rows.Clear();
        }

        private async Task<bool> GrabarTicket(Ticket ticket)
        {
            bool ok = true;
            string url = "https://localhost:7132/api/Ticket";
            string ticketJson = JsonConvert.SerializeObject(ticket);
            var result = await ClientSingleton.GetInstance().PostAsync(url, ticketJson);
            return !result.Equals("Error");
        }

        private void dgvButaca_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            {
                if (e.RowIndex >= 0 && e.ColumnIndex == dgvButaca.Columns["ColQuitar"].Index)
                {
                    if (e.RowIndex < dgvButaca.Rows.Count - 1)
                    {
                        dgvButaca.Rows.RemoveAt(e.RowIndex);
                        ticket.QuitarButaca(dgvButaca.CurrentRow.Index);
                        CalcularSubTotal();
                        CalcularTotal();
                        if (ticket.listBuataca.Count == 0)
                        {
                            btnPagar.Enabled = false;
                            cboFunciones.Enabled = true;
                        }
                    }
                }
            }
        }

        private void cboFunciones_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
