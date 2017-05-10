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
    public class PlaneteAdminVM
    {
        private Planetes currentPlanete;
        private PlanetesAdmin planeteAdmin;
        MySQLManager<Planetes> planeteManager = new MySQLManager<Planetes>();
        ObservableCollection<Planetes> planeteList = new ObservableCollection<Planetes>();

        public PlaneteAdminVM(PlanetesAdmin planeteAdmin)
        {
            this.planeteAdmin = planeteAdmin;

            InitUC();
            InitActions();
            InitLists();
        }

        private void InitUC()
        {
            currentPlanete = new Planetes();
            this.planeteAdmin.PlaneteUC.Planete = currentPlanete;
        }

        private async void InitLists()
        {
            this.planeteAdmin.ListPlaneteUC.LoadItems((await planeteManager.Get()).ToList());
        }

        private void AddInList()
        {
            this.planeteAdmin.ListPlaneteUC.AddItem(this.planeteAdmin.PlaneteUC.Planete);
        }

        private void SupInList()
        {
            this.planeteAdmin.ListPlaneteUC.RemoveItem(this.planeteAdmin.PlaneteUC.Planete);
        }

        private void InitActions()
        {
            this.planeteAdmin.btnDelete.Click += btnDelete_Click;
            this.planeteAdmin.btnOk.Click += btnOk_Click;
            this.planeteAdmin.btnNew.Click += btnNew_Click;
            this.planeteAdmin.ListPlaneteUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.planeteAdmin.PlaneteUC.Planete.Id != 0)
            {
                await planeteManager.Delete(this.planeteAdmin.PlaneteUC.Planete);
                SupInList();
            }
        }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (this.planeteAdmin.PlaneteUC.Planete!= null)
            {
                if (this.planeteAdmin.PlaneteUC.Planete.Id > 0)
                {
                    await planeteManager.Update(this.planeteAdmin.PlaneteUC.Planete);
                }
                else
                {
                    await planeteManager.Insert(this.planeteAdmin.PlaneteUC.Planete);
                    AddInList();
                }
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            this.planeteAdmin.PlaneteUC.Planete = new Planetes();
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Planetes item = (e.AddedItems[0] as Planetes);
                this.planeteAdmin.PlaneteUC.Planete = item;
            }
        }

    }
}
