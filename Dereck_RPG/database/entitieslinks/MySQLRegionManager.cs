using Dereck_RPG.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.database.entitieslinks
{
    public class MySQLRegionManager : MySQLManager<Regions>
    {
        public void GetMonster(Regions region)
        {
            bool isDetached = this.Entry(region).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(region);
            this.Entry(region).Collection(x => x.Monster).Load();
        }
    }
}
