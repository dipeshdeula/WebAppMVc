using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class CustomerController : Controller
    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer () { Id = 101, Name = "Dipesh" , Amount = 25000},
            new Customer () { Id = 102, Name = "Raj" , Amount = 35000},

        };

        //Using viewBag to pass data to view
        public IActionResult Index()
        {
            ViewBag.Message = "Customer Management System";
            ViewBag.CustomerCount = customers.Count;
            ViewBag.CustomerList = customers;
            return View();
        }
        //using viewData to pass data to view

        public IActionResult IndexViewData()
        {
            ViewData["Message"] = "Customer Management System";
            ViewData["CustomerCount"] = customers.Count;
            ViewData["CustomerList"] = customers;
            return View();
        }
        //Temp Data also store data in a key value pair

        public IActionResult IndexTempData()
        {
            TempData["Message"] = "Customer Management System";
            TempData["CustomerCount"] = customers.Count;
            TempData["CustomerList"] = customers;
            return View();
        }

        //Redirect to method

        public IActionResult Method()
        {
            if (TempData["Message"] == null)
                return RedirectToAction("IndexTempData");
            TempData["Message"] = TempData["Message"].ToString();
            return View();

        }

        public IActionResult Details()
        {
            return View();
        }

        //Attribute Routing
        //Attribute Routes overlap the conventional routing
       // [Route("~/")] //Default Attribute Routing

        [Route("/sample/message")]

        public IActionResult Message()
        {
            return View();
        }
    }
}
