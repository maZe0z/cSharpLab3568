using System;
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
using System.Windows.Shapes;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }

        private int GetItemIndex()
        {
            int selectedIndex = ((MainWindow) System.Windows.Application.Current.MainWindow).HeroListView.SelectedIndex;
            return selectedIndex;
        }

        public void ShowInitialCharacteristics()
        {
            if (GetItemIndex() == -1)
            {
                return;
            }

            Hero selectedHero = ((MainWindow) System.Windows.Application.Current.MainWindow).HeroList[GetItemIndex()];
            NameTextBox.Text = selectedHero.Name;
            HealthTextBox.Text = Convert.ToString(selectedHero.Health);
            MvmntSpdBox.Text = Convert.ToString(selectedHero.MovementSpeed);
            TurnRateBox.Text = Convert.ToString(selectedHero.TurnRate);
            NightVisionBox.Text = Convert.ToString(selectedHero.NightVision);
            ArmorBox.Text = Convert.ToString(selectedHero.Armor);
            ResistBox.Text = Convert.ToString(selectedHero.MagicResistance);
            RangeBox.Text = Convert.ToString(selectedHero.AttackRange);
            AttackTimeBox.Text = Convert.ToString(selectedHero.BaseAttackTime);
            DamageBox.Text = Convert.ToString(selectedHero.Damage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(NameTextBox.Text) || String.IsNullOrEmpty(HealthTextBox.Text) ||
            String.IsNullOrEmpty(MvmntSpdBox.Text) || String.IsNullOrEmpty(TurnRateBox.Text) ||
            String.IsNullOrEmpty(NightVisionBox.Text) || String.IsNullOrEmpty(ArmorBox.Text) ||
            String.IsNullOrEmpty(ResistBox.Text) || String.IsNullOrEmpty(RangeBox.Text) ||
            String.IsNullOrEmpty(AttackTimeBox.Text) || String.IsNullOrEmpty(DamageBox.Text))
            {
                MessageBox.Show("The stats have incorrect format!");
                return;
            }

            ((MainWindow) System.Windows.Application.Current.MainWindow).HeroList[GetItemIndex()].Name =
                NameTextBox.Text;
            ((MainWindow)System.Windows.Application.Current.MainWindow).HeroList[GetItemIndex()].Health =
                Convert.ToInt32(HealthTextBox.Text);
            ((MainWindow)System.Windows.Application.Current.MainWindow).HeroList[GetItemIndex()].MovementSpeed =
                Convert.ToInt32(MvmntSpdBox.Text);
            ((MainWindow)System.Windows.Application.Current.MainWindow).HeroList[GetItemIndex()].TurnRate =
                Convert.ToInt32(TurnRateBox.Text);
            ((MainWindow)System.Windows.Application.Current.MainWindow).HeroList[GetItemIndex()].NightVision =
                Convert.ToInt32(NightVisionBox.Text);
            ((MainWindow)System.Windows.Application.Current.MainWindow).HeroList[GetItemIndex()].Armor =
                Convert.ToInt32(ArmorBox.Text);
            ((MainWindow)System.Windows.Application.Current.MainWindow).HeroList[GetItemIndex()].MagicResistance =
                Convert.ToInt32(ResistBox.Text);
            ((MainWindow)System.Windows.Application.Current.MainWindow).HeroList[GetItemIndex()].AttackRange =
                Convert.ToInt32(RangeBox.Text);
            ((MainWindow)System.Windows.Application.Current.MainWindow).HeroList[GetItemIndex()].BaseAttackTime =
                Convert.ToInt32(AttackTimeBox.Text);
            ((MainWindow)System.Windows.Application.Current.MainWindow).HeroList[GetItemIndex()].Damage =
                Convert.ToInt32(DamageBox.Text);
        }
    }
}
