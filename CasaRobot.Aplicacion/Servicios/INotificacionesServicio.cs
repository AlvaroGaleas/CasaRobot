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
    public interface INotificacionesServicio
    {
        [OperationContract]
        Task AddNotificacionesAsync(Notificaciones nuevoNotificaciones);
        [OperationContract]
        Task DeleteNotificacionesAsync(int id);//Eliminar
        [OperationContract]
        Task UpdateNotificacionesAsync(Notificaciones entidad);//Actualizar
        [OperationContract]
        Task<IEnumerable<Notificaciones>> GetAllNotificacionesAsync();//Select *
        [OperationContract]
        Task<Notificaciones> GetbyIdNotificacionesAsync(int id);//Buscar entidades por ID
    }
}
