using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Forum.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string a = form["userName"].ToString();
            string b = form["Password"].ToString();
            ForumContext forum = new ForumContext();
            var user=forum.user.Where(s => s.userName == a && s.Password == b).SingleOrDefault();
            User user1 = new User();
            user1 = (User)user;
            if (user1 != null)
            {
                Session["user"] = user1.userID;
                Session["userName"] = user1.userName;
                Session["usertype"] = user1.userType;
                //ViewBag.error = Session["user"].ToString() + Session["usertype"].ToString();
                return RedirectToAction("Index","Home");
                //return View();
            }
            else
            {
                ViewBag.error = "your name and password do not match";
                return View();
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User u)
        {
            u.like_recieved = 0;
            u.userType = "user";
            ForumContext context = new ForumContext();
            context.user.Add(u);
            context.SaveChanges();
            ViewBag.error = "Account Succesfully Created";
            return RedirectToAction("Login");
        }



    }
}
