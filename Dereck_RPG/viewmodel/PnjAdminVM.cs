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
    public class PnjAdminVM
    {
        private Pnj currentPnj;
        private PnjAdmin pnjAdmin;
        MySQLManager<Pnj> pnjManager = new MySQLManager<Pnj>();
        ObservableCollection<Pnj> pnjList = new ObservableCollection<Pnj>();

        public PnjAdminVM(PnjAdmin pnjAdmin)
        {
            this.pnjAdmin = pnjAdmin;

            InitUC();
            InitActions();
            InitLists();
        }

        private void InitUC()
        {
            currentPnj = new Pnj();
            this.pnjAdmin.PnjUC.Pnj = currentPnj;
            foreach (Race race in Enum.GetValues(typeof(Race)))
            {
                this.pnjAdmin.PnjUC.txtBRace.Items.Add(race);
            }
        }

        private async void InitLists()
        {
            this.pnjAdmin.ListPnjUC.LoadItems((await pnjManager.Get()).ToList());
        }

        private void AddInList()
        {
            this.pnjAdmin.ListPnjUC.AddItem(this.pnjAdmin.PnjUC.Pnj);
        }

        private void SupInList()
        {
            this.pnjAdmin.ListPnjUC.RemoveItem(this.pnjAdmin.PnjUC.Pnj);
        }

        private void InitActions()
        {
            this.pnjAdmin.btnDelete.Click += btnDelete_Click;
            this.pnjAdmin.btnOk.Click += btnOk_Click;
            this.pnjAdmin.btnNew.Click += btnNew_Click;
            this.pnjAdmin.ListPnjUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.pnjAdmin.PnjUC.Pnj.Id != 0)
            {
                await pnjManager.Delete(this.pnjAdmin.PnjUC.Pnj);
                SupInList();
            }
        }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (this.pnjAdmin.PnjUC.Pnj != null)
            {
                if (this.pnjAdmin.PnjUC.Pnj.Id > 0)
                {
                    await pnjManager.Update(this.pnjAdmin.PnjUC.Pnj);
                }
                else
                {
                    await pnjManager.Insert(this.pnjAdmin.PnjUC.Pnj);
                    AddInList();
                }
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            this.pnjAdmin.PnjUC.Pnj = new Pnj();
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Pnj item = (e.AddedItems[0] as Pnj);
                this.pnjAdmin.PnjUC.Pnj = item;
            }
        }
    }

}
