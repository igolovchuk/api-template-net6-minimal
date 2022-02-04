# Set base image for build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Copy project resources
COPY src/ApiTemplate.Customers.Api/ApiTemplate.Customers.Api.csproj src/ApiTemplate.Customers.Api/ApiTemplate.Customers.Api.csproj
RUN dotnet restore "src/ApiTemplate.Customers.Api/ApiTemplate.Customers.Api.csproj"
COPY src/ApiTemplate.Customers.Api src/ApiTemplate.Customers.Api

# Test steps
FROM build as test
COPY tests/ApiTemplate.Customers.UnitTests/ApiTemplate.Customers.UnitTests.csproj tests/ApiTemplate.Customers.UnitTests/ApiTemplate.Customers.UnitTests.csproj
RUN dotnet restore "tests/ApiTemplate.Customers.UnitTests/ApiTemplate.Customers.UnitTests.csproj"
COPY tests/ApiTemplate.Customers.UnitTests tests/ApiTemplate.Customers.UnitTests
ENTRYPOINT ["dotnet", "test", "tests/ApiTemplate.Customers.UnitTests/ApiTemplate.Customers.UnitTests.csproj"]

# Publishing the application
FROM build AS publish
RUN dotnet publish "src/ApiTemplate.Customers.Api/ApiTemplate.Customers.Api.csproj" -c Release -o /app/publish --no-restore

# Final image wrap-up
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "ApiTemplate.Customers.Api.dll" ]
