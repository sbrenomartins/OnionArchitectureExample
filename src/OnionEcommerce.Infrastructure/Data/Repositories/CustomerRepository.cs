namespace OnionEcommerce.Infrastructure.Data.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IDocumentStore _documentStore;

    public CustomerRepository(IDocumentStore documentStore)
    {
        _documentStore = documentStore;
    }

    public void Create(Customer customer)
    {
        using IDocumentSession documentSession = _documentStore.OpenSession();
        documentSession.Store(customer);
        documentSession.SaveChanges();
    }

    public IEnumerable<Customer> Read()
    {
        using IDocumentSession documentSession = _documentStore.OpenSession();
        return documentSession.Query<Customer>().ToList();
    }

    public Customer Read(string Id)
    {
        using IDocumentSession documentSession = _documentStore.OpenSession();
        var customer = documentSession.Load<Customer>(Id);
        return customer;
    }

    public Customer? FindByEmail(string Email)
    {
        using IDocumentSession documentSession = _documentStore.OpenSession();
        var customer = documentSession.Query<Customer>().FirstOrDefault(c => c.Email == Email);
        return customer;
    }

    public void Update(Customer customer)
    {
        using IDocumentSession documentSession = _documentStore.OpenSession();
        var customerEntity = documentSession.Query<Customer>()
                                            .FirstOrDefault(c => c.FirstName == customer.FirstName);

        if (customerEntity is not null)
        {
            customerEntity.FirstName = customer.FirstName;
            customerEntity.LastName = customer.LastName;
            customerEntity.Email = customer.Email;
            customerEntity.Address = customer.Address;
            customerEntity.Cpf = customer.Cpf;
            customerEntity.BirthDate = customer.BirthDate;
            customerEntity.IsActive = customer.IsActive;
        }

        documentSession.SaveChanges();
    }

    public void Delete(string Id)
    {
        using IDocumentSession documentSession = _documentStore.OpenSession();
        var customer = documentSession.Load<Customer>(Id);

        if (customer is not null)
        {
            documentSession.Delete(customer);
            documentSession.SaveChanges();
        }
    }
}
