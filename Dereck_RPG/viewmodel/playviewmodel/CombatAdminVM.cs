using Dereck_RPG.entities;
using Dereck_RPG.views.administration.playadmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.viewmodel.playviewmodel
{
    class CombatAdminVM
    {
        private CombatAdmin combatAdmin;
        private Player currentPlayer;
        private Monster currentMonster;

        public CombatAdminVM(CombatAdmin combatAdmin)
        {
            this.combatAdmin = combatAdmin;
        }

        public CombatAdminVM(CombatAdmin combatAdmin, Player player, Monster monster)
        {
            this.combatAdmin = combatAdmin;
            this.currentPlayer = player;
            this.currentMonster = monster;
        }
    }
}
