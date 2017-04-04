using Dereck_RPG.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    public class Player : EtreVivant
    {
        private Classe classe;
        private List<Quest> quest;

        public Classe Classe
        {
            get { return classe; }
            set { classe = value; }
        }

        public List<Quest> Quest
        {
            get { return quest; }
            set { quest = value; }
        }

    }
}
