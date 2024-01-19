using CLIGameEngine;
using static Level_17_SimulasSoup.SimulasSoup;

namespace Level_17_SimulasSoup
{
    public class SimulasSoup : Game
    {
        private (FoodType Type, MainIngredient MainIngredient, Seasoning Seasoning) _currentSoup;
        public SimulasSoup() : base() {  }
        protected override void Update()
        {
            Console.WriteLine("Place your order, ");

            AddToOrder (
                gameEngine.MenuOptions(new FoodType(), "What type of Food would you like?"),
                new FoodType()
            );
            Console.Clear();

            AddToOrder(
                gameEngine.MenuOptions(new MainIngredient(), "What would you like for a main ingredient?"),
                new MainIngredient()
            );
            Console.Clear();

            AddToOrder(
                gameEngine.MenuOptions(new Seasoning(), "How would you like it seasoned?"),
                new Seasoning()
            );
            Console.Clear();

            Console.WriteLine($"Here is your soup: {_currentSoup.Seasoning} {_currentSoup.MainIngredient} {_currentSoup.Type}");
            gameEngine.EndGame();
        }

        private void AddToOrder(string currentGuess, Enum type)
        {
            Type tempType = type.GetType();
            
            if (tempType == typeof(FoodType))
            {
                Enum.TryParse(currentGuess, out FoodType foodType);
                _currentSoup.Type = foodType;
            }
            if (tempType == typeof(MainIngredient))
            {
                Enum.TryParse(currentGuess, out MainIngredient mainIngredient);
                _currentSoup.MainIngredient = mainIngredient;
            }
            if (tempType == typeof(Seasoning))
            {
                Enum.TryParse(currentGuess, out Seasoning seasoning);
                _currentSoup.Seasoning = seasoning;
            }
        }

        public enum FoodType
        {
            Soup,
            Stew,
            Gumbo
        }
        public enum MainIngredient
        {
            Mushroom,
            Chicken,
            Carrot,
            Potatoe
        }
        public enum Seasoning
        {
            Spicy,
            Salty,
            Sweet
        }
    }
}
