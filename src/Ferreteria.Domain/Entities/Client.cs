using System;
using System.Collections.Generic;

namespace Ferreteria.Domain.Entities;

public class Client
{
    public string Rut { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? UpdateBy { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsDeleted { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = [];
}