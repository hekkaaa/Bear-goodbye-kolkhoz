using BearGoodbyeKolkhozProject.API.Models.ExceptionModel;
using BearGoodbyeKolkhozProject.Business.Exceptions;
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
            catch (BusinessException error)
            {
                await ConstructResponse(context, HttpStatusCode.BadRequest, error.Message);
            }
            catch (Microsoft.Data.SqlClient.SqlException)
            {
                // ошибка когда БД вообще отсуствует или миграция иная на БД и стобцы не сходятся.
                await ConstructResponse(context, HttpStatusCode.ServiceUnavailable, message: "База данных недоступна");
            }
            catch(UnexpectedErrorServerException error)
            {
                await ConstructResponse(context, HttpStatusCode.InternalServerError, error.Message);
            }
            catch(InvalidOperationException error)
            {
                await ConstructResponse(context, HttpStatusCode.InternalServerError, error.Message);
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
            catch (DuplicateException error)
            {
                await ConstructResponse(context, HttpStatusCode.Conflict, error.Message);
            }
            catch (UserIsBlockException error)
            {
                await ConstructResponse(context, HttpStatusCode.Forbidden, error.Message);
            }
            catch (EntryPointNotFoundException error)
            {
                await ConstructResponse(context, HttpStatusCode.NotFound, error.Message);
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

            var updateModel = new ExceptionOutputModel { Code = (int)code, Message = message };

            var result = JsonSerializer.Serialize(updateModel);
            await context.Response.WriteAsync(result);
        }
    }
}
