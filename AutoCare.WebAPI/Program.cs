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
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddPersistenceConfiguration();

builder.Services.AddFluentValidationService();
builder.Services.AddMediatorService();
builder.Services.AddAutoMapperService();

builder.Services.AddExtensionConfiguration();


//cors politikasý güncellenecek.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AutoCareApiCors",
        builder =>
        {
            builder.AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

builder.Services.Configure<JwtTokenModel>(builder.Configuration.GetSection("AppSettings"));

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
        RequireExpirationTime = true, // Token'da expiration time'ýn olmasý gerektiðini doðrular
        RequireAudience = true, // Token'da audience bilgisi olmasý gerektiðini doðrular
        RequireSignedTokens = true // Token'ýn imzalanmýþ olmasý gerektiðini doðrular
    };

});

builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
            factory: partition => new FixedWindowRateLimiterOptions
            {
                AutoReplenishment = true,
                PermitLimit = 5,
                Window = TimeSpan.FromSeconds(10)
            }));

    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.StatusCode = 429;

        if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
        {
            await context.HttpContext.Response.WriteAsync(
                $"Ýstek sýnýr sayýsýna ulaþtýnýz. {retryAfter.TotalMinutes} dakika sonra tekrar deneyiniz. ", cancellationToken: token);
        }
        else
        {
            await context.HttpContext.Response.WriteAsync(
                "Ýstek sýnýrýna ulaþtýnýz. Daha sonra tekrar deneyin. ", cancellationToken: token);
        }
    };
});

builder.Services.AddAuthorization();

builder.Services.AddScoped<TokenService>();


builder.Services.AddDbContext<AutoCareContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    //x.EnableAnnotations();

    x.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { 
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = JwtBearerDefaults.AuthenticationScheme
            }
        },
        Array.Empty<string>()
    }
    }); 

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

app.UseRateLimiter();


app.UseCors("AutoCareApiCors");


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<CustomExceptionMiddleware>();


app.MapControllers();

app.Run();
