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
    public class PlayerAdminVM
    {
        private Player currentPlayer;
        private PlayerAdmin playerAdmin;
        MySQLManager<Player> playerManager = new MySQLManager<Player>();
        ObservableCollection<Player> playerList = new ObservableCollection<Player>();

        public PlayerAdminVM(PlayerAdmin playerAdmin)
        {
            this.playerAdmin = playerAdmin;

            InitUC();
            InitActions();
            this.playerAdmin.PlayerUC.Player= new Player();
            this.playerAdmin.ListPlayerUC.ItemsList.SelectionChanged += ItemsList_SelectionChanged;
            InitLists();
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
