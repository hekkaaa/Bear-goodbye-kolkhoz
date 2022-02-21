﻿using BearGoodbyeKolkhozProject.Business.Exceptions;
using System.Net;
using System.Text.Json;

namespace BearGoodbyeKolkhozProject.API.Infrastructure
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotAuthorizedException error)
            {
                await ConstructResponse(context, HttpStatusCode.Forbidden, error.Message);
            }
            catch (BusinessException ex)
            {
                await ConstructResponse(context, HttpStatusCode.BadRequest, ex.Message);
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                await ConstructResponse(context, HttpStatusCode.ServiceUnavailable, message: "База данных недоступна");
            }
            catch (NotFoundException error)
            {
                await ConstructResponse(context, HttpStatusCode.Forbidden, error.Message);
            }
            catch (NoRoleException error)
            {
                await ConstructResponse(context, HttpStatusCode.Forbidden, error.Message);
            }
            catch (IncorrectPasswordException error)
            {
                await ConstructResponse(context, HttpStatusCode.Forbidden, error.Message);
            }
            catch (Exception ex)
            {
                await ConstructResponse(context, HttpStatusCode.BadRequest, ex.Message);
            }
        }

        private async Task ConstructResponse(HttpContext context, HttpStatusCode code, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var result = JsonSerializer.Serialize(new { message = message });
            await context.Response.WriteAsync(result);
        }
    }
}
