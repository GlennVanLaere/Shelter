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
        void UpdateDog(int shelterId, int AnimalId, Dog dog);
        void UpdateCat(int shelterId, int AnimalId, Cat cat);
        void UpdateOther(int shelterId, int AnimalId, Other other);

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
        public void UpdateDog(int shelterId, int animalId, Dog dog)
        {
            var currentDog = _context.Dogs.FirstOrDefault(x => x.ShelterId == shelterId && x.Id == animalId);
            currentDog.Barker = dog.Barker;

            currentDog.Name = dog.Name;
            currentDog.DateOfBirth = dog.DateOfBirth;
            currentDog.IsChecked = dog.IsChecked;
            currentDog.KidFriendly = dog.KidFriendly;
            currentDog.Since = dog.Since;
            currentDog.Race = dog.Race;
            currentDog.ShelterId = dog.ShelterId;
            currentDog.Street = dog.Street;
            currentDog.PostalCode = dog.PostalCode;
            currentDog.Number = dog.Number;


            _context.Update(currentDog);
            _context.SaveChanges();
        }
        public void UpdateCat(int shelterId, int animalId, Cat cat)
        {
            var currentCat = _context.Cats.FirstOrDefault(x => x.ShelterId == shelterId && x.Id == animalId);
            currentCat.Declawed = cat.Declawed;

            currentCat.Name = cat.Name;
            currentCat.DateOfBirth = cat.DateOfBirth;
            currentCat.IsChecked = cat.IsChecked;
            currentCat.KidFriendly = cat.KidFriendly;
            currentCat.Since = cat.Since;
            currentCat.Race = cat.Race;
            currentCat.ShelterId = cat.ShelterId;
            currentCat.Street = cat.Street;
            currentCat.PostalCode = cat.PostalCode;
            currentCat.Number = cat.Number;

            _context.Update(currentCat);
            _context.SaveChanges();
        }
        public void UpdateOther(int shelterId, int animalId, Other other)
        {
            var currentOther = _context.Others.FirstOrDefault(x => x.ShelterId == shelterId && x.Id == animalId);
            currentOther.Description = other.Description;
            currentOther.Kind = other.Kind;

            currentOther.Name = other.Name;
            currentOther.DateOfBirth = other.DateOfBirth;
            currentOther.IsChecked = other.IsChecked;
            currentOther.KidFriendly = other.KidFriendly;
            currentOther.Since = other.Since;
            currentOther.Race = other.Race;
            currentOther.ShelterId = other.ShelterId;
            currentOther.Street = other.Street;
            currentOther.PostalCode = other.PostalCode;
            currentOther.Number = other.Number;

            _context.Update(currentOther);
            _context.SaveChanges();
        }
    }
}