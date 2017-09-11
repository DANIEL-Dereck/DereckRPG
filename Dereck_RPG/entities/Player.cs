using WorldOfFantasy.entities.bases;
using WorldOfFantasy.entities.enums;
using Faker;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfFantasy.entities
{
    public class Player : BaseDBEntity
    {
        #region attribute
        private String name;
        private int lvl;
        private int vie;
        private Stats stats;
        private Classe classe;
        private Race race;
        #endregion

        #region ctor
        public Player()
        {
        }
        #endregion

        #region propfull
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

        public Classe Classe
        {
            get { return classe; }
            set { classe = value; OnPropertyChanged("Classe"); }
        }

        public Race Race
        {
            get { return race; }
            set { race = value; OnPropertyChanged("Race"); }
        }
        #endregion

        #region method
        public int attack()
        {
            //attack (stats attack) - def enemie
            //si Crit attack + 100%
            if (doACrit())
            {
                return ((this.Stats.Attack * 2) + this.Lvl);
            }
            else
            {
                return (this.Stats.Attack + this.Lvl);
            }
        }

        public int defence()
        {
            //bloque une attack
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
                regen = this.Vie * (0.2);
            }
            else
            {
                regen = this.Vie * (0.07);
            }
            this.vie = this.vie + (int)regen;
        }

        private bool doACrit()
        {
            if (Number.RandomNumber(0, 100) <= this.stats.Critical)
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
