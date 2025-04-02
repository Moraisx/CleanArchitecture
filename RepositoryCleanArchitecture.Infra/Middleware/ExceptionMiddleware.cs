using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using RepositoryCleanArchitecture.Domain.Exceptions;
using RepositoryCleanArchitecture.Domain.Exeptions.ListExceptions;
using RepositoryCleanArchitecture.Domain.Exeptions.Models;
using RepositoryCleanArchitecture.Domain.Exeptions.UnitExceptions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        string json;

        if (exception is DefaultExceptionHandler ex)
        {
            if (ex.ListError is List<DefaultError> listErros)
            {
                var response = new ListError<DefaultError>(
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest,
                ex.ListError,
                HttpStatusCode.BadRequest.ToString());

                json = JsonSerializer.Serialize(response);
                return context.Response.WriteAsync(json);
            }
            else if (ex.Error is DefaultError unitError)
            {
                var response = new UnitError<DefaultError>(
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest,
                    unitError,
                    HttpStatusCode.BadRequest.ToString());

                json = JsonSerializer.Serialize(response);
                return context.Response.WriteAsync(json);
            }
            else return context.Response.WriteAsync(ErroGenerico(context));
        }
        else return context.Response.WriteAsync(ErroGenerico(context));
    }

    private static string ErroGenerico(HttpContext context)
    {
         var response = new UnitError<DefaultError>(
                   context.Response.StatusCode = (int)HttpStatusCode.BadRequest,
                   new DefaultError("Erro", "Erro genérico"),
                   HttpStatusCode.InternalServerError.ToString());
        return JsonSerializer.Serialize(response);
    }

}
