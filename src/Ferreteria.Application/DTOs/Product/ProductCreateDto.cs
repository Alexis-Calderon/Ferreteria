using System;

namespace Ferreteria.Application.DTOs.Product;

public class ProductCreateDto
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? CategoryName { get; set; }
    public string? Brand { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? MeasurementUnit { get; set; }
    public string? SupplierRut { get; set; }
}