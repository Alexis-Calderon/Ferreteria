using System;

namespace Ferreteria.Domain.Entities;

public class Sale
{
    public int IdSale { get; set; }
    public int? IdClient { get; set; }
    public int? IdEmployee { get; set; }
    public decimal Total { get; set; }
    public DateTime? SaleDate { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? PaymentMethod { get; set; }
}