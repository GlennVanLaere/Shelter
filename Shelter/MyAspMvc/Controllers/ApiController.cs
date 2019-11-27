using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyAspMvc.Models;

namespace MyAspMvc.Controllers
{
    public class ApiController : Controller
    {
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        //all information from database
        public IActionResult Index()
        {
            return new ObjectResult(ShelterDatabase.Shelter);
        }
        //the different shelters

        public IActionResult shelters(int ShelterId)
        {
            var info = "ID: " + ShelterDatabase.Shelter.ShelterId + " Name: " + ShelterDatabase.Shelter.Name;
            return new ObjectResult(info);

        }

        public IActionResult Privacy()
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



