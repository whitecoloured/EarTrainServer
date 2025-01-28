using System.Net;

namespace EarTrain.API.Extensions
{
    public static class HandleErrorMethod
    {
        public static async Task HandleError(this HttpResponse response, HttpStatusCode statusCode, string message)
        {
            int codeNumber=(int)statusCode;
            response.StatusCode = codeNumber;
            response.ContentType= "application/json";
            await response.WriteAsJsonAsync(new {Status=codeNumber, Message=message });
        }
    }
}
