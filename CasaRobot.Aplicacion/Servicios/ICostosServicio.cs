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
    public interface ICostosServicio
    {
        [OperationContract]
        Task AddCostosAsync(Costos nuevoCosto);
        [OperationContract]
        Task DeleteCostosAsync(int id);//Eliminar
        [OperationContract]
        Task UpdateCostosAsync(Costos entidad);//Actualizar
        [OperationContract]
        Task<IEnumerable<Costos>> GetAllCostosAsync();//Select *
        [OperationContract]
        Task<Costos> GetbyIdCostosAsync(int id);//Buscar entidades por ID
    }
}
