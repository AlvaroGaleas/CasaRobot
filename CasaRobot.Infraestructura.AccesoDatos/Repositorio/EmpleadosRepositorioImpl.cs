using CasaRobot.Dominio.Modelo.Abstracciones;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Infraestructura.AccesoDatos.Repositorio
{
    public class EmpleadosRepositorioImpl : RepositorioImpl<Empleados>, IEmpleadosRepositorio
    {
        private readonly CasaRobot2Context _dbContext;
        public EmpleadosRepositorioImpl(CasaRobot2Context context) : base(context)
        {
            _dbContext = context;
        }

        public Task<List<Empleados>> ListarEmpleados()
        {
            try
            {
                var resultado = from emplea in _dbContext.Empleados
                                select emplea;
                return resultado.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar empleados"+ex.Message);

            }
        }

        public Task<List<Empleados>> ListarEmpleadosNombre(string nombre)
        {
            try
            {
                var resultado = from emplea in _dbContext.Empleados
                                where emplea.Nombre == nombre
                                select emplea;
                return resultado.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar nombres"+ex.Message);

            }
        }
    }
}
