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
    public interface IEstadosServicio
    {
        [OperationContract]
        Task AddEstadosAsync(Estados nuevoEstados);
        [OperationContract]
        Task DeleteEstadosAsync(int id);//Eliminar
        [OperationContract]
        Task UpdateEstadosAsync(Estados entidad);//Actualizar
        [OperationContract]
        Task<IEnumerable<Estados>> GetAllEstadosAsync();//Select *
        [OperationContract]
        Task<Estados> GetbyIdEstadossAsync(int id);//Buscar entidades por ID
        [OperationContract]
        Task<List<Estados>> ListarEstadosNombre(string NombreEstado);
        [OperationContract]
        Task<List<Estados>> ListarEstados();
    }
}
