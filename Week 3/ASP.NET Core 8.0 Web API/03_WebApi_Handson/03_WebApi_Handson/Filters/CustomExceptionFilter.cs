using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _03_WebApi_Handson.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Write exception to a file
            File.AppendAllText(
                "ErrorLog.txt",
                DateTime.Now + "\n" +
                context.Exception.ToString() +
                "\n---------------------------------\n"
            );

            // Return 500 Internal Server Error
            context.Result = new ObjectResult("Internal Server Error")
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}