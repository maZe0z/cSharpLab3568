﻿using System;
using System.Collections.Generic;

namespace Lab3
{
    public class Hero
    {
        private static string GenerationId() => Guid.NewGuid().ToString();
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

        public string Id { get; }
        
        public Hero(string name, int health, int movementSpeed, 
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
            Id = GenerateId();
        }

        public Hero(string name, int health, int movementSpeed,
            double turnRate, int nightVision, double armor,
            int magicResistance, int attackRange, double baseAttackTime, int damage, string id)
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
            Id = id;
        }

        private static string GenerateId() => Guid.NewGuid().ToString();
        public void Attack(List<Hero> heroList, int attackerIndex, int attackedIndex)
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
