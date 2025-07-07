using CasaRobot.Aplicacion.Servicios;
using CasaRobot.Aplicacion.ServiciosImpl;
using CasaRobot.Dominio.Modelo.Entidades;
using Microsoft.EntityFrameworkCore;

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
                .UseSqlServer("Data Source=DESKTOP-JDC5GN6;Initial Catalog=CasaRobot2;Integrated Security=True;Encrypt=True; TrustServerCertificate= True;")
                .Options; 
            _dbContext = new CasaRobot2Context(options);
            _clientesServicio = new ClientesServicioImpl(_dbContext);
        }

        [Test]
        public async Task InsertarClientes()
        {
            var cliente = new Clientes() { Nombre = "Alvaro", Correo = "alvaro@gmail.com", Telefono = "0987987498", Direccion = "Cayambe"};
            await _clientesServicio.AddClienteAsync(cliente);
            Assert.Pass();
        }
        [TearDown]
        public void Limpiar()
        {
            _dbContext.Dispose();
        }
    }
}