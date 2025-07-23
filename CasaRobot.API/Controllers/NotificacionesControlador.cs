using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CasaRobot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificacionesControlador: ControllerBase
    {
        private INotificacionesServicio _notificacionesServicio;

        public NotificacionesControlador(INotificacionesServicio notificacionesServicio)
        {
            this._notificacionesServicio = notificacionesServicio;
        }
        //Listar notificaciones
        [HttpGet("ListarNotificaciones")]
        public Task<List<Notificaciones>> ListarNotificaciones()
        {
            return _notificacionesServicio.ListarNotificaciones();
        }
        //Insertar notificacion
        [HttpPost("CrearNotificaciones")]
        public async Task<IActionResult> CrearNotificacion([FromBody] Notificaciones nuevoNotificacion)
        {
            try
            {
                await _notificacionesServicio.AddNotificacionesAsync(nuevoNotificacion);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error:{ex.Message}");
                return StatusCode(500, "error interno");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotificaciones(int id)
        {
            try
            {
                await _notificacionesServicio.DeleteNotificacionesAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
