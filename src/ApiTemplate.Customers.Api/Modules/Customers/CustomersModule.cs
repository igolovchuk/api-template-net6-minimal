using ApiTemplate.Modules.Customers.Repositories;
using V1 = ApiTemplate.Modules.Customers.Endpoints.V1;

namespace ApiTemplate.Modules;

public class CustomersModule : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/v1/customers/{uuid:required}", V1.GetById.Handler.Handle);
        endpoints.MapPost("/v1/customers", V1.Create.Handler.Handle);

        return endpoints;
    }

    public IServiceCollection RegisterDependencies(IServiceCollection services)
    {
        services.AddSingleton<ICustomerRepository, CustomerRepository>();
        return services;
    }
}