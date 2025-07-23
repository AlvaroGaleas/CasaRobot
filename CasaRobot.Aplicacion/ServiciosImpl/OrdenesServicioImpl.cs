using CasaRobot.Aplicacion.DTO.DTOs;
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
    public class OrdenesServicioImpl: IOrdenesServicioServicios
    {
        private IOrdenesServicioRepositorio ordenesServicioRepositorio;
        private readonly CasaRobot2Context _dbcontext;
        public OrdenesServicioImpl(CasaRobot2Context _casarobot2Context)
        {
            _dbcontext = _casarobot2Context;
            this.ordenesServicioRepositorio = new OrdenesServicioRepositorioImpl(_casarobot2Context);
        }

        public async Task AddOrdenesServicioAsync(OrdenesServicio nuevoNotificaciones)
        {
            await ordenesServicioRepositorio.AddAsync(nuevoNotificaciones);
        }

        public async Task DeleteOrdenesServicioAsync(int id)
        {
            var orden = await _dbcontext.OrdenesServicio.FindAsync(id);
            if (orden == null)
                throw new KeyNotFoundException("orden no encontrado.");

            _dbcontext.OrdenesServicio.Remove(orden);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrdenesServicio>> GetAllOrdenesServicioAsync()
        {
            return await ordenesServicioRepositorio.GetAllAsync();
        }

        public Task<OrdenesServicio> GetbyIdOrdenesServicioAsync(int id)
        {
            return ordenesServicioRepositorio.GetbyIdAsync(id);
        }

        public Task<List<EstadoClientesDTO>> ListarClientesPorEstado()
        {
            return ordenesServicioRepositorio.ListarClientesPorEstado();
        }

        public Task<List<HistorialTecnicoClienteDTO>> ListarHistorialTecnicoCliente()
        {
            return ordenesServicioRepositorio.ListarHistorialTecnicoCliente();
        }

        public Task<List<EstadoOrdenDetalleDTO>> ListarOrdenesPorEstadoComplejo()
        {
            return ordenesServicioRepositorio.ListarOrdenesPorEstadoComplejo();
        }

        public Task<List<OrdenesServicio>> ListarOrdenesServicio()
        {
            return ordenesServicioRepositorio.ListarOrdenesServicio();
        }

        public async Task UpdateOrdenesServicioAsync(OrdenesServicio entidad)
        {
            await ordenesServicioRepositorio.UpdateAsync(entidad);
        }
    }
}
