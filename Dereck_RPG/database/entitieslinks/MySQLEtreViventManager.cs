using Dereck_RPG.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.database.entitieslinks
{
    public class MySQLEtreViventManager : MySQLManager<EtreVivant>
    {
        public void GetStats(EtreVivant etreVivant)
        {
            bool isDetached = this.Entry(etreVivant).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(etreVivant);
            this.Entry(etreVivant).Reference(x => x.Stats).Load();
        }

        public void GetItems(EtreVivant etreVivant)
        {
            bool isDetached = this.Entry(etreVivant).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(etreVivant);
            this.Entry(etreVivant).Collection(x => x.Stuff).Load();
        }
    }
}
