using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hw4_27EFImageProject.web.Models;
using Microsoft.Extensions.Configuration;
using Hw4_27EFImageProject.Data;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Hw4_27EFImageProject.web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString;

        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        public IActionResult Index()
        {
            var repo = new ImagesRepository(_connectionString);
            return View(repo.GetImages());
        }
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(Image image)
        {
            var repo = new ImagesRepository(_connectionString);
            repo.AddImage(image);
            return Redirect("/");
        }
        public IActionResult ViewImage(int imageId)
        {
            ViewImageViewModel vm = new ViewImageViewModel();
            if (HttpContext.Session.Get<List<int>>("imageIdsLiked") != null)
            {
                vm.ImageIdsLiked = HttpContext.Session.Get<List<int>>("imageIdsLiked");
            }
            var repo = new ImagesRepository(_connectionString);
            vm.Image = repo.GetImageById(imageId);
            return View(vm);
        }

        [HttpPost]
        public IActionResult LikeImage(int id)
        {
            //setting session to include this Image Id
            List<int> imageIdsLiked = HttpContext.Session.Get<List<int>>("imageIdsLiked");
            if (imageIdsLiked == null)
            {
                imageIdsLiked = new List<int>();
            }
            imageIdsLiked.Add(id);
            HttpContext.Session.Set("imageIdsLiked", imageIdsLiked);

            //adding a like to that images like count
            var repo = new ImagesRepository(_connectionString);
            repo.AddLike(id);

            return Json('0');
        }

        public IActionResult GetLikes(int imageId)
        {
            var repo = new ImagesRepository(_connectionString);
            return Json(repo.GetLikesById(imageId));
        }
    }

     public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            string value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }
    }
}
