using Dereck_RPG.database;
using Dereck_RPG.entities;
using Dereck_RPG.entities.enums;
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
    public class RegionAdminVM
    {
        private Regions currentRegion;
        private RegionsAdmin regionAdmin;
        MySQLManager<Regions> regionManager = new MySQLManager<Regions>();
        ObservableCollection<Regions> regionList = new ObservableCollection<Regions>();

        public RegionAdminVM(RegionsAdmin regionAdmin)
        {
            this.regionAdmin = regionAdmin;

            InitUC();
            InitActions();
            this.regionAdmin.RegionUC.Regions= new Regions();
            this.regionAdmin.ListRegionUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
            InitLists();
        }

        private void InitUC()
        {
            currentRegion = new Regions();
            this.regionAdmin.RegionUC.Regions = currentRegion;
            foreach (Climate climate in Enum.GetValues(typeof(Climate)))
            {
                this.regionAdmin.RegionUC.txtBClimate.Items.Add(climate);
            }
        }

        private async void InitLists()
        {
            this.regionAdmin.ListRegionUC.LoadItems((await regionManager.Get()).ToList());
        }

        private void AddInList()
        {
            this.regionAdmin.ListRegionUC.AddItem(this.regionAdmin.RegionUC.Regions);
        }

        private void SupInList()
        {
            this.regionAdmin.ListRegionUC.RemoveItem(this.regionAdmin.RegionUC.Regions);
        }

        private void InitActions()
        {
            this.regionAdmin.btnDelete.Click += btnDelete_Click;
            this.regionAdmin.btnOk.Click += btnOk_Click;
            this.regionAdmin.btnNew.Click += btnNew_Click;
            this.regionAdmin.ListRegionUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.regionAdmin.RegionUC.Regions.Id != 0)
            {
                await regionManager.Delete(this.regionAdmin.RegionUC.Regions);
                SupInList();
            }
        }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (this.regionAdmin.RegionUC.Regions != null)
            {
                if (this.regionAdmin.RegionUC.Regions.Id > 0)
                {
                    await regionManager.Update(this.regionAdmin.RegionUC.Regions);
                }
                else
                {
                    await regionManager.Insert(this.regionAdmin.RegionUC.Regions);
                    AddInList();
                }
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            this.regionAdmin.RegionUC.Regions = new Regions();
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Regions item = (e.AddedItems[0] as Regions);
                this.regionAdmin.RegionUC.Regions = item;
            }
        }
    }
}
