using Microsoft.AspNetCore.Mvc;

namespace surveyProjectYAS.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
