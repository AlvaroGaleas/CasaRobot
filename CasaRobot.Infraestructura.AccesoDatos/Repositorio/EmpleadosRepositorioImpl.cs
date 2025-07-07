using CasaRobot.Dominio.Modelo.Abstracciones;
using CasaRobot.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Infraestructura.AccesoDatos.Repositorio
{
    public class EmpleadosRepositorioImpl : RepositorioImpl<Empleados>, IEmpleadosRepositorio
    {
        public EmpleadosRepositorioImpl(CasaRobot2Context context) : base(context)
        {
        }
    }
}
