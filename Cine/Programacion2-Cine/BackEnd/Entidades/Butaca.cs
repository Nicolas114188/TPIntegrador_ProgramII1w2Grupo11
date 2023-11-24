using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entidades
{
    public class Butaca
    {
        public int ButacaNro { get; set; }
        public int Descuento { get; set; }
        public double Precio { get; set; }
        public int Numero { get; set; }
        public bool Estado { get; set; }
        public Ticket? Ticket { get; set; }
        public TipoCliente Cliente { get; set; }
        public EstadoReserva? EstadoReserva { get; set; }
        public Funcion Funcion { get; set; }
        public Sala? Sala { get; set; }

        public Butaca()
        {

        }
    }
}
