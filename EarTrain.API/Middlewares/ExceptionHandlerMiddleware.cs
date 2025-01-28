using EarTrain.API.Extensions;
using EarTrain.Core.Exceptions;
using System.Net;

namespace EarTrain.API.Middlewares
{
    public class ExceptionHandlerMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task InvokeAsync(HttpContext _httpContext)
        {
            try
            {
                await _next(_httpContext);
            }
            catch (Exception ex)
            {
                switch (ex)
                {
                    case NotFoundException:
                        await _httpContext.Response.HandleError(HttpStatusCode.NotFound, ex.Message); break;
                    case BadRequestException:
                        await _httpContext.Response.HandleError(HttpStatusCode.BadRequest, ex.Message); break;
                    default:
                        await _httpContext.Response.HandleError(HttpStatusCode.InternalServerError, ex.Message); break;
                }
            }
        }
    }
}
