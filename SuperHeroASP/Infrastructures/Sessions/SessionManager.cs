using Models.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperHeroASP.Infrastructures.Sessions
{
    public static class SessionManager
    {
        public static UserClient User
        {
            get { return (UserClient)HttpContext.Current.Session[nameof(User)]; }
            set { HttpContext.Current.Session[nameof(User)] = value; }
        }

        public static string UserName
        {
            get { return (string)HttpContext.Current.Session[nameof(UserName)]; }
            set { HttpContext.Current.Session[nameof(UserName)] = value; }
        }
    }
}