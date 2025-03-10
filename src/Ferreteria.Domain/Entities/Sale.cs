namespace Ferreteria.Domain.Entities;

public class Sale
{
    public int Id { get; set; }
    public string? ClientRut { get; set; }
    public int? EmployeeId { get; set; }
    public decimal Total { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? PaymentMethod { get; set; }
    public string? UpdateBy { get; set; }
    public DateTime? UpdateAt { get; set; }
    public DateTime? CreatedAt { get; set; }
    public bool? IsDeleted { get; set; }

    public virtual Client? ClientRutNavigation { get; set; }
    public virtual Employee? EmployeeIdNavigation { get; set; }
    public virtual ICollection<SaleProduct> SaleProducts { get; set; } = [];
}