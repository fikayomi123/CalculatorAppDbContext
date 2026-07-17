using CalculatorApp.Service.Implementations;
using CalculatorMigrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CalculatorAppDbContex>();
builder.Services.AddTransient<ICalculatorServices, CalculatorServices>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Generates the JSON document endpoint (defaults to /openapi/v1.json)
    app.MapOpenApi();

    // Enable Swagger UI and point it to the native JSON file
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "My API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
