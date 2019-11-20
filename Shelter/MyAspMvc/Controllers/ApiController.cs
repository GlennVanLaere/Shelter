using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyAspMvc.Models;
using Shelter.Shared;

namespace MyAspMvc.Controllers
{
    [Route("/api/shelters")]
    public class ApiController : Controller
    {
        private readonly IShelterDataAccess _dataAccess;
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger, IShelterDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _logger = logger;
        }

        //all information from database
        [HttpGet("/")]
        public IActionResult GetAllShelters()
        {
            return Ok(_dataAccess.GetAllShelters());
        }
        //the different shelters

        [HttpGet("full")]
        public IActionResult GetAllSheltersFull()
        {
            // You return a list here, "not found" is not an issue -- an empty list is still a valid list.
            return Ok(_dataAccess.GetAllSheltersFull());
        }



        [HttpGet("{id}")]
        public IActionResult GetShelter(int id)
        {
            // Either you find the shelter or not. If you don't find your resource return a 404 
            var shelter = _dataAccess.GetShelterById(id); ;
            return shelter == default(Shelter.Shared.Shelter) ? (IActionResult)NotFound() : Ok(shelter);
        }

        [HttpGet("{id}/animals")]
        public IActionResult GetSheltersAnimals(int id)
        {
            // if you don't find the shelter, return a 404. Again, an empty list is an empty list so empty list of animal is a valid result.
            var animals = _dataAccess.GetAnimals(id);
            return animals == default(IEnumerable<Animal>) ? (IActionResult)NotFound() : Ok(animals);
        }


        [HttpGet("{shelterId}/animals/{animalId}")]
        public IActionResult GetAnimalDetails(int shelterId, int animalId)
        {
            // this can return two kinds of 404's; one for the non-existing shelter and one for the non-existing animal.
            var animal = _dataAccess.GetAnimalByShelterAndId(shelterId, animalId);
            return animal == default(Shelter.Shared.Animal) ? (IActionResult)NotFound() : Ok(animal);
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



