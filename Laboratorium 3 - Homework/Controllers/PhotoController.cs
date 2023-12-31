﻿using Laboratorium_3___Homework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace Laboratorium_3___Homework.Controllers
{
    [Authorize(Roles = "admin")]
    public class PhotoController : Controller
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        [AllowAnonymous]
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
            var find = _photoService.FindById(id);
            if (find == null)
            {
                return NotFound();
            }

            return View(_photoService.FindById(id));
        }

        [HttpPost]
        public IActionResult Details()
        {
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateApi()
        {
            return View();

        }

        [HttpPost]
        public IActionResult CreateApi(Photo photo)
        {
            if (ModelState.IsValid)
            {
                _photoService.Add(photo);
                return RedirectToAction("Index");
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult PagedIndex(int page = 1, int size = 5)
        {
            if (size < 2)
            {
                return BadRequest();
            }
            return View(_photoService.FindPage(page, size));
        }
    }
}
