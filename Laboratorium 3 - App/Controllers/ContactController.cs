using Microsoft.AspNetCore.Mvc;
using Laboratorium_3___App.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace Laboratorium_3___App.Controllers
{
    //[Authorize(Roles = "admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_contactService.FindAll());
        }

        public IActionResult PagedIndex(int page = 1, int size = 5)
        {
            if(size < 2)
            {
                return BadRequest();
            }
            return View(_contactService.FindPage(page,size));
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View(new Contact() { OrganizationsList = CreateOrganizationList() });

        }

        
        private List<SelectListItem> CreateOrganizationList()
        {
            List<SelectListItem> organizations = _contactService.FindAllOrganizationsForVieModel()
                .Select(equals => new SelectListItem()
                {
                    Text = equals.Name,
                    Value = equals.Id.ToString(),
                }).ToList();

            return organizations;
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");

            }

            model.OrganizationsList = CreateOrganizationList();

            return View(model);
            
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Update(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_contactService.FindById(id));
        }

        [HttpPost]
        public IActionResult Delete(Contact model)
        {
            _contactService.RemoveById(model.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var find = _contactService.FindById(id);
            if(find == null)
            {
                return NotFound();
            }
            
            return View(_contactService.FindById(id));
            
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
        public IActionResult CreateApi(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contactService.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        
    }
}
