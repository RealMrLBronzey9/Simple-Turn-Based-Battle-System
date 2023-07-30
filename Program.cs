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
            player.CheckStats();
            
            
            // Create enemy
            Enemy enemy = (Enemy)enemyActions.CreateEntity(GetRandomEnemyName(random));
            Thread.Sleep(1000);
            Console.WriteLine($"A wild {enemy.name} appeared!");
            
            while (isPlayerAlive) // Game loop
            {
                // Player & enemy choice num
                int playerChoice;
                int enemyChoice;

                // Speed check
                if (player.speed > enemy.speed)
                {
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
                        case 3:
                            player.CheckStats();
                            continue;
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
                        case 3:
                            player.CheckStats();
                            continue;
                        default:
                            Console.WriteLine("This is not a valid choice!!");
                            continue;
                    }
                }

                else // When speeds are equal
                {
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
                        case 3:
                            player.CheckStats();
                            continue;
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
                    Console.WriteLine($"YOU WON! Against {enemy.name}!!!");
                    // Create enemy
                    enemy = (Enemy)enemyActions.CreateEntity(GetRandomEnemyName(random));
                    Thread.Sleep(750);
                    Console.WriteLine($"A wild {enemy.name} appeared!");
                }
            }
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
            Console.WriteLine("The player can:\n1. Attack\n2. Heal\n3. Check stats");
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
            if (chance >= 0 && chance <= 0.8)
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