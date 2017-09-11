using WorldOfFantasy.entities.bases;
using Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfFantasy.entities
{
    public class Stats : BaseDBEntity
    {
        #region attribute
        private int attack;
        private int defence;
        private int critical;
        #endregion

        #region constructor
        public Stats()
        {

        }

        public Stats(int att, int def, int crit)
        {
            this.attack = att;
            this.defence = def;
            this.critical = crit;
        }
        #endregion

        #region properties
        public int Critical
        {
            get { return critical; }
            set { critical = value; OnPropertyChanged("critical"); }
        }

        public int Defence
        {
            get { return defence; }
            set { defence = value; OnPropertyChanged("Defence"); }
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; OnPropertyChanged("attack"); }
        }
        #endregion

        #region method
        public Stats GenRandomStats()
        {
            Stats stat = new Stats();
            stat.attack = Number.RandomNumber(10, 1000);
            stat.Defence = Number.RandomNumber(1, 500);
            stat.critical = Number.RandomNumber(1, 100);
            return stat;
        }

        static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        #endregion

        public String ToString()
        {
            return ("ATK: " + this.Attack + "| DEF: " + this.Defence + "| CRIT: " + this.Critical);
        }
    }
}
