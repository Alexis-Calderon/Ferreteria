using System;

namespace FerreteriaDominio.Entidades;

public class Producto
{
    public int IdProducto { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public string? Categoria { get; set; }
    public string? Marca { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public string? UnidadMedida { get; set; }
    public int? IdProveedor { get; set; }
    public DateTime FechaIngreso { get; set; }
}