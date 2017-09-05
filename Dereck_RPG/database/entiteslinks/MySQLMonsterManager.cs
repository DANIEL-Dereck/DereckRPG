using WorldOfFantasy.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfFantasy.database.entiteslinks
{
    class MySQLMonsterManager : MySQLManager<Monster>
    {
        public void GetStats(Monster monster)
        {
            bool isDetached = this.Entry(monster).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(monster);
            this.Entry(monster).Reference(x => x.Stats).Load();
        }
    }
}
