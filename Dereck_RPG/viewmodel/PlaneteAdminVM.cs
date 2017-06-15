using Dereck_RPG.database;
using Dereck_RPG.database.entitieslinks;
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
        private MySQLPlaneteManager planeteManager = new MySQLPlaneteManager();
        private RegionsAdmin regionAdmin;
        ObservableCollection<Planetes> planeteList = new ObservableCollection<Planetes>();
        public object UCPlaneteList { get; private set; }

        #region ctor
        public PlaneteAdminVM(PlanetesAdmin planeteAdmin)
        {
            this.planeteAdmin = planeteAdmin;

            InitUC();
            InitLUC();
            InitActions();
        }
        #endregion

        #region init

        private void InitUC()
        {
            currentPlanete = new Planetes();
            this.planeteAdmin.PlaneteUC.Planete = currentPlanete;
        }

        private async void InitLUC()
        {
            this.planeteAdmin.ListPlaneteUC.LoadItems((await planeteManager.Get()).ToList());
        }

        private void InitActions()
        {
            this.planeteAdmin.btnDelete.Click += btnDelete_Click;
            this.planeteAdmin.btnOk.Click += btnOk_Click;
            this.planeteAdmin.btnNew.Click += btnNew_Click;
            this.planeteAdmin.ListPlaneteUC.DuplicateAddressContextMenu.Click += DuplicatePlanete_Click;
            this.planeteAdmin.ListPlaneteUC.RemoveAddressContextMenu.Click += btnDelete_Click;
            this.planeteAdmin.ListPlaneteUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
            this.planeteAdmin.btnRegion.Click += btnRegion_Click;
        }
        #endregion

        #region region
        private void btnRegion_Click(object sender, RoutedEventArgs e)
        {
            if (currentPlanete.Region != null)
            {
                this.planeteAdmin.NavigationService.Navigate(new RegionsAdmin(this));
            }
        }

        public void LoadRegionPage(RegionsAdmin regionAdmin)
        {
            this.regionAdmin = regionAdmin;
            InitLUCRegion();
            InitUC();
            ClicksGenerator();
        }

        private async void btnNewRegion_Click(object sender, RoutedEventArgs e)
        {
            await planeteManager.Insert(this.planeteAdmin.PlaneteUC.Planete);
            this.regionAdmin.RegionUC.txtBName.Text = "";
            this.regionAdmin.RegionUC.txtBClimate.Text = "";
        }

        private async void btnDeleteRegion_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        private async void btnOkRegion_Click(object sender, RoutedEventArgs e)
        {
            await planeteManager.Update(this.planeteAdmin.PlaneteUC.Planete);
            InitLUCRegion();
        }

        private async void btnDonjon_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InitLUCRegion()
        {
            planeteManager.GetRegion(currentPlanete);
        }
        #endregion

        #region planete
        private void DuplicatePlanete_Click(object sender, RoutedEventArgs e)
        {
            Planetes planete = new entities.Planetes();
            planete.Name = this.planeteAdmin.PlaneteUC.Planete.Name;
            planete.Region = this.planeteAdmin.PlaneteUC.Planete.Region;

            Task<Planetes> tPlanete = planeteManager.Insert(planete);
            Planetes planeteRes = (Planetes)tPlanete.Result;
            this.planeteAdmin.PlaneteUC.Planete = planeteRes;
            InitLUC();
        }

        private void AddInList()
        {
            this.planeteAdmin.ListPlaneteUC.AddItem(this.planeteAdmin.PlaneteUC.Planete);
        }

        private void SupInList()
        {
            this.planeteAdmin.ListPlaneteUC.RemoveItem(this.planeteAdmin.PlaneteUC.Planete);
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
            if (this.planeteAdmin.PlaneteUC.Planete != null)
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
                    currentPlanete = (e.AddedItems[0] as Planetes);
                    this.planeteAdmin.PlaneteUC.Planete = currentPlanete;
                planeteManager.GetRegion(currentPlanete);                
            }
        }
        #endregion

        #region other
        private void ClicksGenerator()
        {
            this.regionAdmin.btnNew.Click += btnNewRegion_Click;
            this.regionAdmin.btnDelete.Click += btnDeleteRegion_Click;
            this.regionAdmin.btnOk.Click += btnOkRegion_Click;

            this.regionAdmin.RegionUC.btnDonjon.Click += btnDonjon_Click;
        }
        #endregion




















    }
}
