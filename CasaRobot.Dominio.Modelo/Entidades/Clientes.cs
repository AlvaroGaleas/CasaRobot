﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CasaRobot.Dominio.Modelo.Entidades;

public partial class Clientes
{
    public int ClienteID { get; set; }

    public string Nombre { get; set; }

    public string Correo { get; set; }

    public string Telefono { get; set; }

    public string Direccion { get; set; }

    public virtual ICollection<Equipos> Equipos { get; set; } = new List<Equipos>();

    public virtual ICollection<Notificaciones> Notificaciones { get; set; } = new List<Notificaciones>();
}