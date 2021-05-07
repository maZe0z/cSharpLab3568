using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
            ShadowFiend shadowFiend = new ShadowFiend();
            ListBoxItem menuSFItem = new ListBoxItem();
            menuSFItem.Content = shadowFiend.Name;
            HeroList.Add(shadowFiend);
            HeroListView.Items.Add(menuSFItem);

            Pudge pudge = new Pudge();
            ListBoxItem menuPudgeItem = new ListBoxItem();
            menuPudgeItem.Content = pudge.Name;
            HeroList.Add(pudge);
            HeroListView.Items.Add(menuPudgeItem);

            ImageBox_Copy1.Source = new BitmapImage(new Uri("https://static.wikia.nocookie.net/dota2_gamepedia/images/5/56/Flying_Courier_Dire_model.png/revision/latest/scale-to-width-down/250?cb=20160315185440"));
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

            if (RangedRadioButton.IsChecked == false && MeleeRadioButton.IsChecked == true)
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

                MeleeHero hero = new MeleeHero(name, health, movementSpeed, turnRate,
                    nightVision, armor, magicResistance,
                    attackRange, baseAttackTime, damage);

                HeroList.Add(hero);

                ListBoxItem menuItem = new ListBoxItem();
                //menuItem.Selected += OnSelectedIndexChanged;
                menuItem.Content = hero.Name;

                HeroListView.Items.Add(menuItem);
                NotifyPropertyChanged();
            }

            else if (RangedRadioButton.IsChecked == true && MeleeRadioButton.IsChecked == false)
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

                RangedHero hero = new RangedHero(name, health, movementSpeed, turnRate,
                    nightVision, armor, magicResistance,
                    attackRange, baseAttackTime, damage);

                HeroList.Add(hero);

                ListBoxItem menuItem = new ListBoxItem();
                //menuItem.Selected += OnSelectedIndexChanged;
                menuItem.Content = hero.Name;

                HeroListView.Items.Add(menuItem);
                NotifyPropertyChanged();
            }

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
                "\nDamage: " + HeroList[GetItemIndex()].Damage + 
                "\nAttack type: " + HeroList[GetItemIndex()].AttackType;
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
            ImageBox.Source = HeroList[GetItemIndex()].HeroIcon;
            ImageBox_Copy.Source = HeroList[GetItemIndex()].HeroIcon;
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

        private void LevelUpButton_Click(object sender, RoutedEventArgs e)
        {
            HeroList[GetItemIndex()].AddStats();
        }

        private void RaceMovables(IMovable first, IMovable second)
        {
            double tmpCourTime = second.Move();
            double tmpHeroTime = first.Move();
            

            if (tmpCourTime > tmpHeroTime)
            {
                RaceResultTextBox.Text = "Hero wins the race" +
                    "\nCourier time: " + tmpCourTime +
                    "\nHero time: " + tmpHeroTime;
            }

            else if (tmpCourTime < tmpHeroTime)
            {
                RaceResultTextBox.Text = "Courier wins the race" +
                    "\nCourier time: " + tmpCourTime +
                    "\nHero time: " + tmpHeroTime;
            }

            else if (tmpCourTime == tmpHeroTime)
            {
                RaceResultTextBox.Text = "That's a tie" +
                        "\nCourier time: " + tmpCourTime +
                        "\nHero time: " + tmpHeroTime;
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(DistanceTextBox.Text))
            {
                return;
            }

            else if (EnableObst.IsChecked == true && DisableObst.IsChecked == true)
            {
                return;
            }

            else if (EnableObst.IsChecked == false && DisableObst.IsChecked == false)
            {
                return;
            }

            else if (EnableObst.IsChecked != DisableObst.IsChecked)
            {
                IMovable tmpHero = HeroList[GetItemIndex()];
                IMovable courier = new Courier();

                RaceMovables(tmpHero, courier);
            }
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            HeroList.Sort();
            HeroListView.Items.Clear();
            
            foreach (Hero hero in HeroList)
            {
                ListBoxItem menuItem = new ListBoxItem();
                menuItem.Content = hero.Name;

                HeroListView.Items.Add(menuItem);
            }
        }

        /*else if (EnableObst.IsChecked == false && DisableObst.IsChecked == true)
        {
            Courier tmpCourier = new Courier();

            double tmpHeroTime = HeroList[GetItemIndex()].Move();
            double tmpCourTime = tmpCourier.Move();

            if (tmpCourTime > tmpHeroTime)
            {
                RaceResultTextBox.Text = "Courier? wins the race" +
                    "\nCourier time: " + tmpCourTime +
                    "\nHero time: " + tmpHeroTime;
            }

            if (tmpCourTime < tmpHeroTime)
            {
                RaceResultTextBox.Text = "Hero! wins the race" +
                    "\nCourier time: " + tmpCourTime +
                    "\nHero time: " + tmpHeroTime;
            }

            else
            {
                RaceResultTextBox.Text = "That's a tie" +
                        "\nCourier time: " + tmpCourTime +
                        "\nHero time: " + tmpHeroTime;
            }
        }

        else if (EnableObst.IsChecked == true && DisableObst.IsChecked == false)
        {
            Courier tmpCourier = new Courier();

            double tmpHeroTime = HeroList[GetItemIndex()].Move();
            double tmpCourTime = tmpCourier.Move();

            if (tmpCourTime > tmpHeroTime)
            {
                RaceResultTextBox.Text = "Courier! wins the race" +
                    "\nCourier time: " + tmpCourTime +
                    "\nHero time: " + tmpHeroTime;
            }

            if (tmpCourTime < tmpHeroTime)
            {
                RaceResultTextBox.Text = "Hero? wins the race" +
                    "\nCourier time: " + tmpCourTime +
                    "\nHero time: " + tmpHeroTime;
            }

            else
            {
                RaceResultTextBox.Text = "That's a tie" +
                        "\nCourier time: " + tmpCourTime +
                        "\nHero time: " + tmpHeroTime;
            }
        }*/
    }
}
