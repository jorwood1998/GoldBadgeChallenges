using CafeClasses;
using CafePoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeUI
{
    public class ProgramUI
    {
        private readonly MenuItemRepository _repo;

        public ProgramUI()
        {
            _repo = new MenuItemRepository();
        }

        public void Run()
        {
            Seed();
            RunApplication();
        }


        public void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Komodo Cafe\n" +
                    "1. Add A Menu Item \n" +
                    "2. View All Menu Items \n" +
                    "3. Delete Menu Item \n" +
                    "4. Quit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        ViewAllMenuItems();
                        break;
                    case "3":
                        RemoveMenuItems();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        WaitForKey();
                        break;
                }
                Clear();

            }

        }
        private void AddMenuItem()
        {
            Clear();
            Console.WriteLine("Food Items Available");
            MenuItem menuItems = new MenuItem();

            Console.Write("Please enter a Meal Name: ");
            menuItems.MealName = Console.ReadLine();

            Console.Write("Please enter a description for the meal: ");
            menuItems.Description = Console.ReadLine();

            bool hasAddedAllIngredients = false;
            while (hasAddedAllIngredients == false)
            {
                Console.Write("Please enter the ingredients for the meal: ");

                Console.WriteLine("Available Ingredients: \n" +
                    "1. Beef \n" +
                    "2. Chicken \n" +
                    "3. BBQPork \n" +
                    "4. Onion \n" +
                    "5. Cheese \n" +
                    "6. Lettuce \n" +
                    "5. Tomato \n" +
                    "6. Pickle \n");

                int userInput2 = int.Parse(Console.ReadLine());
                menuItems.Ingredients.Add((Ingredients)userInput2);
                Console.WriteLine("Do you want to add another ingredient y/n?");
                string userInput3 = Console.ReadLine();
                if (userInput3 == "Y".ToLower())
                {
                    continue;
                }
                else
                {
                    hasAddedAllIngredients = true;
                }
            }




            Console.Write("Please enter a price for the meal: ");
            menuItems.Price = Convert.ToDecimal(Console.ReadLine());
            _repo.AddMenuItem(menuItems);

        }

        private void ViewAllMenuItems()
        {
            Clear();
            Console.WriteLine("Menu items available:");
            List<MenuItem> foodItems = _repo.GetAllMenuItems();
            foreach (MenuItem item in foodItems)
            {
                DisplayContentListItem(item);
            }

            WaitForKey();
        }

        private void DisplayContentListItem(MenuItem foodItems)
        {
            Console.WriteLine($"\n" +
                $"Food Item Name: {foodItems.MealName} \n" +
                $"Food Item Description: {foodItems.Description}\n" +
                $"Food Item Price: {foodItems.Price}\n" +
                $"Combo Number: {foodItems.ComboNumber}");
            GetContentIngredients(foodItems);
        }

        private void RemoveMenuItems()
        {
            Clear();
            ViewAllMenuItems();
            Console.WriteLine("Please input the combo number you wish to remove");
            MenuItem item = _repo.GetMenuItem(int.Parse(Console.ReadLine()));
            if (item != null)
            {
                var success = _repo.DeleteExsistingMenuItem(item);
                if (success)
                {
                    Console.WriteLine("removed");
                }
                else
                {
                    Console.WriteLine("failed to remove");
                }
            }
            Console.WriteLine($"The menu item does not exist");

        }
        private void Seed()
        {
            MenuItem bbq = new MenuItem();
            bbq.ComboNumber = 1;
            bbq.MealName = "BBQ n Cheese";
            bbq.Description = "Two of the best things on earth";
            bbq.Price = 300.95m;
            bbq.Ingredients = new List<Ingredients> { Ingredients.BBQPork, Ingredients.Cheese };
            _repo.AddMenuItem(bbq);

            MenuItem nasty = new MenuItem();
            nasty.ComboNumber = 2;
            nasty.MealName = "Nasty meal";
            nasty.Description = "just not good";
            nasty.Price = 10.95m;
            nasty.Ingredients = new List<Ingredients> { Ingredients.Onion, Ingredients.Pickle };
            _repo.AddMenuItem(nasty);

        }

        private void GetContentIngredients(MenuItem foodItem)
        {
            Console.WriteLine("Ingredients: ");
            foreach (var item in foodItem.Ingredients)
            {
                Console.WriteLine(item);
            }
        }

        private void WaitForKey()
        {
            Console.ReadKey();
        }

        private void Clear()
        {
            Console.Clear();
        }

    }
}