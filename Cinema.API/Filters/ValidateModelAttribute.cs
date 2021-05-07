﻿using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using ActionFilterAttribute = System.Web.Http.Filters.ActionFilterAttribute;

namespace Cinema.API.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    { 
        public override void OnActionExecuting(HttpActionContext actionContext) 
        { 
            if (actionContext.ModelState.IsValid ==false)
            {  
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }
}