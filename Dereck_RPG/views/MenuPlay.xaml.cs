using Dereck_RPG.database;
using Dereck_RPG.entities;
using Dereck_RPG.viewmodel.playviewmodel;
using Dereck_RPG.views.administration.playadmin;
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

namespace Dereck_RPG.views
{
    /// <summary>
    /// Logique d'interaction pour MenuPlay.xaml
    /// </summary>
    public partial class MenuPlay : Page
    {
        private Monster currentMonster;
        private Player currentPlayer;

        MySQLManager<Monster> monsterManager = new MySQLManager<Monster>();
        MySQLManager<Player> playerManager = new MySQLManager<Player>();

        ObservableCollection<Monster> monsterList = new ObservableCollection<Monster>();
        ObservableCollection<Player> playerList = new ObservableCollection<Player>();



        public MenuPlay()
        {
            InitializeComponent();
            InitLists();
        }

        private async void InitLists()
        {
            MySQLManager<Monster> monsterManager = new MySQLManager<Monster>();
            this.ListMonsterUC.LoadItems((await monsterManager.Get()).ToList());

            MySQLManager<Player> playerManager = new MySQLManager<Player>();
            this.ListPlayerUC.LoadItems((await playerManager.Get()).ToList());

        }

        private void InitActions()
        {
            this.ListMonsterUC.ItemsList.SelectionChanged += MonsterList_SelectionChanged;
            this.ListPlayerUC.ItemsList.SelectionChanged += PlayerList_SelectionChanged;
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            Page page = new Page();
            NavigationService.Navigate(new CombatAdmin(currentPlayer, currentMonster));
        }

        private void InitLUCPlanete()
        {
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
            }
        }

        private void PlayerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                    Player item = (e.AddedItems[0] as Player);
                    this.currentPlayer = item;
            }
        }
        #endregion

    }
}
