using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
           // ForumContext context = new ForumContext();
            //List<Post> post = new List<Post>();
             //post = context.post.OrderByDescending(s=>s.like_count).ToList();
            return View(/*post*/);
            
        }

    }
}
