using System.Web.Mvc;

namespace Insurance.App.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUserCookie()
        {
            if (Request.Cookies["user"] != null)
            {
                return Json(System.Web.HttpContext.Current.Request.Cookies["user"].Value, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(string.Empty, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public void logOut()
        {
            var session = System.Web.HttpContext.Current.Session;
            session["User"] = null;
        }
    }
}