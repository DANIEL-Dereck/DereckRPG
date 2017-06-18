using Dereck_RPG.database;
using Dereck_RPG.entities;
using Dereck_RPG.views.administration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Dereck_RPG.viewmodel
{
    class StatsAdminVM
    {
        private Stats currentStats;
        private StatsAdmin statsAdmin;
        MySQLManager<Stats> statsManager = new MySQLManager<Stats>();
        ObservableCollection<Stats> statsList = new ObservableCollection<Stats>();

        public StatsAdminVM(StatsAdmin statsAdmin)
        {
            this.statsAdmin = statsAdmin;

            InitUC();
            InitActions();
            InitLists();
        }

        private void InitUC()
        {
            currentStats = new Stats();
            this.statsAdmin.StatsUC.Stats = currentStats;
        }

        private async void InitLists()
        {
            this.statsAdmin.ListStatsUC.LoadItems((await statsManager.Get()).ToList());
        }

        private void AddInList()
        {
            this.statsAdmin.ListStatsUC.AddItem(this.statsAdmin.StatsUC.Stats);
        }

        private void SupInList()
        {
            this.statsAdmin.ListStatsUC.RemoveItem(this.statsAdmin.StatsUC.Stats);
        }

        private void InitActions()
        {
            this.statsAdmin.btnDelete.Click += btnDelete_Click;
            this.statsAdmin.btnOk.Click += btnOk_Click;
            this.statsAdmin.btnNew.Click += btnNew_Click;
            this.statsAdmin.ListStatsUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.statsAdmin.StatsUC.Stats.Id != 0)
            {
                await statsManager.Delete(this.statsAdmin.StatsUC.Stats);
                SupInList();
            }
        }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (this.statsAdmin.StatsUC.Stats != null)
            {
                if (this.statsAdmin.StatsUC.Stats.Id > 0)
                {
                    await statsManager.Update(this.statsAdmin.StatsUC.Stats);
                }
                else
                {
                    await statsManager.Insert(this.statsAdmin.StatsUC.Stats);
                    AddInList();
                }
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            this.statsAdmin.StatsUC.Stats = new Stats();
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                this.statsAdmin.StatsUC.Stats = (e.AddedItems[0] as Stats);
            }
        }


    }
}
