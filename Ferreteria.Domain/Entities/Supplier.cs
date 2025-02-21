using System;

namespace Ferreteria.Domain.Entities;

public class Supplier
{
    public int IdSupplier { get; set; }
    public string Name { get; set; } = null!;
    public string? Contact { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}