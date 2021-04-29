using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Lab3
{
    class ShadowFiend : RangedHero
    {
        public ShadowFiend()
        {
            HeroIcon = new BitmapImage(new Uri("https://static.wikia.nocookie.net/dota2_gamepedia/images/3/36/Shadow_Fiend_icon.png/revision/latest?cb=20160411213752"));
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
