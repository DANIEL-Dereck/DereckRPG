using DereckRPG.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DereckRPG.entities
{
    public class Quest : BaseDBEntity
    {
        private String name;
        private String description;
        private List<Items> recompense;
        private Quest preRequis;
        private List<Objectif> objectif;
        private Pnj pnjReference;

        public Pnj PnjReference
        {
            get { return pnjReference; }
            set { pnjReference = value; }
        }

        public List<Objectif> Objectif
        {
            get { return objectif; }
            set { objectif = value; }
        }

        public Quest PreRequis
        {
            get { return preRequis; }
            set { preRequis = value; }
        }

        public List<Items> Recompense
        {
            get { return recompense; }
            set { recompense = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
