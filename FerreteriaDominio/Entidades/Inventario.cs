using System;

namespace FerreteriaDominio.Entidades;

public class Inventario
{
    public int IdInventario { get; set; }
    public int IdProducto { get; set; }
    public int StockActual { get; set; }
    public DateTime? UltimaActualizacion { get; set; }
}
