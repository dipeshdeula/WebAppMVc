using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace WebAppMVC.Controllers
{
    public class DemoController : Controller
    {
        public object HttpContextRequest { get; private set; }

        public IActionResult Index()
        {
            return View();
        }
        //Data passing throug Session
        public IActionResult Login()
        {
            //session takes key value pair to store data in session where key is string i.e Name and value is object i.e Dipesh
            HttpContext.Session.SetString("username", "Dipesh");
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Index");

        }

        //Query String

        public IActionResult QueryTest()
        {
            string name = "Dipesh Deula";
            if (!string.IsNullOrEmpty(HttpContext.Request.Query["name"]))
            {
                name = HttpContext.Request.Query["name"];
            }
            ViewBag.Name = name;
            return View();
        }
    }
}
