using System;

namespace FerreteriaDominio.Entidades;

public class CompraProducto
{
    public int IdCompraProducto { get; set; }
    public int IdCompra { get; set; }
    public int IdProducto { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }
    public decimal SubTotal { get; set; }
}