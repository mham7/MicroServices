using InventoryService.Data;
using InventoryService.EventConsumer;
using InventoryService.Interfaces;
using InventoryService.NewFolder;
using InventoryService.Persistance.Repository;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<IIventoryRepository,InventoryRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<InventoryDbContext>();
builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.AddConsumer<ProductCreatedConsumer>();
    busConfigurator.AddConsumer<ProductDeleteConsumer>();
    busConfigurator.AddConsumer<ProductUpdateConsumer>();

    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("localhost", "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

        configurator.ReceiveEndpoint("Ace", endpoint =>
        {
            endpoint.ConfigureConsumer<ProductCreatedConsumer>(context);
        });
    });
});

// Add logging to your consumer
builder.Services.AddScoped<ProductCreatedConsumer>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
