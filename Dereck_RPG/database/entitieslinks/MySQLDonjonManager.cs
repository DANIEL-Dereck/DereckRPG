using Dereck_RPG.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.database.entitieslinks
{
    public class MySQLDonjonManager : MySQLManager<Donjon>
    {
        public void GetMonster(Donjon donjon)
        {
            bool isDetached = this.Entry(donjon).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(donjon);
            this.Entry(donjon).Collection(x => x.Monster).Load();
        }

        public void GetMiniBoss(Donjon donjon)
        {
            bool isDetached = this.Entry(donjon).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(donjon);
            this.Entry(donjon).Reference(x => x.MiniBoss).Load();
        }

        public void GetBoss(Donjon donjon)
        {
            bool isDetached = this.Entry(donjon).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(donjon);
            this.Entry(donjon).Reference(x => x.Boss).Load();
        }
    }
}
