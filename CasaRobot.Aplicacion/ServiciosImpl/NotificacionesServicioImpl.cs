using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Abstracciones;
using CasaRobot.Dominio.Modelo.Entidades;
using CasaRobot.Infraestructura.AccesoDatos.Repositorio;
using Microsoft.EntityFrameworkCore;
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
        private readonly CasaRobot2Context _dbcontext;
        public NotificacionesServicioImpl(CasaRobot2Context _casarobot2Context)
        {
            _dbcontext = _casarobot2Context;
            this.notificacionesRepositorio = new NotificacionesRepositorioImpl(_casarobot2Context);
        }

        public async Task AddNotificacionesAsync(Notificaciones nuevoNotificaciones)
        {
            await notificacionesRepositorio.AddAsync(nuevoNotificaciones);
        }

        public async Task DeleteNotificacionesAsync(int id)
        {
            var notifi = await _dbcontext.Notificaciones.FindAsync(id);
            if (notifi == null)
                throw new KeyNotFoundException("notificacion no encontrado.");

            _dbcontext.Notificaciones.Remove(notifi);
            await _dbcontext.SaveChangesAsync();
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
