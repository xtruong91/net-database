using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace MySQL.Filters
{
    public class AdminRequiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("Admin") != "true")
                context.Result = new RedirectResult("/Admin/Login");
            else
                base.OnActionExecuting(context);
        }

        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.Session.GetString("Admin") != "true")
            {
                context.Result = new RedirectResult("/Admin/Login");
                return Task.FromResult(0);
            }
            return base.OnActionExecutionAsync(context, next);
        }
    }
}
