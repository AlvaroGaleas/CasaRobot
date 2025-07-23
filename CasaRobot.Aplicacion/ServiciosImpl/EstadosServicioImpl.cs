using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Dominio.Modelo.Abstracciones;
using CasaRobot.Dominio.Modelo.Entidades;
using CasaRobot.Infraestructura.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CasaRobot.Aplicacion.ServiciosImpl
{
    public class EstadosServicioImpl: IEstadosServicio
    {
        private IEstadosRepositorio estadosRepositorio;
        private readonly CasaRobot2Context _dbcontext;
        public EstadosServicioImpl(CasaRobot2Context _casarobot2Context)
        {
            _dbcontext = _casarobot2Context;
            this.estadosRepositorio = new EstadosRepositorioImpl(_casarobot2Context);
        }

        public async Task AddEstadosAsync(Estados nuevoEstados)
        {
            await estadosRepositorio.AddAsync(nuevoEstados);
        }

        public async Task DeleteEstadosAsync(int id)
        {
            var estados = await _dbcontext.Estados.FindAsync(id);
            if (estados == null)
                throw new KeyNotFoundException("empleado no encontrado.");

            _dbcontext.Estados.Remove(estados);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Estados>> GetAllEstadosAsync()
        {
            return await estadosRepositorio.GetAllAsync();
        }

        public Task<Estados> GetbyIdEstadossAsync(int id)
        {
            return estadosRepositorio.GetbyIdAsync(id);
        }

        public Task<List<Estados>> ListarEstados()
        {
            return estadosRepositorio.ListarEstados();
        }

        public Task<List<Estados>> ListarEstadosNombre(string NombreEstado)
        {
            return estadosRepositorio.ListarEstadosNombre(NombreEstado);
        }

        public async Task UpdateEstadosAsync(Estados entidad)
        {
            await estadosRepositorio.UpdateAsync(entidad);
        }
    }
}
