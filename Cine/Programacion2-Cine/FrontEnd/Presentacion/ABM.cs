using BackEnd.Entidades;
using BackEnd.Servicios;
using BackEnd.Servicios.Interfaz;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace FrontEnd
{
    public partial class ABM : Form
    {
        //Pelicula peliculaNueva;
        IServicio servicio = null;
        List<Pelicula> lPeliculas;
        //List<Genero> lGeneros;
        //List<Idioma> lIdiomas;
        bool esNuevo = true;
        public ABM(FabricaServicios fabrica)
        {
            InitializeComponent();
            servicio = fabrica.CrearServicio();
            lPeliculas = new List<Pelicula>();
            //lGeneros = new List<Genero>();
            //lIdiomas = new List<Idioma>();
            //peliculaNueva = new Pelicula();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea salir?", "SALIENDO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitulo.Text))
            {
                MessageBox.Show("Debe ingresar un titulo.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (cboGenero.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un genero.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int numero;

            bool esNumerico = int.TryParse(txtDuracion.Text, out numero);

            if (!esNumerico)
            {
                MessageBox.Show("Debe ingresar una duracion valida.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDuracion.Focus();
                return;
            }
            if (cboIdioma.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un idioma.", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }



            //guardarpelicula
            Genero g = (Genero)cboGenero.SelectedItem;
            Idioma i = (Idioma)cboIdioma.SelectedItem;
            string Titulo = txtTitulo.Text;
            Genero Genero = g;
            int Duracion = Convert.ToInt32(txtDuracion.Text);
            Idioma Idioma = i;

            Pelicula peliculaNueva = new Pelicula(Titulo, Duracion, Genero, Idioma);
            //string bodyContent = JsonConvert.SerializeObject(peliculaNueva);
            peliculaNueva.EnCartelera = true;

            if (esNuevo)
            {
                if (await CargarPelicula(peliculaNueva))
                {
                    MessageBox.Show("La pelicula se ha cargado con exito", "Carga exitosa", MessageBoxButtons.OK, MessageBoxIcon.None);
                    await CargarTabla();
                    //Clean();
                    lstPeliculas.SelectedIndex = lstPeliculas.Items.Count - 1;
                    EnableNuevo(false);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error con la carga", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int n = lstPeliculas.SelectedIndex;
                //Pelicula p = (Pelicula)lstPeliculas.SelectedValue;
                peliculaNueva.PeliculaNro = lPeliculas[lstPeliculas.SelectedIndex].PeliculaNro;
                if (await EditarPelicula(peliculaNueva))
                {
                    MessageBox.Show("La pelicula se ha editado con exito", "Edicion exitosa", MessageBoxButtons.OK, MessageBoxIcon.None);
                    await CargarTabla();
                    //Clean();
                    lstPeliculas.SelectedIndex = n;
                    EnableNuevo(false);
                }
                else
                {
                    MessageBox.Show("Ocurrio un error con la edicion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private async Task<bool> EditarPelicula(Pelicula peliculaNueva)
        {
            string url = "https://localhost:7132/api/pelicula";
            string peliculaJson = JsonConvert.SerializeObject(peliculaNueva);
            var result = await ClientSingleton.GetInstance().PutAsync(url, peliculaJson);

            return !result.Equals("true");

        }

        private async Task<bool> CargarPelicula(Pelicula pelicula)
        {
            string url = "https://localhost:7132/api/pelicula";
            string peliculaJson = JsonConvert.SerializeObject(pelicula);
            var result = await ClientSingleton.GetInstance().PostAsync(url, peliculaJson);

            return !result.Equals("true");

        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            Pelicula peliculaNueva = new Pelicula();

            peliculaNueva.PeliculaNro = lPeliculas[lstPeliculas.SelectedIndex].PeliculaNro;
            Genero g = (Genero)cboGenero.SelectedItem;
            Idioma i = (Idioma)cboIdioma.SelectedItem;
            peliculaNueva.Titulo = txtTitulo.Text;
            peliculaNueva.TipoGenero = g;
            peliculaNueva.Duracion = Convert.ToInt32(txtDuracion.Text);
            peliculaNueva.Idioma = i;
            peliculaNueva.EnCartelera = false;

            if (await EliminarPelicula(peliculaNueva))
            {
                MessageBox.Show("La pelicula se ha eliminado con exito", "Eliminacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.None);
                await CargarTabla();
                //Clean();
                //btnGrabar.Enabled = false;
                //txtTitulo.Enabled = false;
                //txtDuracion.Enabled = false;
                //cboGenero.Enabled = false;
                //cboIdioma.Enabled = false;
                //cboxSi.Enabled = false;
                //cboxNo.Enabled = false;
                //btnGrabar.Enabled = false;
                //btnNuevo.Enabled = true;
                //btnEditar.Enabled = true;
                //btnEliminar.Enabled = false;
                lstPeliculas.SelectedIndex = lstPeliculas.Items.Count - 1;
                EnableNuevo(false);
            }
            else
            {
                MessageBox.Show("Ocurrio un error con la eliminacion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> EliminarPelicula(Pelicula pelicula)
        {
            string url = "https://localhost:7132/api/pelicula";
            string peliculaJson = JsonConvert.SerializeObject(pelicula);
            var result = await ClientSingleton.GetInstance().PutAsync(url, peliculaJson);

            return !result.Equals("true");

        }

        private void lstPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPeliculas.SelectedIndex >= 0)
            {
                int i = lstPeliculas.SelectedIndex;
                CargarFormulario(i);
            }
        }

        private void CargarFormulario(int i)
        {
            txtTitulo.Text = lPeliculas[i].Titulo.ToString();
            txtDuracion.Text = lPeliculas[i].Duracion.ToString();
            cboGenero.SelectedValue = lPeliculas[i].TipoGenero.GeneroNro;
            cboIdioma.SelectedValue = lPeliculas[i].Idioma.IdiomaNro;

        }

        private async void ABM_Load(object sender, EventArgs e)
        {
            await CargarTabla();
            await CargarComboGenero();
            await CargarComboIdioma();
            lstPeliculas.Enabled = true;
            lstPeliculas.SelectedIndex = 0;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnCancelar.Enabled = false;
        }

        private async Task CargarTabla()
        {
            string url = "https://localhost:7132/api/pelicula";
            var result = await ClientSingleton.GetInstance().GetAsync(url);

            lPeliculas = JsonConvert.DeserializeObject<List<Pelicula>>(result);
            lstPeliculas.Items.Clear();
            foreach (Pelicula pelicula in lPeliculas)
            {
                lstPeliculas.Items.Add(pelicula.Titulo);

            }
        }
        private async Task CargarComboGenero()
        {
            string url = "https://localhost:7132/generos";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            List<Genero> lGeneros = JsonConvert.DeserializeObject<List<Genero>>(result);
            cboGenero.DataSource = lGeneros;
            cboGenero.DisplayMember = "NombreGenero";
            cboGenero.ValueMember = "GeneroNro";
            cboGenero.SelectedIndex = -1;
        }

        private async Task CargarComboIdioma()
        {
            string url = "https://localhost:7132/idiomas";
            var result = await ClientSingleton.GetInstance().GetAsync(url);
            List<Idioma> lIdiomas = JsonConvert.DeserializeObject<List<Idioma>>(result);
            cboIdioma.DataSource = lIdiomas;
            cboIdioma.DisplayMember = "NombreIdioma";
            cboIdioma.ValueMember = "IdiomaNro";
            cboIdioma.SelectedIndex = -1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lstPeliculas.SelectedIndex = -1;
            esNuevo = true;
            Clean();
            EnableNuevo(true);
            txtTitulo.Focus();
        }

        private void Enabled(bool v)
        {
            lstPeliculas.Enabled = !v;
            btnNuevo.Enabled = !v;
            btnEliminar.Enabled = !v;
            btnEditar.Enabled = v;
            btnGrabar.Enabled = true;
            txtTitulo.Enabled = true;
            txtDuracion.Enabled = true;
            cboGenero.Enabled = true;
            cboIdioma.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            //Clean();
            //Enabled(false);
            EnableNuevo(true);
            //if (lstPeliculas.Items.Count > 0)
            //{
            //    lstPeliculas.SelectedIndex = -1;
            //}
            txtTitulo.Focus();

        }

        private void Clean()
        {
            txtTitulo.Text = string.Empty;
            txtDuracion.Text = string.Empty;
            cboGenero.SelectedIndex = -1;
            cboIdioma.SelectedIndex = -1;

        }

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void EnableNuevo(bool v)
        {
            lstPeliculas.Enabled = !v;
            txtTitulo.Enabled = v;
            cboGenero.Enabled = v;
            txtDuracion.Enabled = v;
            cboIdioma.Enabled = v;

            btnNuevo.Enabled = !v;
            btnEditar.Enabled = !v;
            btnEliminar.Enabled = !v;
            btnCancelar.Enabled = v;
            btnGrabar.Enabled = v;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //int n = lstPeliculas.Items.Count - 1;
            if (MessageBox.Show("Esta seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                EnableNuevo(false);
                if (esNuevo)
                {
                    lstPeliculas.SelectedIndex = lstPeliculas.Items.Count - 1;
                    CargarFormulario(lstPeliculas.Items.Count - 1);
                }
                else
                {
                    CargarFormulario(lstPeliculas.SelectedIndex);

                }
                //lstPeliculas.SelectedIndex = n;
                //CargarFormulario(n);
            }
        }
    }
}
