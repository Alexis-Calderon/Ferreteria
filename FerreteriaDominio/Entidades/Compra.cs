using System;

namespace FerreteriaDominio.Entidades;

public class Compra
{
    public int IdCompra { get; set; }
    public int? IdProveedor { get; set; }
    public int? IdEmpleado { get; set; }
    public int? Total { get; set; }
    public DateTime FechaCompra { get; set; }
}
