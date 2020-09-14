using EasyTrip.Business.Repositories.Abstract;
using EasyTrip.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EasyTrip.WEB.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService blogService;
        private readonly IImageService imageService;
        private readonly IContactService contactService;
        public HomeController(IImageService _imageService, IBlogService _blogService, IContactService _contactService)
        {
            imageService = _imageService;
            blogService = _blogService;
            contactService = _contactService;
        }
        public ActionResult Index()
        {
            var images = imageService.GetList(x => x.IsActive);
            return View(images);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(Contact model)
        {
            if (contactService.Insert(model))
            {
                contactService.SendMessage(model);
                TempData["Message"] = true;
                return View();
            }
            else
            {
                TempData["Message"] = false;
                return View(model);
            }
        }
        public PartialViewResult RenderHeader()
        {
            return PartialView("~/Views/Shared/header.cshtml");
        }
        public PartialViewResult RenderFooter()
        {
            return PartialView("~/Views/Shared/footer.cshtml");
        }
        public PartialViewResult HomeBlogs()
        {
            var lastTwoBlogs = blogService.GetList(x => x.IsActive, "Images", "Comments").OrderByDescending(x => x.Created).Take(2).ToList();
            return PartialView(lastTwoBlogs);
        }
        public PartialViewResult HomeLastBlog()
        {
            var lastBlog = blogService.GetList(x => x.IsActive, "Images", "Comments").Where(x => x.Id == 1).ToList();
            return PartialView(lastBlog);
        }
        public PartialViewResult TopWeekBlog()
        {
            var blogs = blogService.GetList(x => x.IsActive).Take(10).ToList();
            return PartialView(blogs);
        }
        public PartialViewResult BestPlacesLeft()
        {
            var blogs = blogService.GetList(x => x.IsActive, "Images").OrderByDescending(x => x.Created).Take(3).ToList();
            return PartialView(blogs);
        }
        public PartialViewResult BestPlacesRight()
        {
            var blogs = blogService.GetList(x => x.IsActive, "Images").OrderBy(x => x.Created).Take(3).ToList();
            return PartialView(blogs);
        }
    }
}