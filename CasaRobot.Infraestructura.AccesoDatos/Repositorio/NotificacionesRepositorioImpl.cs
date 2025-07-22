using CasaRobot.Dominio.Modelo.Abstracciones;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Infraestructura.AccesoDatos.Repositorio
{
    public class NotificacionesRepositorioImpl : RepositorioImpl<Notificaciones>, INotificacionesRepositorio
    {
        private CasaRobot2Context _dbContext;
        public NotificacionesRepositorioImpl(CasaRobot2Context context) : base(context)
        {
            _dbContext = context;
        }

        public Task<List<Notificaciones>> ListarNotificaciones()
        {
            try
            {
                var resultado = from notif in _dbContext.Notificaciones
                                select notif;
                return resultado.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar notificaciones" + ex.Message);

            }
        }
    }
}
