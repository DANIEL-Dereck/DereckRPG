using WorldOfFantasy.database;
using WorldOfFantasy.database.entiteslinks;
using WorldOfFantasy.entities;
using WorldOfFantasy.entities.enums;
using WorldOfFantasy.views.administration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WorldOfFantasy.viewmodel
{
    public class MonsterAdminVM
    {
        #region Attribute
        private Monster currentMonster;
        private Stats currentStats;

        private MonsterAdmin monsterAdmin;
        private StatsAdmin statsAdmin;

//        MySQLMonsterManager monsterManager = new MySQLMonsterManager();
        MySQLManager<Monster> monsterManager = new MySQLManager<Monster>();

        MySQLManager<Stats> statsManager = new MySQLManager<Stats>();

        ObservableCollection<Monster> monsterList = new ObservableCollection<Monster>();
        #endregion

        #region ctor
        public MonsterAdminVM(MonsterAdmin monsterAdmin)
        {
            this.monsterAdmin = monsterAdmin;

            InitUC();
            InitActions();
            this.monsterAdmin.MonsterUC.Monster = new Monster();
            this.monsterAdmin.ListMonsterUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
            InitLists();
        }

        public void LoadStatsPage(StatsAdmin statsAdmin)
        {
            this.statsAdmin = statsAdmin;
            InitLUCStats();
            InitUC();
            ClicksGenerator();
        }
        #endregion

        #region Init
        private void InitUC()
        {
            currentMonster = new Monster();
            this.monsterAdmin.MonsterUC.Monster = currentMonster;

            foreach (MonsterRace monsterRace in Enum.GetValues(typeof(MonsterRace)))
            {
                this.monsterAdmin.MonsterUC.txtBRace.Items.Add(monsterRace);
            }
        }

        private async void InitLists()
        {
            this.monsterAdmin.ListMonsterUC.LoadItems((await monsterManager.Get()).ToList());
        }

        private void InitActions()
        {
            this.monsterAdmin.btnDelete.Click += btnDelete_Click;
            this.monsterAdmin.btnOk.Click += btnOk_Click;
            this.monsterAdmin.btnNew.Click += btnNew_Click;
            this.monsterAdmin.MonsterUC.btnStats.Click += btnStats_Click;
            this.monsterAdmin.ListMonsterUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
        }

        private void ClicksGenerator()
        {
            this.statsAdmin.btnNew.Click += btnNewStats_Click;
            this.statsAdmin.btnOk.Click += btnOkStats_Click;
            this.statsAdmin.btnDelete.Click += btnDeleteStats_Click;
        }

        private void InitLUCStats()
        {
            monsterManager.GetStats(currentMonster);
        }
        #endregion

        #region BTN
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
            if (this.monsterAdmin.MonsterUC.Monster.Id != 0)
            {
                await monsterManager.Update(this.monsterAdmin.MonsterUC.Monster);
            }
            else
            {
                Task<Monster> tMonster = monsterManager.Insert(this.monsterAdmin.MonsterUC.Monster);
                Monster monster = (Monster)tMonster.Result;
                this.monsterAdmin.MonsterUC.Monster = monster;
                InitUC();
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            InitUC();
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            this.monsterAdmin.NavigationService.Navigate(new StatsAdmin(this));
        }

        private async void btnNewStats_Click(object sender, RoutedEventArgs e)
        {
            await monsterManager.Insert(this.monsterAdmin.MonsterUC.Monster);
            InitLUCStats();
        }

        private async void btnOkStats_Click(object sender, RoutedEventArgs e)
        {
            await monsterManager.Update(this.monsterAdmin.MonsterUC.Monster);
            InitLUCStats();
        }

        private async void btnDeleteStats_Click(object sender, RoutedEventArgs e)
        {
            await monsterManager.Delete(this.monsterAdmin.MonsterUC.Monster);
            InitLUCStats();
        }

        private void AddInList()
        {
            this.monsterAdmin.ListMonsterUC.AddItem(this.monsterAdmin.MonsterUC.Monster);
        }

        private void SupInList()
        {
            this.monsterAdmin.ListMonsterUC.RemoveItem(this.monsterAdmin.MonsterUC.Monster);
        }
        #endregion

        #region Other
        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                this.monsterAdmin.MonsterUC.Monster = (e.AddedItems[0] as Monster);
            }
        }
        #endregion
    }
}
