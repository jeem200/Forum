using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class PostController : Controller
    {
        //
        // GET: /Post/

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult  Create(int id,int? postid)
        {
            ViewBag.id = id;
            ViewBag.postid = postid;
            ViewBag.postedBy = Session["user"];
            return View();
        }
     
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            ForumContext context = new ForumContext();
            Post post = new Post();
            post.description = form["description"];
            post.postedAt = DateTime.Now;
            if (form["postType"] =="Quote_Reply")
            {
                
                post.repliedTo=Convert.ToInt32 (form["repliedTo"]);
                //post.repliedTo = p.repliedTo;
                post.postType = "Quote Reply";
                //return post.postType + post.repliedTo +"ThreadID"+form["ThreadID"];
            }
            else
            {
                post.postType = "Thread_Reply";
                //return post.postType;
            }
            post.ThreadID = Convert.ToInt32( form["ThreadID"]);
            post.postedBy=Convert.ToInt32( form["postedBy"]);
            context.post.Add(post);
            context.SaveChanges();
            return RedirectToAction("Details", "Thread", new { id =form["ThreadID"] });
            //return View("~/Views/Thread/Details.cshtml/" + form["ThreadID"].ToString());
            //return post.postedBy.ToString();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ForumContext context = new ForumContext();
            Post post=context.post.Where(s => s.postId == id).FirstOrDefault();
            return View(post);
        }
        [HttpPost]
        public ActionResult Edit(Post p)
        {
            ForumContext context = new ForumContext();
            //context.post.Find(p.postId);
            context.Entry(p).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Details", "Thread", new { id = p.ThreadID });
        }

        public ActionResult Like(int id,int? userId)
        {
            ForumContext context = new ForumContext();
            Like like = new Like();
            like = context.like.Where(s => s.liked_by == userId && s.post_liked == id).FirstOrDefault();
            Post p = context.post.Find(id);
            User u = context.user.Find(p.postedBy);
            if (like == null)
            {
                
                p.like_count += 1;
                context.Entry(p).State = EntityState.Modified;
                u.like_recieved += 1;
                context.Entry(u).State = EntityState.Modified;
                //context.SaveChanges();
                Like like1 = new Like();
                like1.post_liked = id;
                like1.liked_by = Convert.ToInt32( userId);
                context.like.Add(like1);
                context.SaveChanges();
            }
            else if (like != null)
            {
                //Post p = context.post.Find(id);
                p.like_count -= 1;
                u.like_recieved -= 1;
                context.Entry(u).State = EntityState.Modified;
                context.Entry(p).State = EntityState.Modified;
                //context.SaveChanges();
                context.like.Attach(like);
                context.like.Remove(like);
                context.SaveChanges();
            }
            return RedirectToAction("Details", "Thread", new { id = p.ThreadID });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Post p = new Post();
            ForumContext context = new ForumContext();
            p = (Post)context.post.Find(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            ForumContext context = new ForumContext();
            Post p=(Post)context.post.Find(id);
            context.post.Attach(p);
            context.post.Remove(p);
            context.SaveChanges();
            return RedirectToAction("Details", "Thread", new { id=Convert.ToInt32(form["ThreadID"])});
        }
   
    }
}
