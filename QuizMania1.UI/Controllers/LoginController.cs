using Microsoft.AspNetCore.Mvc;
using Quizmania1.Model.ViewModel;
using QuizMania1.UI.Interface;

namespace QuizMania1.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserLogin _iuserlogin;
        public LoginController(IUserLogin iuserlogin)
        {
            _iuserlogin= iuserlogin;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Index(UserLoginVM model)
        {
            var getdetails = await  _iuserlogin.VerifyUser(model);
            if (getdetails != null)
            {
                HttpContext.Session.SetString("UserID", Convert.ToString(getdetails[0].UserId));
                HttpContext.Session.SetString("UserName", Convert.ToString(getdetails[0].Username));
                HttpContext.Session.SetString("JwtValue", Convert.ToString(getdetails[0].Token));
            }
            return Json(getdetails);
        }
    }
}
