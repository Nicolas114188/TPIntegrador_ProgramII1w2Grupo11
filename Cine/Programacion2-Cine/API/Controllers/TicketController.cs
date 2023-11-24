using BackEnd.Entidades;
using BackEnd.Fachada.Implementacion;
using BackEnd.Fachada.Interfaz;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private IAplicacion dataApi; //punto de acceso a la API

        public TicketController()
        {
            dataApi = new Aplicacion();
        }


        // GET: api/<TicketController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TicketController>
        [HttpPost]
        public IActionResult PostTicket(Ticket ticket)
        {
            try
            {
                if (ticket == null)
                {
                    return BadRequest("Datos de ticket incorrectos!");
                }


                if (dataApi.PostTicket(ticket))
                {
                    return Ok("Ticket cargado.");
                }
                else
                {
                    return StatusCode(400, "Error en la carga.");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }


        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
