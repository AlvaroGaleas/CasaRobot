using CasaRobot.Dominio.Modelo.Abstracciones;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CasaRobot.Infraestructura.AccesoDatos.Repositorio
{
    public class EquiposRepositorioImpl : RepositorioImpl<Equipos>, IEquiposRepositorio
    {
        private CasaRobot2Context _dbContext;

        public EquiposRepositorioImpl(CasaRobot2Context context) : base(context)
        {
            _dbContext = context;
        }

        public Task<List<Equipos>> ListarEquiposModelo(string modelo)
        {
            try
            {
                var resultado = from equip in _dbContext.Equipos
                                where equip.Modelo == modelo
                                select equip;
                return resultado.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar modelos");

            }
        }
    }
}
