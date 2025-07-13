using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Aplicacion.ServiciosImpl;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

namespace TestCasaRobot1
{
    public class Tests
    {
        private CasaRobot2Context _dbContext;
        private IClientesServicio _clientesServicio; 

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<CasaRobot2Context>()
                .UseSqlServer("Data Source=DESKTOP-JDC5GN6;Initial Catalog=CasaRobot2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;")
                .Options; 
            _dbContext = new CasaRobot2Context(options);
            _clientesServicio = new ClientesServicioImpl(_dbContext);
        }

        [Test]
        public async Task InsertarClientes()
        {
            var cliente = new Clientes() 
            { 
                Nombre = "Alvaro", 
                Correo = "alvaro@gmail.com", 
                Telefono = "0987987498", 
                Direccion = "Cayambe" 
            };
            await _clientesServicio.AddClienteAsync(cliente);
            Assert.Pass();
        }

        // Consulta 1 simple: Clientes → Equipos → OrdenesServicio
        [Test]
        public async Task Consulta1_EquiposConOrdenes()
        {
            var resultado = await (
                from c in _dbContext.Clientes
                join e in _dbContext.Equipos
                    on c.ClienteID equals e.ClienteID
                join os in _dbContext.OrdenesServicio
                    on e.EquipoID equals os.EquipoID
                select new
                {
                    c.ClienteID,
                    Cliente = c.Nombre,
                    e.EquipoID,
                    Equipo = e.Marca + " " + e.Modelo,
                    os.OrdenID,
                    os.FechaIngreso
                }
            ).ToListAsync();

            Assert.IsNotEmpty(resultado);
        }

        // Consulta 2 corregida: OrdenesServicio → HistorialServicios → Empleados
        [Test]
        public async Task Consulta2_HistorialTecnicoSimple()
        {
            var resultado = await (
                from os in _dbContext.OrdenesServicio
                join hs in _dbContext.HistorialServicios
                    on os.OrdenID equals hs.OrdenID
                join emp in _dbContext.Empleados
                    on hs.EmpleadoID equals emp.EmpleadoID
                select new
                {
                    os.OrdenID,
                    DescripcionTrabajo = hs.DescripcionTrabajo,
                    Tecnico = emp.Nombre,
                    FechaIngreso = os.FechaIngreso
                }
            ).ToListAsync();

            Assert.IsNotEmpty(resultado);
        }

        // Consulta 3: Órdenes por cliente y equipo (3 entidades)
        [Test]
        public async Task Consulta3_OrdenesPorClienteEquipo()
        {
            var resultado = await (
                from c in _dbContext.Clientes
                join e in _dbContext.Equipos
                    on c.ClienteID equals e.ClienteID
                join os in _dbContext.OrdenesServicio
                    on e.EquipoID equals os.EquipoID
                select new
                {
                    c.ClienteID,
                    Cliente = c.Nombre,
                    e.EquipoID,
                    os.OrdenID,
                    os.FechaIngreso
                }
            ).ToListAsync();

            Assert.IsNotEmpty(resultado);
        }

        [TearDown]
        public void Limpiar()
        {
            _dbContext.Dispose();
        }
    }
}
