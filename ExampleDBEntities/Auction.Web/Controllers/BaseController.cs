using System.Web.Mvc;
using Auction.Data.UnitOfWork;

namespace Auction.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork Unit;

        public BaseController(IUnitOfWork unit)
        {
            Unit = unit;
        }
    }
}