using System;

namespace Ferreteria.Core.Entities;

public class Inventory
{
    public int IdInventory { get; set; }
    public int IdProduct { get; set; }
    public int CurrentStock { get; set; }
    public int? UpdateBy { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}