using System;

namespace Ferreteria.Core.Entities;

public class SaleProduct
{
    public int IdSaleProduct { get; set; }
    public int IdSale { get; set; }
    public int IdProduct { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Subtotal { get; set; }
    public int? UpdateBy { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
    public virtual Sale? IdSaleNavigation { get; set; }
}