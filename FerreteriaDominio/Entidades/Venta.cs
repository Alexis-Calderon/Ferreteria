using System;

namespace FerreteriaDominio.Entidades;

public class Venta
{
    public int IdVenta { get; set; }
    public int? IdCliente { get; set; }
    public int? IdEmpleado { get; set; }
    public decimal Total { get; set; }
    public DateTime? FechaVenta { get; set; }
    public DateTime? FechaPago { get; set; }
    public string? MetodoPago { get; set; }
}