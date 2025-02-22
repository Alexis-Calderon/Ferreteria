using System;
using System.Collections.Generic;

namespace Ferreteria.Core.Entities;

public class Client
{
    public int IdClient { get; set; }
    public string FirstName { get; set; } = null!;
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = [];
}