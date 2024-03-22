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
using Microsoft.Extensions.Configuration;
using sib_api_v3_sdk.Client;
using Amazon.SimpleEmail;
using Microsoft.Extensions.DependencyInjection;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Runtime;
using Amazon;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Configuration.Default.ApiKey.Add("api-key", builder.Configuration["BrevoApi:ApiKey"]);
builder.Services.AddControllers();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped(
    typeof(IRequestHandler<GetAllGenericCommand<Users>, List<Users>>),
    typeof(GetAllGenericCommandHandler<Users>)
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
builder.Services.AddTransient<IEmailSenderService, SESService>();
builder.Services.AddTransient<IOTPService, OtpService>();
builder.Services.AddScoped<IRequestHandler<GetCommand<Users>, Users>, GetCommandHandler<Users>>();
builder.Services.AddScoped<IRequestHandler<GetCommand<Address>, Address>, GetCommandHandler<Address>>();
builder.Services.AddScoped<IRequestHandler<GetCommand<Review>, Review>, GetCommandHandler<Review>>();
builder.Services.AddAutoMapper(typeof(Program), typeof(MappingProfile));
builder.Services.AddAWSService<IAmazonSimpleEmailService>(new AWSOptions
{
    Credentials = new BasicAWSCredentials("AKIAV7GTMXMYZYZJBYWT", "iZSUWqYzm4nr6Erjkq7BwfzFJ/k68XjSJ/JBllZo"),
    Region = RegionEndpoint.APNortheast3 // Specify the appropriate region
});
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
