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
    public class EmpleadosServicioImpl: IEmpleadosServicio
    {
        private IEmpleadosRepositorio empleadosRepositorio;
        private readonly CasaRobot2Context _dbcontext;
        public EmpleadosServicioImpl(CasaRobot2Context _casarobot2Context)
        {
            _dbcontext = _casarobot2Context;
            this.empleadosRepositorio = new EmpleadosRepositorioImpl(_casarobot2Context);
        }

        public async Task AddEmpleadosAsync(Empleados nuevoCosto)
        {
            await empleadosRepositorio.AddAsync(nuevoCosto);
        }

        public async Task DeleteEmpleadosAsync(int id)
        {
            await empleadosRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<Empleados>> GetAllEmpleadosAsync()
        {
            return await empleadosRepositorio.GetAllAsync();
        }

        public Task<Empleados> GetbyIdEmpleadosAsync(int id)
        {
            return empleadosRepositorio.GetbyIdAsync(id);
        }

        public Task UpdateEmpleadosAsync(Empleados entidad)
        {
            return empleadosRepositorio.UpdateAsync(entidad);
        }

        public Task<List<Empleados>> ListarEmpleadosNombre(string nombre)
        {
            return empleadosRepositorio.ListarEmpleadosNombre(nombre);
        }

        public Task<List<Empleados>> ListarEmpleados()
        {
            return empleadosRepositorio.ListarEmpleados();
        }
    }
}
