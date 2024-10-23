namespace OnionEcommerce.Application.Mappers;

public class CustomerMapper : IMapper<Customer, CustomerDTO>, IMapper<CustomerDTO, Customer>
{
    public CustomerDTO Map(Customer source)
    {
        return new CustomerDTO
        {
            FirstName = source.FirstName,
            LastName = source.LastName,
            Email = source.Email,
            BirthDate = source.BirthDate,
            Cpf = source.Cpf,
            Address = new AddressDTO
            {
                City = source.Address.City,
                Complement = source.Address.Complement,
                Number = source.Address.Number,
                PostalCode = source.Address.PostalCode,
                State = source.Address.State,
                Street = source.Address.Street,
            }
        };
    }

    public IEnumerable<CustomerDTO> Map(IEnumerable<Customer> source)
    {
        return source.Select(s => new CustomerDTO
        {
            BirthDate = s.BirthDate,
            Cpf = s.Cpf,
            Email = s.Email,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Address = new AddressDTO
            {
                City = s.Address.City,
                Complement = s.Address.Complement,
                Number = s.Address.Number,
                PostalCode = s.Address.PostalCode,
                State = s.Address.State,
                Street = s.Address.Street,
            }
        }).ToList();
    }

    public Customer Map(CustomerDTO source)
    {
        return new Customer
        {
            FirstName = source.FirstName,
            LastName = source.LastName,
            BirthDate = source.BirthDate,
            Cpf = source.Cpf,
            Email = source.Email,
            Address = new Address
            {
                City = source.Address.City,
                Complement = source.Address.Complement,
                Number = source.Address.Number,
                PostalCode = source.Address.PostalCode,
                State = source.Address.State,
                Street = source.Address.Street,
            }
        };
    }

    public IEnumerable<Customer> Map(IEnumerable<CustomerDTO> source)
    {
        return source.Select(s => new Customer
        {
            FirstName = s.FirstName,
            LastName = s.LastName,
            BirthDate = s.BirthDate,
            Cpf = s.Cpf,
            Email = s.Email,
            Address = new Address
            {
                City = s.Address.City,
                Complement = s.Address.Complement,
                Number = s.Address.Number,
                PostalCode = s.Address.PostalCode,
                State = s.Address.State,
                Street = s.Address.Street,
            }
        }).ToList();
    }
}
