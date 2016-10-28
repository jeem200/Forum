using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
namespace Forum.Controllers
{
    public class ForumController : Controller
    {
        //
        // GET: /Forum/

        public ActionResult Board()
        {
            
            ForumContext context = new ForumContext();
           

            return View( context.board.ToList());
        }
        public ActionResult Details(int id)
        {
            ForumContext context = new ForumContext();
            List<Thread> threadList=new List<Thread>();
            threadList=context.thread.Where(s => s.BoardId == id).ToList();
            ViewBag.id = id;
            return View(threadList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Board b)
        {
            ForumContext context = new ForumContext();
            context.board.Add(b);
            context.SaveChanges();
            return RedirectToAction("Board");
        }

    }
}
