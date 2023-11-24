using BackEnd.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Datos.interfaz
{
    public interface IFuncionDAO
    {
        List<Pelicula> ObtenerPeliculas(bool cartelera);
        List<Idioma> ObtenerIdiomas();
        List<Genero> ObtenerGenero();
        List<Horario> ObtenerHorario();
        List<FormaPago> ObtenerFormaPago();
        List<TipoCliente> ObtenerTipoCliente();
        bool CrearPelicula(Pelicula oPelicula);
        bool ModificarFuncion(Funcion oFuncion);
        bool ModificarPelicula(Pelicula oPelicula);
        bool CrearFuncion(Funcion oFuncion);
        List<Funcion> ObtenerFunciones();
        List<Butaca> ObtenerButacas(int i);
        bool VerificarLogin(string user, string password);

    }
}
