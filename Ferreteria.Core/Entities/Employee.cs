using System;
using System.Collections.Generic;

namespace Ferreteria.Core.Entities;

public class Employee
{
    public int IdEmployee { get; set; }
    public int IdUser { get; set; }
    public string? JobPosition { get; set; }
    public string? Phone { get; set; }
    public DateTime? HiringDate { get; set; }
    public int? UpdateBy { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
    public virtual ICollection<Purchase> Purchases { get; set; } = [];
    public virtual ICollection<Sale> Sales { get; set; } = [];
}