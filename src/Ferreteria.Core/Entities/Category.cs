using System;
using System.Collections.Generic;

namespace Ferreteria.Core.Entities;

public class Category
{
    public int IdCategory { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? UpdateBy { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public virtual ICollection<Product> Products { get; set; } = [];
}