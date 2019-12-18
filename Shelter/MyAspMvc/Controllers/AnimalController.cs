using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyAspMvc.Models;
using Shelter.Shared;
using System.Linq;

namespace MyAspMvc.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Details(int id)
        {
            var targetAnimal = ShelterDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Shelter.Shared.Animal))
            {
                return NotFound();
            }
            return View(targetAnimal);
        }
        public IActionResult Delete(int id)
        {
            var targetAnimal = ShelterDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Shelter.Shared.Animal))
            {
                return NotFound();
            }
            return View(targetAnimal);
        }

        [HttpPost]
        public IActionResult DoDelete(int id)
        {
            var targetAnimal = ShelterDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Shelter.Shared.Animal))
            {
                return NotFound();
            }
            ShelterDatabase.Shelter.Animals.Remove(targetAnimal);
            return RedirectToAction("Index");

        }
        public IActionResult Index()
        {

            return View(ShelterDatabase.Shelter);
        }
        public IActionResult Edit(int id)
        {
            var targetAnimal = ShelterDatabase.Shelter.Animals.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Shelter.Shared.Animal))
            {
                return NotFound();
            }
            return View(targetAnimal);
        }
        public IActionResult DoEdit(int id, string name)
        {
            var targetAnimal = ShelterDatabase.ShelterContext.Animals.FirstOrDefault(x => x.Id == id);
            if (targetAnimal == default(Shelter.Shared.Animal))
            {
                return NotFound();
            }
            targetAnimal.Name = name;
            return RedirectToAction("Index");
        }
    }
}