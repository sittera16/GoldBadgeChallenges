using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repository
{
    public class MenuItems
    {
        public MenuItems() { }
        public MenuItems
        (
            double mealNumber,
            string mealName,
            string mealDescription,
            string mealIngredients,
            int mealPrice
        )
        {
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDescription;
            MealIngredients = mealIngredients;
            MealPrice = mealPrice;
        }
        public double MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string MealIngredients { get; set; }
        public int MealPrice { get; set; }
    }

}
