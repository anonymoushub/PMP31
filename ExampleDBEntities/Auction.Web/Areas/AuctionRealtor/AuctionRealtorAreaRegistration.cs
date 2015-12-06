using System.Web.Mvc;

namespace Auction.Web.Areas.AuctionRealtor
{
    public class AuctionRealtorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AuctionRealtor";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AuctionRealtor_default",
                "AuctionRealtor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}