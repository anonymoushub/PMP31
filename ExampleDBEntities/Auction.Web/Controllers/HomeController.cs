using System.Web.Mvc;
using System.Web.Security;
using Auction.Data.UnitOfWork;
using Auction.Web.Utils;
using Auction.Web.ViewModels;

namespace Auction.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly CryproUtil _cryptoUtil;

        public HomeController(IUnitOfWork unit) : base(unit)
        {
            _cryptoUtil = new CryproUtil();
        }


        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Registration()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public ActionResult Registration(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(userModel);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public ActionResult Login(UserViewModel userModel)
        {
            if (ModelState.IsValid)
            {
                var dbUser = Unit.UserRepository.GetUserByEmail(userModel.Email);
                if(_cryptoUtil.EqualsTo(userModel.Password, dbUser.Password, dbUser.PasswordSalt))
                {
                    FormsAuthentication.SetAuthCookie(userModel.Email, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("Email", "Smth goes wrong!:(");
            return View(userModel);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}