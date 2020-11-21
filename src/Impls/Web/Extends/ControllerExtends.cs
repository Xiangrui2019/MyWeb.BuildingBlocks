using Microsoft.AspNetCore.Mvc;
using SeedWork.ErrorCode;
using SeedWork.Models.Message;

namespace Web.Extends
{
    public static class ControllerExtends
    {
        public static IActionResult Message(this ControllerBase controller, ErrorType errorType, string errorMessage)
        {
            return controller.Ok(new MessageModel
            {
                Code = errorType,
                Message = errorMessage
            });
        }
    }
}