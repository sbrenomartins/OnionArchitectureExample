namespace OnionEcommerce.Domain.Core.Interfaces.Services;

public interface ICustomerService
{
    void Create(Customer customer);
    IEnumerable<Customer> Read();
    Customer Read(string id);
    void Update(Customer customer);
    void Delete(string id);
}
