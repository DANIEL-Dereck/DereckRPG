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
    public class DonjonAdminVM
    {
        private Donjon currentDonjon;
        private DonjonAdmin donjonAdmin;
        MySQLManager<Donjon> donjonManager = new MySQLManager<Donjon>();
        ObservableCollection<Donjon> donjonList = new ObservableCollection<Donjon>();

        public DonjonAdminVM(DonjonAdmin donjonAdmin)
        {
            this.donjonAdmin = donjonAdmin;

            InitUC();
            InitActions();
            InitLists();
        }

        private void InitUC()
        {
            currentDonjon = new Donjon();
            this.donjonAdmin.DonjonUC.Donjon = currentDonjon;
        }

        private async void InitLists()
        {
            this.donjonAdmin.ListDonjonUC.LoadItems((await donjonManager.Get()).ToList());
        }

        private void AddInList()
        {
            this.donjonAdmin.ListDonjonUC.AddItem(this.donjonAdmin.DonjonUC.Donjon);
        }

        private void SupInList()
        {
            this.donjonAdmin.ListDonjonUC.RemoveItem(this.donjonAdmin.DonjonUC.Donjon);
        }

        private void InitActions()
        {
            this.donjonAdmin.btnDelete.Click += btnDelete_Click;
            this.donjonAdmin.btnOk.Click += btnOk_Click;
            this.donjonAdmin.btnNew.Click += btnNew_Click;
            this.donjonAdmin.ListDonjonUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.donjonAdmin.DonjonUC.Donjon.Id != 0)
            {
                await donjonManager.Delete(this.donjonAdmin.DonjonUC.Donjon);
                SupInList();
            }
        }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (this.donjonAdmin.DonjonUC.Donjon != null)
            {
                if (this.donjonAdmin.DonjonUC.Donjon.Id > 0)
                {
                    await donjonManager.Update(this.donjonAdmin.DonjonUC.Donjon);
                }
                else
                {
                    await donjonManager.Insert(this.donjonAdmin.DonjonUC.Donjon);
                    AddInList();
                }
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            this.donjonAdmin.DonjonUC.Donjon = new Donjon();
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Donjon item = (e.AddedItems[0] as Donjon);
                this.donjonAdmin.DonjonUC.Donjon = item;
            }
        }

    }

}
