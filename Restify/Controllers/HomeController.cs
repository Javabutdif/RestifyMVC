using Microsoft.AspNetCore.Mvc;
using Restify.Data;
using Restify.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.SqlClient;

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
                ConnectionString connectionString = new ConnectionString();
               

                
                string sql = "INSERT INTO Landlord(landlord_first_name, landlord_last_name, landlord_email, landlord_contact, landlord_password) " +
                             "VALUES(@fname, @lname, @email, @contact, @pass)";

            
                using (SqlConnection connection = new SqlConnection(connectionString.connection()))
                {
                  
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        
                        command.Parameters.AddWithValue("@fname", fname);
                        command.Parameters.AddWithValue("@lname", lname);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@contact", contact);
                        command.Parameters.AddWithValue("@pass", pass);

                        
                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();

                      
                        connection.Close();
                    }
                }

                // Redirect to login and display a notification
                TempData["RegistrationSuccess"] = "Account registered successfully. Please log in.";
                return RedirectToAction("Login");
            }

    public IActionResult Register()
        {
            return View();
        }
        public void LoginButton(string email, string pass)
        {
            ConnectionString connectionString = new ConnectionString();



            string sql = "SELECT * FROM Landlord WHERE landlord_email = @email AND landlord_password = @pass";


            using (SqlConnection connection = new SqlConnection(connectionString.connection()))
            {

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pass", pass);

                    connection.Open();

                    // Execute the SELECT query and get the results
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            TempData["LoginSuccess"] = "Account login successfully.";
                        }
                        else
                        {
                            // Data not found, handle accordingly
                        }
                    }

                    connection.Close();
                }
            }
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
