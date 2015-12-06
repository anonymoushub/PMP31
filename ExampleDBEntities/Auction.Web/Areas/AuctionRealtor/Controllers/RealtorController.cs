using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Auction.Model.Enums;
using Auction.Web.Providers;

namespace Auction.Web.Areas.AuctionRealtor.Controllers
{
    [AuthorizeProvider(RoleList = new[] {Role.AuctionRealtor})]
    public class RealtorController : Controller
    {
        // GET: AuctionRealtor/Realtor
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeProvider(RoleList = new[] { Role.AuctionRealtor, Role.SimpleUser })]
        public ActionResult Test()
        {
            return View("Index");
        }
    }
}