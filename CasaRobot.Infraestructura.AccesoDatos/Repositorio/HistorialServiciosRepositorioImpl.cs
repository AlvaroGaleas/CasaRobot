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
    public class HistorialServiciosRepositorioImpl : RepositorioImpl<HistorialServicios>, IHistorialServiciosRepositorio
    {
        private CasaRobot2Context _dbContext;
        public HistorialServiciosRepositorioImpl(CasaRobot2Context context) : base(context)
        {
            _dbContext = context;
        }

        public Task<List<HistorialServicios>> ListarHistoriales()
        {
            try
            {
                var resultado = from histor in _dbContext.HistorialServicios
                                select histor;
                return resultado.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar equipos" + ex.Message);

            }
        }
    }
}
