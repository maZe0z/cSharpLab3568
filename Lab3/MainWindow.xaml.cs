﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<Hero> HeroList = new List<Hero>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            int health = Convert.ToInt32(Health.Text);
            int movementSpeed = Convert.ToInt32(MovementSpeed.Text);
            double turnRate = Convert.ToDouble(TurnRate.Text);
            int nightVision = Convert.ToInt32(NightVision.Text);
            double armor = Convert.ToDouble(Armor.Text);
            int magicResistance = Convert.ToInt32(MagicResistance.Text);
            int attackRange = Convert.ToInt32(AttackRange.Text);
            double baseAttackTime = Convert.ToDouble(BaseAttackTime.Text);
            int damage = Convert.ToInt32(Damage.Text);

            Hero hero = new Hero(name, health, movementSpeed, turnRate,
                nightVision, armor, magicResistance,
                attackRange, baseAttackTime, damage);

            HeroList.Add(hero);

            ListBoxItem menuItem = new ListBoxItem();
            menuItem.Content = hero.Name;

            HeroListView.Items.Add(menuItem);
        }

        private void OnSelected(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
