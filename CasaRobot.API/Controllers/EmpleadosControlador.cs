using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CasaRobot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosControlador: ControllerBase
    {
        private IEmpleadosServicio _empleadosServicio;
        public EmpleadosControlador(IEmpleadosServicio empleadosServicio)
        {
            _empleadosServicio = empleadosServicio;
        }
        [HttpGet("GetEmpleados")]
        //Listar empleados
        public Task<IEnumerable<Empleados>> GetEmpleados()
        {
            return _empleadosServicio.GetAllEmpleadosAsync();
        }
        //Listar empleados por nombre
        [HttpGet("ListarEmpleados/{nombre}")]
        public Task<List<Empleados>> GetEmpleadosNombre(string nombre)
        {
            return _empleadosServicio.ListarEmpleadosNombre(nombre);
        }

        [HttpPost("crear Empleado")]        
        public async Task<IActionResult> CrearEmpleado([FromBody] Empleados nuevoEmpleado)
        {
            try
            {
                await _empleadosServicio.AddEmpleadosAsync(nuevoEmpleado);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"error:{ex.Message}");
                return StatusCode(500, "error interno");
            }
        }
        [HttpPut("UpdateEmpleado/{id}")]
        public async Task<IActionResult> UpdateEmpleados(int id, [FromBody] Empleados empleadosActualizado)
        {
            if (id != empleadosActualizado.EmpleadoID)
                return BadRequest("El ID no coincide");

            await _empleadosServicio.UpdateEmpleadosAsync(empleadosActualizado);
            return NoContent();
        }
    }
}
