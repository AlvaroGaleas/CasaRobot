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
    public interface IHistorialServiciosServicio
    {
        [OperationContract]
        Task AddHistorialServiciosAsync(HistorialServicios nuevoEstados);//Insertar
        [OperationContract]
        Task DeleteHistorialServiciosAsync(int id);//Eliminar
        [OperationContract]
        Task UpdateHistorialServiciosAsync(HistorialServicios entidad);//Actualizar
        [OperationContract]
        Task<IEnumerable<HistorialServicios>> GetAllHistorialServiciosAsync();//Select *
        [OperationContract]
        Task<HistorialServicios> GetbyIdHistorialServiciosAsync(int id);//Buscar entidades por ID
        [OperationContract]
        Task<List<HistorialServicios>> ListarHistoriales();//ListarHistoriales
    }
}
