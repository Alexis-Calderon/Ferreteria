using System;

namespace FerreteriaDominio.Entidades;

public class Empleado
{
    public int IdEmpleado { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Apellido { get; set; }
    public string? Cargo { get; set; }
    public string? Telefono { get; set; }
    public string? Email { get; set; }
    public DateTime? FechaContratacion { get; set; }
}