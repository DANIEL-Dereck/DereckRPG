using Dereck_RPG.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.database.entitieslinks
{
    public class MySQLItemManager : MySQLManager<Items>
    {
        public void GetStats(Items items)
        {
            bool isDetached = this.Entry(items).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(items);
            this.Entry(items).Reference(x => x.Statistique).Load();
        }
    }
}
