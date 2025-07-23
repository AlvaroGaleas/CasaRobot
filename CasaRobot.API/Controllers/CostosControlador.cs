using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CasaRobot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CostosControlador: ControllerBase
    {
        private ICostosServicio _costosServicio;
        public CostosControlador(ICostosServicio costosServicio)
        {
            _costosServicio = costosServicio;
        }

        [HttpGet("GetCostos")]
        //Listar Costos
        public Task<IEnumerable<Costos>> GetCostos()
        {
            return _costosServicio.GetAllCostosAsync();
        }

        [HttpPost("InsertarCostos")]
        public async Task<IActionResult> CrearCliente([FromBody] Costos nuevoCosto)
        {
            try
            {
                await _costosServicio.AddCostosAsync(nuevoCosto);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error:{ex.Message}");
                return StatusCode(500, "error interno");
            }
        }
        [HttpPut("ActualizarCosto/{id}")]
        public async Task<IActionResult> UpdateCosto(int id, [FromBody] Costos costoActualizado)
        {
            if (id != costoActualizado.CostoID)
            return BadRequest("El ID no coincide");

            await _costosServicio.UpdateCostosAsync(costoActualizado);            
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCostos(int id)
        {
            try
            {
                await _costosServicio.DeleteCostosAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
