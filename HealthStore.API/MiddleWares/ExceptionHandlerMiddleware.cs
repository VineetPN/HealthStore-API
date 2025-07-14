using System.Net;

namespace HealthStore.API.MiddleWares;

public class ExceptionHandlerMiddleware {
    private readonly RequestDelegate requestDelegate;
    private readonly ILogger<ExceptionHandlerMiddleware> logger;

    public ExceptionHandlerMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionHandlerMiddleware> logger)
    {
        this.requestDelegate = requestDelegate;
        this.logger = logger;
    }

    public async Task InvokeAsync(HttpContext context){
        try{
            await requestDelegate(context);
        }
        catch(Exception e){
            var errorID = Guid.NewGuid();

            logger.LogError(e, $"{errorID} : {e.Message}");

            //Return a custom error response

            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var error = new {
                ID = errorID,
                ErrorMessage = "Something went wrong! We are looking to resolve it!"
            };

            await context.Response.WriteAsJsonAsync(error);
        }
    }


}