using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [RequestSizeLimit(100000)]
        public IActionResult NewPage()
        {
            var people = new List<Person> {
                new Person(firstName: "Matthew", lastName: "Cataldi"),
                new Person(firstName: "Jenna", lastName: "Cataldi"),
                new Person(firstName: "Capone", lastName: "Cataldi"),
                new Person(firstName: "Callie", lastName: "Cataldi"),
            };

            var person = Person.FullName("Matthew", "Cataldi");
            return Json(people);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string MyCrap(string extraCrap, int? years)
        {
            return HtmlEncoder.Default.Encode($"My Crap is here to stay with { extraCrap } with years being { years }.");
        }
    }
}
