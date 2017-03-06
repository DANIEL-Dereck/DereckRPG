using DereckRPG.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DereckRPG.entities
{
    public class Caracteristiques : BaseDBEntity
    {
        private int force;
        private int intelligence;
        private int chance;
        private int agilite;
        private int vie;

        public int Vie
        {
            get { return vie; }
            set { vie = value; }
        }

        public int Agilite
        {
            get { return agilite; }
            set { agilite = value; }
        }

        public int Chance
        {
            get { return chance; }
            set { chance = value; }
        }
        
        public int Intelligence
        {
            get { return intelligence; }
            set { intelligence = value; }
        }

        public int Force
        {
            get { return force; }
            set { force = value; }
        }

    }
}
