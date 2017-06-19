using Dereck_RPG.entities.bases;
using Dereck_RPG.entities.enums;
using Faker;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    public class Monster : BaseDBEntity
    {
        private String name;
        private int lvl;
        private int vie;
        private Stats stats;
        private MonsterRace monsterRace;

        public String Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
        public int Lvl
        {
            get { return lvl; }
            set { lvl = value; OnPropertyChanged("Lvl"); }
        }

        public int Vie
        {
            get { return vie; }
            set { vie = value; OnPropertyChanged("Vie"); }
        }

        public Stats Stats
        {
            get { return stats; }
            set { stats = value; OnPropertyChanged("Stats"); }
        }

        public MonsterRace MonsterRace
        {
            get { return monsterRace; }
            set { monsterRace = value; OnPropertyChanged("MonsterRace"); }
        }

        #region method
        public int attaque()
        {
            //Attaque (stats attaque) - def enemie
            //si Crit attaque + 100%
            if (doACrit())
            {
                return (this.Stats.Attaque * 2);
            }
            else
            {
                return (this.Stats.Attaque);
            }
        }

        public int defence()
        {
            //bloque une attaque
            // si crit +100%def
            if (doACrit())
            {
                return (this.Stats.Defence * 2);
            }
            else
            {
                return (this.Stats.Defence);
            }

        }

        public void regeneration()
        {
            double regen;

            if (doACrit())
            {
                regen = this.Vie * (0.15) ;
            }
            else
            {
                regen = this.Vie * (0.07);
            }
            this.vie = this.vie + (int)regen;
        }

        private bool doACrit()
        {
            if (Number.RandomNumber(0, 100) <= this.stats.Critique)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        #endregion
    }
}
