// See https://aka.ms/new-console-template for more information
using game1401_la_starter;

Console.WriteLine("Hello, World!");

FirePokemon Charazard = new FirePokemon("Charazard");
GrassPokemon LeafyGuy = new GrassPokemon("Leafy Guy");

FightInterface fightInterface = new FightInterface();

fightInterface.player1Pokemon = Charazard;
fightInterface.player2Pokemon = LeafyGuy;

fightInterface.PlayerInput();