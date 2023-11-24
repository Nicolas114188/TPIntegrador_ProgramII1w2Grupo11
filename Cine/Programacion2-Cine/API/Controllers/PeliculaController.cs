using BackEnd.Entidades;
using BackEnd.Fachada.Implementacion;
using BackEnd.Fachada.Interfaz;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private IAplicacion dataApi; //punto de acceso a la API

        public PeliculaController()
        {
            dataApi = new Aplicacion();
        }

        // GET: api/<PeliculaController>
        [HttpGet]
        public IActionResult GetPelicula()
        {
            List<Pelicula> lst = null;
            try
            {
                lst = dataApi.GetPeliculas(true);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        // GET api/<PeliculaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("/generos")]
        public IActionResult GetGeneros()
        {
            List<Genero> lg = null;

            try
            {
                lg = dataApi.GetGeneros();
                return Ok(lg);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno!! Intente luego");
            }
        }

        [HttpGet("/idiomas")]
        public IActionResult GetIdiomas()
        {
            List<Idioma> li = null;

            try
            {
                li = dataApi.GetIdiomas();
                return Ok(li);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno!! Intente luego");
            }
        }

        [HttpGet("/horarios")]
        public IActionResult GetHorarios()
        {
            List<Horario> lh = null;

            try
            {
                lh = dataApi.GetHorarios();
                return Ok(lh);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno!! Intente luego");
            }
        }

        // POST api/<PeliculaController>
        [HttpPost]
        

        public IActionResult PostPelicula(Pelicula pelicula)
        {
            try
            {
                if (pelicula == null)
                {
                    return BadRequest("Datos de pelicula incorrectos!");
                }

                if (dataApi.PostPelicula(pelicula))
                {
                    return Ok("Pelicula cargada.");
                }
                else
                {
                    return StatusCode(400, "Error en la carga.");
                }
                //return Ok(dataApi.PostPelicula(pelicula)); //el postpelicula devuelve booleano :S
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        // PUT api/<PeliculaController>/5
        [HttpPut]
        public IActionResult Put(Pelicula pelicula)
        {
            try
            {
                dataApi.PutPelicula(pelicula);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        


    }
}
