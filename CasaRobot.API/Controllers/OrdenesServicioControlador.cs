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
        [HttpPut("ActualizarOrdenes/{id}")]
        public async Task<IActionResult> UpdateHistorial(int id, [FromBody] OrdenesServicio ordenActualizado)
        {
            if (id != ordenActualizado.OrdenID)
                return BadRequest("El ID no coincide");

            await _ordenesServicioServicios.UpdateOrdenesServicioAsync(ordenActualizado);
            return NoContent();
        }
        //Insertar ordenes
        [HttpPost("CrearOrdenes")]
        public async Task<IActionResult> CrearNotificacion([FromBody] OrdenesServicio nuevaOrdenServicio)
        {
            try
            {
                await _ordenesServicioServicios.AddOrdenesServicioAsync(nuevaOrdenServicio);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error:{ex.Message}");
                return StatusCode(500, "error interno");
            }
        }
    }
}
