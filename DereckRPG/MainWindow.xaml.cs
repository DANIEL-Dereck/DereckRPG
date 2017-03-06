using DereckRPG.logger;
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

namespace DereckRPG
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Logger logger = new Logger("myLogger", LogMode.CURRENT_FOLDER, AlertMode.OVERLAY, "INIT", true);
            logger.Log("Initialisation application");
        }

        /*
        private void btnExempe_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window();
            window.Content = new <Page>Admin(); 
            window.Show();
        }
        */
    }
}
