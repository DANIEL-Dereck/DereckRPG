using WorldOfFantasy.database;
using WorldOfFantasy.database.entiteslinks;
using WorldOfFantasy.entities;
using WorldOfFantasy.viewmodel.playviewmodel;
using WorldOfFantasy.views.administration.playadmin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WorldOfFantasy.views
{
    /// <summary>
    /// Logique d'interaction pour MenuPlay.xaml
    /// </summary>
    public partial class MenuPlay : Page
    {
        private Monster currentMonster = new Monster();
        private Player currentPlayer = new Player();

        MySQLMonsterManager monsterManager = new MySQLMonsterManager();
        MySQLPlayerManager playerManager = new MySQLPlayerManager();

        ObservableCollection<Monster> monsterList = new ObservableCollection<Monster>();
        ObservableCollection<Player> playerList = new ObservableCollection<Player>();



        public MenuPlay()
        {
            InitializeComponent();
            InitActions();
            InitLists();
        }

        private async void InitLists()
        {
            MySQLMonsterManager monsterManager = new MySQLMonsterManager();
            this.ListMonsterUC.LoadItems((await monsterManager.Get()).ToList());

            MySQLPlayerManager playerManager = new MySQLPlayerManager();
            this.ListPlayerUC.LoadItems((await playerManager.Get()).ToList());
        }

        private void InitActions()
        {
            this.ListMonsterUC.ItemsList.SelectionChanged += MonsterList_SelectionChanged;
            this.ListPlayerUC.ItemsList.SelectionChanged += PlayerList_SelectionChanged;
            RemoveDeadMonster();
            RemoveDeadPlayer();
        }

        private void RemoveDeadMonster()
        {
            
        }

        private void RemoveDeadPlayer()
        {

        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            if (this.currentMonster.Id <= 0 || this.currentPlayer.Id <= 0)
            {
                System.Windows.MessageBox.Show("Select player and monster");
            } else if (this.currentMonster.Vie <= 0)
            {
                System.Windows.MessageBox.Show("This monster is dead");
            } else if (this.currentPlayer.Vie <= 0)
            {
                System.Windows.MessageBox.Show("This player is dead");
            } else 
            {
                Page page = new Page();
                NavigationService.Navigate(new CombatAdmin(this.currentPlayer, this.currentMonster));
            }
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as Window).Close();

        }

        #region SelectionChange
        private void MonsterList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Monster item = (e.AddedItems[0] as Monster);
                this.currentMonster = item;
                monsterManager.GetStats(this.currentMonster);
            }
        }

        private void PlayerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                    Player item = (e.AddedItems[0] as Player);
                    this.currentPlayer = item;
                playerManager.GetStats(this.currentPlayer);
            }
        }
        #endregion

    }
}
