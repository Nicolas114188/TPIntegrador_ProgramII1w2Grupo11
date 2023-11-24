using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entidades
{
    public class Funcion
    {
        public int FuncionNro { get; set; }
        public double Precio { get; set; }
        public Pelicula Pelicula { get; set; }
        public Horario Horario { get; set; }
        public DateTime FechaFuncion { get; set; }

        //DANGER!!!, pero funciona by:messi
        public string NombrePelicula
        {
            get
            {
                string titulo = Pelicula != null ? Pelicula.Titulo : "";
                string fecha = FechaFuncion.ToString("dd/MM/yyyy"); 
                string hora = Horario != null ? Horario.Hora.ToString() : ""; 
                return $"{titulo} - {fecha} - {hora}";
            }
        }
        public Funcion(Pelicula peli, Horario hrsPeli)
        {
            Pelicula = peli;
            Horario = hrsPeli;
        }

        public Funcion()
        {
        }
    }
}
