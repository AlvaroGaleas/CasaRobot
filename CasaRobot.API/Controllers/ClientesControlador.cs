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

        [HttpGet("GetClientes")]
        //Listar clientes
        public Task<IEnumerable<Clientes>> GetClientes()
        {
            return _clientesServicio.GetAllClienteAsync();
        }
    }
}
