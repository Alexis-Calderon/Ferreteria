using System;

namespace Ferreteria.Core.Entities;

public class User
{
    public int IdUser { get; set; }
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public int? UpdateBy { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Employee? IdEmployeeNavigation { get; set; }
}
