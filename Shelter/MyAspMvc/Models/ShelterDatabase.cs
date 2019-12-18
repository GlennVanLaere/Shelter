using System.Collections.Generic;
using Shelter.Shared;
using System;

namespace MyAspMvc.Models
{
    public interface IShelterDatabase
    {
        void Initialize();
    }
    public class ShelterDatabase : IShelterDatabase
    {
        private ShelterContext _context;
        public ShelterDatabase(ShelterContext context)
        {
            _context = context;
        }

        public void Initialize()
        {
            var shelter = new Shelter.Shared.Shelter()
            {
                Id = 1,
                Name = "Our shelter"
            };

            shelter.Animals = new List<Animal>
                {
                   new Cat{ Id = 1,Name = "Poes",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = false,Since = DateTime.Now,Declawed = true,Race = "Hairless Sphynx"},
                   new Cat{ Id = 2,Name = "Kity",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = false,Since = DateTime.Now,Declawed = true,Race = "Hairless Sphynx"},
                   new Cat{ Id = 3,Name = "wietel",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = false,Since = DateTime.Now,Declawed = true,Race = "Hairless Sphynx"},
                   new Dog{ Id = 4,Name = "Felix",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = true,Since = DateTime.Now,Barker = true,Race = "Golden Retriever"},
                   new Dog{ Id = 5,Name = "peppa",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = true,Since = DateTime.Now,Barker = true,Race = "Danish Dog"},
                };
            _context.Add(shelter);
            _context.SaveChanges();
        }
    }
}
