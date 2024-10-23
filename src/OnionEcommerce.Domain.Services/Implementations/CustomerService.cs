
namespace OnionEcommerce.Domain.Services.Implementations;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void Create(Customer customer)
    {
        try
        {
            ValidateEmail(customer.Email);

            customer.IsActive = true;
            customer.CreatedOn = DateTime.Now;
            customer.Address.IsActive = true;
            customer.Address.CreatedOn = DateTime.Now;

            _customerRepository.Create(customer);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public IEnumerable<Customer> Read()
    {
        try
        {
            return _customerRepository.Read();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Customer Read(string id)
    {
        try
        {
            return _customerRepository.Read(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(Customer customer)
    {
        try
        {
            _customerRepository.Update(customer);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Delete(string id)
    {
        try
        {
            _customerRepository.Delete(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void ValidateEmail(string email)
    {
        if (!IsEmailValid(email))
            throw new InvalidEmailException(email);

        var customer = _customerRepository.FindByEmail(email);

        if (customer is not null)
            throw new DuplicatedEmailException(email);
    }

    private bool IsEmailValid(string email)
    {
        if (string.IsNullOrEmpty(email)) return false;

        try
        {
            var emailAddress = new MailAddress(email);

            if (emailAddress.Address != email) return false;

            return CheckDomain(emailAddress.Host);
        }
        catch (Exception)
        {
            return false;
        }
    }

    private bool CheckDomain(string domain)
    {
        try
        {
            var lookup = new LookupClient();
            var result = lookup.Query(domain, QueryType.MX);

            return result.Answers.MxRecords().Any();
        }
        catch (Exception)
        {
            return false;
        }
    }
}
