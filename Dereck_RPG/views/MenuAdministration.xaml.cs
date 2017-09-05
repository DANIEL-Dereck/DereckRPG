using WorldOfFantasy.views.administration;
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

namespace WorldOfFantasy.views
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

        private void btnMonster_Click(object sender, RoutedEventArgs e)
        {
            Page page = new Page();
            NavigationService.Navigate(new MonsterAdmin());
        }

        private void btnPlayer_Click(object sender, RoutedEventArgs e)
        {
            Page page = new Page();
            NavigationService.Navigate(new PlayerAdmin());
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).Close();
        }
    }
}
