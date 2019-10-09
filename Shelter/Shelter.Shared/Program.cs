using System;
using System.Collections.Generic;
using System.Linq;

namespace Shelter.Shared
{
    class Program
    {
        static void Main(string[] args)
        {
            var shelter = new Shelter()
            {
                Name = "Our shelter"
            };

            Console.WriteLine($"TEST");

            shelter.Animals = new List<Animal>();
            shelter.Animals.Add(new Cat() { Name = "Poes", DateOfBirth = new DateTime(2000,02,14), IsChecked = true, KidFriendly = false, Since = DateTime.Now, Declawed = true, Race = "Hairless Sphynx"});

            shelter.Cats.ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Name} - {x.DateOfBirth} - {x.Declawed}");
            });
    
        }
    }

    public class Shelter
    {
        public string Name { get; set; }
        public ICollection<Animal> Animals { get; set; }

        public ICollection<Cat> Cats => Animals.OfType<Cat>().ToList();
    }

    public class Person
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

    public class Animal
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsChecked { get; set; }
        public bool KidFriendly { get; set; }
        public DateTime Since { get; set; }
    }

    public class Cat : Animal
    {
        public bool Declawed { get; set; }
        public string Race { get; set; }
    }

    public class Dog : Animal
    {
        public bool Barker { get; set; }
        public string Race { get; set; }
    }
}