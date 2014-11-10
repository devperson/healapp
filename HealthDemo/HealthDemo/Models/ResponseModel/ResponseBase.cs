using Newtonsoft.Json;
using System;

namespace HealthDemo.Models.ResponseModel
{
	public class ResponseBase
	{   
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }       
	}

    public class ErrorResponseModel
    {
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
    }
}

