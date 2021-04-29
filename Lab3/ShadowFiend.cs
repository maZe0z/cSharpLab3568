using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class ShadowFiend : RangedHero
    {
        public ShadowFiend()
        {
            Health = 580;
            Name = "Shadow Fiend";
            AttackRange = 500;
            Armor = 3.33;
            BaseAttackTime = 1.7;
            TurnRate = 0.9;
            MagicResistance = 25;
            NightVision = 800;
            Damage = 42;
            MovementSpeed = 305;
        }
    }
}
