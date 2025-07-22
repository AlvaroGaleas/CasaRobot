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
    public class MetodosPagoRepositorioImpl : RepositorioImpl<MetodosPago>, IMetodosPagoRepositorio
    {
        private CasaRobot2Context _dbContext;
        public MetodosPagoRepositorioImpl(CasaRobot2Context context) : base(context)
        {
            _dbContext = context;
        }

        public Task<List<MetodosPago>> ListarMetodosPago()
        {
            try
            {
                var resultado = from metod in _dbContext.MetodosPago
                                select metod;
                return resultado.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar metodos" + ex.Message);

            }
        }
    }
}
