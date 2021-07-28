using System;

namespace API.Errors
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultErrorMessage(statusCode);
        }


        public int StatusCode {get;set;}
        public string Message {get;set;}

        private string GetDefaultErrorMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made a badrequest",
                401 => "Unauthorized! You shall not pass!",
                404 => "Resource not found",
                500 => "Server internal error",
                _ => "Error occurred"
            };
        }
    }
}