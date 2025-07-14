using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Aplicacion.DTO.DTOs
{
    public class EstadoOrdenDetalleDTO
    {
        public string Estado { get; set; }
        public List<string> DescripcionesProblema { get; set; }
        public List<string> Clientes { get; set; }
        public List<string> Equipos { get; set; }
        public decimal CostoTotal { get; set; }
    }
}
