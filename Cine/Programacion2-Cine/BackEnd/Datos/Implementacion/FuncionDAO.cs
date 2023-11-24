using BackEnd.Datos.interfaz;
using BackEnd.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BackEnd.Datos.Implementacion
{
    public class FuncionDAO : IFuncionDAO
    {
        public List<FormaPago> ObtenerFormaPago()
        {
            List<FormaPago> lFormaPago = new List<FormaPago>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("Formas_pago");

            foreach (DataRow fila in tabla.Rows)
            {
                FormaPago fp = new FormaPago();
                fp.IdFormaPago = Convert.ToInt32(fila["id_forma_pago"].ToString());
                fp.NombrePago = fila["descripcion"].ToString();
                lFormaPago.Add(fp);
            }

            return lFormaPago;
        }

        public List<Horario> ObtenerHorario()
        {
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("Horarios");
            List<Horario> lh = new List<Horario>();

            foreach (DataRow h in tabla.Rows)
            {
                Horario Nh = new Horario();
                Nh.CantHora = Convert.ToInt32(h[0]);
                Nh.Hora = h[1].ToString();
                lh.Add(Nh);
            }
            return lh;
        }

        public List<Genero> ObtenerGenero()
        {
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("Generos");
            List<Genero> lg = new List<Genero>();

            foreach (DataRow g in tabla.Rows)
            {
                Genero Ng = new Genero();
                Ng.GeneroNro = Convert.ToInt32(g[0]);
                Ng.NombreGenero = g[1].ToString();
                lg.Add(Ng);
            }
            return lg;
        }

        public List<Idioma> ObtenerIdiomas()
        {
            List<Idioma> lIdioma = new List<Idioma>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("Idiomas");

            foreach (DataRow fila in tabla.Rows)
            {
                Idioma i = new Idioma();
                i.IdiomaNro = Convert.ToInt32(fila["id_idioma"].ToString());
                i.NombreIdioma = fila["descripcion"].ToString();

                lIdioma.Add(i);
            }

            return lIdioma;
        }

        public List<Pelicula> ObtenerPeliculas(bool cartelera)
        {
            List<Pelicula> lPelicula = new List<Pelicula>();
            string consultaSql = "  select p.*, i.descripcion idioma, " +
                "g.descripcion genero from Peliculas p join Idiomas i on p.id_idioma = i.id_idioma" +
                " join Generos g on g.id_genero = p.id_genero";
            DataTable tabla = HelperDao.ObtenerInstancia().Sql(consultaSql);

            foreach (DataRow fila in tabla.Rows)
            {
                Pelicula p = new Pelicula();

                if (cartelera == true && Convert.ToBoolean(fila["en_cartelera"]) == true)
                {

                    p.PeliculaNro = int.Parse(fila["id_pelicula"].ToString());
                    p.Titulo = fila["titulo"].ToString();
                    p.Duracion = int.Parse(fila["duracion"].ToString());
                    p.EnCartelera = Convert.ToBoolean(fila["en_cartelera"]);
                    p.Idioma = new Idioma();
                    p.Idioma.IdiomaNro = int.Parse(fila["id_idioma"].ToString());
                    p.Idioma.NombreIdioma = fila["idioma"].ToString();
                    p.TipoGenero = new Genero();
                    p.TipoGenero.GeneroNro = int.Parse(fila["id_genero"].ToString());
                    p.TipoGenero.NombreGenero = fila["genero"].ToString();

                    lPelicula.Add(p);

                }
                else if (cartelera == false)
                {
                    p.PeliculaNro = int.Parse(fila["id_pelicula"].ToString());
                    p.Titulo = fila["titulo"].ToString();
                    p.Duracion = int.Parse(fila["duracion"].ToString());
                    p.EnCartelera = Convert.ToBoolean(fila["en_cartelera"]);
                    p.Idioma = new Idioma();
                    p.Idioma.IdiomaNro = int.Parse(fila["id_idioma"].ToString());
                    p.Idioma.NombreIdioma = fila["idioma"].ToString();
                    p.TipoGenero = new Genero();
                    p.TipoGenero.GeneroNro = int.Parse(fila["id_genero"].ToString());
                    p.TipoGenero.NombreGenero = fila["genero"].ToString();

                    lPelicula.Add(p);
                }

            }

            return lPelicula;
        }

        public bool CrearPelicula(Pelicula pelicula)
        {
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion(); //HelperDao es donde esta el singleton

            SqlCommand comando = new SqlCommand();
            conexion.Open();
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@titulo", pelicula.Titulo);
            comando.Parameters.AddWithValue("@Duracion", pelicula.Duracion);
            comando.Parameters.AddWithValue("@en_cartelera", pelicula.EnCartelera);
            comando.Parameters.AddWithValue("@id_genero", pelicula.TipoGenero.GeneroNro);
            comando.Parameters.AddWithValue("@Idioma", pelicula.Idioma.IdiomaNro);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Peliculas VALUES (@Titulo, @Duracion, @en_cartelera, @Idioma, @id_genero)";
            int filasAfectadas = comando.ExecuteNonQuery();
            conexion.Close();

            if (filasAfectadas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CrearFuncion(Funcion funcion)
        {
            bool resultado = true;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion(); //HelperDao es donde esta el singleton

            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@Precio", funcion.Precio);
            comando.Parameters.AddWithValue("@id_pelicula ", funcion.Pelicula.PeliculaNro);
            comando.Parameters.AddWithValue("@id_horario", funcion.Horario.CantHora);
            comando.Parameters.AddWithValue("@fecha_funcion ", funcion.FechaFuncion);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO Funciones VALUES (@Precio, @id_pelicula, @id_horario, @fecha_funcion)";
            if (comando.ExecuteNonQuery() == 0)
            {
                resultado = false;
            }

            return resultado;

        }
        public bool ModificarFuncion(Funcion funcion)
        {
            bool resultado = true;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion(); //HelperDao es donde esta el singleton

            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@id_funcion", funcion.FuncionNro);
            comando.Parameters.AddWithValue("@Precio", funcion.Precio);
            comando.Parameters.AddWithValue("@id_pelicula ", funcion.Pelicula.PeliculaNro);
            comando.Parameters.AddWithValue("@id_horario", funcion.Horario.CantHora);
            comando.Parameters.AddWithValue("@FechaFuncion ", funcion.FechaFuncion);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE Funciones " +
                "set (precio = @Precio, id_pelicula = @id_pelicula, id_horario = @id_horario, " +
                "fecha_funcion = @FechaFuncion)";
            if (comando.ExecuteNonQuery() == 0)
            {
                resultado = false;
            }

            return resultado;

        }

        public bool ModificarPelicula(Pelicula pelicula)
        {
            bool resultado = true;
            SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();

            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.Parameters.AddWithValue("@PeliculaNro", pelicula.PeliculaNro);
            comando.Parameters.AddWithValue("@Titulo", pelicula.Titulo);
            comando.Parameters.AddWithValue("@Duracion", pelicula.Duracion);
            comando.Parameters.AddWithValue("@en_cartelera", pelicula.EnCartelera);
            comando.Parameters.AddWithValue("@id_genero", pelicula.TipoGenero.GeneroNro);
            comando.Parameters.AddWithValue("@Idioma", pelicula.Idioma.IdiomaNro);
            comando.CommandType = CommandType.Text;
            comando.CommandText = "UPDATE Peliculas " +
                "set titulo = @Titulo, duracion = @Duracion, en_cartelera = @en_cartelera, id_idioma = @Idioma, id_genero = @id_genero " +
                "where id_pelicula = @PeliculaNro";
            if (comando.ExecuteNonQuery() == 0)
            {
                resultado = false;
            }

            conexion.Close();
            return resultado;
        }

        public List<Funcion> ObtenerFunciones()
        {
            List<Funcion> lFuncion = new List<Funcion>();
            string consultaSql = "select * from Funciones f join Peliculas p on f.id_pelicula = p.id_pelicula join Horarios h on h.id_horario = f.id_horario order by id_funcion desc";
            DataTable tabla = HelperDao.ObtenerInstancia().Sql(consultaSql);

            foreach (DataRow fila in tabla.Rows)
            {
                Funcion f = new Funcion();

                f.FuncionNro = int.Parse(fila[0].ToString());
                f.Precio = double.Parse(fila[1].ToString());
                f.Pelicula = new Pelicula();
                f.Pelicula.PeliculaNro = int.Parse(fila[2].ToString());
                f.Pelicula.Titulo = fila[6].ToString();
                f.Pelicula.EnCartelera = bool.Parse(fila[8].ToString());
                f.Horario = new Horario();
                f.Horario.Hora = fila[12].ToString();
                f.Horario.CantHora = int.Parse(fila[3].ToString());
                f.FechaFuncion = DateTime.Parse(fila[4].ToString());

                //if (f.FechaFuncion >= DateTime.Now)
                //{
                    lFuncion.Add(f);
                //}

            }

            return lFuncion;

        }

        public List<TipoCliente> ObtenerTipoCliente()
        {
            List<TipoCliente> lTipoCliente = new List<TipoCliente>();
            DataTable tabla = HelperDao.ObtenerInstancia().Consultar("Tipos_cliente");

            foreach (DataRow fila in tabla.Rows)
            {
                TipoCliente tc = new TipoCliente();
                tc.TipoNro = Convert.ToInt32(fila[0]);
                tc.ClienteNombre = fila[1].ToString();
                lTipoCliente.Add(tc);
            }

            return lTipoCliente;
        }

        public List<Butaca> ObtenerButacas(int id_funcion)
        {
            List<Butaca> lButacas = new List<Butaca>();
            string consultaSql = "SELECT * FROM Butacas WHERE id_funcion = " + id_funcion.ToString();
            DataTable tabla = HelperDao.ObtenerInstancia().Sql(consultaSql);

            foreach (DataRow fila in tabla.Rows)
            {
                Butaca b = new Butaca();

                //if (Convert.ToBoolean(fila["estado"]) == v)
                //{

                b.ButacaNro = int.Parse(fila["id_butaca"].ToString());
                b.Descuento = int.Parse(fila["descuento_porcentaje"].ToString());
                b.Precio = double.Parse(fila["precio_butaca"].ToString());
                b.Numero = Convert.ToInt32(fila["numero"]);
                b.Estado = bool.Parse(fila["estado"].ToString());
                b.Ticket = new Ticket();
                b.Ticket.TicketNro = int.Parse(fila["id_ticket"].ToString());
                b.Cliente = new TipoCliente();
                b.Cliente.TipoNro = int.Parse(fila["id_tipo_cliente"].ToString());
                b.EstadoReserva = new EstadoReserva();
                b.EstadoReserva.NroReserva = int.Parse(fila["id_estado_reserva"].ToString());
                b.Funcion = new Funcion();
                b.Funcion.FuncionNro = int.Parse(fila["id_funcion"].ToString());
                b.Sala = new Sala();
                b.Sala.SalaNro = int.Parse(fila["id_sala"].ToString());

                lButacas.Add(b);

                //}
                //else if (v == true)
                //{
                //    b.ButacaNro = int.Parse(fila["id_butaca"].ToString());
                //    b.Descuento = int.Parse(fila["descuento_porcentaje"].ToString());
                //    b.Precio = double.Parse(fila["precio_butaca"].ToString());
                //    b.Numero = Convert.ToInt32(fila["numero"]);
                //    b.Estado = bool.Parse(fila["estado"].ToString());
                //    b.Ticket = new Ticket();
                //    b.Ticket.TicketNro = int.Parse(fila["id_ticket"].ToString());
                //    b.Cliente = new TipoCliente();
                //    b.Cliente.TipoNro = int.Parse(fila["id_tipo_cliente"].ToString());
                //    b.EstadoReserva = new EstadoReserva();
                //    b.EstadoReserva.NroReserva = int.Parse(fila["id_estado_reserva"].ToString());
                //    b.Funcion = new Funcion();
                //    b.Funcion.FuncionNro = int.Parse(fila["id_funcion"].ToString());
                //    b.Sala = new Sala();
                //    b.Sala.SalaNro = int.Parse(fila["id_sala"].ToString());

                //    lButacas.Add(b);
            }
            return lButacas;
        }

        public bool VerificarLogin(string user, string password)
        {
            //List<Butaca> lButacas = new List<Butaca>();
            string consultaSql = "SELECT * FROM Usuarios where usuario = '" + user + "' and pass = '" + password + "'";
            DataTable tabla = HelperDao.ObtenerInstancia().Sql(consultaSql);
            if (tabla.Rows.Count > 0)
            {
                return true;
            } else
            {
                return false;
            }

        }

        //public bool EliminarPelicula(int id)
        //{
        //    bool resultado = true;
        //    SqlConnection conexion = HelperDao.ObtenerInstancia().ObtenerConexion();

        //    conexion.Open();
        //    SqlCommand comando = new SqlCommand();
        //    comando.Connection = conexion;
        //    comando.Parameters.Add(new SqlParameter("@PeliculaNro", oPelicula.PeliculaNro));
        //    comando.CommandType = CommandType.Text;
        //    comando.CommandText = "DELETE FROM Peliculas WHERE id_pelicula = @PeliculaNro";
        //    if (comando.ExecuteNonQuery() == 0)
        //    {
        //        resultado = false;
        //    }

        //    conexion.Close();
        //    return resultado;
        //}
    }
}
