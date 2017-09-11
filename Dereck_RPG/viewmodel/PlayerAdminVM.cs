using WorldOfFantasy.database;
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
using WorldOfFantasy.database.entiteslinks;

namespace WorldOfFantasy.viewmodel
{
    public class PlayerAdminVM
    {
        private Player currentPlayer;
        private PlayerAdmin playerAdmin;

//        MySQLManager<Player> playerManager = new MySQLManager<Player>();
        MySQLPlayerManager playerManager = new MySQLPlayerManager();

        ObservableCollection<Player> playerList = new ObservableCollection<Player>();

        private Stats currentStats;
        private StatsAdmin statsAdmin;

        public PlayerAdminVM(PlayerAdmin playerAdmin)
        {
            this.playerAdmin = playerAdmin;

            InitUC();
            InitActions();
            this.playerAdmin.PlayerUC.Player= new Player();
            this.playerAdmin.ListPlayerUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
            InitLists();
        }

        public void LoadStatsPage(StatsAdmin statsAdmin)
        {
            this.statsAdmin = statsAdmin;
            InitLUCStats();
            InitUC();
            ClicksGenerator();
        }

        private void InitLUCStats()
        {
            playerManager.GetStats(currentPlayer);
        }

        private void ClicksGenerator()
        {
            this.statsAdmin.btnNew.Click += btnNewStats_Click;
            this.statsAdmin.btnOk.Click += btnOkStats_Click;
            this.statsAdmin.btnDelete.Click += btnDeleteStats_Click;
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            this.playerAdmin.NavigationService.Navigate(new StatsAdmin(this));
        }

        private async void btnNewStats_Click(object sender, RoutedEventArgs e)
        {
            await playerManager.Insert(this.playerAdmin.PlayerUC.Player);
            InitLUCStats();
        }

        private async void btnOkStats_Click(object sender, RoutedEventArgs e)
        {
            await playerManager.Update(this.playerAdmin.PlayerUC.Player);
            InitLUCStats();
        }

        private async void btnDeleteStats_Click(object sender, RoutedEventArgs e)
        {
            await playerManager.Delete(this.playerAdmin.PlayerUC.Player);
            InitLUCStats();
        }


        private void InitUC()
        {
            currentPlayer = new Player();
            this.playerAdmin.PlayerUC.Player = currentPlayer;
            foreach (Race race in Enum.GetValues(typeof(Race)))
            {
                this.playerAdmin.PlayerUC.txtBRace.Items.Add(race);
            }
            foreach (Classe classe in Enum.GetValues(typeof(Classe)))
            {
                this.playerAdmin.PlayerUC.txtBClasse.Items.Add(classe);
            }
        }

        private async void InitLists()
        {
            this.playerAdmin.ListPlayerUC.LoadItems((await playerManager.Get()).ToList());
        }

        private void AddInList()
        {
            this.playerAdmin.ListPlayerUC.AddItem(this.playerAdmin.PlayerUC.Player);
        }

        private void SupInList()
        {
            this.playerAdmin.ListPlayerUC.RemoveItem(this.playerAdmin.PlayerUC.Player);
        }

        private void InitActions()
        {
            this.playerAdmin.btnDelete.Click += btnDelete_Click;
            this.playerAdmin.btnOk.Click += btnOk_Click;
            this.playerAdmin.btnNew.Click += btnNew_Click;
            this.playerAdmin.PlayerUC.btnStats.Click += btnStats_Click;
            this.playerAdmin.ListPlayerUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.playerAdmin.PlayerUC.Player.Id != 0)
            {
                await playerManager.Delete(this.playerAdmin.PlayerUC.Player);
                SupInList();
            }
        }

        private async void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (this.playerAdmin.PlayerUC.Player != null)
            {
                if (this.playerAdmin.PlayerUC.Player.Id > 0)
                {
                    await playerManager.Update(this.playerAdmin.PlayerUC.Player);
                }
                else
                {
                    await playerManager.Insert(this.playerAdmin.PlayerUC.Player);
                    AddInList();
                }
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            this.playerAdmin.PlayerUC.Player = new Player();
        }

        private void ItemsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                this.playerAdmin.PlayerUC.Player = (e.AddedItems[0] as Player);
            }
            /*
            if (e.AddedItems.Count > 0)
            {
                Player item = (e.AddedItems[0] as Player);
                this.playerAdmin.PlayerUC.Player = item;
            }
            */
        }

    }
}
