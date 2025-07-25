﻿using CasaRobot.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Dominio.Modelo.Abstracciones
{
    public interface IEstadosRepositorio: IRepositorio<Estados>
    {
        Task<List<Estados>> ListarEstadosNombre(string nombre);
        Task<List<Estados>> ListarEstados();
    }
}
