using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Tililin.Domain.Exceptions;

namespace Tililin.Application.Middleware;

public class ExceptionMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    private readonly string _responseContentType = "application/json";

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            // 404 Não encontrado
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            context.Response.ContentType = _responseContentType;
            await context.Response.WriteAsync(
                JsonSerializer.Serialize(new { message = ex.Message }));
        }
        catch (BusinessException ex)
        {
            // 409 para conflito de negócio
            context.Response.StatusCode = StatusCodes.Status409Conflict;
            context.Response.ContentType = _responseContentType;
            await context.Response.WriteAsync(
                JsonSerializer.Serialize(new { message = ex.Message }));
        }
    }
}
