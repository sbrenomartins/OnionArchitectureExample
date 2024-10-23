namespace OnionEcommerce.Application.Interfaces;

public interface ICustomerApplicationService
{
    void Create(CustomerDTO customerDTO);
    IEnumerable<CustomerDTO> Read();
    CustomerDTO Read(string id);
    void Update(CustomerDTO customerDTO);
    void Delete(string id);
}
