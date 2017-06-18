using Dereck_RPG.database;
using Dereck_RPG.entities;
using Dereck_RPG.viewmodel;
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

namespace Dereck_RPG.views.administration
{
    /// <summary>
    /// Logique d'interaction pour StatsAdmin.xaml
    /// </summary>
    public partial class StatsAdmin : Page
    {
        public StatsAdmin()
        {
            InitializeComponent();
            this.DataContext = new StatsAdminVM(this);
            InitLists();
        }

        public StatsAdmin(MonsterAdminVM monsterAdminVM)
        {
            InitializeComponent();
            this.DataContext = monsterAdminVM;
            InitLists();
        }

        public StatsAdmin(PlayerAdminVM playerAdminVM)
        {
            InitializeComponent();
            this.DataContext = playerAdminVM;
            InitLists();
        }

        private async void InitLists()
        {
            MySQLManager<Stats> statsManager = new MySQLManager<Stats>();
            this.ListStatsUC.LoadItems((await statsManager.Get()).ToList());
        }
    }
}
