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
                Id = 1,
                Animals = new List<Animal> {
                  new Other { Name = "Streep"},
                  new Cat{Name = "Poes",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = false,Since = DateTime.Now,Declawed = true,Race = "Hairless Sphynx"},
                  new Cat{Name = "Kity",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = false,Since = DateTime.Now,Declawed = true,Race = "Hairless Sphynx"},
                  new Cat{Name = "wietel",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = false,Since = DateTime.Now,Declawed = true,Race = "Hairless Sphynx"},
                  new Dog{Name = "Felix",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = true,Since = DateTime.Now,Barker = true,Race = "Golden Retriever"},
                  new Dog{Name = "peppa",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = true,Since = DateTime.Now,Barker = true,Race = "Danish Dog"},
        }
            };
            _context.Shelter.Add(shelter);

            _context.SaveChanges();
        }

    }


}