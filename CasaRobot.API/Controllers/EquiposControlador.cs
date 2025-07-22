using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CasaRobot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquiposControlador: ControllerBase
    {
        private IEquiposServicio equiposServicio;

        public EquiposControlador(IEquiposServicio equiposServicio)
        {
            this.equiposServicio = equiposServicio;
        }
        [HttpGet("GetEquipos")]
        //Listar Equipos
        public Task<IEnumerable<Equipos>> GetEquipos()
        {
            return equiposServicio.GetAllEquiposAsync();
        }
        //Listar equipos por modelo
        [HttpGet("ListarEquipos/{modelo}")]
        public Task<List<Equipos>> GetEquiposModelo (string modelo)
        {
            return equiposServicio.ListarEquiposModelo(modelo);
        }
        [HttpPost("crear equipo")]
        public async Task<IActionResult> CrearEquipo([FromBody] Equipos nuevoEquipo)
        {
            try
            {
                await equiposServicio.AddEquiposAsync(nuevoEquipo);
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

            await equiposServicio.UpdateEquiposAsync(equiposActualizado);
            return NoContent();
        }
    }    
}
