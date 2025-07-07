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
    public class ClientesServicioImpl :IClientesServicio
    {
        private IClientesRepositorio clientesRepositorio;
        public ClientesServicioImpl(CasaRobot2Context _casarobot2Context)
        {
            this.clientesRepositorio = new ClientesRepositorioImpl(_casarobot2Context);
        }

        public async Task AddClienteAsync(Clientes nuevoCliente)
        {
            await clientesRepositorio.AddAsync(nuevoCliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
           await clientesRepositorio.DeleteAsync(id);
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
