using System;
using System.Collections.Generic;

namespace CustomerService.Models;

public partial class Users
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;
    
    public string password { get; set; } = null!;

    public Boolean is_active { get; set; }=false;
    public DateOnly? RegistrationDate { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
