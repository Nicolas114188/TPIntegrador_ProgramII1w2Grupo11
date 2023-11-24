using BackEnd.Entidades;
using BackEnd.Fachada.Implementacion;
using BackEnd.Fachada.Interfaz;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ButacaController : ControllerBase
    {
        private IAplicacion dataApi; //punto de acceso a la API

        public ButacaController()
        {
            dataApi = new Aplicacion();
        }

        // GET: api/<ButacaController>
        [HttpGet]
        public IActionResult Get(int i)
        {
            List<Butaca> lst = null;
            try
            {
                lst = dataApi.GetButacas(i);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

            // GET api/<ButacaController>/5
       [HttpGet("{id}")]


        // POST api/<ButacaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ButacaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ButacaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
