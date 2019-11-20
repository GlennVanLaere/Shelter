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
    Animal GetAnimalByShelterAndId(int shelterId, int animalId);
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
        .Include(shelter=> shelter.Animals);
    
    }


    public IEnumerable<Animal> GetAnimals(int shelterId)
    {
      return _context.Shelter
        .Include(shelter => shelter.Animals)
        .FirstOrDefault(x => x.Id == shelterId)?.Animals;
    }

    public Shelter.Shared.Shelter GetShelterById(int id)
    {
      return _context.Shelter.FirstOrDefault(x => x.Id == id);
    }

    public Animal GetAnimalByShelterAndId(int shelterId, int animalId)
    {
        return _context.Animals
        .FirstOrDefault(x => x.Id == shelterId && x.Id == animalId);
    }
  }
}