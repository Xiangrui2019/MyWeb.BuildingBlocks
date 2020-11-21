using System;
using Microsoft.AspNetCore.Http;
using SeedWork.ErrorCode;
using SeedWork.Models.Message;

namespace Handler.Exceptions
{
    public class UnexpectedException : Exception
    {
        public MessageModel Response { get; set; }
        public ErrorType Code => Response.Code;

        public UnexpectedException(MessageModel model) : base(model.Message)
        {
            Response = model;
        }
    }
}