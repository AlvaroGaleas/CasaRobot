using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CasaRobot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquiposControlador: ControllerBase
    {
        private IEquiposServicio _equiposServicio;

        public EquiposControlador(IEquiposServicio equiposServicio)
        {
            this._equiposServicio = equiposServicio;
        }
        [HttpGet("GetEquipos")]
        //Listar Equipos
        public Task<List<Equipos>> ListarEquipos()
        {
            return _equiposServicio.ListarEquipos();
        }
        //Listar equipos por modelo
        [HttpGet("ListarEquipos/{modelo}")]
        public Task<List<Equipos>> GetEquiposModelo (string modelo)
        {
            return _equiposServicio.ListarEquiposModelo(modelo);
        }
        [HttpPost("CrearEquipo")]
        public async Task<IActionResult> CrearEquipo([FromBody] Equipos nuevoEquipo)
        {
            try
            {
                await _equiposServicio.AddEquiposAsync(nuevoEquipo);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error:{ex.Message}");
                return StatusCode(500, "error interno");
            }
        }
        [HttpPut("UpdateEquipo/{id}")]
        public async Task<IActionResult> UpdateEquipo(int id, [FromBody] Equipos equiposActualizado)
        {
            if (id != equiposActualizado.EquipoID)
                return BadRequest("El ID no coincide");

            await _equiposServicio.UpdateEquiposAsync(equiposActualizado);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipos(int id)
        {
            try
            {
                await _equiposServicio.DeleteEquiposAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }    
}
