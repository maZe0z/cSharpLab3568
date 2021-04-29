using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class MeleeHero : Hero
    {
        public override string AttackType { get; set; } = "Melee";

        public MeleeHero(){}

        public MeleeHero(string name, int health, int movementSpeed,
            double turnRate, int nightVision, double armor,
            int magicResistance, int attackRange, double baseAttackTime, int damage)
        {
            Name = name;
            Health = health;
            MovementSpeed = movementSpeed;
            TurnRate = turnRate;
            NightVision = nightVision;
            Armor = armor;
            MagicResistance = magicResistance;
            AttackRange = attackRange;
            BaseAttackTime = baseAttackTime;
            Damage = damage;
        }

        public override void AddStats()
        {
            Health += 300;
            Armor *= 2;
            Damage *= 2;
        }

        public override void Attack(List<Hero> heroList, int attackerIndex, int attackedIndex)
        {
            if (heroList[attackedIndex].Health - heroList[attackerIndex].Damage < 0)
            {
                heroList[attackedIndex].Health = 0;
            }
            else
            {
                heroList[attackedIndex].Health = heroList[attackedIndex].Health - heroList[attackerIndex].Damage;
            }
        }
    }
}
