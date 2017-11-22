using System;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {

        const string Name = "_Name";
        const string YearsMember = "_YearsMember";
        const string Date = "_Date";    


        public IActionResult Index()
        {
            HttpContext.Session.SetString("_Name", "Matthew Cataldi");
            HttpContext.Session.SetInt32("_YearsMember", 3);
            HttpContext.Session.SetString("_Date", DateTime.Now.Date.ToString());

            TempData.Add("Key", "Value");
            var tempKey = TempData["Key"];


            // return RedirectToAction("SessionNameYears");
            return RedirectToPage("/HelloWorld/Welcome");
        }

        public IActionResult SessionNameYears()
        {
            var name = HttpContext.Session.GetString("_Name");
            var yearsMember = HttpContext.Session.GetInt32("_YearsMember");
            var date = HttpContext.Session.GetString("_Date");
            var content = $"My name is { name } and I have been a member for { yearsMember } years.\nToday is { date }.";
            content += $"{ Directory.GetCurrentDirectory() }";

            // HttpContext.Session.Remove("_Name");
            // HttpContext.Session.Clear();
            // HttpContext.Session.
            return Content(content);
        }

        // GET: /HelloWorld/Welcome/ 
        public IActionResult Welcome(string name, int numTimes = 1)
        {

            ViewData["Message"] = $"Hello {name}.";
            ViewData["NumTimes"] = numTimes;
            // HtmlEncoder.Default.Encode helps prevent against malicious input from namely JavaScript

            return View();
            //  return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}.");
        }
    }


    public static class SessionExtensions 
    {
        public static void Get<T> (this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Set<T> (this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : 
                                JsonConvert.DeserializeObject<T>(value);
        }
    }
}