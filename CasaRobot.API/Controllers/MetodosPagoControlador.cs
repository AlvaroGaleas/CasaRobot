using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CasaRobot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MetodosPagoControlador: ControllerBase
    {
        private IMetodosPagoServicio _metodosPagoServicio;

        public MetodosPagoControlador(IMetodosPagoServicio metodosPagoServicio)
        {
            this._metodosPagoServicio = metodosPagoServicio;
        }
        [HttpGet("ListarMetodos")]
        //Listar metodos
        public Task<List<MetodosPago>> ListarMetodosPago()
        {
            return _metodosPagoServicio.ListarMetodosPago();
        }
        //Insertar metodo
        [HttpPost("CrearMetodoPago")]
        public async Task<IActionResult> CrearMetodoPago([FromBody] MetodosPago nuevoMetodo)
        {
            try
            {
                await _metodosPagoServicio.AddMetodosPagoAsync(nuevoMetodo);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error:{ex.Message}");
                return StatusCode(500, "error interno");
            }
        }
        [HttpPut("ActualizarMetodo/{id}")]
        public async Task<IActionResult> UpdateMetodoPago(int id, [FromBody] MetodosPago metodoActualizado)
        {
            if (id != metodoActualizado.PagoID)
                return BadRequest("El ID no coincide");

            await _metodosPagoServicio.UpdateMetodosPagoAsync(metodoActualizado);
            return NoContent();
        }
    }
}
