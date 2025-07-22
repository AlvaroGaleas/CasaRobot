using CasaRobot.Dominio.Modelo.Entidades;
using System;
using CasaRobot.Aplicacion.DTO.DTOs; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Dominio.Modelo.Abstracciones
{
    public interface IOrdenesServicioRepositorio: IRepositorio<OrdenesServicio>
    {
        Task<List<EstadoOrdenDetalleDTO>> ListarOrdenesPorEstadoComplejo();
        Task<List<HistorialTecnicoClienteDTO>> ListarHistorialTecnicoCliente();
        Task<List<EstadoClientesDTO>> ListarClientesPorEstado();
        Task<List<OrdenesServicio>> ListarOrdenesServicio();
    }
}
