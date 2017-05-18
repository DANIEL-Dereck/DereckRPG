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
    public class MonsterAdminVM
    {
        private Monster currentMonster;
        private MonsterAdmin monsterAdmin;
        MySQLManager<Monster> monsterManager = new MySQLManager<Monster>();
        ObservableCollection<Monster> monsterList = new ObservableCollection<Monster>();

        public MonsterAdminVM(MonsterAdmin monsterAdmin)
        {
            this.monsterAdmin = monsterAdmin;

            InitUC();
            InitActions();
            InitLists();
        }

        private void InitUC()
        {
            currentMonster = new Monster();
            this.monsterAdmin.MonsterUC.Monster = currentMonster;
        }

        private async void InitLists()
        {
            this.monsterAdmin.ListMonsterUC.LoadItems((await monsterManager.Get()).ToList());
        }

        private void AddInList()
        {
            this.monsterAdmin.ListMonsterUC.AddItem(this.monsterAdmin.MonsterUC.Monster);
        }

        private void SupInList()
        {
            this.monsterAdmin.ListMonsterUC.RemoveItem(this.monsterAdmin.MonsterUC.Monster);
        }

        private void InitActions()
        {
            this.monsterAdmin.btnDelete.Click += btnDelete_Click;
            this.monsterAdmin.btnOk.Click += btnOk_Click;
            this.monsterAdmin.btnNew.Click += btnNew_Click;
            this.monsterAdmin.ListMonsterUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.monsterAdmin.MonsterUC.Monster.Id != 0)
            {
                await monsterManager.Delete(this.monsterAdmin.MonsterUC.Monster);
                SupInList();
            }
        }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (this.monsterAdmin.MonsterUC.Monster != null)
            {
                if (this.monsterAdmin.MonsterUC.Monster.Id > 0)
                {
                    await monsterManager.Update(this.monsterAdmin.MonsterUC.Monster);
                }
                else
                {
                    await monsterManager.Insert(this.monsterAdmin.MonsterUC.Monster);
                    AddInList();
                }
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            this.monsterAdmin.MonsterUC.Monster = new Monster();
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Monster item = (e.AddedItems[0] as Monster);
                this.monsterAdmin.MonsterUC.Monster = item;
            }
        }

    }
}
