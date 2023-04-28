using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PostComment.Auth
{
    public class Logged : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext) // kono return type nai ...based on authorization
        {
            var token = actionContext.Request.Headers.Authorization;//request header e j authorization ta ache oi data ta cole asbe

            if (token == null)
            {
                actionContext.Response = 
                actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg= "No Token supplied"});
            }
            
            else if (!AuthService.IsTokenValid(token.ToString()))
           {
             actionContext.Response =
           actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "No Token expired" });
           }
            base.OnAuthorization(actionContext);
        }
    }
}