using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPocos
{
    public class Menu
    {
        public Menu(string foodName, string foodDesc, string foodIng, double foodPrice, int comboNumber)
        {
            FoodName = foodName;
            FoodDesc = foodDesc;
            FoodIng = foodIng;
            FoodPrice = foodPrice;
            ComboNumber = comboNumber;
        }
        public string FoodName { get; set;}
        public string FoodDesc { get; set;}
        public string FoodIng { get; set;}
        public double FoodPrice { get; set; }
        public int ComboNumber { get; set; }
    }
}
