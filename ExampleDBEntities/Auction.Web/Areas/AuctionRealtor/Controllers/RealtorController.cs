using System.Web.Mvc;
using Auction.Model.Enums;
using Auction.Web.Providers;
using Auction.Web.Services;

namespace Auction.Web.Areas.AuctionRealtor.Controllers
{
    [AuthorizeProvider(RoleList = new[] {Role.AuctionRealtor})]
    public class RealtorController : Controller
    {
        // GET: AuctionRealtor/Realtor
        public ActionResult Index()
        {
            var user = UserService.GetCurrentUser();
            return View();
        }

        [AuthorizeProvider(RoleList = new[] { Role.AuctionRealtor, Role.SimpleUser })]
        public ActionResult Test()
        {
            return View("Index");
        }
    }
}