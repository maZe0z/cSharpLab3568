using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab3
{
    class Courier : IMovable
    {
        public double Health { get; set; } = 70;

        public double MovementSpeed { get; set; } = 280;

        public double TurnRate { get; set; } = 0.5;

        public double NightVision { get; set; } = 200;

        public void deliverItems()
        {
            return;
        }

        public double Move()
        {
            Courier courier = new Courier();

            double courTime;
            courTime = Convert.ToDouble(((MainWindow)Application.Current.MainWindow).DistanceTextBox.Text) / courier.MovementSpeed;
            return courTime;
        }
    }
}
