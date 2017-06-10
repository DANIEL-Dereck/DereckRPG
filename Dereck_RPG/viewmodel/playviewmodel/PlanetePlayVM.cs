using Dereck_RPG.database;
using Dereck_RPG.entities;
using Dereck_RPG.views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Dereck_RPG.viewmodel.playviewmodel
{
    class PlanetePlayVM
    {
        private Planetes currentPlanete;
        private MenuPlay planetePlay;
        MySQLManager<Planetes> planeteManager = new MySQLManager<Planetes>();
        ObservableCollection<Planetes> planeteList = new ObservableCollection<Planetes>();


        public PlanetePlayVM(MenuPlay planetePlay)
        {
            this.planetePlay = planetePlay;

            InitUC();
            InitActions();
            InitLists();
        }

        private void InitUC()
        {

        }

        private async void InitLists()
        {
            this.planetePlay.ListPlaneteUC.LoadItems((await planeteManager.Get()).ToList());
        }

        private void InitActions()
        {
            this.planetePlay.ListPlaneteUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Planetes item = (e.AddedItems[0] as Planetes);
                
            }
        }

    }
}