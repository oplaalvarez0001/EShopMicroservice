


var builder = WebApplication.CreateBuilder(args);
var assesmbly = typeof(Program).Assembly;

// Add services to the container. (Registration Operations fopr DI)

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assesmbly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assesmbly);

builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("CatalogDbConnString")!);
}
).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

app.UseExceptionHandler(options => { });


app.Run();
