﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CasaRobot.Dominio.Modelo.Entidades;

public partial class MetodosPago
{
    public int PagoID { get; set; }

    public int? OrdenID { get; set; }

    public string Metodo { get; set; }

    public DateTime? FechaPago { get; set; }

    public decimal? Monto { get; set; }

    public virtual OrdenesServicio Orden { get; set; }
}