using ApiTemplate.Modules.Customers.Core;
using ApiTemplate.Modules.Customers.Endpoints.V1.Create;
using ApiTemplate.Shared.Extensions;

namespace ApiTemplate.UnitTests.Modules.Customers.Endpoints.V1.Create;

public class MappingProfileTests
{
    private readonly IMapper _mapper;

    public MappingProfileTests()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        config.AssertConfigurationIsValid();
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void Mapper_ShouldMapRequestCorrectly()
    {
        var request = new Request
        {
            Uuid = Guid.NewGuid().ToString(),
            FirstName = "John",
            LastName = "Doe",
            EmailAddress = "john-doe@mail.com"
        };

        var mapped = _mapper.Map<Customer>(request);

        mapped.Should().NotBeNull();

        mapped.Uuid.Should().Be(request.Uuid);
        mapped.FirstName.Should().Be(request.FirstName);
        mapped.LastName.Should().Be(request.LastName);
        mapped.EmailAddress.Should().Be(request.EmailAddress);
    }
}
