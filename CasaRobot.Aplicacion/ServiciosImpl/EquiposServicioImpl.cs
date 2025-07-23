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
    public class EquiposServicioImpl: IEquiposServicio
    {
        private IEquiposRepositorio equiposRepositorio;
        private readonly CasaRobot2Context _dbcontext;
        public EquiposServicioImpl(CasaRobot2Context _casarobot2Context)
        {
            _dbcontext = _casarobot2Context;
            this.equiposRepositorio = new EquiposRepositorioImpl(_casarobot2Context);
        }

        public async Task AddEquiposAsync(Equipos nuevoEquipo)
        {
            await equiposRepositorio.AddAsync(nuevoEquipo);
        }

        public async Task DeleteEquiposAsync(int id)
        {
            var equipos = await _dbcontext.Equipos.FindAsync(id);
            if (equipos == null)
                throw new KeyNotFoundException("empleado no encontrado.");

            _dbcontext.Equipos.Remove(equipos);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Equipos>> GetAllEquiposAsync()
        {
            return await equiposRepositorio.GetAllAsync();
        }

        public Task<Equipos> GetbyIdEquiposAsync(int id)
        {
            return equiposRepositorio.GetbyIdAsync(id);
        }

        public Task<List<Equipos>> ListarEquipos()
        {
            return equiposRepositorio.ListarEquipos();
        }

        public Task<List<Equipos>> ListarEquiposModelo(string modelo)
        {
            return equiposRepositorio.ListarEquiposModelo(modelo);
        }

        public async Task UpdateEquiposAsync(Equipos entidad)
        {
            await equiposRepositorio.UpdateAsync(entidad);
        }
    }
}
