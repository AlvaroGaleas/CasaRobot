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
    public class EquiposServicioImpl: IEquiposServicio
    {
        private IEquiposRepositorio equiposRepositorio;
        public EquiposServicioImpl(CasaRobot2Context _casarobot2Context)
        {
            this.equiposRepositorio = new EquiposRepositorioImpl(_casarobot2Context);
        }

        public async Task AddEquiposAsync(Equipos nuevoEquipo)
        {
            await equiposRepositorio.AddAsync(nuevoEquipo);
        }

        public async Task DeleteEquiposAsync(int id)
        {
            await equiposRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<Equipos>> GetAllEquiposAsync()
        {
            return await equiposRepositorio.GetAllAsync();
        }

        public Task<Equipos> GetbyIdEquiposAsync(int id)
        {
            return equiposRepositorio.GetbyIdAsync(id);
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
