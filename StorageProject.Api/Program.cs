using FluentValidation;
using Microsoft.EntityFrameworkCore;
using StorageProject.Application.Contracts;
using StorageProject.Application.Services;
using StorageProject.Application.Validators;
using StorageProject.Domain.Contracts;
using StorageProject.Infrasctructure.Data;
using StorageProject.Infrastructure.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers()
                .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("StorageContext");

builder.Services.AddDbContext<AppDbContext>(options =>
                                            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                                                   .EnableDetailedErrors()
                                                   .EnableSensitiveDataLogging());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<BrandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CategoryValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
