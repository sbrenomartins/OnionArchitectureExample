namespace OnionEcommerce.Domain.Models;

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string Cpf { get; set; }
    public Address Address { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
}
