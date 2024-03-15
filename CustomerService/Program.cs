using CustomerService.Features.Generic.Query.GetAllCommand;
using CustomerService.Features.Generic.Query.GetCommand;
using CustomerService.Interfaces.Repositories;
using CustomerService.Models;
using CustomerService.Persistance.Context;
using CustomerService.Persistance.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped(
    typeof(IRequestHandler<GetAllGenericCommand<Customer>, List<Customer>>),
    typeof(GetAllGenericCommandHandler<Customer>)
);
builder.Services.AddScoped(
    typeof(IRequestHandler<GetAllGenericCommand<Address>, List<Address>>),
    typeof(GetAllGenericCommandHandler<Address>)
);
builder.Services.AddScoped(
    typeof(IRequestHandler<GetAllGenericCommand<Review>, List<Review>>),
    typeof(GetAllGenericCommandHandler<Review>)
);
//get command
builder.Services.AddScoped<IRequestHandler<GetCommand<Customer>, Customer>, GetCommandHandler<Customer>>();
builder.Services.AddScoped<IRequestHandler<GetCommand<Address>, Address>, GetCommandHandler<Address>>();
builder.Services.AddScoped<IRequestHandler<GetCommand<Review>, Review>, GetCommandHandler<Review>>();


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); ;
builder.Services.AddDbContext<CustomerContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
