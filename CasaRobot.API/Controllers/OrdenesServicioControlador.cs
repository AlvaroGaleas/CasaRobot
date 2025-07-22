using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CasaRobot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenesServicioControlador
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
    }
}
