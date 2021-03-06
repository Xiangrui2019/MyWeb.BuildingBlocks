﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SeedWork.ErrorCode;
using SeedWork.Models.Message;

namespace Handler.AOP
{
    public class ApiNotFoundHandler : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound
                && !context.HttpContext.Response.HasStarted)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Result = new JsonResult(new MessageModel
                {
                    Code = ErrorType.NotFound,
                    Message = "对不起, 我们找不到这个资源"
                });
            }
            
            base.OnActionExecuted(context);
        }
    }
}