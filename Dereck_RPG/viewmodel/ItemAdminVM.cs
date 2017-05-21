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
    public class ItemAdminVM
    {
        private Items currentItem;
        private ItemAdmin itemAdmin;
        MySQLManager<Items> itemManager = new MySQLManager<Items>();
        ObservableCollection<Items> itemList = new ObservableCollection<Items>();

        public ItemAdminVM(ItemAdmin itemAdmin)
        {
            this.itemAdmin = itemAdmin;

            InitUC();
            InitActions();
            InitLists();
        }

        private void InitUC()
        {
            currentItem = new Items();
            this.itemAdmin.ItemUC.Item = currentItem;
            foreach (Rarete rarete in Enum.GetValues(typeof(Rarete)))
            {
                this.itemAdmin.ItemUC.txtBRarete.Items.Add(rarete);
            }
            foreach (ItemCategory itemCat in Enum.GetValues(typeof(ItemCategory)))
            {
                this.itemAdmin.ItemUC.txtBCategorie.Items.Add(itemCat);
            }
        }

        private async void InitLists()
        {
            this.itemAdmin.ListItemUC.LoadItems((await itemManager.Get()).ToList());
        }

        private void AddInList()
        {
            this.itemAdmin.ListItemUC.AddItem(this.itemAdmin.ItemUC.Item);
        }

        private void SupInList()
        {
            this.itemAdmin.ListItemUC.RemoveItem(this.itemAdmin.ItemUC.Item);
        }

        private void InitActions()
        {
            this.itemAdmin.btnDelete.Click += btnDelete_Click;
            this.itemAdmin.btnOk.Click += btnOk_Click;
            this.itemAdmin.btnNew.Click += btnNew_Click;
            this.itemAdmin.ListItemUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.itemAdmin.ItemUC.Item.Id != 0)
            {
                await itemManager.Delete(this.itemAdmin.ItemUC.Item);
                SupInList();
            }
        }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (this.itemAdmin.ItemUC.Item != null)
            {
                if (this.itemAdmin.ItemUC.Item.Id > 0)
                {
                    await itemManager.Update(this.itemAdmin.ItemUC.Item);
                }
                else
                {
                    await itemManager.Insert(this.itemAdmin.ItemUC.Item);
                    AddInList();
                }
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            this.itemAdmin.ItemUC.Item = new Items();
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Items item = (e.AddedItems[0] as Items);
                this.itemAdmin.ItemUC.Item = item;
            }
        }

    }

}
