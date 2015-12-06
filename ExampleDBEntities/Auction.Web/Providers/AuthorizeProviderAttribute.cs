using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Auction.Model;
using Auction.Model.Enums;
using Auction.Web.Services;

namespace Auction.Web.Providers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeProviderAttribute : AuthorizeAttribute
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
            if (!RoleService.Is(user.Identity.Name, RoleList))
            {
                return false;
            }
            return true;
        }

    }
}