using Dereck_RPG.database;
using Dereck_RPG.entities;
using Dereck_RPG.viewmodel.playviewmodel;
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
    /// Logique d'interaction pour MenuPlay.xaml
    /// </summary>
    public partial class MenuPlay : Page
    {
        public MenuPlay()
        {
            InitializeComponent();
            this.DataContext = new PlanetePlayVM(this);
            InitLists();
        }

        private async void InitLists()
        {
            MySQLManager<Planetes> planetesManager = new MySQLManager<Planetes>();
            this.ListPlaneteUC.LoadItems((await planetesManager.Get()).ToList());
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
