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

        public int maxHealth;
        public int health;
        public int attack;
        public int defense;
        public int speed;

        public abstract void CheckStats();
    }



    class Player : Entity
    {
        public string name;

        public Player(string name, int health, int attack, int defense, int speed)
        {
            this.health = health;
            this.attack = attack;
            this.defense = defense;
            this.speed = speed;
            this.name = name;    
            maxHealth = health;

        }

        public override void CheckStats()
        {
            Console.WriteLine($"The stats for {name} are:\nHEALTH: {health}\nATK: {attack}\nDEF: {defense}\nSPD: {speed}");
        }
    }



    class Enemy : Entity
    {
        public string name;

        public Enemy(string name, int health, int attack, int defense, int speed)
        {
            this.health = health;
            this.attack = attack;
            this.defense = defense;
            this.speed = speed;
            this.name = name;
            maxHealth = health;
        }

        public override void CheckStats()
        {
            Console.WriteLine($"The stats for {name} are:\nATK: {attack}\nDEF: {defense}\nSPD: {speed}");
        }

    }
}
