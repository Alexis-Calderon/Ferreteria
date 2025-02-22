using System;
using System.Collections.Generic;

namespace Ferreteria.Core.Entities;

public class Purchase
{
    public int IdPurchase { get; set; }
    public int? IdSupplier { get; set; }
    public int? IdEmployee { get; set; }
    public int? Total { get; set; }
    public DateTime PurchaseDate { get; set; }

    public virtual Employee? IdEmployeeNavigation { get; set; }
    public virtual Supplier? IdSupplierNavigation { get; set; }
    public virtual ICollection<PurchaseProduct> PurchaseProducts { get; set; } = [];
}