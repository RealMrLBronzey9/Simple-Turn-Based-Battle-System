﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Turn_Based_Battle_System
{
    interface IActions
    {
        Entity CreateEntity(string name);
        int Attack(int userATK, int opDEF, int opHP);
        int Heal(int userHP, int maxHP, Random random);

    }




    class PlayerActions : IActions
    {


        // Create Player
        public Entity CreateEntity(string name)
        {
            Random random = new Random();
            int HP;
            int ATK;
            int DEF;
            int SPD;

            HP = random.Next(15, 25);
            ATK = random.Next(5, 10);
            DEF = random.Next(5, 10);
            SPD = random.Next(1, 5);

            return new Player(name, HP, ATK, DEF, SPD); 
        }


        // Player Attacks
        public int Attack(int playerATK, int enemyDEF, int enemyHP)
        {
            Random random = new Random();
            int baseDamage = 3;
            // Random damage variables
            int minRDamage = -2;
            int maxRDamage = +2;

            int attack = (enemyDEF - playerATK) + baseDamage + random.Next(minRDamage, maxRDamage);

            if (attack <= 0)
            {
                Thread.Sleep(500);
                Console.WriteLine("The attack was ineffective! One damage inflicted!");
                enemyHP = --enemyHP;
            }
            else
            {   // When the attack is over 0
                Thread.Sleep(500);
                Console.WriteLine($"The attack dealt {attack} points of damage!");
                enemyHP = enemyHP - attack;
            }
            return enemyHP;
        }


        // Player Heals
        public int Heal(int playerHP, int maxHP, Random random)
        {
            int healAmount = playerHP + (random.Next(0, maxHP / 2));

            playerHP += healAmount;
            playerHP = Math.Min(playerHP, maxHP);
            
            if(playerHP == maxHP)
            {
                Thread.Sleep(500);
                Console.WriteLine("You healed to MAX health!");
            }
            else if (playerHP < maxHP && playerHP != 0)
            {
                Thread.Sleep(500);
                Console.WriteLine($"You healed {healAmount} points of HP!");
            }
            else
            {
                Thread.Sleep(500);
                Console.WriteLine("L you didn't heal a point of HP!!");
            }

            return playerHP;
        }

    }




    class EnemyActions : IActions
    {
        
        public Entity CreateEntity(string name)
        {
            Random random = new Random();

            int HP;
            int ATK;
            int DEF;
            int SPD;
            HP = random.Next(15, 25);
            ATK = random.Next(5, 10);
            DEF = random.Next(5, 10);
            SPD = random.Next(1, 5);

            return new Enemy(name, HP, ATK, DEF, SPD);
        }


        // Enemy Attacks
        public int Attack(int enemyATK, int playerDEF, int playerHP)
        {
            Random random = new Random();
            Thread.Sleep(500);
            Console.WriteLine($"The enemy decides to attack!");
            int baseDamage = 3;
            // Random damage variable
            int minRDamage = -2;
            int maxRDamage = +2;

            int attack = (playerDEF - enemyATK) + baseDamage + random.Next(minRDamage, maxRDamage);

            if (attack <= 0)
            {
                Thread.Sleep(500);
                Console.WriteLine("The attack on you was ineffective! One damage inflicted!");
                playerHP = --playerHP;
            }
            else
            {   // When the attack is over 0
                Thread.Sleep(500);
                Console.WriteLine($"The attack on you dealt {attack} points of damage!");
                playerHP = playerHP - attack;
            }
            return playerHP;
        }


        // Enemy Heals
        public int Heal(int enemyHP, int maxHP, Random random)
        {
            Thread.Sleep(500);
            Console.WriteLine("The enemy decides to heal!");
            int healAmount = enemyHP + (random.Next(0, maxHP / 2));

            enemyHP += healAmount;
            enemyHP = Math.Min(enemyHP, maxHP);

            if (enemyHP == maxHP)
            {
                Thread.Sleep(500);
                Console.WriteLine("The enemy healed to MAX HP!");
            }
            else if (enemyHP < maxHP && enemyHP != 0)
            {
                Thread.Sleep(500);
                Console.WriteLine($"The enemy healed {healAmount} points of HP!");
            }
            else
            {
                Thread.Sleep(500);
                Console.WriteLine("Nice! The enemy wasn't able to heal!!");
            }

            return enemyHP;
        }
    }
}