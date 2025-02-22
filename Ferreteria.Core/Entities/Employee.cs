using System;
using System.Collections.Generic;

namespace Ferreteria.Core.Entities;

public class Employee
{
    public int IdEmployee { get; set; }
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string? JobPosition { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public DateTime? HiringDate { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = [];
    public virtual ICollection<Sale> Sales { get; set; } = [];
}