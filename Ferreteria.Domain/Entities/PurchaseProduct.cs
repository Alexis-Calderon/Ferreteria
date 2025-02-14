using System;

namespace Ferreteria.Domain.Entities;

public class PurchaseProduct
{
    public int IdPurchaseProduct { get; set; }
    public int IdPurchase { get; set; }
    public int IdProduct { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal { get; set; }
}