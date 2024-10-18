using Assignment_02.Models;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_02.Services
{
	public class RecipeService
	{
		private List<Recipe> _recipes; // Use private access modifier
		public RecipeService() // Corrected the constructor name
		{
			_recipes = new List<Recipe>
	{
new Recipe
{
	Id = 1,
	Name = "Pancakes",
	Ingredients = new List<string> { "Flour", "Eggs", "Milk" },
	Instructions = "Mix and cook",
	Category = "Breakfast",
	ImageUrl = "/images/Pancake.png", // Use the relative path
    Description = "A quick breakfast recipe"
},

		new Recipe
		{
			Id = 2,
			Name = "Spaghetti",
			Ingredients = new List<string> { "Pasta", "Tomato Sauce" },
			Instructions = "Boil pasta, add sauce",
			Category = "Lunch",
			ImageUrl = "/images/spagi.png",
            Description = "A quick lunch option"
		},
		new Recipe
		{
			Id = 3,
			Name = "Grilled Chicken",
			Ingredients = new List<string> { "Chicken", "Olive Oil", "Herbs" },
			Instructions = "Grill the chicken",
			Category = "Dinner",
			ImageUrl = "/images/chicki.png",
            Description = "Perfect for a family dinner"
		},
		new Recipe
		{
			Id = 4,
			Name = "Caesar Salad",
			Ingredients = new List<string> { "Lettuce", "Croutons", "Caesar dressing" },
			Instructions = "Toss all ingredients together",
			Category = "Salad",
			ImageUrl = "/images/salad.png",
            Description = "A fresh salad for any meal"
		},
		new Recipe
		{
			Id = 5,
			Name = "Tacos",
			Ingredients = new List<string> { "Taco shells", "Ground beef", "Cheese", "Lettuce", "Tomato" },
			Instructions = "Fill taco shells with ingredients",
			Category = "Dinner",
			ImageUrl = "/images/Tacos.png",
            Description = "A fun and customizable dinner option"
		},
		new Recipe
		{
			Id = 6,
			Name = "Chocolate Chip Cookies",
			Ingredients = new List<string> { "Flour", "Sugar", "Butter", "Chocolate Chips" },
			Instructions = "Mix and bake",
			Category = "Dessert",
			ImageUrl = "/images/chip.png",
            Description = "A classic sweet treat"
		},
		new Recipe
		{
			Id = 7,
			Name = "Vegetable Stir Fry",
			Ingredients = new List<string> { "Mixed vegetables", "Soy sauce", "Ginger", "Garlic" },
			Instructions = "Stir fry all ingredients",
			Category = "Lunch",
			ImageUrl = "/images/vege.png",
            Description = "A quick and healthy meal"
		},
		new Recipe
		{
			Id = 8,
			Name = "Omelette",
			Ingredients = new List<string> { "Eggs", "Cheese", "Vegetables" },
			Instructions = "Whisk eggs and cook with fillings",
			Category = "Breakfast",
			ImageUrl = "/images/omi.png",
            Description = "A versatile breakfast option"
		},
		new Recipe
		{
			Id = 9,
			Name = "Beef Stroganoff",
			Ingredients = new List<string> { "Beef", "Mushrooms", "Onions", "Sour cream" },
			Instructions = "Cook beef and serve with sauce",
			Category = "Dinner",
			ImageUrl = "/images/beef.png",
            Description = "A hearty meal perfect for winter"
		},
		new Recipe
		{
			Id = 10,
			Name = "Margarita Pizza",
			Ingredients = new List<string> { "Pizza dough", "Tomato sauce", "Mozzarella cheese", "Basil" },
			Instructions = "Assemble and bake",
			Category = "Dinner",
			ImageUrl = "/images/pizza.png",
            Description = "A classic Italian dish"
		}
	};
		}


		// Returns a list of all recipes
		public List<Recipe> GetAllRecipes()
		{
			return _recipes;
		}

		// Returns a single recipe based on its ID
		public Recipe GetRecipeById(int id)
		{
			return _recipes.FirstOrDefault(r => r.Id == id);
		}

		// Adds a new recipe to the list
		public void AddRecipe(Recipe newRecipe)
		{
			newRecipe.Id = _recipes.Any() ? _recipes.Max(r => r.Id) + 1 : 1; // Check if _recipes is empty
			_recipes.Add(newRecipe);
		}

		// Deletes a recipe based on its ID
		public void DeleteRecipe(int id)
		{
			var recipe = _recipes.FirstOrDefault(r => r.Id == id);
			if (recipe != null)
			{
				_recipes.Remove(recipe);
			}
		}

		// Updates an existing recipe
		public void UpdateRecipe(Recipe recipe)
		{
			var existingRecipe = _recipes.FirstOrDefault(r => r.Id == recipe.Id); // Renamed variable for clarity
			if (existingRecipe != null)
			{
				existingRecipe.Name = recipe.Name;
				existingRecipe.Category = recipe.Category;
				existingRecipe.Ingredients = recipe.Ingredients;
				existingRecipe.Instructions = recipe.Instructions;
				existingRecipe.ImageUrl = recipe.ImageUrl;
				existingRecipe.Description = recipe.Description;
			}
		}

		// Searches for recipes based on a search term
		public List<Recipe> SearchRecipe(string searchTerm)
		{
			if (string.IsNullOrEmpty(searchTerm))
			{
				return _recipes; // If search term is empty, return all recipes
			}
			return _recipes.Where(r => r.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
		}

		// Returns recipes filtered by category
		public List<Recipe> GetRecipesByCategory(string category)
		{
			if (string.IsNullOrEmpty(category)) // Simplified condition
			{
				return _recipes; // If category is empty, return all recipes
			}
			return _recipes.Where(r => r.Category.ToLower() == category.ToLower()).ToList(); // Added ToLower for case-insensitivity
		}
	}
}
