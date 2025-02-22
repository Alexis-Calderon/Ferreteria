using System;

namespace Ferreteria.Core.Entities;

public class Inventory
{
    public int IdInventory { get; set; }
    public int IdProduct { get; set; }
    public int CurrentStock { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual Product? ProductNavigation { get; set; }
}