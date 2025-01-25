using System;
using System.Collections.Generic;

namespace ZooManagementSystem
{
    public class Animal
    {
        private static int idCounter = 0; // متغیر استاتیک برای شماره‌گذاری
        private int id; // شناسه هر حیوان

        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public string SpecialFeatures { get; set; }
        public int Quantity { get; set; }

        // سازنده
        public Animal(string name, string species, int age, string specialFeatures, int quantity)
        {
            this.id = ++idCounter; // افزایش شماره و تخصیص به شناسه
            this.Name = name;
            this.Species = species;
            this.Age = age;
            this.SpecialFeatures = specialFeatures;
            this.Quantity = quantity;
        }

        public int GetId()
        {
            return id;
        }

        public override string ToString()
        {
            return $"ID: {id}, Name: {Name}, Species: {Species}, Age: {Age}, Special Features: {SpecialFeatures}, Quantity: {Quantity}";
        }
    }

    public class Zoo
    {
        private List<Animal> animals = new List<Animal>();

        public void AddAnimal(Animal animal)
        {
            animals.Add(animal);
            Console.WriteLine("Animal added successfully!");
        }

        public void DisplayAnimals()
        {
            Console.WriteLine("List of Animals in the Zoo:");
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        public void ViewAnimalDetails(int id)
        {
            var animal = animals.Find(a => a.GetId() == id);
            if (animal != null)
            {
                Console.WriteLine(animal);
            }
            else
            {
                Console.WriteLine("Animal not found!");
            }
        }

        public void EditAnimal(int id, string name, string species, int age, string specialFeatures, int quantity)
        {
            var animal = animals.Find(a => a.GetId() == id);
            if (animal != null)
            {
                animal.Name = name;
                animal.Species = species;
                animal.Age = age;
                animal.SpecialFeatures = specialFeatures;
                animal.Quantity = quantity;
                Console.WriteLine("Animal details updated successfully!");
            }
            else
            {
                Console.WriteLine("Animal not found!");
            }
        }

        public void DeleteAnimal(int id)
        {
            var animal = animals.Find(a => a.GetId() == id);
            if (animal != null)
            {
                animals.Remove(animal);
                Console.WriteLine("Animal deleted successfully!");
            }
            else
            {
                Console.WriteLine("Animal not found!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            // منوی اصلی
            while (true)
            {
                Console.WriteLine("\nZoo Management System");
                Console.WriteLine("1. Add Animal");
                Console.WriteLine("2. View All Animals");
                Console.WriteLine("3. View Animal Details");
                Console.WriteLine("4. Edit Animal");
                Console.WriteLine("5. Delete Animal");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // افزودن حیوان جدید
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Species: ");
                        string species = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Enter Special Features: ");
                        string specialFeatures = Console.ReadLine();
                        Console.Write("Enter Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());

                        Animal newAnimal = new Animal(name, species, age, specialFeatures, quantity);
                        zoo.AddAnimal(newAnimal);
                        break;

                    case 2:
                        // مشاهده لیست تمامی حیوانات
                        zoo.DisplayAnimals();
                        break;

                    case 3:
                        // مشاهده جزئیات یک حیوان خاص
                        Console.Write("Enter Animal ID: ");
                        int idToView = int.Parse(Console.ReadLine());
                        zoo.ViewAnimalDetails(idToView);
                        break;

                    case 4:
                        // ویرایش اطلاعات یک حیوان
                        Console.Write("Enter Animal ID to Edit: ");
                        int idToEdit = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter New Species: ");
                        string newSpecies = Console.ReadLine();
                        Console.Write("Enter New Age: ");
                        int newAge = int.Parse(Console.ReadLine());
                        Console.Write("Enter New Special Features: ");
                        string newSpecialFeatures = Console.ReadLine();
                        Console.Write("Enter New Quantity: ");
                        int newQuantity = int.Parse(Console.ReadLine());

                        zoo.EditAnimal(idToEdit, newName, newSpecies, newAge, newSpecialFeatures, newQuantity);
                        break;

                    case 5:
                        // حذف یک حیوان
                        Console.Write("Enter Animal ID to Delete: ");
                        int idToDelete = int.Parse(Console.ReadLine());
                        zoo.DeleteAnimal(idToDelete);
                        break;

                    case 6:
                        // خروج از برنامه
                        return;

                    default:
                        Console.WriteLine("Invalid option! Please try again.");
                        break;
                }
            }
        }
    }
}
