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
    public class ClientesRepositorioImpl : RepositorioImpl<Clientes>, IClientesRepositorio
    {
        private readonly CasaRobot2Context _dbContext;
        public ClientesRepositorioImpl(CasaRobot2Context context) : base(context)
        {
            _dbContext = context;
        }

        public Task<List<Clientes>> ListarClientes()
        {
            try
            {
                var resultado = from clie in _dbContext.Clientes
                                select clie;
                return resultado.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar clientes"+ex.Message);

            }
        }

        public Task<List<Clientes>> ListarClientesNombre(string nombre)
        {
            try
            {
                var resultado = from clie in _dbContext.Clientes
                                where clie.Nombre == nombre
                                select clie;
                return resultado.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar nombres"+ex.Message);

            }
        }
    }
}
