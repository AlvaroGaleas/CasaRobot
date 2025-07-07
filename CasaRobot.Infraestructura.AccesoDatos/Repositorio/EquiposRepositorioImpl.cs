using CasaRobot.Dominio.Modelo.Abstracciones;
using CasaRobot.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Infraestructura.AccesoDatos.Repositorio
{
    public class EquiposRepositorioImpl : RepositorioImpl<Equipos>, IEquiposRepositorio
    {
        public EquiposRepositorioImpl(CasaRobot2Context context) : base(context)
        {
        }
    }
}
