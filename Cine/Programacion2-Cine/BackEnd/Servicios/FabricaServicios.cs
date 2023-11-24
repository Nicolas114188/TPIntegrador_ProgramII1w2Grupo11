using BackEnd.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Servicios
{
    public abstract class FabricaServicios
    {
        public abstract IServicio CrearServicio();
    }
}
