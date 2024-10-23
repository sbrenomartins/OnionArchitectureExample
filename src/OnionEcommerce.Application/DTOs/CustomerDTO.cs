namespace OnionEcommerce.Application.DTOs;

public class CustomerDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string Cpf { get; set; }
    public AddressDTO Address { get; set; }
}
