using CasaRobot.Aplicacion.DTO.DTOs;
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
    public class OrdenesServicioRepositorioImpl : RepositorioImpl<OrdenesServicio>, IOrdenesServicioRepositorio
    {
        private readonly CasaRobot2Context _dbContext;
        public OrdenesServicioRepositorioImpl(CasaRobot2Context context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<EstadoOrdenDetalleDTO>> ListarOrdenesPorEstadoComplejo()
        {
            try
            {
                var datos = await (from orden in _dbContext.Set<OrdenesServicio>()
                                   join estado in _dbContext.Set<Estados>() on orden.EstadoID equals estado.EstadoID
                                   join equipo in _dbContext.Set<Equipos>() on orden.EquipoID equals equipo.EquipoID
                                   join cliente in _dbContext.Set<Clientes>() on equipo.ClienteID equals cliente.ClienteID
                                   join costo in _dbContext.Set<Costos>() on orden.OrdenID equals costo.OrdenID into costosJoin
                                   from costo in costosJoin.DefaultIfEmpty()
                                   select new
                                   {
                                       Estado = estado.NombreEstado,
                                       DescripcionProblema = orden.DescripcionProblema,
                                       ClienteNombre = cliente.Nombre,
                                       EquipoNombre = $"{equipo.Marca} {equipo.Modelo}",
                                       Monto = costo != null ? (costo.Monto ?? 0) : 0
                                   }).ToListAsync();

                var resultado = datos
                    .GroupBy(x => x.Estado)
                    .Select(g => new EstadoOrdenDetalleDTO
                    {
                        Estado = g.Key,
                        DescripcionesProblema = g.Select(x => x.DescripcionProblema ?? "").Distinct().ToList(),
                        Clientes = g.Select(x => x.ClienteNombre).Distinct().ToList(),
                        Equipos = g.Select(x => x.EquipoNombre).Distinct().ToList(),
                        CostoTotal = g.Sum(x => x.Monto)
                    })
                    .ToList();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar órdenes complejas: " + ex.Message);
            }
        }
        public async Task<List<HistorialTecnicoClienteDTO>> ListarHistorialTecnicoCliente()
        {
            try
            {
                var datos = await (from hs in _dbContext.Set<HistorialServicios>()
                                   join os in _dbContext.Set<OrdenesServicio>() on hs.OrdenID equals os.OrdenID
                                   join emp in _dbContext.Set<Empleados>() on hs.EmpleadoID equals emp.EmpleadoID
                                   join eq in _dbContext.Set<Equipos>() on os.EquipoID equals eq.EquipoID
                                   join cli in _dbContext.Set<Clientes>() on eq.ClienteID equals cli.ClienteID
                                   join costo in _dbContext.Set<Costos>() on os.OrdenID equals costo.OrdenID into costosJoin
                                   from costo in costosJoin.DefaultIfEmpty()
                                   select new
                                   {
                                       Tecnico = emp.Nombre,
                                       Cliente = cli.Nombre,
                                       OrdenID = os.OrdenID,
                                       Costo = costo != null ? (costo.Monto ?? 0) : 0
                                   }).ToListAsync();

                var resultado = datos
                    .GroupBy(x => x.Tecnico)
                    .Select(g => new HistorialTecnicoClienteDTO
                    {
                        Tecnico = g.Key,
                        Clientes = g.Select(x => x.Cliente).Distinct().ToList(),
                        Ordenes = g.Select(x => x.OrdenID).Distinct().ToList(),
                        CostoTotal = g.Sum(x => x.Costo)
                    })
                    .ToList();

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar historial " + ex.Message);
            }
        }

        public async Task<List<EstadoClientesDTO>> ListarClientesPorEstado()
        {
            try
            {
                var resultado = (from orden in _dbContext.OrdenesServicio
                                 join estado in _dbContext.Estados
                                    on orden.EstadoID equals estado.EstadoID
                                 join equipo in _dbContext.Equipos
                                    on orden.EquipoID equals equipo.EquipoID
                                 join cliente in _dbContext.Clientes
                                    on equipo.ClienteID equals cliente.ClienteID
                                 group cliente by estado.NombreEstado into grupo
                                 select new EstadoClientesDTO
                                 {
                                     NombreEstado = grupo.Key,
                                     NombresClientes = grupo.Select(c => c.Nombre).Distinct().ToList()
                                 }).ToListAsync();

                return await resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar clientes por estado: " + ex.Message);
            }
        }

    }
}
