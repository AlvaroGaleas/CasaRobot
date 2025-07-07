using CasaRobot.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Dominio.Modelo.Abstracciones
{
    public interface IClientesRepositorio :IRepositorio<Clientes>
    {
        public Task<List<Clientes>> ListarClientes();
        public Task<List<Clientes>> ListarClientesNombre(string nombre);
    }
}
