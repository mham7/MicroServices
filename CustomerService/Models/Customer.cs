using System;
using System.Collections.Generic;

namespace CustomerService.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;
    
    public string password { get; set; } = null!;

    public int? Phone { get; set; }

    public DateOnly? RegistrationDate { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
