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

        bool wait = false;

        AI bot;
        ICharacter BotCharacter;
        ICharacter Player;

        Animation animPlayer;
        Animation animPlayerSpell;

        Animation animOpponent;
        Animation animOpponentSpell;
        public Gameplay(Frame fram, ICharacter chPlayer)
        {
            InitializeComponent();

            frame = fram;
            bot = new AI();
            BotCharacter = bot.Character;
            Player = chPlayer;

            fWait.Content = new WaitOpponent();
            fWait.Visibility = Visibility.Hidden;

            lblPlayer.DataContext = Player;
            PlayerHPBar.DataContext = Player;
            PlayerManaBar.DataContext = Player;

            lblOpponent.DataContext = BotCharacter;
            OpponentHPBar.DataContext = BotCharacter;
            OpponentManaBar.DataContext = BotCharacter;

            imgHit.DataContext = Player;
            imgSpell.DataContext = Player;

            animPlayer = new Animation(imgPlayer, Player.Sprites_IDLE());
            animPlayer.start();
            animOpponent = new Animation(imgOpponent, BotCharacter.Sprites_IDLE());
            animOpponent.start();

        }

        private void btnHit_Click(object sender, RoutedEventArgs e)
        {
            HITAnimation();
            WinLose();
            Task t = Task.Run(() =>
            {
                Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Visible; }));
                //Thread.Sleep(14500);
                wait = false;
                while (wait != true) { }

                Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Hidden; }));
            });
            BotAnimation();
        }
        private void btnSpell_Click(object sender, RoutedEventArgs e)
        {
            if (Player.GetMana() > 50)
            {
                Player.ManaPrice(50);
                SPELLAnimation();
                WinLose();
                Task s = Task.Run(() =>
                {

                    Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Visible; }));
                    wait = false;
                    while (wait != true) { }
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Hidden; }));
                });
                BotAnimation();
            }
            WinLose();
        }
        private void btnHeal_Click(object sender, RoutedEventArgs e)
        {
            if (Player.GetMana() > 20)
            {
                Player.ManaPrice(20);
                Player.Heal();
                Task h = Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Visible; }));
                    wait = false;
                    //Thread.Sleep(8000);
                    while (wait != true) { }
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Hidden; }));
                });
            }
            WinLose();
        }
        private void btnShild_Click(object sender, RoutedEventArgs e)
        {
            if (Player.GetMana() > 30)
            {
                Player.ManaPrice(30);
                Player.SetShild(true);
                Task sh = Task.Run(() =>
                {
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Visible; }));
                    wait = false;
                    //Thread.Sleep(8000);
                    while (wait != true) { }
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { fWait.Visibility = Visibility.Hidden; }));
                });
                bot.Battle(Player);
            }
            WinLose();
        }
        void WinLose()
        {
            if (Player.GetHP() < 1)
            {
                animPlayer.SetImagesLibrary(Player.Sprites_DIE(), true);
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
                animOpponent.SetImagesLibrary(BotCharacter.Sprites_DIE(), true);
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
        }

        void HITAnimation()
        {
            Task h = Task.Run(() =>
            {
                animPlayer.SetImagesLibrary(Player.Sprites_RUN(), false);
                int r = 50;
                while (r < 600)
                {
                    r += 5;
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { Canvas.SetLeft(imgPlayer, r); }));
                    Thread.Sleep(30);
                }
                animPlayer.SetImagesLibrary(Player.Sprites_ATTACK(), false);
                Thread.Sleep(750);
                BotCharacter.SetHP(Player.Hit());
                animPlayer.SetImagesLibrary(Player.Sprites_RUN(), false);
                //WinLose();
                Dispatcher.BeginInvoke(new ThreadStart(delegate { imgX.ScaleX = -1; }));

                while (r > 65)
                {
                    r -= 5;
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { Canvas.SetLeft(imgPlayer, r); }));
                    Thread.Sleep(30);
                }
                Dispatcher.BeginInvoke(new ThreadStart(delegate { imgX.ScaleX = 1; }));
                animPlayer.SetImagesLibrary(Player.Sprites_IDLE(), false);
            });
        }

        void SPELLAnimation()
        {
            animPlayerSpell = new Animation(playerSpell, Player.Sprites_SPELL_Part_2());
            animPlayerSpell.start();
            Task s = Task.Run(() =>
            {
                animPlayer.SetImagesLibrary(Player.Sprites_SPELL_Part_1(), false);
                Thread.Sleep(700);
                animPlayer.SetImagesLibrary(Player.Sprites_IDLE(), false);
                Dispatcher.BeginInvoke(new ThreadStart(delegate { playerSpell.Visibility = Visibility; }));
                int r = 135;
                while (r < 650)
                {
                    r += 5;
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { Canvas.SetLeft(playerSpell, r); }));
                    Thread.Sleep(10);
                }
                Dispatcher.BeginInvoke(new ThreadStart(delegate { playerSpell.Visibility = Visibility.Hidden; }));
                Dispatcher.BeginInvoke(new ThreadStart(delegate { Canvas.SetLeft(playerSpell, 135); }));
                BotCharacter.SetHP(Player.Spell());
            });
        }

        void BotAnimation()
        {
            int animNumb = bot.Battle(Player);
            if (animNumb == 1)
            {
                Task h = Task.Run(() =>
                {
                    Thread.Sleep(9000);
                    animOpponent.SetImagesLibrary(BotCharacter.Sprites_RUN(), false);
                    int r = 690;
                    while (r > 155)
                    {
                        r -= 5;
                        Dispatcher.BeginInvoke(new ThreadStart(delegate { Canvas.SetLeft(imgOpponent, r); }));
                        Thread.Sleep(30);
                    }
                    animOpponent.SetImagesLibrary(BotCharacter.Sprites_ATTACK(), false);
                    Thread.Sleep(750);
                    Player.SetHP(BotCharacter.Hit());
                    animOpponent.SetImagesLibrary(BotCharacter.Sprites_RUN(), false);
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { imgOX.ScaleX = 1; }));

                    while (r < 690)
                    {
                        r += 5;
                        Dispatcher.BeginInvoke(new ThreadStart(delegate { Canvas.SetLeft(imgOpponent, r); }));
                        Thread.Sleep(30);
                    }
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { imgOX.ScaleX = -1; }));
                    animOpponent.SetImagesLibrary(BotCharacter.Sprites_IDLE(), false);
                    Player.ManaRegeneration();
                    BotCharacter.ManaRegeneration();
                    wait = true;
                });
            }
            else if (animNumb == 2)
            {
                animOpponentSpell = new Animation(OpponentSpell, bot.Character.Sprites_SPELL_Part_2());
                animOpponentSpell.start();
                Task s = Task.Run(() =>
                {
                    Thread.Sleep(9000);
                    BotCharacter.ManaPrice(50);
                    animOpponent.SetImagesLibrary(BotCharacter.Sprites_SPELL_Part_1(), false);
                    Thread.Sleep(700);
                    animOpponent.SetImagesLibrary(BotCharacter.Sprites_IDLE(), false);
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { OpponentSpell.Visibility = Visibility; }));
                    int r = 650;
                    while (r > 125)
                    {
                        r -= 5;
                        Dispatcher.BeginInvoke(new ThreadStart(delegate { Canvas.SetLeft(OpponentSpell, r); }));
                        Thread.Sleep(10);
                    }
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { OpponentSpell.Visibility = Visibility.Hidden; }));
                    Dispatcher.BeginInvoke(new ThreadStart(delegate { Canvas.SetLeft(OpponentSpell, 135); }));
                    Player.SetHP(BotCharacter.Hit());
                    Player.ManaRegeneration();
                    BotCharacter.ManaRegeneration();
                    wait = true;
                });
            }
            else 
            {
                wait = true;
            }
        }
    }
}