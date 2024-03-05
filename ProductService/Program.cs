using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Persistance;
using ProductService.Interfaces.Repositories;
using ProductService.Interfaces.Services;
using ProductService.Interfaces.Services.Utilities;
using ProductService.Persistance.Repository;
using ProductService.Service;
using ProductService.Service.Utlities;
using System.Reflection;
using ProductService.Persistance.Context;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IBlobService, BlobService>();
builder.Services.AddAutoMapper(typeof(Program), typeof(MappingProfile));
builder.Services.AddScoped<IProductLogic,ProductLogic>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddMassTransit(busConfigurator =>
{
    busConfigurator.SetKebabCaseEndpointNameFormatter();

    busConfigurator.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("localhost", "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

    });
    
    
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductsContext>();


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
