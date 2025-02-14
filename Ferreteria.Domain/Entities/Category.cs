using System;

namespace Ferreteria.Domain.Entities;

public class Category
{
    public int IdCategory { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
