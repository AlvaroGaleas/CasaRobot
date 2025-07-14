using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Aplicacion.DTO.DTOs
{
    public class HistorialTecnicoClienteDTO
    {
        public string Tecnico { get; set; }
        public List<string> Clientes { get; set; }
        public List<int> Ordenes { get; set; }
        public decimal CostoTotal { get; set; }
    }
}