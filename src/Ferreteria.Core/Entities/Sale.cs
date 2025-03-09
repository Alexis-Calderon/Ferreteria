using System;
using System.Collections.Generic;

namespace Ferreteria.Core.Entities;

public class Sale
{
    public int IdSale { get; set; }
    public int? IdClient { get; set; }
    public int? IdEmployee { get; set; }
    public decimal Total { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? PaymentMethod { get; set; }
    public int? UpdateBy { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public virtual Client? IdClientNavigation { get; set; }
    public virtual Employee? IdEmployeeNavigation { get; set; }
    public virtual ICollection<SaleProduct> SaleProducts { get; set; } = [];
}