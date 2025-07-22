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
    public class CostosServicioImpl: ICostosServicio
    {
        private ICostosRepositorio costosRepositorio;
        private readonly CasaRobot2Context _dbcontext;
        public CostosServicioImpl(CasaRobot2Context _casarobot2Context)
        {
            _dbcontext = _casarobot2Context;
            this.costosRepositorio = new CostosRepositorioImpl(_casarobot2Context);
        }

        public async Task AddCostosAsync(Costos nuevoCosto)
        {
            await costosRepositorio.AddAsync(nuevoCosto);
        }

        public async Task DeleteCostosAsync(int id)
        {
            await costosRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<Costos>> GetAllCostosAsync()
        {
            return await costosRepositorio.GetAllAsync();
        }

        public Task<Costos> GetbyIdCostosAsync(int id)
        {
            return costosRepositorio.GetbyIdAsync(id);
        }

        public async Task UpdateCostosAsync(Costos entidad)
        {
            await costosRepositorio.UpdateAsync(entidad);
        }
    }
}
