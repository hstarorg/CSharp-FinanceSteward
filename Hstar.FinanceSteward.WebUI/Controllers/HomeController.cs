using System.Web.Security;
using Hstar.FinanceSteward.IBLL;
using Hstar.FinanceSteward.Model;
using System;
using System.Web;
using System.Web.Mvc;
using Hstar.Framework.Ioc;
using Hstar.Framework.Serializer;

namespace Hstar.FinanceSteward.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeBll homeBll;

        public HomeController()
        {
            homeBll = AutofacHelper.GetInstance<IHomeBll>();
        }
        [HttpGet]
        public ActionResult Login()
        {
            //请求登录页面，则先清除登录信息（不关心是否登录）
            FormsAuthentication.SignOut();
            var user = new UsersEntity();
            if (Request.Cookies["username"] != null)
            {
                user.UserName = Request.Cookies["username"].Value;
                ViewBag.RememberAccount = true;
            }
            else
            {
                ViewBag.RememberAccount = false;
            }
            return View("Login", user);
        }

        [HttpPost]
        public ActionResult Login(UsersEntity user, bool rememberAccount = false)
        {
            var userModel = homeBll.IsLoginSucceed(user);
            //登录成功
            if (userModel != null)
            {
                //记录登录信息
                userModel.UserPass = "";
                FormsAuthentication.SetAuthCookie(JsonSerialization.Serialize(userModel),false);
                var cookie = new HttpCookie("username", user.UserName)
                           {
                               Expires = DateTime.Now.AddMonths(rememberAccount ? 1 : -1)
                           };
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("loginerror", "用户名密码不匹配");
            ViewBag.RememberAccount = rememberAccount;
            return View("Login", user);
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Index");
            }
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Welcome()
        {
            return View("Welcome");
        }
    }
}