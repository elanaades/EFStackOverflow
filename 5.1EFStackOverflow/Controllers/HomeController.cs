using _5._1EFStackOverflow.Data;
using _5._1EFStackOverflow.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _5._1EFStackOverflow.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString;

        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        public IActionResult Index()
        {
            var repo = new QuestionsRepository(_connectionString);
            return View(repo.GetQuestions());
        }

    
    }
}