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

namespace Dereck_RPG.views.play
{
    /// <summary>
    /// Logique d'interaction pour SelectRegionUC.xaml
    /// </summary>
    public partial class SelectRegionUC : UserControl
    {
        public SelectRegionUC()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            /*
            Page page = new Page();
            NavigationService.Navigate(new DonjonAdmin());
            */
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).Close();

        }
    }
}
