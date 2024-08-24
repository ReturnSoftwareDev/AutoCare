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
using AutoCare.Application.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddPersistenceConfiguration();

builder.Services.AddFluentValidationService();
builder.Services.AddMediatorService();
builder.Services.AddAutoMapperService();

builder.Services.AddExtensionConfiguration();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AutoCareApiCors",
        builder =>
        {
            builder.AllowAnyHeader()
                   .AllowAnyMethod()
                   .SetIsOriginAllowed((host) => true)
                   .AllowCredentials();
        });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt=>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidAudience = builder.Configuration["AppSettings:ValidAudience"],
        ValidIssuer = builder.Configuration["AppSettings:ValidIssuer"],
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Key"])),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidateAudience = true,
        ValidateIssuer = true,
        RequireExpirationTime = true, // Token'da expiration time'�n olmas� gerekti�ini do�rular
        RequireAudience = true, // Token'da audience bilgisi olmas� gerekti�ini do�rular
        RequireSignedTokens = true // Token'�n imzalanm�� olmas� gerekti�ini do�rular
    };

});

//Rate Limiting kurulacak.
//Refresh token olu�turulacak db ye kay�t edilecek.


builder.Services.AddAuthorization();

builder.Services.AddScoped<JwtGeneratorToken>();


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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
