using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    class RangedHero : Hero
    {
        public override string AttackType { get; set; } = "Ranged";

        public RangedHero(){}

        public RangedHero(string name, int health, int movementSpeed,
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

        public override void Attack(List<Hero> heroList, int attackerIndex, int attackedIndex)
        {
            Random random = new Random();

            int rand = random.Next(0, 100);

            if (rand < 75) //25%
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
            else
            {
                MessageBox.Show("Miss!", "Warning");
                return;
            }
        }


        public override void AddStats()
        {
            Health += 200;
            Armor *= 2;
            Damage *= 3;
        }
    }
}
