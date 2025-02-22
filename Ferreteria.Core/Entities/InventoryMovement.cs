using System;

namespace Ferreteria.Core.Entities;

public class InventoryMovement
{
    public int IdInventoryMovement { get; set; }
    public int IdProduct { get; set; }
    public string MovementType { get; set; } = null!;
    public int Quantity { get; set; }
    public DateTime MovementDate { get; set; }
    public string? Reference { get; set; }
    public virtual Product? ProductNavigation { get; set; }
}