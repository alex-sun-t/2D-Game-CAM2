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

        Animation kt;
        Animation ar;
        Animation me;

        SolidColorBrush white;
        SolidColorBrush black;

        Frame frame;

        int ml_sec = 150;

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

            white = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            black = new SolidColorBrush(Color.FromRgb(0, 0, 0));

            Animation kt = new Animation(imgWar,knight.Sprites_IDLE());
            kt.start();
            Animation ar = new Animation(imgArch, archer.Sprites_IDLE());
            ar.start();
            Animation me = new Animation(imgMage,mage.Sprites_IDLE());
            me.start();
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
    }
}
