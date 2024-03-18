using CustomerService.Business_Logic.Utilities;
using CustomerService.Features.Generic.Query.GetAllCommand;
using CustomerService.Features.Generic.Query.GetCommand;
using CustomerService.Interfaces.Business_Logic.Utilities;
using CustomerService.Interfaces.Repositories;
using CustomerService.Models;
using CustomerService.Persistance.Context;
using CustomerService.Persistance.Repositories;
using CustomerService.Services;
using CustomerService.Services.Utilities;
using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
builder.Services.AddTransient<IEmailSenderService, EmailSenderService>();
builder.Services.AddTransient<IOTPService, OtpService>();
builder.Services.AddScoped<IRequestHandler<GetCommand<Customer>, Customer>, GetCommandHandler<Customer>>();
builder.Services.AddScoped<IRequestHandler<GetCommand<Address>, Address>, GetCommandHandler<Address>>();
builder.Services.AddScoped<IRequestHandler<GetCommand<Review>, Review>, GetCommandHandler<Review>>();
builder.Services.AddAutoMapper(typeof(Program), typeof(MappingProfile));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); ;
builder.Services.AddDbContext<CustomerContext>();
builder.Logging.ClearProviders(); // Clear default providers (optional)
builder.Logging.AddConsole();
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
