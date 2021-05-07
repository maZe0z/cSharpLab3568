using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Lab3
{
    public abstract class Hero : IMovable, IComparable<Hero>
    {
        public BitmapImage HeroIcon { get; set; }

        public void LoadImage(Bitmap image)
        {
            int x, y;

            for (x = 0; x < image.Width; x++)
            {
                for (y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                    image.SetPixel(x, y, newColor);
                }
            }
        }

        public abstract string AttackType { get; set; }

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

        private static string GenerateId() => Guid.NewGuid().ToString();

        public abstract void AddStats();

        public abstract void Attack(List<Hero> heroList, int attackerIndex, int attackedIndex);

        public double Move()
        {
            double heroTime;

            if (((MainWindow)Application.Current.MainWindow).EnableObst.IsChecked == true) {
                heroTime = Convert.ToDouble(((MainWindow)Application.Current.MainWindow).DistanceTextBox.Text) / ((MainWindow)Application.Current.MainWindow).HeroList[
                    ((MainWindow)Application.Current.MainWindow).HeroListView.SelectedIndex].MovementSpeed + 5;
                return heroTime;
            }

            else if (((MainWindow)Application.Current.MainWindow).EnableObst.IsChecked == false)
            {
                heroTime = Convert.ToDouble(((MainWindow)Application.Current.MainWindow).DistanceTextBox.Text) / ((MainWindow)Application.Current.MainWindow).HeroList[
                    ((MainWindow)Application.Current.MainWindow).HeroListView.SelectedIndex].MovementSpeed;
                return heroTime;
            }

            else
            {
                heroTime = 0;
                return heroTime;
            }
        }

        public int CompareTo(Hero hero)
        {
            return MovementSpeed.CompareTo(hero.MovementSpeed);
        }
    }
}
