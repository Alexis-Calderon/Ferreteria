using System;

namespace Ferreteria.Domain.Entities;

public class InventoryMovement
{
    public int IdInventoryMovement { get; set; }
    public int IdProduct { get; set; }
    public string MovementType { get; set; } = null!;
    public int Quantity { get; set; }
    public DateTime MovementDate { get; set; }
    public string? Reference { get; set; }
}