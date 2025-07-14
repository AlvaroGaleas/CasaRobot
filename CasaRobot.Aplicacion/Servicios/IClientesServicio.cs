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
    public interface IClientesServicio
    {
        [OperationContract]
        Task AddClienteAsync(Clientes nuevoCliente);
        [OperationContract]
        Task DeleteClienteAsync(int id);//Eliminar
        [OperationContract]
        Task UpdateClienteAsync(Clientes entidad);//Actualizar
        [OperationContract]
        Task<IEnumerable<Clientes>> GetAllClienteAsync();//Select *
        [OperationContract]
        Task<Clientes> GetbyIdClienteAsync(int id);//Buscar entidades por ID
        [OperationContract]
        Task<List<Clientes>> ListarClientes();
        [OperationContract]
        Task<List<Clientes>> ListarClientesNombre(string nombre);
      
    }
}
