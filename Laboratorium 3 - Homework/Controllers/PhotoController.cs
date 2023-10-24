using Laboratorium_3___Homework.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___Homework.Controllers
{
    public class PhotoController : Controller
    {
        static Dictionary<int, Photo> _photos = new Dictionary<int, Photo>();
        static int id = 1;
        public IActionResult Index()
        {
            return View(_photos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Photo model)
        {
            if (ModelState.IsValid)
            {
                //dodaj model do bazy lub kolekcji
                model.Id = id++;
                _photos.Add(model.Id, model);
                return RedirectToAction("Index");

            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_photos[id]);
        }

        [HttpPost]
        public IActionResult Delete(Photo model)
        {
            _photos.Remove(model.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_photos[id]);
        }

        [HttpPost]
        public IActionResult Update(Photo model)
        {
            if (ModelState.IsValid)
            {
                _photos[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_photos[id]);
        }

        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction("Index");
        }
    }
}
