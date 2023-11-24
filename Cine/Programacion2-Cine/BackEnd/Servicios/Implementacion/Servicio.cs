using BackEnd.Datos.Implementacion;
using BackEnd.Datos.interfaz;
using BackEnd.Entidades;
using BackEnd.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace BackEnd.Servicios.Implementacion
{
    public class Servicio : IServicio
    {
        private IFuncionDAO dao;
        private ITicketDAO tDao;

        public Servicio()
        {
            dao = new FuncionDAO();
            tDao= new TicketDAO();
        }

        public bool DeletedPelicula(Pelicula oPelicula)
        {
            return dao.ModificarPelicula(oPelicula);
        }

        public List<FormaPago> GetFormaPago()
        {
            return dao.ObtenerFormaPago();
        }

        public List<Genero> GetGenero()
        {
            return dao.ObtenerGenero();
        }

        public List<Horario> GetHorario()
        {
            return dao.ObtenerHorario();
        }

        public List<Idioma> GetIdioma()
        {
            return dao.ObtenerIdiomas();
        }

        public List<Pelicula> GetPelicula(bool cartelera)
        {
            return dao.ObtenerPeliculas(cartelera);
        }

        public bool ModifyFuncion(Funcion oFuncion)
        {
            return dao.ModificarFuncion(oFuncion);
        }

        public bool ModifyPelicula(Pelicula oPelicula)
        {
            return dao.ModificarPelicula(oPelicula);
        }

        public bool SaveFuncion(Funcion oFuncion)
        {
            return dao.CrearFuncion(oFuncion);
        }

        public bool SavePelicula(Pelicula oPelicula)
        {
            return dao.CrearPelicula(oPelicula);
        }

        public bool SaveTicket(Ticket oTicket)
        {
            return tDao.CrearTiket(oTicket);
        }
    }
}
