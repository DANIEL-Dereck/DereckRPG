using Dereck_RPG.entities;
using Dereck_RPG.views.administration.playadmin;
using Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Dereck_RPG.viewmodel.playviewmodel
{
    class CombatAdminVM
    {
        private const int tourmax = 666;
        private int tour;

        private const int maxregen = 10;
        private int regen;

        private CombatAdmin combatAdmin;
        private Player currentPlayer = new Player();
        private Monster currentMonster = new Monster();

        public CombatAdminVM(CombatAdmin combatAdmin)
        {
            this.combatAdmin = combatAdmin;
        }

        public CombatAdminVM(CombatAdmin combatAdmin, Player player, Monster monster)
        {

                this.combatAdmin = combatAdmin;
                this.currentPlayer = player;
                this.currentMonster = monster;


                this.tour = 0;
            this.regen = 0;
                InitUC();
                InitActions();
        }

        private void InitUC()
        {
            combatAdmin.CombatUC.PlayerAffUC.Player = this.currentPlayer;
            combatAdmin.CombatUC.PlayerAffUC.Stats = this.currentPlayer.Stats;

            combatAdmin.CombatUC.MonsterAffUC.Monster = this.currentMonster;
            combatAdmin.CombatUC.MonsterAffUC.Stats = this.currentMonster.Stats;
        }

        #region Combat

        private void InitActions()
        {
            this.combatAdmin.btnAttaque.Click += btnAttaque_Click;
            this.combatAdmin.btnDefence.Click += btnDefence_Click;
            this.combatAdmin.btnRegeneration.Click += btnRegeneration_Click;
            this.combatAdmin.btnAbandonner.Click += btnAbandonner_Click;
        }

        private void btnAttaque_Click(object sender, RoutedEventArgs e)
        {
            int monsterAction = 0;
            if (regen <= maxregen)
            {
                monsterAction = Number.RandomNumber(0, 3);
            }
            else
            {
                monsterAction = Number.RandomNumber(0, 2);
            }

            if (monsterAction == 0)
            {
                currentMonster.Vie = currentMonster.Vie - currentPlayer.attaque();
                currentPlayer.Vie = currentPlayer.Vie - currentMonster.attaque();
            }
            else if (monsterAction == 1)
            {
                if ((currentMonster.Vie + currentMonster.defence() - currentPlayer.attaque()) <= currentMonster.Vie)
                {
                    currentMonster.Vie = currentMonster.Vie + currentMonster.defence() - currentPlayer.attaque();
                }
            }
            else
            {
                if (regen <= maxregen)
                {
                    currentMonster.regeneration();
                    regen += 1;
                }
            }
            this.tour += 1;
            VerifWin();
        }

        private void btnDefence_Click(object sender, RoutedEventArgs e)
        {
            int monsterAction = 0;
            if (regen <= maxregen)
            {
                monsterAction = Number.RandomNumber(0, 3);
            }
            else
            {
                monsterAction = Number.RandomNumber(0, 2);
            }

            if (monsterAction == 0)
            {
                if ((currentPlayer.Vie + currentPlayer.defence() - currentMonster.attaque()) <= currentPlayer.Vie)
                {
                    currentPlayer.Vie = currentPlayer.Vie + currentPlayer.defence() - currentMonster.attaque();
                }
            }
            else if (monsterAction == 1)
            {
                currentMonster.defence();
            }
            else
            {
                if (regen <= maxregen)
                {
                    currentMonster.regeneration();
                    regen += 1;
                }
            }
            this.tour += 1;
            VerifWin();
        }

        private void btnRegeneration_Click(object sender, RoutedEventArgs e)
        {
            int monsterAction = 0;
            if (regen <= maxregen)
            {
                monsterAction = Number.RandomNumber(0, 3);
            }
            else
            {
                monsterAction = Number.RandomNumber(0, 2);
            }
            currentPlayer.regeneration();

            if (monsterAction == 0)
            {
                currentPlayer.Vie = currentPlayer.Vie - currentMonster.attaque();
            } else if (monsterAction == 1)
            {
                currentMonster.defence();
            } else
            {
                if (regen <= maxregen)
                {
                    currentMonster.regeneration();
                    regen += 1;
                }
            }
            this.tour += 1;
            VerifWin();
        }

        private void btnAbandonner_Click(object sender, RoutedEventArgs e)
        {
            this.currentPlayer.Vie = 0;
            this.combatAdmin.NavigationService.GoBack();
        }

        private void VerifWin()
        {
            if (this.currentPlayer.Vie <= 0 || this.currentMonster.Vie <= 0 || this.tour >= tourmax)
            {
                if (this.currentMonster.Vie <= 0)
                {
                    if (this.currentPlayer.Vie <= 0)
                    {
                        this.currentPlayer.Vie = 1000;
                    }
                    System.Windows.MessageBox.Show("You WIN !!!");
                }
                else if (this.currentPlayer.Vie <= 0)
                {
                    System.Windows.MessageBox.Show("Monster WIN !!!");
                }
                 else
                {
                    System.Windows.MessageBox.Show("End of fight");
                }
                this.combatAdmin.NavigationService.GoBack();
            }
        }
        #endregion


    }
}
