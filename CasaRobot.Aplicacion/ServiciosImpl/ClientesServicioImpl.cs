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
    public class ClientesServicioImpl :IClientesServicio
    {
        private IClientesRepositorio clientesRepositorio;
        private readonly CasaRobot2Context _dbcontext;
        public ClientesServicioImpl(CasaRobot2Context _casarobot2Context)
        {
            _dbcontext = _casarobot2Context;
            clientesRepositorio = new ClientesRepositorioImpl(_dbcontext);
        }

        public async Task AddClienteAsync(Clientes nuevoCliente)
        {
            await clientesRepositorio.AddAsync(nuevoCliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _dbcontext.Clientes.FindAsync(id);
            if (cliente == null)
                throw new KeyNotFoundException("Cliente no encontrado.");

            _dbcontext.Clientes.Remove(cliente);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Clientes>> GetAllClienteAsync()
        {
            return await clientesRepositorio.GetAllAsync();
        }

        public Task<Clientes> GetbyIdClienteAsync(int id)
        {
            return clientesRepositorio.GetbyIdAsync(id);
        }

        public Task<List<Clientes>> ListarClientes()
        {
            return clientesRepositorio.ListarClientes();
        }

        public Task<List<Clientes>> ListarClientesNombre(string nombre)
        {
            return clientesRepositorio.ListarClientesNombre(nombre);
        }

        public async Task UpdateClienteAsync(Clientes entidad)
        {
            await clientesRepositorio.UpdateAsync(entidad);
        }
    }
}
