using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repository
{
    public class MenutItemRepository
    {
        public List<MenuItems> _menuItems = new List<MenuItems>();

        public bool AddMealToMenu(MenuItems meal)
        {
            int startingCount = _menuItems.Count;
            _menuItems.Add(meal);

            bool wasAdded = (_menuItems.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<MenuItems> GetAllMeals()
        {
            return _menuItems;
        }

        public List<MenuItems> GetAllMealsByMealNumber(double mealNumber)
        {
            List<MenuItems> foundMeals = new List<MenuItems>();
            foreach (MenuItems meal in _menuItems)
            {
                if (meal.MealNumber == mealNumber)
                {
                    foundMeals.Add(meal);
                }
            }
            return foundMeals;
        }

        public bool DeleteExistingMeal(MenuItems existingMeal)
        {
            bool deleteResult = _menuItems.Remove(existingMeal);
            return deleteResult;
        }
    }
}
