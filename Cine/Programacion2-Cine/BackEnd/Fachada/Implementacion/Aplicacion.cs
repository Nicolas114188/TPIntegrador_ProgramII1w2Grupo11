using BackEnd.Datos.Implementacion;
using BackEnd.Datos.interfaz;
using BackEnd.Entidades;
using BackEnd.Fachada.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Fachada.Implementacion
{
    public class Aplicacion : IAplicacion
    {
        private IFuncionDAO dao;
        private ITicketDAO tDao;
        public Aplicacion()
        {
            dao = new FuncionDAO();
            tDao = new TicketDAO();
        }

        public List<FormaPago> GetFormaPago()
        {
            return dao.ObtenerFormaPago();
        }

        public List<Genero> GetGeneros()
        {
            return dao.ObtenerGenero();
        }

        public List<Horario> GetHorarios()
        {
            return dao.ObtenerHorario();
        }

        public List<Idioma> GetIdiomas()
        {
            return dao.ObtenerIdiomas();
        }

        public List<Pelicula> GetPeliculas(bool cartelera)
        {
            return dao.ObtenerPeliculas(cartelera);
        }

        public List<TipoCliente> GetTipoCliente()
        {
            return dao.ObtenerTipoCliente();
        }

        public bool PostFuncion(Funcion funcion)
        {
            return dao.CrearFuncion(funcion);
        }

        public bool PostPelicula(Pelicula pelicula)
        {
            return dao.CrearPelicula(pelicula);
        }

        public bool PostTicket(Ticket ticket)
        {
            //Validar que los atributos necesarios en ticket no sean nulos

            return tDao.CrearTiket(ticket);
        }

        //public bool DeletePelicula(int id)
        //{
        //    return dao.EliminarPelicula(id);
        //}

        public bool PutPelicula(Pelicula pelicula)
        {
            return dao.ModificarPelicula(pelicula);
        }

        public List<Funcion> GetFunciones()
        {
            return dao.ObtenerFunciones();
        }

        public List<Butaca> GetButacas(int id_funcion)
        {
            return dao.ObtenerButacas(id_funcion);
        }

        public bool GetLogin(string user, string password)
        {
            return dao.VerificarLogin(user, password);
        }
    }
}
