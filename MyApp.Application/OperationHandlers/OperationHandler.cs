using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application 
{
    public class OperationHandler<T>
    {
        public bool? IsSuccess { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public static OperationHandler<T> Success(T data, string? message = "Success")
        {
            var result = new OperationHandler<T>()
            {
                IsSuccess = true,
                Data = data,
                Message = message,
            };
            return result;
        }

        public static OperationHandler<T> Error(T data, string? message = "Error")
        {
            var result = new OperationHandler<T>()
            {
                IsSuccess = false,
                Data = data,
                Message = message,
            };
            return result;
        }
    }
}
