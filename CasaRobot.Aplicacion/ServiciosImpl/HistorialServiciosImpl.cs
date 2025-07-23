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
    public class HistorialServiciosImpl : IHistorialServiciosServicio
    {
        private IHistorialServiciosRepositorio historialServiciosRepositorio;
        private readonly CasaRobot2Context _dbcontext;
        public HistorialServiciosImpl(CasaRobot2Context _casarobot2Context)
        {
            _dbcontext = _casarobot2Context;
            this.historialServiciosRepositorio = new HistorialServiciosRepositorioImpl(_casarobot2Context);
        }

        public async Task AddHistorialServiciosAsync(HistorialServicios nuevoEstados)
        {
            await historialServiciosRepositorio.AddAsync(nuevoEstados);
        }

        public async Task DeleteHistorialServiciosAsync(int id)
        {
            var historial = await _dbcontext.HistorialServicios.FindAsync(id);
            if (historial == null)
                throw new KeyNotFoundException("historial no encontrado.");

            _dbcontext.HistorialServicios.Remove(historial);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<HistorialServicios>> GetAllHistorialServiciosAsync()
        {
            return await historialServiciosRepositorio.GetAllAsync();
        }

        public async Task<HistorialServicios> GetbyIdHistorialServiciosAsync(int id)
        {
            return await historialServiciosRepositorio.GetbyIdAsync(id);
        }

        public Task<List<HistorialServicios>> ListarHistoriales()
        {
            return historialServiciosRepositorio.ListarHistoriales();
        }

        public async Task UpdateHistorialServiciosAsync(HistorialServicios entidad)
        {
            await historialServiciosRepositorio.UpdateAsync(entidad);
        }
    }
}
