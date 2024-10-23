using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game1401_la_starter
{
    internal class FightInterface
    {
        private bool isPlayer1 = true;
        private bool isGameWon = false;

        public Pokemon player1Pokemon;
        public Pokemon player2Pokemon;

        private bool didErrorHappen = false;




        public void PlayerInput()
        {
            while (!isGameWon)
            {
                string userInput;
                int input;

                didErrorHappen = false;

                PrintPlayerOptions();

                if (isPlayer1)
                {
                    Console.WriteLine("Player 1 What do you want to do?");
                    userInput = Console.ReadLine();
                    bool works = int.TryParse(userInput, out int result);
                    if (!works)
                    {
                    Console.Clear();
                    Console.WriteLine("incorrect input, please try again");
                    didErrorHappen = true;
                    continue;
                    }
                    else
                    {
                        input = int.Parse(userInput);
                    }
                    switch (input)
                    {
                        case 1: // attack
                            PokemonAttack(player2Pokemon, player1Pokemon);
                            break;
                        case 2: // item
                            player1Pokemon.HealHealth(new Random().Next(10, 40));
                            Console.WriteLine(player1Pokemon.GetName() + " has " + player1Pokemon.GetCurrentHealth() + " health left");
                            break;
                        case 3: // run
                            Console.WriteLine(player1Pokemon.GetName() + " has " + player1Pokemon.GetCurrentHealth() + " health left");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Incorrect Input, please try again");
                            didErrorHappen = true;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Player 2 What do you want to do?");
                    userInput = Console.ReadLine();
                    bool works = int.TryParse(userInput, out int result);
                    if (!works)
                    {
                        Console.Clear();
                        Console.WriteLine("incorrect input, please try again");
                        didErrorHappen = true;
                        continue;
                    }
                    else
                    {
                        input = int.Parse(userInput);
                    }
                    switch (input)
                    {
                        case 1:
                            PokemonAttack(player1Pokemon, player2Pokemon);
                            break;
                        case 2:
                            player1Pokemon.HealHealth(new Random().Next(10, 40));
                            Console.WriteLine(player2Pokemon.GetName() + " has " + player2Pokemon.GetCurrentHealth() + " health left");
                            break;
                        case 3:
                            Console.WriteLine(player2Pokemon.GetName() + " has " +  player2Pokemon.GetCurrentHealth() + " health left");
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Incorrect Input, please try again");
                            didErrorHappen = true;
                            break;
                    }
                }

                if (!didErrorHappen)
                {
                    isPlayer1 = !isPlayer1;
                }

                if (player1Pokemon.GetCurrentHealth() <= 0 || player2Pokemon.GetCurrentHealth() <= 0)
                {
                    isGameWon = true;

                    if (isPlayer1)
                    {
                        Console.WriteLine("Game is over and player 2 Wins!");
                    }
                    else
                    {
                        Console.WriteLine("Game is over and player 1 Wins!");
                    }
                }

            }
        }
        
        

        private void PrintPlayerOptions()
        {
            Console.WriteLine("1: Attack");
            Console.WriteLine("2: Item");
            Console.WriteLine("3: Run");
        }

        private void PokemonAttack(Pokemon pokemon1, Pokemon pokemon2)
            {
                if (pokemon1.GetCurrentHealth() >= 1)
                {
                    pokemon1.TakeDamage(TypeDamageOutput(pokemon1, pokemon2));
                    Console.WriteLine(pokemon1._name + " took " + TypeDamageOutput(pokemon1, pokemon2) + " damage");
                }
                else
                {
                    pokemon1.TakeDamage(TypeDamageOutput(pokemon1, pokemon2));
                    Console.WriteLine(pokemon1._name + " is dead");
                }
            }

        private void HealPokemon(Pokemon pokemon)
            {
                pokemon.HealHealth(new Random().Next(5, 20));
            }

        private int TypeDamageOutput(Pokemon pokemon1, Pokemon pokemon2)
            {
                int outputDamage = 0;

                // fire
                if (pokemon1.GetType() == Pokemon.Types.Grass && pokemon2.GetType() == Pokemon.Types.Fire || pokemon1.GetType() == Pokemon.Types.Fire && pokemon2.GetType() == Pokemon.Types.Water || pokemon1.GetType() == Pokemon.Types.Water && pokemon2.GetType() == Pokemon.Types.Electric || pokemon1.GetType() == Pokemon.Types.Water && pokemon2.GetType() == Pokemon.Types.Grass)
                {
                    Console.WriteLine("It was super effective!");
                    outputDamage = pokemon2.GetAttackDamage() * 2;
                    return outputDamage;
                }
                else
                {
                    Console.WriteLine("It was normal.");
                    outputDamage = pokemon2.GetAttackDamage();
                    return outputDamage;
                }

                return outputDamage;
            }
    }
}
