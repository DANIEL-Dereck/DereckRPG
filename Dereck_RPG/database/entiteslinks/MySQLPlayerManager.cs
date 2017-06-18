using Dereck_RPG.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.database.entiteslinks
{
    class MySQLPlayerManager : MySQLManager<Player>
    {
        public void GetStats(Player player)
        {
            bool isDetached = this.Entry(player).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(player);
            this.Entry(player).Reference(x => x.Stats).Load();
        }
    }
}
