using EasyTrip.Business.Repositories.Abstract;
using EasyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EasyTrip.WEB.MVC.UI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private readonly IAdminService adminService;
        public LoginController(IAdminService _adminService)
        {
            adminService = _adminService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin model)
        {
            var result = adminService.Get(x => x.AdminName == model.AdminName && x.Password == model.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(result.AdminName, false);
                Session["AdminName"] = result.AdminName.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}