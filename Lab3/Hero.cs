using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Hero
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public int MovementSpeed { get; set; }

        public double TurnRate { get; set; }

        public int NightVision { get; set; }

        public double Armor { get; set; }

        public int MagicResistance { get; set; }

        public int AttackRange { get; set; }

        public double BaseAttackTime { get; set; }

        public int Damage { get; set; }

        public Hero(string name, int health, int movementSpeed, 
            double turnRate, int nightVision, double armor,
            int magicResistance, int attackRange, double baseAttackTime, int damage)
        {
            this.Name = name;
            this.Health = health;
            this.MovementSpeed = movementSpeed;
            this.TurnRate = turnRate;
            this.NightVision = nightVision;
            this.Armor = armor;
            this.MagicResistance = magicResistance;
            this.AttackRange = attackRange;
            this.BaseAttackTime = baseAttackTime;
            this.Damage = damage;
        }
    }
}
