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
    public class EstadosRepositorioImpl : RepositorioImpl<Estados>, IEstadosRepositorio
    {
        private CasaRobot2Context _dbContext;
        public EstadosRepositorioImpl(CasaRobot2Context context) : base(context)
        {
            _dbContext = context;
        }
        public Task<List<Estados>> ListarEstadosNombre(string nombre)
        {
            try
            {
                var resultado = from estad in _dbContext.Estados
                                where estad.NombreEstado == nombre
                                select estad;
                return resultado.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar estados" + ex.Message);

            }
        }
        public Task<List<Estados>> ListarEstados()
        {
            try
            {
                var resultado = from estad in _dbContext.Estados
                                select estad;
                return resultado.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar equipos" + ex.Message);

            }
        }

    }
}
