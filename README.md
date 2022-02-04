# Api Template Minimal API .Net6

.net6 template for mimnimal API

# Build and Run 

### docker-compose

```
docker-compose up --build
```

### docker

```
docker build  -t api-minimal:dev .  
docker run -d -p 8080:80 --name myapp api-minimal:dev
```

### postman collection location
```
/docs/ApiTemplate.Customers.Api.postman_collection
```

## 3rd party Dependencies

- [FluentValidation](https://fluentvalidation.net)
- [AutoMapper](https://automapper.org)
- [Serilog](https://serilog.net)
- [FluentAssertions](https://fluentassertions.com)
- [Xunit](https://xunit.net)
- [Coverlet](https://dotnetfoundation.org/projects/coverlet)