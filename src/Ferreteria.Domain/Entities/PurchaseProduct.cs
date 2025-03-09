using System;

namespace Ferreteria.Core.Entities;

public class PurchaseProduct
{
    public int IdPurchaseProduct { get; set; }
    public int IdPurchase { get; set; }
    public int IdProduct { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal { get; set; }
    public int? UpdateBy { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
    public virtual Purchase? IdPurchaseNavigation { get; set; }
}