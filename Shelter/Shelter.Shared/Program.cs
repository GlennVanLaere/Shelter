using System;
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

            shelter.Cats = new List<Cat>();
            shelter.Cats = new Cat() { Declawed = 0, Race = "naaktkat"});

            shelter.Cats.ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Declawed} - {x.Race}");
            });
        }
    }

    public class Shelter
    {
        public string Name { get; set; }
    }

    public class Person
    {
        public string FullName => $"{Lastname}, ${FirstName}";
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }

    public class Manager
    {

    }

    public class CareTaker
    {
        public Animal TakesCareOf { get; set; }
    }

    public class Administrator
    {

    }

    public class Animal
    {
        public string Name { get; set; }
        public int DateOfBirth { get; set; }
        public bool IsChecked { get; set; }
        public bool KidFriendly { get; set; }
        public DateTime Since { get; set; }
    }

    public class Cat
    {
        public bool Declawed { get; set; }
        public string Race { get; set; }
    }

    public class Dog
    {
        public bool Barker { get; set; }
        public string Race { get; set; }
    }
}