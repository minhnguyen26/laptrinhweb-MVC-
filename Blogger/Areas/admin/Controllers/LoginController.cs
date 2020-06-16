using Blogger.Areas.admin.code;
using Blogger.Areas.admin.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blogger.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        //GET: admin/Login
        [HttpGet]
        public ActionResult Index()
        {

            {
                return View();
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var result = new AccountModel().Login(model.UserName, model.Password);
            if (result && ModelState.IsValid)
            {
                SessionHelper.SetSession(new UserSession() { UserName = model.UserName });
                return RedirectToAction("Index", "Default");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập nhập hoặc mật khẩu không hợp lệ");
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
    
            return RedirectToAction("Index", "Login");
        }
    }
}
