using CasaRobot.Aplicacion.DTO.DTOs;
using CasaRobot.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Aplicacion.Servicios
{
    [ServiceContract]
    public interface IOrdenesServicioServicios
    {
        [OperationContract]
        Task AddOrdenesServicioAsync(OrdenesServicio nuevoNotificaciones);
        [OperationContract]
        Task DeleteOrdenesServicioAsync(int id);//Eliminar
        [OperationContract]
        Task UpdateOrdenesServicioAsync(OrdenesServicio entidad);//Actualizar
        [OperationContract]
        Task<IEnumerable<OrdenesServicio>> GetAllOrdenesServicioAsync();//Select *
        [OperationContract]
        Task<OrdenesServicio> GetbyIdOrdenesServicioAsync(int id);//Buscar entidades por ID
        [OperationContract]
        Task<List<EstadoOrdenDetalleDTO>> ListarOrdenesPorEstadoComplejo();
        [OperationContract]
        Task<List<HistorialTecnicoClienteDTO>> ListarHistorialTecnicoCliente();
        [OperationContract]
        Task<List<EstadoClientesDTO>> ListarClientesPorEstado();
        [OperationContract]
        Task<List<OrdenesServicio>> ListarOrdenesServicio();
    }
}
