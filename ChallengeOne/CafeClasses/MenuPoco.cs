using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafePoco
{
    public enum Ingredients
    {
        Beef = 1,
        Chicken,
        BBQPork,
        Onion,
        Cheese,
        Lettuce,
        Tomato,
        Pickle

    }
    public class MenuItem
    {

        public MenuItem() { }
        public MenuItem(int comboNumber, string mealName, string description, List<Ingredients> ingredients, decimal price)
        {
            ComboNumber = comboNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
        public int ComboNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<Ingredients> Ingredients { get; set; } = new List<Ingredients>();
        public decimal Price { get; set; }
    }
}