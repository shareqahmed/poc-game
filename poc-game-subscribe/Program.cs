// See https://aka.ms/new-console-template for more information
using poc_game_subscribe;

Console.WriteLine("Hello, World!");
var gameService = new GameStateService();
gameService.Init(20, 20);
Console.WriteLine($"Initialize: Coins = {gameService.State.Coins}, Stars = {gameService.State.Stars}");

Console.WriteLine("Starting transaction: Buying 5 stars for 10 coins.");
gameService.BuyStars(5, 5);
Console.WriteLine("Transaction completed.");

Console.WriteLine($"Final State: Coins = {gameService.State.Coins}, Stars = {gameService.State.Stars}");
