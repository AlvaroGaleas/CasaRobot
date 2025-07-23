using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CasaRobot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenesServicioControlador: ControllerBase
    {
        private IOrdenesServicioServicios _ordenesServicioServicios;
       
        public OrdenesServicioControlador(IOrdenesServicioServicios ordenesServicioServicios)
        {
            this._ordenesServicioServicios = ordenesServicioServicios;
        }
        //Listar ordenesServicio
        [HttpGet("ListarOrdenesServicio")]
        public Task<List<OrdenesServicio>> ListarOrdenesServicio()
        {
            return _ordenesServicioServicios.ListarOrdenesServicio();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenes(int id)
        {
            try
            {
                await _ordenesServicioServicios.DeleteOrdenesServicioAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
