using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SeedWork.ErrorCode;
using SeedWork.Models.Message;

namespace Handler.Services
{
    internal static class ReusltGenerator
    {
        internal static MessageCollection<string> GetInvalidModelStateErrorResponse(ModelStateDictionary modelState)
        {
            var list = (from value in modelState from error in value.Value.Errors select error.ErrorMessage).ToList();
            var arg = new MessageCollection<string>(list)
            {
                Code = ErrorType.BadRequest,
                Message = "您的输入中有数个错误!"
            };
            
            return arg;
        }

        internal static MessageModel GetServerExceptionResponse()
        {
            var projectName = System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name;
            var arg = new MessageModel
            {
                Code = ErrorType.UnknownError,
                Message = $"对不起, 这个服务{projectName}发生了崩溃."
            };
            
            return arg;
        }
    }
}