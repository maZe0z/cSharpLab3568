using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Lab3
{
    class Pudge : MeleeHero
    {
        public Pudge()
        {
            HeroIcon = new BitmapImage(new Uri("https://static.wikia.nocookie.net/dota2_gamepedia/images/c/c0/Pudge_icon.png/revision/latest?cb=20160411211506"));
            Health = 700;
            Name = "Pudge";
            AttackRange = 150;
            Armor = 0.33;
            BaseAttackTime = 1.7;
            TurnRate = 0.7;
            MagicResistance = 25;
            NightVision = 800;
            Damage = 67;
            MovementSpeed = 280;
        }

        public override void AddStats()
        {
            Health += 700;
            Armor *= 2;
            Damage *= 3;
        }
    }
}
