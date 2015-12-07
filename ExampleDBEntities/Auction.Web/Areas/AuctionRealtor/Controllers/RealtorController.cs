using System.Linq;
using System.Web.Mvc;
using Auction.Data.UnitOfWork;
using Auction.Model.Enums;
using Auction.Web.Controllers;
using Auction.Web.Providers;
using Auction.Web.Services;

namespace Auction.Web.Areas.AuctionRealtor.Controllers
{
    [AuthorizeProvider(RoleList = new[] {Role.AuctionRealtor})]
    public class RealtorController : BaseController
    {
        public RealtorController(IUnitOfWork unit) : base(unit)
        {    
        }

        // GET: AuctionRealtor/Realtor
        public ActionResult Index()
        {
            var user = UserService.GetCurrentUser();
            var auctions = Unit.AuctionRepository.GetAllAuctions();
            return View(auctions.ToList());
        }

        [AuthorizeProvider(RoleList = new[] { Role.AuctionRealtor, Role.SimpleUser })]
        public ActionResult Test()
        {
            return View("Index");
        }
    }
}