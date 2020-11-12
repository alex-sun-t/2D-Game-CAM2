using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Coop_Exam
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        Frame frame;
        public Menu(Frame fram)
        {
            InitializeComponent();
            frame = fram;
        }

        private void btnSingle_Click(object sender, RoutedEventArgs e)
        {
            frame.Content = new SelectCharacter(frame);
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            Process StartLocation = Process.GetCurrentProcess();
            StartLocation.Kill();
        }
    }
}
