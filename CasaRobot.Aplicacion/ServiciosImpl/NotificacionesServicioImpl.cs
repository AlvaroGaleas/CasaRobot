using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Abstracciones;
using CasaRobot.Dominio.Modelo.Entidades;
using CasaRobot.Infraestructura.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Aplicacion.ServiciosImpl
{
    public class NotificacionesServicioImpl :INotificacionesServicio
    {
        private INotificacionesRepositorio notificacionesRepositorio;
        public NotificacionesServicioImpl(CasaRobot2Context _casarobot2Context)
        {
            this.notificacionesRepositorio = new NotificacionesRepositorioImpl(_casarobot2Context);
        }

        public async Task AddNotificacionesAsync(Notificaciones nuevoNotificaciones)
        {
            await notificacionesRepositorio.AddAsync(nuevoNotificaciones);
        }

        public async Task DeleteNotificacionesAsync(int id)
        {
            await notificacionesRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<Notificaciones>> GetAllNotificacionesAsync()
        {
            return await notificacionesRepositorio.GetAllAsync();
        }

        public Task<Notificaciones> GetbyIdNotificacionesAsync(int id)
        {
            return notificacionesRepositorio.GetbyIdAsync(id);
        }

        public Task<List<Notificaciones>> ListarNotificaciones()
        {
            return notificacionesRepositorio.ListarNotificaciones();
        }

        public async Task UpdateNotificacionesAsync(Notificaciones entidad)
        {
            await notificacionesRepositorio.UpdateAsync(entidad);
        }
    }
}
