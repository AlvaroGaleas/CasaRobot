﻿using CasaRobot.Dominio.Modelo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaRobot.Dominio.Modelo.Abstracciones
{
    public interface IEquiposRepositorio : IRepositorio<Equipos>
    {
        Task<List<Equipos>> ListarEquiposModelo(string modelo);
        Task<List<Equipos>> ListarEquipos();
    }
}
