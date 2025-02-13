using System;

namespace FerreteriaDominio.Entidades;

public class Proveedor
{
    public int IdProveedor { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Contacto { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public string? Direccion { get; set; }
}
