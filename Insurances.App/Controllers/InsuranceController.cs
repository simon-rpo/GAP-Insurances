using Insurances.App;
using System.Web.Mvc;

namespace Insurance.App.Controllers
{
    public class InsuranceController : Controller
    {
        [SessionAuthorizeAttribute]
        public ActionResult Insurance()
        {
            return View();
        }
    }
}
