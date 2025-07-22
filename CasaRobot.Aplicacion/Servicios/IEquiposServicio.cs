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
    public interface IEquiposServicio
    {
        [OperationContract]
        Task AddEquiposAsync(Equipos nuevoEquipo);
        [OperationContract]
        Task DeleteEquiposAsync(int id);//Eliminar
        [OperationContract]
        Task UpdateEquiposAsync(Equipos entidad);//Actualizar
        [OperationContract]
        Task<IEnumerable<Equipos>> GetAllEquiposAsync();//Select *
        [OperationContract]
        Task<Equipos> GetbyIdEquiposAsync(int id);//Buscar entidades por ID
        [OperationContract]
        Task<List<Equipos>> ListarEquiposModelo(string modelo);
        

    }
}
