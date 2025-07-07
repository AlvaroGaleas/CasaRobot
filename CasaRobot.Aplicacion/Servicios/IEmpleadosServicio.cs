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
    public interface IEmpleadosServicio
    {
        [OperationContract]
        Task AddEmpleadosAsync(Empleados nuevoCosto);
        [OperationContract]
        Task DeleteEmpleadosAsync(int id);//Eliminar
        [OperationContract]
        Task UpdateEmpleadosAsync(Empleados entidad);//Actualizar
        [OperationContract]
        Task<IEnumerable<Empleados>> GetAllEmpleadosAsync();//Select *
        [OperationContract]
        Task<Empleados> GetbyIdEmpleadosAsync(int id);//Buscar entidades por ID
    }
}
