using ApiTemplate.Modules.Customers.Endpoints.V1.Create;

namespace ApiTemplate.UnitTests.Modules.Customers.Endpoints.V1.Create;

public class ValidatorTests
{
    private readonly Validator _validator;

    public ValidatorTests() =>
        _validator = new Validator();

    [Fact]
    public async Task Validate_ModelIsValid_ReturnsNoErrors()
    {
        var model = new Request
        {
            Uuid = Guid.NewGuid().ToString(),
            FirstName = "John",
            LastName = "Doe",
            EmailAddress = "john-doe@mail.com"
        };

        var validationResult = await _validator.ValidateAsync(model);
        validationResult.Errors.Should().BeEmpty();
    }

    [Fact]
    public async Task Validate_ModelIsNotValid_ReturnsErrors()
    {
        var validationResult = await _validator.ValidateAsync(new Request());
        validationResult.Errors.Any().Should().BeTrue();
    }
}
