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
    public interface IMetodosPagoServicio
    {
        [OperationContract]
        Task AddMetodosPagoAsync(MetodosPago nuevoMetodosPago);
        [OperationContract]
        Task DeleteMetodosPagoAsync(int id);//Eliminar
        [OperationContract]
        Task UpdateMetodosPagoAsync(MetodosPago entidad);//Actualizar
        [OperationContract]
        Task<IEnumerable<MetodosPago>> GetAllMetodosPagoAsync();//Select *
        [OperationContract]
        Task<MetodosPago> GetbyIdMetodosPagoAsync(int id);//Buscar entidades por ID
        [OperationContract]
        Task<List<MetodosPago>> ListarMetodosPago();//Listar
    }
}
