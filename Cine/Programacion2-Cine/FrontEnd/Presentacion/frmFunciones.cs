using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackEnd.Entidades;
using BackEnd.Servicios;
using BackEnd.Servicios.Implementacion;
using BackEnd.Servicios.Interfaz;
using FrontEnd.Http;
using Newtonsoft.Json;
using Windows.ApplicationModel.Appointments;

namespace FrontEnd
{
    public partial class frmFunciones : Form
    {
        List<Funcion> lFunciones;
        IServicio serv = null;
        bool esNuevo = false;

        public frmFunciones()
        {
            InitializeComponent();
            lFunciones = new List<Funcion>();
            serv = new Servicio();
        }

        //private async void frmFunciones_Load(object sender, EventArgs e)
        //{
        //}

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?", "SALIENDO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private async void btnGrabar_Click(object sender, EventArgs e)
        {
            if (cboHorario.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un horario.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dtpFecha.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("La fecha seleccionada no puede ser menor a la actual.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            double numero;
            bool esNumerico = double.TryParse(txtPrecio.Text, out numero);

            if (!esNumerico)
            {
                MessageBox.Show("Debe ingresar un precio valido.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPrecio.Focus();
                return;
            }

            Funcion funcionNueva = new Funcion();
            funcionNueva.Pelicula = (Pelicula)cboPeliculasActivas.SelectedItem;
            funcionNueva.FechaFuncion = dtpFecha.Value;
            funcionNueva.Horario = (Horario)cboHorario.SelectedItem;
            funcionNueva.Precio = Convert.ToDouble(txtPrecio.Text);



            if (esNuevo)
            {
                if (await CargarFuncion(funcionNueva))
                {
                    MessageBox.Show("La funcion se ha cargado con exito", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.None);
                    await CargarListaFunciones();
                    //Clean();
                    lstPeliculasEnCartelera.SelectedIndex = lstPeliculasEnCartelera.Items.Count - 1;
                    EnableNuevo(false);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error con la carga", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int n = lstPeliculasEnCartelera.SelectedIndex;
                //Pelicula p = (Pelicula)lstPeliculas.SelectedValue;
                funcionNueva.FuncionNro = lFunciones[lstPeliculasEnCartelera.SelectedIndex].FuncionNro;
                if (await EditarFucion(funcionNueva))
                {
                    MessageBox.Show("La pelicula se ha editado con exito", "Edicion exitosa", MessageBoxButtons.OK, MessageBoxIcon.None);
                    //Clean();
                    lstPeliculasEnCartelera.SelectedIndex = n;
                    EnableNuevo(false);
                    await CargarListaFunciones();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error con la edicion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private async Task<bool> EditarFucion(Funcion funcion)
        {
            string url = "https://localhost:7132/api/funcion";
            string funcionJson = JsonConvert.SerializeObject(funcion);
            var result = await ClientSingleton.GetInstance().PutAsync(url, funcionJson);

            return !result.Equals("true");

        }

        private async Task<bool> CargarFuncion(Funcion funcion)
        {
            string url = "https://localhost:7132/api/funcion";
            string funcionJson = JsonConvert.SerializeObject(funcion);
            var result = await ClientSingleton.GetInstance().PostAsync(url, funcionJson);

            return !result.Equals("true");

        }

        private async void btnNuevo_Click(object sender, EventArgs e)
        {
            //cboPeliculasActivas.Enabled = true;
            //cboPeliculasActivas.SelectedIndex = -1;
            //cboPeliculasActivas.DropDownStyle = ComboBoxStyle.DropDownList;
            //await CargarComboPeliculas();
            //dtpFecha.Value = DateTime.Now;
            //cboHorario.SelectedIndex = -1;
            //txtPrecio.Text = string.Empty;
            //lstPeliculasEnCartelera.Enabled = false;

            //lstPeliculasEnCartelera.SelectedIndex = -1;
            esNuevo = true;
            cboPeliculasActivas.DropDownStyle = ComboBoxStyle.DropDownList;
            Clean();
            EnableNuevo(true);
            cboPeliculasActivas.Focus();
        }

        private void EnableNuevo(bool v)
        {
            lstPeliculasEnCartelera.Enabled = !v;
            cboPeliculasActivas.Enabled = v;
            dtpFecha.Enabled = v;
            cboHorario.Enabled = v;
            txtPrecio.Enabled = v;

            btnNuevo.Enabled = !v;
            btnCancelar.Enabled = v;
            btnGrabar.Enabled = v;
        }


        private void Clean()
        {
            cboPeliculasActivas.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            cboHorario.SelectedIndex = -1;
            txtPrecio.Text = string.Empty;
        }


        private void lstPeliculasEnCartelera_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Funcion funcion = (Funcion)lstPeliculasEnCartelera.SelectedItem;
            int i = lstPeliculasEnCartelera.SelectedIndex;
            CargarFormulario(i);
            //if (lstPeliculasEnCartelera.SelectedIndex >= 0)
            //{
            //    cboPeliculasActivas.Text = lFunciones[i].Pelicula.Titulo;
            //    txtPrecio.Text = lFunciones[i].Precio.ToString();
            //    dtpFecha.Value = lFunciones[i].FechaFuncion;
            //    cboHorario.SelectedValue = lFunciones[i].Horario.CantHora;
            //}
        }

        private void CargarFormulario(int i)
        {
            cboPeliculasActivas.Text = lFunciones[i].Pelicula.Titulo;
            txtPrecio.Text = lFunciones[i].Precio.ToString();
            dtpFecha.Value = lFunciones[i].FechaFuncion;
            cboHorario.SelectedValue = lFunciones[i].Horario.CantHora;
        }

        private async Task CargarComboHorario()
        {
            string url = "https://localhost:7132/horarios";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            List<Horario> lHorarios = JsonConvert.DeserializeObject<List<Horario>>(result);
            cboHorario.DataSource = lHorarios;
            cboHorario.DisplayMember = "Hora";
            cboHorario.ValueMember = "CantHora";
            cboHorario.SelectedIndex = -1;
        }

        private async void frmFunciones_Load_1(object sender, EventArgs e)
        {
            await CargarComboHorario();
            await CargarListaFunciones();
            Enable(false);
            await CargarComboPeliculas();
        }

        private async Task CargarComboPeliculas()
        {
            List<Pelicula> lPeliculas = new List<Pelicula>();
            {
                string url = "https://localhost:7132/api/Pelicula";
                var result = await ClientSingleton.GetInstance().GetAsync(url);
                lPeliculas = JsonConvert.DeserializeObject<List<Pelicula>>(result);
                //foreach (Pelicula peli in lPeliculas)
                //{
                //    if (peli.EnCartelera == false)
                //    {
                //        lPeliculas.Remove(peli);
                //    }
                //}
                cboPeliculasActivas.DataSource = lPeliculas;
                cboPeliculasActivas.DisplayMember = "Titulo";
                cboPeliculasActivas.ValueMember = "PeliculaNro";
                cboPeliculasActivas.SelectedIndex = -1;
            }
        }

        private async Task CargarListaFunciones()
        {
            string url = "https://localhost:7132/api/Funcion";
            var result = await ClientSingleton.GetInstance().GetAsync(url);

            lFunciones = JsonConvert.DeserializeObject<List<Funcion>>(result);
            lstPeliculasEnCartelera.Items.Clear();
            //lstPeliculasEnCartelera.DataSource = lFunciones;

            foreach (Funcion funcion in lFunciones)
            {
                lstPeliculasEnCartelera.Items.Add(funcion.Pelicula.Titulo);

            }
        }

        private void Enable(bool v)
        {
            cboPeliculasActivas.Enabled = v;
            dtpFecha.Enabled = v;
            cboHorario.Enabled = v;
            txtPrecio.Enabled = v;
            lstPeliculasEnCartelera.Enabled = !v;
            if (v)
            {
                cboPeliculasActivas.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            btnNuevo.Enabled = !v;
            btnCancelar.Enabled = v;
            btnGrabar.Enabled = v;

        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            //Funcion funcion = (Funcion)lstPeliculasEnCartelera.SelectedItem;
            //funcion.Pelicula = (Pelicula)cboPeliculasActivas.SelectedItem;
            //funcion.FechaFuncion = dtpFecha.Value;
            //funcion.Horario = (Horario)cboHorario.SelectedItem;
            //funcion.Precio = Convert.ToDouble(txtPrecio.Text);

            //string url = $"https://localhost:7132/api/funcion/{funcion.FuncionNro}";
            //string funcionJson = JsonConvert.SerializeObject(funcion);
            //var result = await ClientSingleton.GetInstance().PutAsync(url, funcionJson);

            esNuevo = false;
            Enable(true);
            cboPeliculasActivas.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //int n = lstPeliculas.Items.Count - 1;
            if (MessageBox.Show("Esta seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                EnableNuevo(false);
                if (esNuevo)
                {
                    lstPeliculasEnCartelera.SelectedIndex = lstPeliculasEnCartelera.Items.Count - 1;
                    CargarFormulario(lstPeliculasEnCartelera.Items.Count - 1);
                    cboPeliculasActivas.DropDownStyle = ComboBoxStyle.DropDown;
                }
                else
                {
                    CargarFormulario(lstPeliculasEnCartelera.SelectedIndex);

                }
                //lstPeliculas.SelectedIndex = n;
                //CargarFormulario(n);
            }
        }

    }
}
