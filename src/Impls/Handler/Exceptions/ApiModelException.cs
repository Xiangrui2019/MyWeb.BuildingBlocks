﻿using System;
using SeedWork.ErrorCode;

namespace Handler.Exceptions
{
    public class ApiModelException : Exception
    {
        public ErrorType Code { get; set; }

        public ApiModelException(ErrorType code, string message) : base(message)
        {
            Code = code;
        }
    }
}