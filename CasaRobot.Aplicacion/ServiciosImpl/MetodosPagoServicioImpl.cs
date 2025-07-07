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
    public class MetodosPagoServicioImpl: IMetodosPagoServicio
    {
        private IMetodosPagoRepositorio metodosPagoRepositorio;
        public MetodosPagoServicioImpl(CasaRobot2Context _casarobot2Context)
        {
            this.metodosPagoRepositorio = new MetodosPagoRepositorioImpl(_casarobot2Context);
        }

        public async Task AddMetodosPagoAsync(MetodosPago nuevoMetodosPago)
        {
            await metodosPagoRepositorio.AddAsync(nuevoMetodosPago);
        }

        public async Task DeleteMetodosPagoAsync(int id)
        {
            await metodosPagoRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<MetodosPago>> GetAllMetodosPagoAsync()
        {
            return await metodosPagoRepositorio.GetAllAsync();
        }

        public Task<MetodosPago> GetbyIdMetodosPagoAsync(int id)
        {
            return metodosPagoRepositorio.GetbyIdAsync(id);
        }

        public async Task UpdateMetodosPagoAsync(MetodosPago entidad)
        {
            await metodosPagoRepositorio.UpdateAsync(entidad);
        }
    }
}
