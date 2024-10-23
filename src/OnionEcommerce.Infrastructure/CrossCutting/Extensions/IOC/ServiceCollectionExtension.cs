namespace OnionEcommerce.Infrastructure.CrossCutting.Extensions.IOC;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddRavenDb(this IServiceCollection service)
    {
        service.TryAddSingleton<IDocumentStore>(ctx =>
        {
            var ravenDbSettings = ctx.GetRequiredService<IOptions<RavenDbSettings>>().Value;
            var store = new DocumentStore
            {
                Urls = new[] { ravenDbSettings.Url },
                Database = ravenDbSettings.DatabaseName,
            };

            store.Initialize();

            return store;
        });

        return service;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection service) 
    {
        service.TryAddSingleton<ICustomerRepository, CustomerRepository>();
        return service;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection service)
    {
        service.TryAddSingleton<ICustomerService, CustomerService>();
        return service;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection service)
    {
        service.TryAddSingleton<ICustomerApplicationService, CustomerApplicationService>();
        return service;
    }

    public static IServiceCollection AddMappers(this IServiceCollection service)
    {
        service.TryAddSingleton<IMapper<Customer, CustomerDTO>, CustomerMapper>();
        service.TryAddSingleton<IMapper<CustomerDTO, Customer>, CustomerMapper>();
        return service;
    }
}
