using EasyTrip.Business.Repositories.Abstract;
using EasyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyTrip.WEB.MVC.UI.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        private readonly IBlogService blogService;
        private readonly ICommentService commentService;
        public BlogController(IBlogService _blogService, ICommentService _commentService)
        {
            blogService = _blogService;
            commentService = _commentService;
        }
        public ActionResult Index()
        {
            var list = blogService.GetList(x => x.IsActive, "Images", "Comments").OrderByDescending(x => x.Created).ToList();
            return View(list);
        }
        public ActionResult SingleBlog(int blogId)
        {
            var blog = blogService.Get(x => x.Id == blogId, "Images","Comments");
            return View(blog);
        }
        [HttpGet]
        public PartialViewResult AddComment(int blogId)
        {
            ViewBag.BlogId = blogId;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddComment(Comment model)
        {
            commentService.Insert(model);
            return PartialView();
        }
    }
}