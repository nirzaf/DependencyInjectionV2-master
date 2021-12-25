using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonalBlog.Interface;
using System;

namespace PersonalBlog.Strategies
{
    public class ProtectorAttribute : Attribute, IActionFilter
    {
        private readonly IAuthorizer _authorizer;
        public ProtectorAttribute(IAuthorizer authorizer)
        {
            _authorizer = authorizer;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!_authorizer.IsAuthorized())
            {
                context.Result = new RedirectToActionResult("Error", "Home", null);
            }
        }
    }
}
