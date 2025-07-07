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
    public class HistorialServiciosImpl : IHistorialServiciosServicio
    {
        private IHistorialServiciosRepositorio historialServiciosRepositorio;
        public HistorialServiciosImpl(CasaRobot2Context _casarobot2Context)
        {
            this.historialServiciosRepositorio = new HistorialServiciosRepositorioImpl(_casarobot2Context);
        }

        public async Task AddHistorialServiciosAsync(HistorialServicios nuevoEstados)
        {
            await historialServiciosRepositorio.AddAsync(nuevoEstados);
        }

        public async Task DeleteHistorialServiciosAsync(int id)
        {
            await historialServiciosRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<HistorialServicios>> GetAllHistorialServiciosAsync()
        {
            return await historialServiciosRepositorio.GetAllAsync();
        }

        public async Task<HistorialServicios> GetbyIdHistorialServiciosAsync(int id)
        {
            return await historialServiciosRepositorio.GetbyIdAsync(id);
        }

        public async Task UpdateHistorialServiciosAsync(HistorialServicios entidad)
        {
            await historialServiciosRepositorio.UpdateAsync(entidad);
        }
    }
}
