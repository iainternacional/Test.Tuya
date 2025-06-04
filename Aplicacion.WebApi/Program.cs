var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddScoped<ProcessPresenter>();

app.MapGet("/", () => "Hello World!");

app.Run();
