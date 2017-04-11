using Dereck_RPG.views.administration;
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

namespace Dereck_RPG.views
{
    /// <summary>
    /// Logique d'interaction pour MenuAdministration.xaml
    /// </summary>
    public partial class MenuAdministration : Page
    {
        public MenuAdministration()
        {
            InitializeComponent();
        }

        private void btnDonjon_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnEtreVivant_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnItem_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnObjectif_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnPlanetes_Click(object sender, RoutedEventArgs e)
        {
            Page page = new Page();
            NavigationService.Navigate(new PlanetesAdmin());
        }

        private void btnQuest_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnRegion_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
