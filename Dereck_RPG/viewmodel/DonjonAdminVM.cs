using ClassLibrary2.Entities.Reflection;
using Dereck_RPG.database;
using Dereck_RPG.database.entitieslinks;
using Dereck_RPG.entities;
using Dereck_RPG.views.administration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Dereck_RPG.viewmodel
{
    public class DonjonAdminVM
    {
        #region Attribute
        private Donjon currentDonjon;
        private DonjonAdmin donjonAdmin;
        MySQLDonjonManager donjonManager = new MySQLDonjonManager();
        ObservableCollection<Donjon> donjonList = new ObservableCollection<Donjon>();
        #endregion

        #region ctor
        public DonjonAdminVM(DonjonAdmin donjonAdmin)
        {
            this.donjonAdmin = donjonAdmin;

            InitLists();
            InitUC();
            InitActions();
        }
        #endregion

        #region init method
        private void InitUC()
        {
            this.resetDonjon();
        }

        private async void InitLists()
        {
            this.donjonAdmin.ListDonjonUC.LoadItems((await donjonManager.Get()).ToList());
        }

        private void InitActions()
        {
            this.donjonAdmin.btnDelete.Click += BtnDelete_Click;
            this.donjonAdmin.btnOk.Click += btnOk_Click;
            this.donjonAdmin.btnNew.Click += btnNew_Click;
            this.donjonAdmin.ListDonjonUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
            this.donjonAdmin.ListDonjonUC.RemoveDonjonContextMenu.Click += RemoveDonjonContextMenu_OnClick;
            this.donjonAdmin.ListDonjonUC.DuplicateDonjonContextMenu.Click += DuplicateDonjonContextMenu_OnClick;
        }
        #endregion

        #region event
        #region list


        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Donjon item = (e.AddedItems[0] as Donjon);
                currentDonjon = item;
                donjonManager.GetBoss(currentDonjon);
                donjonManager.GetMiniBoss(currentDonjon);
                donjonManager.GetMonster(currentDonjon);
                this.donjonAdmin.DonjonUC.Donjon = currentDonjon;
            }
        }
        #endregion

        #region Btn
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            currentDonjon = this.donjonAdmin.DonjonUC.Donjon;

            if (currentDonjon.Id == 0)
            {
                MessageBox.Show("Cannot delete new element in database");
            }
            else
            {
                MessageBoxResult mbr = MessageBox.Show("Do you really want to delete this item ?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);

                if (mbr == MessageBoxResult.OK)
                {
                    confirmDelete();                }
            }
        }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            currentDonjon = this.donjonAdmin.DonjonUC.Donjon;

            if (currentDonjon.Id != 0)
            {
                try
                {
                    await donjonManager.Update(currentDonjon);
                }
                catch (DbEntityValidationException dbe)
                {
                    MessageBox.Show("One or more fields are not valid.");
                    Console.WriteLine(dbe);
                }
            }
            else
            {
                try
                {
                    await donjonManager.Insert(currentDonjon);
                    this.donjonAdmin.ListDonjonUC.AddItem(currentDonjon);
                }
                catch (DbEntityValidationException dbe)
                {
                    MessageBox.Show("One or more fields are not valid.");
                    Console.WriteLine(dbe);
                }
            }
        }
    

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            resetDonjon();
        }

        #endregion

        #region ContextMenu
        private void RemoveDonjonContextMenu_OnClick(object sender, RoutedEventArgs e)
        {
         //   confirmDelete();
        }

        /**
         * Callback on "Duplicate" item in Context menu
         */
        private async void DuplicateDonjonContextMenu_OnClick(object sender, RoutedEventArgs e)
        {
            if (this.donjonAdmin.ListDonjonUC.ItemsList.SelectedIndex > -1)
            {
                var donjon = new Donjon();
                donjon = (Donjon)this.donjonAdmin.ListDonjonUC.ItemsList.SelectedItem;
                donjonManager.GetBoss(donjon);
                donjonManager.GetMiniBoss(donjon);
                donjonManager.GetMonster(donjon);
                await donjonManager.Insert(donjon);
                this.donjonAdmin.ListDonjonUC.LoadItems((await donjonManager.Get()).ToList());
            }

        }
        #endregion

        #endregion

        #region util
        private async void confirmDelete()
        {
            MessageBoxResult mbr = MessageBox.Show("Do you really want to delete this item ?", "Confirm", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);

            if (mbr == MessageBoxResult.OK)
            {
                await donjonManager.Delete(currentDonjon);
                this.donjonAdmin.ListDonjonUC.RemoveItem(currentDonjon);
                this.resetDonjon();
            }
        }

        private void resetDonjon()
        {
            currentDonjon = new Donjon();
            this.donjonAdmin.DonjonUC.Donjon = currentDonjon;
        }

    #endregion
}
}
