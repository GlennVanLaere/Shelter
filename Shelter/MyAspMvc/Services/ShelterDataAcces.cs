using System.Collections.Generic;
using System.Linq;
using Shelter.Shared;
using Microsoft.EntityFrameworkCore;

namespace MyAspMvc
{
    public interface IShelterDataAccess
    {
        IEnumerable<Shelter.Shared.Shelter> GetAllShelters();
        IEnumerable<Shelter.Shared.Shelter> GetAllSheltersFull();
        Shelter.Shared.Shelter GetShelterById(int id);

        IEnumerable<Animal> GetAnimals(int shelterId);
        IEnumerable<Cat> GetCats(int shelterId);
        IEnumerable<Dog> GetDogs(int shelterId);
        IEnumerable<Other> GetOthers(int shelterId);

        Animal GetAnimalByShelterAndId(int shelterId, int animalId);
        void UpdateAnimal(int shelterId, int AnimalId, Animal animal);
    }

    public class ShelterDataAccess : IShelterDataAccess
    {
        private ShelterContext _context;

        public ShelterDataAccess(ShelterContext context)
        {
            _context = context;
        }

        public IEnumerable<Shelter.Shared.Shelter> GetAllShelters()
        {
            return _context.Shelter;
        }

        public IEnumerable<Shelter.Shared.Shelter> GetAllSheltersFull()
        {
            return _context.Shelter
              .Include(shelter => shelter.Animals);

        }


        public IEnumerable<Animal> GetAnimals(int shelterId)
        {
            return _context.Shelter
              .Include(shelter => shelter.Animals)
              .FirstOrDefault(x => x.Id == shelterId)?.Animals;
        }
        //Deze methode moet enkel cats teruggeven uit <animals>
        public IEnumerable<Cat> GetCats(int shelterId)
        {
            return _context.Cats.ToList();
        }

        public IEnumerable<Dog> GetDogs(int shelterId)
        {
            return _context.Dogs.ToList().OfType<Dog>();
        }

        public IEnumerable<Other> GetOthers(int shelterId)
        {
            return _context.Others.ToList().OfType<Other>();
        }


        public Shelter.Shared.Shelter GetShelterById(int id)
        {
            return _context.Shelter.FirstOrDefault(x => x.Id == id);
        }

        public Animal GetAnimalByShelterAndId(int shelterId, int animalId)
        {
            return _context.Animals
            .FirstOrDefault(x => x.ShelterId == shelterId && x.Id == animalId);
        }
        public void UpdateAnimal(int shelterId, int animalId, Animal animal)
        {
            var existingAnimal = _context.Animals
                .FirstOrDefault(x => x.ShelterId == shelterId && x.Id == animalId);
            existingAnimal.Name = animal.Name;
            existingAnimal.DateOfBirth = animal.DateOfBirth;
            existingAnimal.IsChecked = animal.IsChecked;
            existingAnimal.KidFriendly = animal.KidFriendly;
            existingAnimal.Since = animal.Since;
            existingAnimal.Race = animal.Race;
            existingAnimal.ShelterId = animal.ShelterId;

            _context.Update(existingAnimal);
            _context.SaveChanges();
        }
    }
}