using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crudleon.Controllers;
using crudleon.Models.Entity.Prime;

namespace crudleon.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            user oUser = (user)HttpContext.Current.Session["User"];

            if (oUser == null)
            {
                if (filterContext.Controller is AccessController == false) // == false esta de mas, pero para que se entienda asi se puso
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home");
                }
            }
            

            base.OnActionExecuting(filterContext);
        }
    }
}