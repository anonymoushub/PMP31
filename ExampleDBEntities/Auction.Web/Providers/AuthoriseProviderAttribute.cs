using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Auction.Model;
using Auction.Model.Enums;

namespace Auction.Web.Providers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthoriseProviderAttribute : AuthorizeAttribute
    {
        public Role[] RoleList { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }
            IPrincipal user = httpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                return false;
            }
            if ((RoleList.Length > 0) && !RoleList.Select(p => p.ToString()).Any<string>(new Func<string, bool>(user.IsInRole)))
            {
                return false;
            }
            return true;
        }

    }
}