using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Shelter.Shared
{
  public interface IDatabaseInitializer
  {
    void Initialize();
  }

  public class DatabaseInitializer : IDatabaseInitializer
  {
    private ShelterContext _context;
    private ILogger<DatabaseInitializer> _logger;
    public DatabaseInitializer(ShelterContext context, ILogger<DatabaseInitializer> logger)
    {
      _context = context;
      _logger = logger;
    }
    public void Initialize()
    {
      try
      {
        if (_context.Database.EnsureCreated())
        {
          AddData();
        }
      }
      catch (Exception ex)
      {
        _logger.LogCritical(ex, "Error occurred while creating database");

      }
    }

    private void AddData()
    {
      
      var shelter = new Shelter()
      {
        Name = "our shelter",
        ShelterId = 1,
        Animals = new List<Animal> {
          new Dog { Name = "Tommy"},
          new Cat { Name = "pluisje "},
          new Other { Name = "Streep"}
        }
      };
      _context.Shelter.Add(shelter);

      _context.SaveChanges();
    }
  }
}