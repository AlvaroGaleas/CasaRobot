using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CasaRobot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesControlador: ControllerBase
    {

        private IClientesServicio _clientesServicio;
        public ClientesControlador(IClientesServicio clientesServicio)
        {
            _clientesServicio = clientesServicio;
        }
        //Listar Equipos
        [HttpGet("GetClientes")]            
        
        public Task<List<Clientes>> ListarClientes()
        {
            return _clientesServicio.ListarClientes();
        }
        //Listar clientes por nombre
        [HttpGet("ListarClientesNombre/{nombre}")]
        public Task<List<Clientes>> GetClientesNombre(string nombre)
        {
            return _clientesServicio.ListarClientesNombre(nombre);
        }

        [HttpPost("CrearCliente")]
        public async Task<IActionResult> CrearCliente([FromBody] Clientes nuevoCliente)
        {
            try
            {
                await _clientesServicio.AddClienteAsync(nuevoCliente);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error:{ex.Message}");
                return StatusCode(500,"error interno");
            }
        }

    }
}
