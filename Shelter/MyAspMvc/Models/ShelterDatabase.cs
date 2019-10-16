using System.Collections.Generic;
using Shelter.Shared;
using System;

namespace MyAspMvc.Models
{
    public class ShelterDatabase
    {
        private static bool _isInitialized = false;
        private static Shelter.Shared.Shelter _shelter = null;

        private static void Initialize()
        {
            if (!_isInitialized)
            {
                var shelter = new Shelter.Shared.Shelter()
                {
                    Name = "Our shelter"
                };

                shelter.Animals = new List<Animal>
                {
                   new Cat{ Name = "Poes",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = false,Since = DateTime.Now,Declawed = true,Race = "Hairless Sphynx"},
                   new Cat{ Name = "Kity",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = false,Since = DateTime.Now,Declawed = true,Race = "Hairless Sphynx"},
                   new Cat{ Name = "wietel",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = false,Since = DateTime.Now,Declawed = true,Race = "Hairless Sphynx"},
                   new Dog{ Name = "Felix",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = true,Since = DateTime.Now,Barker = true,Race = "Golden Retriever"},
                   new Dog{ Name = "peppa",DateOfBirth = new DateTime(2000, 02, 14),IsChecked = true,KidFriendly = true,Since = DateTime.Now,Barker = true,Race = "Danish Dog"},
                };

                _shelter = shelter;
                _isInitialized = true;
            }

        }
        public static Shelter.Shared.Shelter Shelter
        {
            get
            {
                Initialize();
                return _shelter;
            }
        }

    }
}
