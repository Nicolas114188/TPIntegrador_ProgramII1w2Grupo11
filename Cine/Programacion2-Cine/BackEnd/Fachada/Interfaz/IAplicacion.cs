using BackEnd.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Fachada.Interfaz
{
    public interface IAplicacion
    {
        List<Pelicula> GetPeliculas(bool cartelera);

        bool PostPelicula(Pelicula pelicula);

        List<Genero> GetGeneros();

        List<Idioma> GetIdiomas();
        bool PutPelicula(Pelicula pelicula);
        //bool DeletePelicula(Pelicula pelicula);
        List<Horario> GetHorarios();
        
        List<Funcion> GetFunciones();
        List<FormaPago> GetFormaPago();
        List<TipoCliente> GetTipoCliente();
        bool PostTicket(Ticket ticket);
        bool PostFuncion(Funcion funcion);
        List<Butaca>? GetButacas(int i);
        bool GetLogin(string user, string password);
    }
}
