using System;

namespace Ferreteria.Domain.Entities;

public class SaleProduct
{
    public int IdSaleProduct { get; set; }
    public int IdSale { get; set; }
    public int IdProduct { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal { get; set; }
}