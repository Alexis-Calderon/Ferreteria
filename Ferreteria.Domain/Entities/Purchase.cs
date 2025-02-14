using System;

namespace Ferreteria.Domain.Entities;

public class Purchase
{
    public int IdPurchase { get; set; }
    public int? IdSupplier { get; set; }
    public int? IdEmployee { get; set; }
    public int? Total { get; set; }
    public DateTime PurchaseDate { get; set; }
}