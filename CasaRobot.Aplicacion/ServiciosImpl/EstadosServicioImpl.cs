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
    public class EstadosServicioImpl: IEstadosServicio
    {
        private IEstadosRepositorio estadosRepositorio;
        public EstadosServicioImpl(CasaRobot2Context _casarobot2Context)
        {
            this.estadosRepositorio = new EstadosRepositorioImpl(_casarobot2Context);
        }

        public async Task AddEstadosAsync(Estados nuevoEstados)
        {
            await estadosRepositorio.AddAsync(nuevoEstados);
        }

        public async Task DeleteEstadosAsync(int id)
        {
            await estadosRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<Estados>> GetAllEstadosAsync()
        {
            return await estadosRepositorio.GetAllAsync();
        }

        public Task<Estados> GetbyIdEstadossAsync(int id)
        {
            return estadosRepositorio.GetbyIdAsync(id);
        }

        public async Task UpdateEstadosAsync(Estados entidad)
        {
            await estadosRepositorio.UpdateAsync(entidad);
        }
    }
}
