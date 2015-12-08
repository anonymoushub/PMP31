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
            var auctions = Unit.AuctionRepository.GetAllAuctions();
            return View(auctions.ToList());
        }

        public ActionResult Approved()
        {
            var auctions = Unit.AuctionRepository.GetAllAuctions()
                            .Where(a => a.Approved);
            return View("Index", auctions.ToList());
        }

        public ActionResult ApprovedByMe()
        {
            var currentUserId = UserService.GetCurrentUser().Id;
            var auctions = Unit.AuctionRepository.GetApprovedAuctions()
                .Where(a => a.Approved && a.ApprovedBy.Id == currentUserId);
            return View("Index", auctions.ToList());
        }

        public ActionResult Details(int id)
        {
            var auction = Unit.AuctionRepository.GetById(id);        
            return View(auction);
        }

        public ActionResult Approve(int id)
        {
            var currentUserId = UserService.GetCurrentUser().Id;
            var auction = Unit.AuctionRepository.GetById(id);
            auction.Approved = true;
            auction.ApprovedBy = Unit.UserRepository.GetById(currentUserId);
            Unit.Commit();
            return RedirectToAction("Approved");
        }

        public ActionResult Decline(int id)
        {
            var auction = Unit.AuctionRepository.GetById(id);
            auction.Approved = false;
            auction.ApprovedBy = null;
            Unit.Commit();
            return RedirectToAction("Index");
        }

        // 1 - Name
        // 2 - Year
        // 3 - Price
        public ActionResult SortBy(int id)
        {
            var auctions = Unit.AuctionRepository.GetAllAuctions();
            switch (id)
            {
                case 2:
                    ViewBag.SortedBy = "Year";
                    return View("Index", auctions.OrderBy(a => a.Product.Year).ToList());
                case 3:
                    ViewBag.SortedBy = "Price";
                    return View("Index", auctions.OrderBy(a => a.Product.AboutPrice).ToList());
                default:
                    ViewBag.SortedBy = "Name";
                    return View("Index", auctions.OrderBy(a => a.Name).ToList());
            }
        }

        public ActionResult Search(string text)
        {
            var auctions = Unit.AuctionRepository.GetAllAuctions()
                               .Where(a => a.Name.ToLower().Contains(text.ToLower()));
            return View("Index", auctions.ToList());
        }
    }
}