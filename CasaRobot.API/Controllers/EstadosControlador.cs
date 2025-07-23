using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CasaRobot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadosControlador: ControllerBase
    {
        private IEstadosServicio _estadosServicio;
        public EstadosControlador(IEstadosServicio estadosServicio)
        {
            this._estadosServicio = estadosServicio;
        }
        [HttpGet("ListarEstadosTodos")]
        //Listar estados
        public Task<List<Estados>> ListarEstados()
        {
            return _estadosServicio.ListarEstados();
        }
        //Listar estados por nombre
        [HttpGet("ListarEstados/{nombre}")]
        public Task<List<Estados>> GetEquiposModelo(string nombre)
        {
            return _estadosServicio.ListarEstadosNombre(nombre);
        }

        //Insertar estado
        [HttpPost("CrearEstado")]
        public async Task<IActionResult> CrearEstado([FromBody] Estados nuevoEstado)
        {
            try
            {await _estadosServicio.AddEstadosAsync(nuevoEstado);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error:{ex.Message}");
                return StatusCode(500, "error interno");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstados(int id)
        {
            try
            {
                await _estadosServicio.DeleteEstadosAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpPut("ActualizarEstados/{id}")]
        public async Task<IActionResult> UpdateEstados(int id, [FromBody] Estados estadoActualizado)
        {
            if (id != estadoActualizado.EstadoID)
                return BadRequest("El ID no coincide");

            await _estadosServicio.UpdateEstadosAsync(estadoActualizado);
            return NoContent();
        }
    }
}
