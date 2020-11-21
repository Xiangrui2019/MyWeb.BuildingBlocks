using Handler.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Handler.AOP
{
    public class ApiModelStateChecker : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new JsonResult(
                    ReusltGenerator.GetInvalidModelStateErrorResponse(
                        context.ModelState)
                    );
            }

            base.OnActionExecuting(context);
        }
    }
}