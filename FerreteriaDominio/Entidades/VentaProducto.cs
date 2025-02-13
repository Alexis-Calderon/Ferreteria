using System;

namespace FerreteriaDominio.Entidades;

public class VentaProducto
{
    public int IdVentaProducto { get; set; }
    public int IdVenta { get; set; }
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal SubTotal { get; set; }
}