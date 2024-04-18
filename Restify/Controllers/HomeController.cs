using Microsoft.AspNetCore.Mvc;
using Restify.Data;
using Restify.Models;
using System.Diagnostics;

namespace Restify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

     
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult RegisterContact(string fname, string lname, string email, string contact, string pass)
        {
            Landlord land = new Landlord { landlord_first_name = fname, landlord_last_name = lname, landlord_email = email, landlord_contact = contact, landlord_password = pass };
            _db.landlords.Add(land);
            _db.SaveChanges();

            // Redirect to login and display a notification
            TempData["RegistrationSuccess"] = "Account registered successfully. Please log in.";
            return RedirectToAction("Login");


        }
        public IActionResult Register()
        {
            return View();
        }

  
      



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
