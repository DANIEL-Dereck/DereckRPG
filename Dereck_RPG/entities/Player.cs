using Dereck_RPG.entities.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    [Table("Player")]
    public class Player : EtreVivant
    {
        private Classe classe;
        private Race race;

        public Race Race
        {
            get { return race; }
            set { race = value; }
        }

        public Classe Classe
        {
            get { return classe; }
            set { classe = value; }
        }



    }
}
