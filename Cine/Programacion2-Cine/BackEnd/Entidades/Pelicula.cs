using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entidades
{
    public class Pelicula
    {
        public int PeliculaNro { get; set; }
        //public DateTime FechaEstreno { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }
        public bool EnCartelera { get; set; }
        public Genero? TipoGenero { get; set; }
        public Idioma? Idioma { get; set; }
        //public DateTime FechaSalida { get; set; }
        public Pelicula(string nombre, int duracion, Genero tipoGenero, Idioma idioma)
        {
            Titulo = nombre;
            Duracion = duracion;
            TipoGenero = tipoGenero;
            Idioma = idioma;

        }
        public Pelicula()
        {                
        }
    }
}
