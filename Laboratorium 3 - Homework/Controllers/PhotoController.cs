using Laboratorium_3___Homework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Laboratorium_3___Homework.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        public IActionResult Index()
        {
            return View(_photoService.FindAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Photo() { AuthorsList = CreateAuthorList() });
        }

        private List<SelectListItem> CreateAuthorList()
        {
            List<SelectListItem> authors = _photoService.FindAllAuthorsForViewModel()
                .Select(equals => new SelectListItem()
                {
                    Text = equals.Name,
                    Value = equals.Id.ToString(),
                }).ToList();

            return authors;
        }

        [HttpPost]
        public IActionResult Create(Photo model)
        {
            if (ModelState.IsValid)
            {
                _photoService.Add(model);
                return RedirectToAction("Index");

            }
            model.AuthorsList = CreateAuthorList();
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_photoService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Photo model)
        {
            _photoService.RemoveById(model.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_photoService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Photo model)
        {
            if (ModelState.IsValid)
            {
                _photoService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_photoService.FindById(id));
        }

        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction("Index");
        }
    }
}
