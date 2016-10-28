using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace Forum.Controllers
{
    public class ThreadController : Controller
    {
        //
        // GET: /Thread/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            ForumContext context = new ForumContext();
            List<Thread> threadList = new List<Thread>();
            var thread = context.thread.Where(s => s.id == id).Include(s => s.post).FirstOrDefault() ;
            ViewBag.id = id;
            ViewBag.status = thread.status;
            return View(thread);
        }
        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag.id = id;
            ViewBag.user=Session["user"];
            return View();
        }
        [HttpPost]
        public ActionResult Create(Thread t,FormCollection form)
        {
            ForumContext context = new ForumContext();
            Thread thread = new Thread();
            thread.startpost = t.startpost;
            thread.BoardId = t.BoardId;
            thread.title = t.title;
            thread.status = "Unlocked";
            context.thread.Add(thread);
            context.SaveChanges();
            Post post = new Post();
            post.postType = "start";
            post.ThreadID = thread.id;
            post.description = thread.startpost;
            post.postedAt = DateTime.Now;
            post.postType = "Thread_Reply";
            //FormCollection form = new FormCollection();           
            post.postedBy = Convert.ToInt32(form["startedBy"]);
            context.post.Add(post);
            
            context.SaveChanges();
            return RedirectToAction("Details", "Forum", new {id=t.BoardId });
        }
        [HttpGet]
        public ActionResult LockThread(int id)
        {
            ForumContext context = new ForumContext();
            Thread thread = context.thread.Where(s => s.id == id).FirstOrDefault();
            thread.status = "Locked";
            context.Entry(thread).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Details", "Thread", new { id=id});
        }
        [HttpGet]
        public ActionResult UnlockThread(int id)
        {
            ForumContext context = new ForumContext();
            Thread thread = context.thread.Where(s => s.id == id).FirstOrDefault();
            thread.status = "Unlocked";
            context.Entry(thread).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Details", "Thread", new { id = id });
        }

    }
}
