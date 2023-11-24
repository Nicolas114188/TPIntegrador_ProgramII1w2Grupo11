using BackEnd.Fachada.Implementacion;
using BackEnd.Fachada.Interfaz;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IAplicacion dataApi; //punto de acceso a la API

        public LoginController()
        {
            dataApi = new Aplicacion();
        }

        // GET: api/<ButacaController>
        [HttpGet]
        public IActionResult Get(string user, string password)
        {
            bool lst = false;
            try
            {
                lst = dataApi.GetLogin(user, password);
                return Ok(lst);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }
}
