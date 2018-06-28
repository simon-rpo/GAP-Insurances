using Insurances.Dto;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace Insurance.App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            if (HttpContext.Session["User"] == null)
            {
                return RedirectToAction("login", "login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Authenticate(string Data1, string Data2)
        {
            UserDto oUser = JsonConvert.DeserializeObject<UserDto>(Data1);
            Session["User"] = oUser;

            if (Session["User"] != null)
            {
                return Json(oUser);
            }
            else
            {
                return View();
            }
        }

    }
}