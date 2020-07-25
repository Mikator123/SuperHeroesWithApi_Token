using SuperHeroASP.Infrastructures.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroASP.Infrastructures.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)] // va autoriser les accès aux actions/controller si il est précisé [AnonymousRequired]
    public class AnonymousRequiredAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return SessionManager.User == null; // si la session est null
        }
    }
}