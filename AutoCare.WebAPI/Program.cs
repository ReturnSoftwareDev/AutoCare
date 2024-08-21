using AutoCare.Persistance.Context;
using AutoCare.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;
using AutoCare.Domain.Entities;
using AutoCare.Application.Services;
using AutoCare.Application.Base;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using FluentValidation;
using AutoCare.Application.FVExceptions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceConfiguration();

builder.Services.AddFluentValidationService();
builder.Services.AddMediatorService();
builder.Services.AddAutoMapperService();

builder.Services.AddExtensionConfiguration();


builder.Services.AddControllers();

builder.Services.AddDbContext<AutoCareContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CustomExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
