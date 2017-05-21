using Dereck_RPG.entities.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    public class Player : EtreVivant
    {
        private Classe classe;
        private List<Items> stuff;

        public Classe Classe
        {
            get { return classe; }
            set { classe = value; }
        }
        public List<Items> Stuff
        {
            get { return stuff; }
            set { stuff = value; }
        }
    }
}
