using System;
using System.Collections.Generic;
using System.Linq;

namespace Shelter.Shared
{
    public class IdClass
    {
        public int Id { get; set; }
    }
    class Program : IdClass
    {
        static void Main(string[] args)
        {
            var shelter = new Shelter()
            {
                Name = "Our shelter"
            };
            shelter.Animals = new List<Animal>();
            shelter.Animals.Add(new Cat() { Name = "Poes", DateOfBirth = new DateTime(2000, 02, 14), IsChecked = true, KidFriendly = false, Since = DateTime.Now, Declawed = true, Race = "Hairless Sphynx" });
        }
    }

    public class Shelter : IdClass
    {
        public string Name { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }

    public class Person : IdClass
    {
        public string FullName => $"{LastName}, ${FirstName}";
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }

    public class Manager : Person
    {

    }

    public class CareTaker : Person
    {
        public Animal TakesCareOf { get; set; }
    }

    public class Administrator : Person
    {

    }

    public class Animal : IdClass
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsChecked { get; set; }
        public bool KidFriendly { get; set; }
        public DateTime Since { get; set; }
        public string Race { get; set; }
        public int ShelterId { get; set; }
    }

    public class Cat : Animal
    {
        public bool Declawed { get; set; }

    }

    public class Dog : Animal
    {
        public bool Barker { get; set; }

    }

    public class Other : Animal
    {
        public string Description { get; set; }
        public bool Kind { get; set; }

    }
}