using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult UserMenuCon()
        {
            return View();
        }

        public ActionResult ViewUserList()
        {
            ForumContext context=new ForumContext();
            List<User> u=new List<User>();
            u = context.user.ToList();
            return View(u);
        }

        public ActionResult Edit(int id)
        {
            ForumContext context = new ForumContext();
            User u=context.user.Where(s => s.userID == id).FirstOrDefault();
            u.userType = "Moderator";
            context.Entry(u).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("ViewUserList", "User");
        }

        public ActionResult EditDemote(int id)
        {
            ForumContext context = new ForumContext();
            User u = context.user.Where(s => s.userID == id).FirstOrDefault();
            u.userType = "user";
            context.Entry(u).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("ViewUserList", "User");
        }
        public ActionResult UserPost(int id)
        {
            ForumContext context = new ForumContext();
            List<Post> p = new List<Post>();
            p=context.post.Where(s => s.postedBy == id).ToList();
            return View(p);
        }

    }
}
