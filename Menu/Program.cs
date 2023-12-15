using Menu.Classes_Interfaces;
using Menu.Data;
using Menu.Repository;
using System.Text.Json;

bool isWroking = true;
var menuRepository = new MenuSqlRepository<rezMenu>(new MenuDbContext());
menuRepository.AddedItem += AddEventItemToList;
menuRepository.RemovedItem += RemoveEventItemToList;

while (isWroking)
{
	Console.Clear();
	Greeting();
	string optionSelected = optionSelectedMethod();
	isWroking = selectingWhatUserWishesToDoMethod(isWroking, optionSelected, menuRepository);
	Console.ReadKey();
}
//--------------------------------------------------------------------------------------------------------------------------------------------------------------
void AddEventItemToList(object? sender, rezMenu e)
{
	const string addedItemEvent = "AddedItemEvent.json";
	List<string> addedItemEventList = new List<string>();
	string jsonAddedItemEventList;
	if (File.Exists(addedItemEvent))
	{
		jsonAddedItemEventList = File.ReadAllText(addedItemEvent);
		addedItemEventList = JsonSerializer.Deserialize<List<string>>(jsonAddedItemEventList);
	}
	string itemAdded = $"Date Added: {DateTime.Now}, Menu Item: {e.itemName}, Menu Price: {e.itemPrice}, From: {sender.GetType().Name}";
	addedItemEventList.Add(itemAdded);
	jsonAddedItemEventList = JsonSerializer.Serialize(addedItemEventList);
	File.WriteAllText(addedItemEvent, jsonAddedItemEventList);
}
void RemoveEventItemToList(object? sender, rezMenu e)
{
	const string removedItemEvent = "RemovedItemEvent.json";
	List<string> removedItemEventList = new List<string>();
	string jsonRemovedItemEventList;
	if (File.Exists(removedItemEvent))
	{
		jsonRemovedItemEventList = File.ReadAllText(removedItemEvent);
		removedItemEventList = JsonSerializer.Deserialize<List<string>>(jsonRemovedItemEventList);
	}
	string itemRemoved = $"Date Removed: {DateTime.Now}, Menu Item: {e.itemName}, Menu Price: {e.itemPrice}, From: {sender.GetType().Name}";
	removedItemEventList.Add(itemRemoved);
	jsonRemovedItemEventList = JsonSerializer.Serialize(removedItemEventList);
	File.WriteAllText(removedItemEvent, jsonRemovedItemEventList);
}
//--------------------------------------------------------------------------------------------------------------------------------------------------------------
void Greeting()
{
	Console.WriteLine(
		$"Welcome to Soylent Green Cafe where our Customer is our specialty!! {Environment.NewLine}" +
		$"I will be your host Jenna {Environment.NewLine}" +
		$"{Environment.NewLine}" +
		$"How may I assist you from the following options? {Environment.NewLine}" +
		$"{Environment.NewLine}" +
		$"[View] the Menu {Environment.NewLine}" +
		$"[Add] new item to the menu {Environment.NewLine}" +
		$"[Remove] an item from the menu {Environment.NewLine}" +
		$"[Exit] Soylent Green Cafe {Environment.NewLine}" +
		$"{Environment.NewLine}" +
		$"Input preferred choice within []?"
		);
}
static string optionSelectedMethod() => Console.ReadLine().ToLower();
bool selectingWhatUserWishesToDoMethod(bool isWroking, string optionSelected, MenuSqlRepository<rezMenu> menuRepository)
{
	switch (optionSelected)
	{
		case "view":
			ViewMenuGeneralMethod(menuRepository);
			break;
		case "add":
			AddToMenuMethod(menuRepository);
			break;
		case "remove":
			RemoveFromMenuMethod(menuRepository);
			break;
		case "exit":
			Console.WriteLine("Thank you for trying Soylent Green Cafe where our Customers are our specialty!");
			isWroking = false;
			break;
		default:
			Console.WriteLine("Incorrect input, please try again.");
			break;

	}
	return isWroking;
}
//--------------------------------------------------------------------------------------------------------------------------------------------------------------
void ViewMenuGeneralMethod(IRepository<rezMenu> menuRepository)
{
	Console.Clear() ;
	MenuGreeting();
	ViewMenu(menuRepository);
}
void MenuGreeting()
{
    Console.WriteLine($"Thank you for dining at Soylent Green Cafe where our Customer is our specialty!!{Environment.NewLine}" +
		$"Please take a look at our menu!! {Environment.NewLine}"
		);
}
void ViewMenu(IReadRepository<IMenu> menuRepository)
{
	var items = menuRepository.GetAll();
	foreach (var item in items)
	{	
		Console.WriteLine(item.Id + ". " + item.itemName + " " + item.itemPrice);	
	}
}
//--------------------------------------------------------------------------------------------------------------------------------------------------------------
void AddToMenuMethod(MenuSqlRepository<rezMenu> menuRepository)
{
	bool isWorking = true;
	while (isWorking)
	{
		Console.Clear();
		WhatToAddText();
		string optionToAddSelected = optionToAddSelectedMethod();
		selectingWhatToAddToTheMenuMethod(optionToAddSelected, menuRepository);
		isWorking = ContinueAddingMethod(isWorking);
	}
}
void WhatToAddText()
{
	Console.WriteLine(
		$"What would you like to add to the menu? {Environment.NewLine}" +
		$"A [Drink]? {Environment.NewLine}" +
		$"A [Meal] {Environment.NewLine}"
		);
}
string optionToAddSelectedMethod() => Console.ReadLine().ToLower();
void selectingWhatToAddToTheMenuMethod(string optionToAddSelected, MenuSqlRepository<rezMenu> menuRepository)
{
	bool isWorkingSubLoop = true;
	while (isWorkingSubLoop)
	{
		switch (optionToAddSelected)
		{
			case "drink":
				AddDrinkMethod(menuRepository);
				isWorkingSubLoop = false;
				break;
			case "meal":
				AddMealMethod(menuRepository);
				isWorkingSubLoop = false;
				break;
			default:
				Console.WriteLine("You entered an invalid option, please try again");
				optionToAddSelected = optionToAddSelectedMethod();
				isWorkingSubLoop = true;
				Console.ReadKey();
				break;
		}
	}

}
void AddDrinkMethod(IWriteRepository<Drinks> drinkRepository)
{
	Console.WriteLine($"What is the drinks name? {Environment.NewLine}");
	string nameOfDrink = NamingDrinkMethod();
	Console.WriteLine($"What is the drinks price? {Environment.NewLine}");
	float priceOfDrink = PriceDrinkMethod();
	drinkRepository.Add(new Drinks { itemName = nameOfDrink, itemPrice = priceOfDrink });
	drinkRepository.Save();
}
string NamingDrinkMethod() => Console.ReadLine();
float PriceDrinkMethod() => float.Parse(Console.ReadLine());
void AddMealMethod(IWriteRepository<Food> mealRepository)
{
	Console.WriteLine($"What is the meals name? {Environment.NewLine}");
	string nameOfMeal = NamingMealMethod();
	Console.WriteLine($"What is the meals price? {Environment.NewLine}");
	float priceOfMeal = PriceMealMethod();
	mealRepository.Add(new Food { itemName = nameOfMeal, itemPrice = priceOfMeal });
	mealRepository.Save();
}
string NamingMealMethod() => Console.ReadLine();
float PriceMealMethod() => float.Parse(Console.ReadLine());
bool ContinueAddingMethod(bool isWorking)
{
	bool isWorkingSubLoop = true;
	Console.WriteLine("Would you like to request another item to the menu? Y/N");
	while (isWorkingSubLoop)
	{
		string willContinue = Console.ReadLine().ToLower();
		if (willContinue == "y")
		{
			isWorking = true;
			isWorkingSubLoop = false;
		}
		else if (willContinue == "n")
		{
			isWorking = false;
			isWorkingSubLoop = false;
		}
		else
		{
			isWorkingSubLoop = true;
			Console.WriteLine("Please write y for yes and n for no");
		}
	}
	return isWorking;
}
//--------------------------------------------------------------------------------------------------------------------------------------------------------------
void RemoveFromMenuMethod(MenuSqlRepository<rezMenu> menuRepository)
{
	bool isWorking = true;
	while (isWorking)
	{
		Console.Clear();
		WhatToRemoveText(menuRepository);
		int optionToRemoveSelected = optionToRemoveSelectedMethod();
		selectingWhatToRemoveFromTheMenuMethod(optionToRemoveSelected, menuRepository);
		isWorking = ContinueRemovingMethod(isWorking);
	}
}
void WhatToRemoveText(MenuSqlRepository<rezMenu> menuRepository)
{
    Console.WriteLine("Which item # would you like to remove from our menu?");
	ViewMenu(menuRepository);
}
int optionToRemoveSelectedMethod() => int.Parse(Console.ReadLine());
void selectingWhatToRemoveFromTheMenuMethod(int optionToRemoveSelected, IRepository<rezMenu> menuRepository)
{
	var item = menuRepository.GetSpecific(optionToRemoveSelected);
	menuRepository.RemoveItem(item);
	menuRepository.Save();
}
bool ContinueRemovingMethod(bool isWorking)
{
	bool isWorkingSubLoop = true;
	Console.WriteLine("Would you like to continue removing items? y/n");
	while (isWorkingSubLoop)
	{
		string willContinue = Console.ReadLine().ToLower();
		if (willContinue == "y")
		{
			isWorking = true;
			isWorkingSubLoop = false;
		}
		else if (willContinue == "n")
		{
			isWorking = false;
			isWorkingSubLoop = false;
		}
		else
		{
			isWorkingSubLoop = true;
			Console.WriteLine("Please write y for yes and n for no");
		}
	}
	return isWorking;
}
//--------------------------------------------------------------------------------------------------------------------------------------------------------------