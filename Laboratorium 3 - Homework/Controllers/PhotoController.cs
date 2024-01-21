using Laboratorium_3___Homework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Laboratorium_3___Homework.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;


        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        //[AllowAnonymous]
        //public IActionResult Index()
        //{
            
        //    return View(_photoService.FindAll());
        //}

        //[Authorize(Roles = "admin,user")]
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View(new Photo() { AuthorsList = CreateAuthorList() });
        //}

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

        //[Authorize(Roles = "admin,user")]
        //[HttpPost]
        //public IActionResult Create(Photo model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _photoService.Add(model);
        //        return RedirectToAction("PagedIndex");

        //    }
        //    model.AuthorsList = CreateAuthorList();
        //    return View();
        //}

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_photoService.FindById(id));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Delete(Photo model)
        {
            _photoService.AddRecent(model);
            _photoService.RemoveById(model.Id);

            return RedirectToAction("PagedIndex");
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_photoService.FindById(id));
        }

        [Authorize(Roles = "admin,user")]
        [HttpPost]
        public IActionResult Update(Photo model)
        {
            if (ModelState.IsValid)
            {
                _photoService.Update(model);
                return RedirectToAction("PagedIndex");
            }
            return View();
        }

        [Authorize(Roles = "admin,user,guest")]
        [HttpGet]
        public IActionResult Details(int id)
        {
            Console.WriteLine(id);
            var find = _photoService.FindById(id);
            if (find == null)
            {
                return NotFound();
            }

            return View(_photoService.FindById(id));
        }

        [Authorize(Roles = "admin,user, guest")]
        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction("PagedIndex");
        }

        [Authorize(Roles = "admin,user")]
        [HttpGet]
        public IActionResult CreateApi()
        {
            return View();

        }

        [Authorize(Roles = "admin, user, guest")]
        [HttpGet]
        public IActionResult CreateComment(int id)
        {
            ViewBag.PhotoId = id;
            return View();

        }

        [Authorize(Roles = "admin,user")]
        [HttpPost]
        public IActionResult CreateApi(Photo photo)
        {
            if (ModelState.IsValid)
            {
                _photoService.Add(photo);
                return RedirectToAction("PagedIndex");
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult PagedIndex(int? authorId, int page = 1, int size = 7)
        {
            if (size < 2)
            {
                return BadRequest();
            }

            ViewBag.AuthorsList = CreateAuthorList();

            var x = _photoService.FindPage(page, size, authorId);

            foreach (var photo in x.Data)
            {
                photo.AuthorsList = CreateAuthorList();
            }

            ViewBag.AuthorId = authorId;
            return View(x);
        }


        [Authorize(Roles = "admin,user")]
        [HttpGet]
        public IActionResult RecentlyDeleted()
        {
            foreach(var x in _photoService.FindAllRecent())
            {
                Console.WriteLine(x);
            }
            return View(_photoService.FindAllRecent());
        }


        [Authorize(Roles = "admin,user")]
        public IActionResult Restore(int id)
        {
            var restoredPhoto = _photoService.FindByIdRestore(id);
            if (restoredPhoto != null)
            {
                _photoService.DeleteRecent(restoredPhoto);
                _photoService.Add(restoredPhoto);
            }

            return RedirectToAction("RecentlyDeleted");
        }


        [Authorize(Roles = "admin,user")]
        [HttpGet]
        public IActionResult DetailsDeleted(int id)
        {
            var find = _photoService.FindByIdRestore(id);
            if (find == null)
            {
                return NotFound();
            }

            return View(_photoService.FindByIdRestore(id));
        }

        [Authorize(Roles = "admin,user")]
        [HttpPost]
        public IActionResult DetailsDeleted()
        {
            return RedirectToAction("RecentlyDeleted");
        }
    }
}
