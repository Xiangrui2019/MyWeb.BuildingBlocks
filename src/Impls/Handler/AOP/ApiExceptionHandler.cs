using Handler.Exceptions;
using Handler.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SeedWork.Models.Message;

namespace Handler.AOP
{
    public class ApiExceptionHandler : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            switch (context.Exception)
            {
                case UnexpectedException exp:
                    context.ExceptionHandled = true;
                    context.Result = new JsonResult(new MessageModel
                    {
                        Code = exp.Code,
                        Message = exp.Message
                    });
                    break;
                case ApiModelException exp:
                    context.ExceptionHandled = true;
                    context.Result = new JsonResult(new MessageModel
                    {
                        Code = exp.Code,
                        Message = exp.Message
                    });
                    break;
                default:
                    context.ExceptionHandled = true;
                    context.Result = new JsonResult(
                        ReusltGenerator.GetServerExceptionResponse());
                    break;
            }
        }
    }
}