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
    /// Логика взаимодействия для Gameplay.xaml
    /// </summary>
    public partial class Gameplay : Page
    {
        Frame frame;

        AI bot;
        ICharacter BotCharacter;
        ICharacter Player;
        public Gameplay(Frame fram, ICharacter chPlayer)
        {
            InitializeComponent();

            frame = fram;
            bot = new AI();
            BotCharacter = bot.Character;
            Player = chPlayer;

            fWait.Content = new WaitOpponent();
            fWait.Visibility = Visibility.Hidden;

            lblPlayer.DataContext = chPlayer;
            PlayerHPBar.DataContext = chPlayer;
            PlayerManaBar.DataContext = chPlayer;

            lblOpponent.DataContext = BotCharacter;
            OpponentHPBar.DataContext = BotCharacter;
            OpponentManaBar.DataContext = BotCharacter;

            imgHit.DataContext = Player;
            imgSpell.DataContext = Player;
            imgShild.DataContext = Player;
        }

        private void btnHit_Click(object sender, RoutedEventArgs e)
        {
            BotCharacter.SetHP(Player.Hit());
            WinLose();
            Task r = Task.Run(() =>
            {
                Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Visible; }));
                Thread.Sleep(3000);
                bot.Battle(Player);
                Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Hidden; }));
            });
            WinLose();
        }
        private void btnSpell_Click(object sender, RoutedEventArgs e)
        {
            if (Player.GetMana() > 50)
            {
                BotCharacter.SetHP(Player.Spell());
                WinLose();
                Task s = Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Visible; }));
                    Thread.Sleep(3000);
                    bot.Battle(Player);
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Hidden; }));
                });
            }
            WinLose();
        }
        private void btnHeal_Click(object sender, RoutedEventArgs e)
        {
            if (Player.GetMana() > 20)
            {
                Player.Heal();
                Task h = Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Visible; }));
                    Thread.Sleep(3000);
                    bot.Battle(Player);
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Hidden; }));
                });
            }
            WinLose();
        }
        private void btnShild_Click(object sender, RoutedEventArgs e)
        {
            if (Player.GetMana() > 30)
            {
                Player.SetShild(true);
                Task sh = Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Visible; }));
                    Thread.Sleep(3000);
                    bot.Battle(Player);
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Hidden; }));
                });
            }
            WinLose();
        }
        void WinLose()
        {
            if (Player.GetHP() < 1)
            {
                WinLoseFrame.Content = new WinLose("You Lose!");
                btnHit.IsEnabled = false;
                btnSpell.IsEnabled = false;
                btnHeal.IsEnabled = false;
                btnShild.IsEnabled = false;
                Task t = Task.Run(() =>
                {
                    Thread.Sleep(3000);
                    frame.Content = new Menu(frame);
                });
                return;
            }
            else if (OpponentHPBar.Value < 1)
            {
                WinLoseFrame.Content = new WinLose("You Win!");
                btnHit.IsEnabled = false;
                btnSpell.IsEnabled = false;
                btnHeal.IsEnabled = false;
                btnShild.IsEnabled = false;
                Task t = Task.Run(() =>
                {
                    Thread.Sleep(3000);
                    frame.Content = new Menu(frame);
                });
                return;
            }

            void Anima_Knight()
            {
                Dispatcher.BeginInvoke(new ThreadStart(delegate { }));
            }
        }

    }
}