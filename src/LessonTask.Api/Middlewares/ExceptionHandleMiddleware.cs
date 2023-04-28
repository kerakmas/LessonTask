using Azure;
using LessonTask.Api.Models;
using LessonTask.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace LessonTask.Api.Middlewares
{
    public class ExceptionHandleMiddleware : Controller
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionHandleMiddleware> logger;

        public ExceptionHandleMiddleware(RequestDelegate next, ILogger<ExceptionHandleMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (TaskLessonException exception)
            {
                context.Response.StatusCode = exception.Code;
                await context.Response.WriteAsJsonAsync(new Responce

                {
                    Code = exception.Code,
                    Message = exception.Message
                });
            }
            catch (Exception exception)
            {
                this.logger.LogError($"{exception}\n\n");
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new Responce
                {
                    Code = 500,
                    Message = exception.Message
                });
            }
        }
    }
}
