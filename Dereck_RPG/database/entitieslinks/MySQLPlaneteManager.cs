using Dereck_RPG.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Dereck_RPG.database.entitieslinks
{
    public class MySQLPlaneteManager : MySQLManager<Planetes>
    {
        public void GetRegion(Planetes planetes)
        {
            bool isDetached = this.Entry(planetes).State == EntityState.Detached;
            if (isDetached)
                this.DbSetT.Attach(planetes);
            this.Entry(planetes).Collection(x => x.Region).Load();
        }
    }
}
