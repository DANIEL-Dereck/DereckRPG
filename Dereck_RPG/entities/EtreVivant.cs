using Dereck_RPG.entities.bases;
using Dereck_RPG.entities.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    [Table("EtreVivant")]
    public abstract class EtreVivant : BaseDBEntity
    {
        private String name;
        private int lvl;
        private int vie;
        private Stats stats;
//        [Association("", "", "")]
        private List<Items> stuff;

        public List<Items> Stuff
        {
            get { return stuff; }
            set { stuff = value; }
        }

        public Stats Stats
        {
            get { return stats; }
            set { stats = value; }
        }

        public int Vie
        {
            get { return vie; }
            set { vie = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Lvl
        {
            get { return lvl; }
            set { lvl = value; }
        }

        public void attaque(EtreVivant adversaire)
        {
            //Attaque (stats attaque) - def enemie
            //si Crit attaque + 150%
            if (doACrit())
            {
            }
            else
            {
                
            }
        }

        public void defence()
        {
            //bloque une attaque
            // si crit +150%def
            if (doACrit())
            {
            }
            else
            {
            }

        }

        public void regeneration()
        {
            //Regeneration de 7% de la vie actuel
            //si Crit Regeneration de 15% de la vie actuel
            int regen;

            if (doACrit())
            {
                regen = this.vie % 15;
            }
            else
            {
                regen = this.vie % 7;
            }
            this.vie = this.vie + regen;
        }

        private bool doACrit()
        {
            Random rnd = new Random();
            if (rnd.Next(0, 100) <= this.stats.Critique)
            {
                return (true);
            } else
            {
                return (false);
            }
        }


    }
}
