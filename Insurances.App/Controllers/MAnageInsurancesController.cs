using Insurances.App;
using System.Web.Mvc;

namespace Insurance.App.Controllers
{
    public class ManageInsurancesController : Controller
    {
        [SessionAuthorizeAttribute]
        public ActionResult ManageInsurances()
        {
            return View();
        }
    }
}