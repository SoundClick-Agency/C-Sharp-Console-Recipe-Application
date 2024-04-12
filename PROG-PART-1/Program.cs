using System;

namespace RecipeProgram
{
    class Recipe
    {
        private Ingredient[] ingredients; // store ingredients (array)
        private string[] steps; //store steps (array)

        // Constructor to Use arrays
        public Recipe()
        {
            ingredients = new Ingredient[0];
            steps = new string[0];
        }







        // enter recipe details
        public void EnterDetails()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("Enter the number of ingredients:");
            int ingredientCount = Convert.ToInt32(Console.ReadLine());
            ingredients = new Ingredient[ingredientCount];

            // input ingredient details - loop
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                string name = Console.ReadLine();

                Console.WriteLine($"Enter the quantity of {name}:");
                double quantity = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine($"Enter the unit of measurement for {name}:");
                string unit = Console.ReadLine();

                ingredients[i] = new Ingredient(name, quantity, unit);
            }

            Console.WriteLine("Enter the number of steps:");
            int stepCount = Convert.ToInt32(Console.ReadLine());
            steps = new string[stepCount];

            // input steps - loop
            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                steps[i] = Console.ReadLine();
            }
            Console.WriteLine("***************************************************");
        }

        //display recipe details
        public void DisplayRecipe()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("Recipe:");
            Console.WriteLine("Ingredients:");

            // Display ingredients
            foreach (Ingredient ingredient in ingredients)
            {
                Console.WriteLine(ingredient.ToString());
            }

            Console.WriteLine("Steps:");

            // Display steps
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
            Console.WriteLine("***************************************************");
        }

        //scale recipe quantities
        public void ScaleRecipe(double factor)
        {
            // Scale quantities of ingredients and display
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ScaleQuantity(factor);
                Console.WriteLine(ingredient.ToString());
            }
        }

        // reset ingredient quantities to original values
        public void ResetQuantities()
        {
            // Reset quantities of ingredients and display
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.ResetQuantity();
                Console.WriteLine(ingredient.ToString());
            }
        }

        // Method to clear recipe data
        public void ClearData()
        {
            // Clear arrays
            ingredients = new Ingredient[0];
            steps = new string[0];
        }
    }

    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        private readonly double originalQuantity;

        public Ingredient(string name, double quantity, string unit)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            originalQuantity = quantity;
        }

        public void ScaleQuantity(double factor)
        {
            Quantity *= factor;
        }

        public void ResetQuantity()
        {
            Quantity = originalQuantity;
        }

        public override string ToString()
        {
            return $"{Quantity} {Unit} of {Name}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            while (true)
            {
                // menu options
                Console.WriteLine("***************************************************");
                Console.WriteLine("Recipe Application");
                Console.WriteLine("***************************************************");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear data");
                Console.WriteLine("6. Exit");
                Console.WriteLine("***************************************************");

                // Get user choice
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
                {
                    Console.WriteLine("**********************************************************");
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    Console.WriteLine("**********************************************************");
                    continue;
                }

                // Perform action based on user choice
                switch (choice)
                {
                    case 1:
                        recipe.EnterDetails();
                        break;
                    case 2:
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        Console.WriteLine("***************************************************");
                        Console.WriteLine("Enter scaling factor (0.5, 2, or 3):");
                        double factor;
                        if (!double.TryParse(Console.ReadLine(), out factor) || (factor != 0.5 && factor != 2 && factor != 3))
                        {
                            Console.WriteLine("Invalid scaling factor. Please enter 0.5, 2, or 3.");
                            continue;
                        }
                        recipe.ScaleRecipe(factor);
                        break;
                    case 4:
                        recipe.ResetQuantities();
                        break;
                    case 5:
                        recipe.ClearData();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
