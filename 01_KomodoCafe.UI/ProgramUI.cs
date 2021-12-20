using _01_KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe.UI
{
    public class ProgramUI
    {
        private readonly MenutItemRepository _menuRepo;

        public ProgramUI()
        {
            _menuRepo = new MenutItemRepository();
        }
        public void Run()
        {
            Seed();
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Komodo's Menu UI\n" +
                    "1. Add a Menu Item\n" +
                    "2. View All Existing Menu Items\n" +
                    "3. Delete an Existing Menu Item\n" +
                    "500. Exit Komodo's Menu UI");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddAMenuItem();
                        break;
                    case "2":
                        ViewAllExistingMenuItems();
                        break;
                    case "3":
                        DeleteAnExistingMenuItem();
                        break;
                    case "500":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Selection");
                        WaitForKey();
                        break;
                }
            }
        }

        private void AddAMenuItem()
        {
            Console.Clear();
            MenuItems menuItems = new MenuItems();

            Console.Write("Please enter the new menu item's number: ");
            string mealNumber = Console.ReadLine();
            double mealNum = Convert.ToDouble(mealNumber);
            menuItems.MealNumber = mealNum;

            Console.Write("Please enter the new menu item's name: ");
            string mealName = Console.ReadLine();
            menuItems.MealName = mealName;

            Console.Write("Please enter the new menu item's description: ");
            string mealDescription = Console.ReadLine();
            menuItems.MealDescription = mealName;

            Console.Write("Please enter the new menu item's ingredients: ");
            string mealIngredients = Console.ReadLine();
            menuItems.MealIngredients = mealName;

            Console.Write("Please enter the new menu item's price: ");
            string mealPrice = Console.ReadLine();
            int mealCost = Convert.ToInt32(mealPrice);
            menuItems.MealPrice = mealCost;

            _menuRepo.AddMealToMenu(menuItems);
        }

        private void ViewAllExistingMenuItems()
        {
            Console.Clear();
            Console.WriteLine("All existing menu items: ");
            List<MenuItems> menuItems = _menuRepo.GetAllMeals();
            foreach (MenuItems menuItem in menuItems)
            {
                DisplayMenuItemList(menuItem);
            }
            WaitForKey();
        }

        private void DisplayMenuItemList(MenuItems menuItem)
        {
            Console.WriteLine($"{menuItem.MealNumber} ({menuItem.MealName})\n" +
                $"{menuItem.MealDescription}\n" +
                $"{menuItem.MealIngredients}\n" +
                $"${menuItem.MealPrice}\n" +
                $"=======================================================================");
        }

        private void DeleteAnExistingMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Which item would you like to remove?");

            int index = 0;
            List<MenuItems> menuItems = _menuRepo.GetAllMeals();
            foreach (MenuItems item in menuItems)
            {
                Console.Write($"{index + 1}. ");
                DisplayMenuItemList(item);
                index++;
            }
            string optionString = Console.ReadLine();
            int option = Convert.ToInt32(optionString);

            MenuItems itemToDelete = menuItems[option - 1];

            Console.WriteLine("Are you sure you want to delete this? (y/n)");
            DisplayMenuItemList(itemToDelete);
            if (Console.ReadLine() == "y")
            {
                _menuRepo.DeleteExistingMeal(itemToDelete);
                Console.WriteLine("Item deleted!");
            }
            else
            {
                Console.WriteLine("Canceled");
            }
            WaitForKey();
        }

        private void WaitForKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void Seed()
        {
            MenuItems cheeseBurger = new MenuItems();
            cheeseBurger.MealNumber = 1;
            cheeseBurger.MealName = "Cheeseburger";
            cheeseBurger.MealDescription = "An All-American Classic burger with cheese.";
            cheeseBurger.MealIngredients = "Bun, hamburger patty, cheese";
            cheeseBurger.MealPrice = 5;
            _menuRepo.AddMealToMenu(cheeseBurger);

            MenuItems salad = new MenuItems();
            salad.MealNumber = 2;
            salad.MealName = "Salad";
            salad.MealDescription = "A healthy option for those worried about their waist-line.";
            salad.MealIngredients = "lettuce, dressing, cheese, carrots, tomatoe, egg";
            salad.MealPrice = 7;
            _menuRepo.AddMealToMenu(salad);

            MenuItems fries = new MenuItems();
            fries.MealNumber = 3;
            fries.MealName = "Fries";
            fries.MealDescription = "The perfect compliment to any meal.";
            fries.MealIngredients = "potatoes";
            fries.MealPrice = 2;
            _menuRepo.AddMealToMenu(fries);
        }
    }
}
