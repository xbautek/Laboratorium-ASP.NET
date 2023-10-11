using Laboratorium.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using System.Diagnostics;

namespace Laboratorium.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public enum Operators
        {
            Add, Sub, Div, Mul
        }
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About(string author, int? id)
        {
            //string author = Request.Query["author"];
            //string strid = Request.Query["id"];
            //if(int.TryParse(strid, out var id))
            //{
            //    ViewBag.Author = author + " id = " + id;
            //}

            if(id==null || author == null)
            {
                return BadRequest();
            }
            ViewBag.Author = author + " id = " + id;
            return View();
        }

        public IActionResult Calculator(string op, double x, double y)
        {
            if(op == "add")
            {
                ViewBag.Result = x + y;
            }else if(op == "sub")
            {
                ViewBag.Result = x - y;
            }
            else if (op == "mul")
            {
                ViewBag.Result = x * y;
            }
            else if (op == "div")
            {
                ViewBag.Result = x/y;
            }


            return View();
        }

        //zadekklaruj metode calculator z parametrami query
        // op string ktory moze zawierac add, sub, mul, div
        // x, y(double) ktore zawieraja liczbe
        // Utworz widok ktory zwroci wynik dzialania


        public IActionResult Kalkulator([FromQuery(Name = "operator")]Operators? op, double? x, double? y)
        {
            if (op == null || x==null || y ==null)
            {
                return View("Error");
            }

            string r = "";

            switch (op)
            {
                case Operators.Add:
                    r = $"{x}+{y} = {x + y}";
                    break;
                case Operators.Sub:
                    r = $"{x}-{y} = {x - y}";
                    break;
            }
            ViewBag.Result = r;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}