var builder = WebApplication.CreateBuilder(args);

// Add services to the container. (Registration Operations fopr DI)
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("CatalogDbConnString")!);
}
).UseLightweightSessions();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();


app.Run();
