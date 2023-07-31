using System.Xml.Linq;
using System.Threading;

namespace Simple_Turn_Based_Battle_System
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            PlayerActions playerActions = new PlayerActions();
            EnemyActions enemyActions = new EnemyActions();


            // Create player
            string playerName = "Joe";
            Console.WriteLine("Welcome to the simple turn based battle system game!");
            Thread.Sleep(1000);
            Console.WriteLine("Enter the name for your hero: ");
            playerName = Console.ReadLine();

            Thread.Sleep(750);
            Console.WriteLine($"Hello {playerName}! We will randomly generate your other stats");

            Player player = (Player)playerActions.CreateEntity(playerName);


            // Initialize Game
            bool isPlayerAlive = true;
            Thread.Sleep(750);
            
            // Create enemy
            Enemy enemy = (Enemy)enemyActions.CreateEntity(GetRandomEnemyName(random));
            Thread.Sleep(1000);
            Console.WriteLine($"A wild {enemy.name} appeared!");
            int turn = 0;


            while (isPlayerAlive) // Game loop
            {
                turn++;
                // Player & enemy choice num
                int playerChoice;
                int enemyChoice;

                // Speed check
                if (player.speed > enemy.speed)
                {
                    // Display stats
                    Thread.Sleep(500);
                    Console.WriteLine($"-------------- Turn #{turn} --------------");
                    enemy.DisplayStats();
                    player.DisplayStats();

                    // Player goes first
                    playerChoice = PlayerChoice();

                    switch (playerChoice)
                    {
                        case 1:
                            enemy.health = playerActions.Attack(player.attack, enemy.defense, enemy.health);
                            break;
                        case 2:
                            player.health = playerActions.Heal(player.health, player.maxHealth, random);
                            break;
                        default:
                            Console.WriteLine("This is not a valid choice!!");
                            continue;
                    }
                    // Enemy turn
                    enemyChoice = EnemyChoice(random);

                    switch (enemyChoice)
                    {
                        case 1: // Attack
                            player.health = enemyActions.Attack(enemy.attack, player.defense, player.health);
                            break;
                        case 2: // Heal
                            enemy.health = enemyActions.Heal(enemy.health, enemy.maxHealth, random);
                            break;
                    }
                }

                else if (player.speed < enemy.speed)
                {
                    // Enemy goes first
                    enemyChoice = EnemyChoice(random);

                    switch (enemyChoice)
                    {
                        case 1: // Attack
                            player.health = enemyActions.Attack(enemy.attack, player.defense, player.health);
                            break;
                        case 2: // Heal
                            enemy.health = enemyActions.Heal(enemy.health, enemy.maxHealth, random);
                            break;
                    }

                    // Display stats
                    Thread.Sleep(500);
                    Console.WriteLine($"-------------- Turn #{turn} --------------");
                    enemy.DisplayStats();
                    player.DisplayStats();

                    // Player turn
                    playerChoice = PlayerChoice();

                    switch (playerChoice)
                    {
                        case 1:
                            enemy.health = playerActions.Attack(player.attack, enemy.defense, enemy.health);
                            break;
                        case 2:
                            player.health = playerActions.Heal(player.health, player.maxHealth, random);
                            break;
                        default:
                            Console.WriteLine("This is not a valid choice!!");
                            continue;
                    }
                }

                else // When speeds are equal
                {
                    // Display stats
                    Thread.Sleep(500);
                    Console.WriteLine($"-------------- Turn #{turn} --------------");
                    enemy.DisplayStats();
                    player.DisplayStats();

                    // Player goes first
                    playerChoice = PlayerChoice();

                    switch (playerChoice)
                    {
                        case 1:
                            enemy.health = playerActions.Attack(player.attack, enemy.defense, enemy.health);
                            break;
                        case 2:
                            player.health = playerActions.Heal(player.health, player.maxHealth, random);
                            break;
                        default:
                            Console.WriteLine("This is not a valid choice!!");
                            continue;
                    }
                    // Enemy turn
                    enemyChoice = EnemyChoice(random);

                    switch (enemyChoice)
                    {
                        case 1: // Attack
                            player.health = enemyActions.Attack(enemy.attack, player.defense, player.health);
                            break;
                        case 2: // Heal
                            enemy.health = enemyActions.Heal(enemy.health, enemy.maxHealth, random);
                            break;
                    }
                }

                // Check if player or enemy is dead
                if (player.health <= 0)
                {
                    isPlayerAlive = false;
                    Thread.Sleep(750);
                    Console.WriteLine("Defeat!");
                }
                else if(enemy.health <= 0)
                {
                    Thread.Sleep(750);
                    Console.WriteLine($"YOU WON! Against {enemy.name} within {turn} turns!!!");
                    turn = 0;
                    // Create enemy
                    enemy = (Enemy)enemyActions.CreateEntity(GetRandomEnemyName(random));
                    Thread.Sleep(750);
                    Console.WriteLine($"A wild {enemy.name} appeared!");
                }
            }
            Console.WriteLine("Restart this program to start again!");
            Console.ReadKey();
        }



        // Choice methods
        static string GetRandomEnemyName(Random random) // Name explains
        {
            int index = random.Next(EnemyNames.Names.Length);
            return EnemyNames.Names[index];
        }


        static int PlayerChoice()
        {
            int decision;
            Thread.Sleep(750);
            Console.WriteLine("The player can:\n1. Attack\n2. Heal");
            Thread.Sleep(250);
            Console.WriteLine("Type the number you want to do!");
            decision = Convert.ToInt32(Console.ReadLine());

            return decision;
        }

        static int EnemyChoice(Random random)
        {
            int decision;
            double chance;
            chance = random.NextDouble();

            // Chances of 
            if (chance >= 0 && chance <= 0.95)
            {
                decision = 1;
            }
            else
            {
                decision = 2;
            }
            return decision;
        }
    }
}