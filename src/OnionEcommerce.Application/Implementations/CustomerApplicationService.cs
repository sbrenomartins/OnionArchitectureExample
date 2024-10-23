
namespace OnionEcommerce.Application.Implementations;

public class CustomerApplicationService : ICustomerApplicationService
{
    private readonly ICustomerService _customerService;
    private readonly IMapper<CustomerDTO, Customer> _mapperEntity;
    private readonly IMapper<Customer, CustomerDTO> _mapperDto;

    public CustomerApplicationService(ICustomerService customerService, 
                                      IMapper<CustomerDTO, Customer> mapperEntity, 
                                      IMapper<Customer, CustomerDTO> mapperDto)
    {
        _customerService = customerService;
        _mapperEntity = mapperEntity;
        _mapperDto = mapperDto;
    }

    public void Create(CustomerDTO customerDTO)
    {
        var customerEntity = _mapperEntity.Map(customerDTO);
        _customerService.Create(customerEntity);
    }

    public IEnumerable<CustomerDTO> Read()
    {
        var customers = _customerService.Read();
        return _mapperDto.Map(customers);
    }

    public CustomerDTO Read(string id)
    {
        var customer = _customerService.Read(id);
        return _mapperDto.Map(customer);
    }

    public void Update(CustomerDTO customerDTO)
    {
        var customerEntity = _mapperEntity.Map(customerDTO);
        _customerService.Update(customerEntity);
    }

    public void Delete(string id)
    {
        _customerService.Delete(id);
    }
}
