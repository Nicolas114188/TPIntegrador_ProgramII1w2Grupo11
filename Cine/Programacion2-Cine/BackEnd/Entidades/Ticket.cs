using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.Entidades
{
    public class Ticket
    {
        public int TicketNro { get; set; }
        public DateTime fecha_ticket { get; set; }
        public bool Pagado { get; set; }
        public List<Butaca> listBuataca { get; set; }

        //[Required(ErrorMessage = "qweqwe")]
        public FormaPago FormaPago { get; set; }
        public Ticket()
        {
            listBuataca = new List<Butaca>();
        }
        public void AgregarButaca(Butaca butaca)
        {
            listBuataca.Add(butaca);
        }
        public void QuitarButaca(int posicion)
        {
            listBuataca.RemoveAt(posicion);
        }

        public void VaciarButacas()
        {
            listBuataca.Clear();
        }
    }
}
