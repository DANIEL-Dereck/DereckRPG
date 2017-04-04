using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    public class Pnj : EtreVivant
    {
        private List<Items> loot;
        private List<Quest> quest;

        public List<Items> Loot
        {
            get { return loot; }
            set { loot = value; }
        }
        public List<Quest> Quest
        {
            get { return quest; }
            set { quest = value; }
        }

    }
}
