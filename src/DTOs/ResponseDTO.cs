using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.DTOs
{
    public class ResponseDTO<T>
    {
        public string Status { get; set; } = "";
        public string Message { get; set; } = "";
        public T? Data { get; set; }

        public ResponseDTO(string status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}