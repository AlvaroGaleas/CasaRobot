using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CasaRobot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialServiciosControlador: ControllerBase
    {
        private IHistorialServiciosServicio _historialServiciosServicio;

        public HistorialServiciosControlador(IHistorialServiciosServicio historialServiciosServicio)
        {
            this._historialServiciosServicio = historialServiciosServicio;
        }
        [HttpGet("ListarHistorialesTodos")]
        //Listar historiales
        public Task<List<HistorialServicios>> ListarHistoriales()
        {
            return _historialServiciosServicio.ListarHistoriales();
        }
        [HttpPut("ActualizarHistorial/{id}")]
        public async Task<IActionResult> UpdateHistorial(int id, [FromBody] HistorialServicios historialActualizado)
        {
            if (id != historialActualizado.HistorialID)
            return BadRequest("El ID no coincide");

            await _historialServiciosServicio.UpdateHistorialServiciosAsync(historialActualizado);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialServicios(int id)
        {
            try
            {
                await _historialServiciosServicio.DeleteHistorialServiciosAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
