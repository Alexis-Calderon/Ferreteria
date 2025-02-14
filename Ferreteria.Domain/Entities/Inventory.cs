using System;

namespace Ferreteria.Domain.Entities;

public class Inventory
{
    public int IdInventory { get; set; }
    public int IdProduct { get; set; }
    public int CurrentStock { get; set; }
    public DateTime? UpdatedAt { get; set; }
}