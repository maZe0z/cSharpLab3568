using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Lab3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public List<Hero> HeroList = new List<Hero>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(Name.Text) || String.IsNullOrEmpty(Health.Text) ||
                String.IsNullOrEmpty(TurnRate.Text) || String.IsNullOrEmpty(Name.Text) ||
                String.IsNullOrEmpty(NightVision.Text) || String.IsNullOrEmpty(Armor.Text) ||
                String.IsNullOrEmpty(MagicResistance.Text) || String.IsNullOrEmpty(AttackRange.Text) ||
                String.IsNullOrEmpty(BaseAttackTime.Text) || String.IsNullOrEmpty(Damage.Text))
            {
                MessageBox.Show("The stats have incorrect format or not all stats are filled in!");
                return;
            }

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
            //menuItem.Selected += OnSelectedIndexChanged;
            menuItem.Content = hero.Name;

            HeroListView.Items.Add(menuItem);
            NotifyPropertyChanged();
        }

        private int GetItemIndex()
        {
            int selectedIndex = HeroListView.SelectedIndex;
            return selectedIndex;
        }

        private void ShowCharacteristics()
        {
            if (GetItemIndex() == -1)
            {
                return;
            }
            
            HeroCharacteristics.Text = "Name: " + HeroList[GetItemIndex()].Name +
                "\nHealth: " + HeroList[GetItemIndex()].Health +
                "\nMovement speed: " + HeroList[GetItemIndex()].MovementSpeed +
                "\nTurn rate: " + HeroList[GetItemIndex()].TurnRate +
                "\nNight vision: " + HeroList[GetItemIndex()].NightVision +
                "\nArmor: " + HeroList[GetItemIndex()].Armor +
                "\nMagic resistance: " + HeroList[GetItemIndex()].MagicResistance +
                "\nAttack range: " + HeroList[GetItemIndex()].AttackRange +
                "\nBase attack time: " + HeroList[GetItemIndex()].BaseAttackTime +
                "\nDamage: " + HeroList[GetItemIndex()].Damage;
            NotifyPropertyChanged();
        }

        private void ShowCharacteristics(int index)
        {
            if (index < 0 || index > HeroList.Count)
            {
                return;
            }

            HeroCharacteristics.Text = "Name: " + HeroList[GetItemIndex()].Name +
                                       "\nHealth: " + HeroList[GetItemIndex()].Health +
                                       "\nMovement speed: " + HeroList[GetItemIndex()].MovementSpeed +
                                       "\nTurn rate: " + HeroList[GetItemIndex()].TurnRate +
                                       "\nNight vision: " + HeroList[GetItemIndex()].NightVision +
                                       "\nArmor: " + HeroList[GetItemIndex()].Armor +
                                       "\nMagic resistance: " + HeroList[GetItemIndex()].MagicResistance +
                                       "\nAttack range: " + HeroList[GetItemIndex()].AttackRange +
                                       "\nBase attack time: " + HeroList[GetItemIndex()].BaseAttackTime +
                                       "\nDamage: " + HeroList[GetItemIndex()].Damage;
            NotifyPropertyChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ShowCharacteristics();
        }

        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(AttackingHeroTextBox.Text) || String.IsNullOrEmpty(AttackedHeroTextBox.Text))
            {
                return;
            }

            /*if (Convert.ToInt32(AttackingHeroTextBox.Text) < HeroList.Count ||
                Convert.ToInt32(AttackedHeroTextBox.Text) < HeroList.Count)
            {
                return;
            }
            if (Convert.ToInt32(AttackingHeroTextBox.Text) > HeroList.Count ||
                Convert.ToInt32(AttackedHeroTextBox.Text) > HeroList.Count)
            {
                return;
            }*/

            for (int i = 0; i < 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(100);
            }

            int attackerIndex = Convert.ToInt32(AttackingHeroTextBox.Text);
            int attackedIndex = Convert.ToInt32(AttackedHeroTextBox.Text);

            HeroList[attackerIndex].Attack(HeroList, attackerIndex, attackedIndex);
        }

        private void EditModeButton_Click(object sender, RoutedEventArgs e)
        {
            if (GetItemIndex() == -1)
            {
                return;
            }

            EditWindow editWindow = new EditWindow();
            editWindow.Show();
            editWindow.ShowInitialCharacteristics();
        }
    }
}
