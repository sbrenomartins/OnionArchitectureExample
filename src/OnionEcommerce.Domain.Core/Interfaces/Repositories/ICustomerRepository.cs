namespace OnionEcommerce.Domain.Core.Interfaces.Repositories;

public interface ICustomerRepository
{
    void Create(Customer customer);
    IEnumerable<Customer> Read();
    Customer Read(string Id);
    Customer? FindByEmail(string Email);
    void Update(Customer customer);
    void Delete(string Id);
}
