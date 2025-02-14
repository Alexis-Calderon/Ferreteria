using System;

namespace Ferreteria.Domain.Entities;

public class Product
{
    public int IdProduct { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string? Brand { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? MeasurementUnit { get; set; }
    public int? IdSupplier { get; set; }
    public DateTime CreatedAt { get; set; }
}
