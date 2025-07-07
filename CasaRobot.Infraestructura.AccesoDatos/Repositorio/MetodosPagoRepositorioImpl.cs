using CasaRobot.Dominio.Modelo.Abstracciones;
using CasaRobot.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Infraestructura.AccesoDatos.Repositorio
{
    public class MetodosPagoRepositorioImpl : RepositorioImpl<MetodosPago>, IMetodosPagoRepositorio
    {
        public MetodosPagoRepositorioImpl(CasaRobot2Context context) : base(context)
        {
        }
    }
}
