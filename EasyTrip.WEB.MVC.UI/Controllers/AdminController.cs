using EasyTrip.Business.Repositories.Abstract;
using EasyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyTrip.WEB.MVC.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private readonly IBlogService blogService;
        private readonly ICommentService commentService;
        private readonly IContactService contactService;
        public AdminController(IBlogService _blogService, ICommentService _commentService, IContactService _contactService)
        {
            blogService = _blogService;
            commentService = _commentService;
            contactService = _contactService;
        }
        [Authorize]
        public ActionResult Index()
        {
            var blogs = blogService.GetList(x => x.IsActive).OrderByDescending(x => x.Created).ToList();
            return View(blogs);
        }
        [HttpGet]
        public ActionResult InsertBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertBlog(Blog model)
        {
            if (blogService.Insert(model))
            {
                TempData["Result"] = true;
            }
            else
            {
                TempData["Result"] = false;
            }
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult DeleteBlog(int blogId)
        {
            var blog = blogService.Get(x => x.Id == blogId);
            if (blogService.Delete(blog))
            {
                TempData["DeleteBlog"] = true;
            }
            else
            {
                TempData["DeleteBlog"] = false;
            }
            return RedirectToAction("Index", "Admin");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int blogId)
        {
            var blog = blogService.Get(x => x.Id == blogId);
            return View(blog);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBlog(Blog model)
        {
            var blog = blogService.Get(x => x.Id == model.Id);
            blog.Title = model.Title;
            blog.Content = model.Content;
            if (blogService.Update(blog))
            {
                TempData["UpdateBlog"] = true;
            }
            else
            {
                TempData["UpdateBlog"] = false;
            }
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult CommentList()
        {
            var comments = commentService.GetList(x => x.IsActive, "Blog").OrderByDescending(x => x.Created).ToList();
            return View(comments);
        }
        public ActionResult DeleteComment(int commentId)
        {
            var comment = commentService.Get(x => x.Id == commentId);
            if (commentService.Delete(comment))
            {
                TempData["DeleteComment"] = true;
            }
            else
            {
                TempData["DeleteComment"] = false;
            }
            return RedirectToAction("CommentList");
        }
        [HttpGet]
        public ActionResult UpdateComment(int commentId)
        {
            var comment = commentService.Get(x => x.Id == commentId);
            return View(comment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateComment(Comment model)
        {
            var comment = commentService.Get(x => x.Id == model.Id);
            comment.Text = model.Text;
            if (commentService.Update(comment))
            {
                TempData["UpdateComment"] = true;
            }
            else
            {
                TempData["UpdateComment"] = false;
            }
            return RedirectToAction("CommentList");
        }
        public ActionResult ContactList()
        {
            var contacts = contactService.GetList(x=>x.IsActive).OrderByDescending(x => x.Created).ToList();
            return View(contacts);
        }
        public ActionResult DeleteContact(int contactId)
        {
            var contact = contactService.Get(x => x.Id == contactId);
            if (contactService.Delete(contact))
            {
                TempData["DeleteContact"] = true;
            }
            else
            {
                TempData["DeleteContact"] = false;
            }
            return RedirectToAction("ContactList");
        }
        [HttpGet]
        public ActionResult UpdateContact(int contactId)
        {
            var contact = contactService.Get(x => x.Id == contactId);
            return View(contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateContact(Contact model)
        {
            var contact = contactService.Get(x => x.Id == model.Id);
            contact.FullName = model.FullName;
            contact.Email = model.Email;
            contact.Message = model.Message;
            if (contactService.Update(contact))
            {
                TempData["UpdateContact"] = true;
            }
            else
            {
                TempData["UpdateContact"] = false;
            }
            return RedirectToAction("ContactList");
        }
        [HttpGet]
        public ActionResult InsertContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertContact(Contact model)
        {
            if (contactService.Insert(model))
            {
                TempData["InsertContact"] = true;
            }
            else
            {
                TempData["InsertContact"] = false;
            }
            return RedirectToAction("ContactList");
        }
    }
}