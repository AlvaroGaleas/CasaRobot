using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Aplicacion.ServiciosImpl;
using CasaRobot.Dominio.Modelo.Abstracciones;
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
        private IOrdenesServicioServicios _ordenesServicioServicio; 

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<CasaRobot2Context>()
                .UseSqlServer("Data Source=STEPHYR;Initial Catalog=CasaRobot2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;")
                .Options; 
            _dbContext = new CasaRobot2Context(options);
            _ordenesServicioServicio = new OrdenesServicioImpl (_dbContext);
        }

        [Test]
        /* public async Task InsertarClientes()
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
         //Consulta 4: 
         public async Task ProbarListarOrdenesPorEstadoComplejo()
         {
             var ordenes = await _ordenesServicioRepositorio.ListarOrdenesPorEstadoComplejo();

             foreach (var item in ordenes)
             {
                 Console.WriteLine($"Estado: {item.Estado}");
                 Console.WriteLine("Clientes:");
                 foreach (var cliente in item.Clientes)
                 {
                     Console.WriteLine($" - {cliente}");
                 }

                 Console.WriteLine("Equipos:");
                 foreach (var equipo in item.Equipos)
                 {
                     Console.WriteLine($" - {equipo}");
                 }

                 Console.WriteLine("Descripciones:");
                 foreach (var desc in item.DescripcionesProblema)
                 {
                     Console.WriteLine($" - {desc}");
                 }

                 Console.WriteLine($"Costo Total: {item.CostoTotal}");
                 Console.WriteLine("--------------------------------------");
             }
         }
        //Consulta 5: Listar historial técnico por cliente
        public async Task ListarHistorialTecnicoClienteTest()
        {
            var resultado = await _ordenesServicioServicio.ListarHistorialTecnicoCliente();

            foreach (var item in resultado)
            {
                Console.WriteLine($"Técnico: {item.Tecnico}");
                Console.WriteLine("Clientes:");
                foreach (var cliente in item.Clientes)
                {
                    Console.WriteLine($" - {cliente}");
                }
                Console.WriteLine("Órdenes:");
                foreach (var orden in item.Ordenes)
                {
                    Console.WriteLine($" - Orden ID: {orden}");
                }
                Console.WriteLine($"Costo Total: {item.CostoTotal}");
                Console.WriteLine("--------------------------------------");
            }

            Assert.IsNotEmpty(resultado);
        }*/
        //Consulta 6: Listar clientes por estado
        public async Task ListarClientesPorEstadoTest()
        {
            var resultado = await _ordenesServicioServicio.ListarClientesPorEstado();

            foreach (var item in resultado)
            {
                Console.WriteLine($"Estado: {item.NombreEstado}");
                Console.WriteLine("Clientes:");
                foreach (var cliente in item.NombresClientes)
                {
                    Console.WriteLine($" - {cliente}");
                }
                Console.WriteLine("-------------------------------");
            }

            Assert.IsNotEmpty(resultado);
        }



        [TearDown]
        public void Limpiar()
        {
            _dbContext.Dispose();
        }
    }
}
