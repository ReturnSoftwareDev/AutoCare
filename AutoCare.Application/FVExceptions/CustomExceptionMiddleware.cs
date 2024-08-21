using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.FVExceptions
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var result = string.Empty;

            if (exception is ValidationException validationException)
            {
                var errorMessages = validationException.Errors
                    .Select(err => err.ErrorMessage)
                    .ToList();

                result = System.Text.Json.JsonSerializer.Serialize(new
                {
                    Message = errorMessages.ToList()
                });
            }
            else
            {
                result = System.Text.Json.JsonSerializer.Serialize(new
                {
                    Message = "An unexpected error occurred."
                });
            }

            return context.Response.WriteAsync(result);

        }




    }
}
