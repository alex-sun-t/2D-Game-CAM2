using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Coop_Exam
{
    /// <summary>
    /// Логика взаимодействия для SelectCharacter.xaml
    /// </summary>
    public partial class SelectCharacter : Page
    {
        ICharacter character;

        SolidColorBrush white;
        SolidColorBrush black;

        Frame frame;

        int ml_sec = 100;

        Knight knight;
        Archer archer;
        Mage mage;

        public SelectCharacter(Frame fram)
        {
            InitializeComponent();

            knight = new Knight();
            archer = new Archer();
            mage = new Mage();

            frame = fram;
            Task k = Task.Run(() => Animation_Knight_IDLE());
            Task a = Task.Run(() => Animation_Archer_IDLE());
            Task m = Task.Run(() => Animation_Mage_IDLE());

            white = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            black = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }

        private void b1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btnFight.IsEnabled = true;
            b1.BorderBrush = white;
            b2.BorderBrush = black;
            b3.BorderBrush = black;
            character = new Knight();
        }

        private void b2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btnFight.IsEnabled = true;
            b1.BorderBrush = black;
            b2.BorderBrush = white;
            b3.BorderBrush = black;
            character = new Archer();
        }

        private void b3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btnFight.IsEnabled = true;
            b1.BorderBrush = black;
            b2.BorderBrush = black;
            b3.BorderBrush = white;
            character = new Mage();
        }

        private void btnFight_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new Gameplay(frame, character);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new Menu(frame);
        }
        void Animation_Knight_IDLE()
        {
            while (true)
            {
                foreach (var item in knight.Animation_IDLE())
                {
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { imgWar.Source = new BitmapImage(new Uri(item, UriKind.RelativeOrAbsolute)); }));
                    Thread.Sleep(ml_sec);
                }
            }
        }

        void Animation_Archer_IDLE()
        {
            while (true)
            {
                foreach (var item in archer.Animation_IDLE())
                {
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { imgArch.Source = new BitmapImage(new Uri(item, UriKind.RelativeOrAbsolute)); }));
                    Thread.Sleep(ml_sec);
                }
            }
        }

        void Animation_Mage_IDLE()
        {
            while (true)
            {
                foreach (var item in mage.Animation_IDLE())
                {
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { imgMage.Source = new BitmapImage(new Uri(item, UriKind.RelativeOrAbsolute)); }));
                    Thread.Sleep(ml_sec);
                }
            }
        }
    }
}
