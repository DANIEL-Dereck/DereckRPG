using WorldOfFantasy.database;
using WorldOfFantasy.entities;
using WorldOfFantasy.viewmodel;
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
using WorldOfFantasy.database.entiteslinks;

namespace WorldOfFantasy.views.administration
{
    /// <summary>
    /// Logique d'interaction pour PlayerAdmin.xaml
    /// </summary>
    public partial class PlayerAdmin : Page
    {

            public PlayerAdmin()
            {
                InitializeComponent();
                this.DataContext = new PlayerAdminVM(this);
                InitLists();
            }


            private async void InitLists()
            {
            MySQLPlayerManager playerManager = new MySQLPlayerManager();
            this.ListPlayerUC.LoadItems((await playerManager.Get()).ToList());
        }
    }
}

