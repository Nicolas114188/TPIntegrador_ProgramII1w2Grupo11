using BackEnd.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Datos.interfaz
{
    public interface ITicketDAO
    {
        bool CrearTiket(Ticket oTicket);
    }
}
