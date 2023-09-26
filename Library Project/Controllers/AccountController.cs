using Library_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Library_Project.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(MemberModel member)
        { 
            using (var context=new DLMSDatabaseEntities())
            {
                bool isValid=context.User.Any(x=>x.UserName == member.UserName && x.Password == member.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(member.UserName, false);
                    return RedirectToAction("Index","Home");
                }
                ModelState.AddModelError("", "Invalid UserName And Password");
                return View();
            }
            
        }
        public ActionResult SignUp()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User model)
        {
            using (var context = new DLMSDatabaseEntities())
            {
                context.User.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}