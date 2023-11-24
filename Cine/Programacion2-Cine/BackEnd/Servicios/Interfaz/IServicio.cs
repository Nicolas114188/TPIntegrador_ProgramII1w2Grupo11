using BackEnd.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace BackEnd.Servicios.Interfaz
{
    public interface IServicio
    {
        List<Pelicula> GetPelicula(bool cartelera);

        bool SavePelicula(Pelicula oPelicula);

        bool ModifyPelicula(Pelicula oPelicula);
        bool DeletedPelicula(Pelicula oPelicula);
        bool SaveFuncion(Funcion oFuncion);
        bool ModifyFuncion(Funcion oFuncion);

        List<FormaPago> GetFormaPago();
        bool SaveTicket(Ticket oTicket);
        List<Genero> GetGenero();
        List<Idioma> GetIdioma();
        List<Horario> GetHorario();  
    }
}
