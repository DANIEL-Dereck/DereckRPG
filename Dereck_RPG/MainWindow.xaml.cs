using Dereck_RPG.database;
using Dereck_RPG.logger;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dereck_RPG
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Logger logger = new Logger("myLogger", LogMode.CURRENT_FOLDER, AlertMode.OVERLAY, "MaintWindows", true);
        MySQLFullDB msload = new MySQLFullDB();
        public MainWindow()
        {
            InitializeComponent();
            //logger.Log("Test1");
            //logger.Log("Test2", LogMode.NONE, AlertMode.TOAST);
            //logger.Log("Test3", LogMode.NONE, AlertMode.MESSAGE_BOX);
            //logger.Log("Test4", LogMode.NONE, AlertMode.MESSAGE_BOX_CUSTOM);
            //logger.Log("MainWindows loaded", LogMode.NONE, AlertMode.CONSOLE);
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow window = new NavigationWindow();
            //window.Content = newAdministrationAdmin();
            window.Show();
        }

        private void btnAdministration_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow window = new NavigationWindow();
            //window.Content = newPlayAdmin();
            window.Show();
        }

        /*
        private void btn[OBJET]_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow window = new NavigationWindow();
            window.Content = new [OBJET]Admin();
            window.Show();
        }
        */

    }
}
