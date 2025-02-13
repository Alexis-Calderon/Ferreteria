using System;

namespace FerreteriaDominio.Entidades;

public class InventarioMovimiento
{
    public int IdInventarioMovimiento { get; set; }
    public int IdProducto { get; set; }
    public string TipoMovimiento { get; set; } = null!;
    public int Cantidad { get; set; }
    public DateTime FechaMovimiento { get; set; }
    public string? Referencia { get; set; }
}
