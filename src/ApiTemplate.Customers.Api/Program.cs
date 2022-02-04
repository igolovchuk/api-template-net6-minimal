var app = WebApplication.CreateBuilder(args)
    .ConfigureBuilder()
    .Build();

app.ConfigureApp();
app.Run();
