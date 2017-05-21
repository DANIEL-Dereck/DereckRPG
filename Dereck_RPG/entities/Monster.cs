using Dereck_RPG.entities.bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    public class Monster : EtreVivant
    {
        private List<Items> loot;

        public List<Items> Loot
        {
            get { return loot; }
            set { loot = value; }
        }
    }
}
