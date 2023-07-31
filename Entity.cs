using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Turn_Based_Battle_System
{
    abstract class Entity
    {
        // Basic stats

        public string name;
        public int maxHealth;
        public int health;
        public int attack;
        public int defense;
        public int speed;

        public abstract void DisplayStats();
    }


    class Player : Entity
    {
        public int userPoints = 5;
        public Player(string name, int health, int attack, int defense, int speed)
        {
            this.health = health;
            this.attack = attack;
            this.defense = defense;
            this.speed = speed;
            this.name = name;    
            maxHealth = health;

        }

        public override void DisplayStats()
        {
            Console.WriteLine($"<< {name} >> -- HP: {health}/{maxHealth} -- UP: {userPoints}/5 -- ATK: {attack} -- DEF: {defense} -- SPD: {speed}\n");
        }
    }


    class Enemy : Entity
    {
        public Enemy(string name, int health, int attack, int defense, int speed)
        {
            this.health = health;
            this.attack = attack;
            this.defense = defense;
            this.speed = speed;
            this.name = name;
            maxHealth = health;
        }

        public override void DisplayStats()
        {
            Console.WriteLine($"<< {name} >> -- HP: {health}/{maxHealth}");
        }
    }
}
