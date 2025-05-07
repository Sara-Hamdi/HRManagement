using HRManagement.Domain.Shared;
using HRManagement.Domain.Shared.Exceptions;
using Microsoft.Extensions.Localization;

namespace HRManagement.API.CustomMiddlewares
{
    public class ExceptionHandlingMiddleware
    {
        public readonly RequestDelegate _next;
        public readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public readonly IStringLocalizer<ExceptionHandlingMiddleware> _localizer;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IStringLocalizer<ExceptionHandlingMiddleware> localizer)
        {
            _next = next;
            _logger = logger;
            _localizer = localizer;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BusinessException ex)
            {

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = 403;
                var result = new
                {
                    code = ex.Code,
                    message = _localizer[ex.Code].Value,
                };

                await httpContext.Response.WriteAsJsonAsync(result);

            }
            catch (EntityNotFoundException ex)
            {

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = 404;
                var result = new
                {
                    code = EntityNotFoundException.Code,
                    message = _localizer[Constants.ErrorCodes.EntityNotFound, [ex.EntityName, ex.Id]],

                };

                await httpContext.Response.WriteAsJsonAsync(result);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var result = new
                {
                    code = Constants.ErrorCodes.InternalServerError,
                    message = _localizer[Constants.ErrorCodes.InternalServerError].Value
                };

                await httpContext.Response.WriteAsJsonAsync(result);
            }
        }
    }
}
