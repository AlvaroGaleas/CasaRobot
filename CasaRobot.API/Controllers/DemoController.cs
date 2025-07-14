using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace CasaRobot.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class DemoController:   Controller
    {
        [HttpGet]
        public string mensaje()
        {
            return "hola mundo";
        }
        [HttpGet("{nombre}")]
        public string saludos(string nombre)
        {
            return "hola" + nombre;
        }
        
    }
}
