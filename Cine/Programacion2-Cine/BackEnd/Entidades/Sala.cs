using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entidades
{
    public class Sala
    {
        public int SalaNro { get; set; }
        public string? Descripcion { get; set; }
        public int Capacidad { get; set; }
        public TipoSala? TipoSala { get; set; }

        public Sala()
        {

        }
    }
}
