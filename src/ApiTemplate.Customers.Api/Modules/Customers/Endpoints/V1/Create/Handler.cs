using AutoMapper;
using ApiTemplate.Modules.Customers.Core;
using ApiTemplate.Modules.Customers.Repositories;

namespace ApiTemplate.Modules.Customers.Endpoints.V1.Create;

public class Handler
{
    public static async Task<IResult> Handle(Request request, IValidatorService validator, IMapper mapper,
        ICustomerRepository repository, CancellationToken cancellation)
    {
        await validator.ValidateAsync(request, cancellation);

        await repository.AddAsync(mapper.Map<Customer>(request), cancellation);

        return Results.Created($"/customers/{request.Uuid}", null);
    }
}
