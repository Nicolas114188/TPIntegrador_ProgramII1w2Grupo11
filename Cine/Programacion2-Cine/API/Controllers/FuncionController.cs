using BackEnd.Entidades;
using BackEnd.Fachada.Implementacion;
using BackEnd.Fachada.Interfaz;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private IAplicacion dataApi; //punto de acceso a la API

        public FuncionController()
        {
            dataApi = new Aplicacion();
        }

        // GET: api/<FuncionController>
        [HttpGet]
        public IActionResult GetFuncion()
        {
            List<Funcion> lst = null;
            try
            {
                lst = dataApi.GetFunciones();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
        [HttpGet("/formaPago")]
        public IActionResult GetFormaPago()
        {
            List<FormaPago> lst = null;
            try
            {
                lst = dataApi.GetFormaPago();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/tipoCliente")]
        public IActionResult GetTipoCliente()
        {
            List<TipoCliente> lst = null;
            try
            {
                lst = dataApi.GetTipoCliente();
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        // GET api/<FuncionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FuncionController>
        [HttpPost]
        public IActionResult Post(Funcion funcion)
        {
            try
            {
                if (funcion == null)
                {
                    return BadRequest("Datos de pelicula incorrectos!");
                }

                if (dataApi.PostFuncion(funcion))
                {
                    return Ok("Funcion cargada.");
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

        // PUT api/<FuncionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Funcion funcion)
        {
        }

        // DELETE api/<FuncionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
