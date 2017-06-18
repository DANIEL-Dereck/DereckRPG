using Dereck_RPG.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    public class Stats : BaseDBEntity
    {
        private int attaque;
        private int defence;
        private int critique;

        public Stats()
        {

        }

        public Stats(int att, int def, int crit)
        {
            this.attaque = att;
            this.defence = def;
            this.critique = crit;
        }

        public Stats GenRandomStats()
        {
            Random rnd = new Random();
            Stats stat = new Stats();
            stat.Attaque = rnd.Next(20, 1000);
            stat.Defence = rnd.Next(20, 1000);
            stat.Critique = rnd.Next(1, 100);
            return stat;
        }

        public int Critique
        {
            get { return critique; }
            set { critique = value; OnPropertyChanged("Critique"); }
        }

        public int Defence
        {
            get { return defence; }
            set { defence = value; OnPropertyChanged("Defence"); }
        }

        public int Attaque
        {
            get { return attaque; }
            set { attaque = value; OnPropertyChanged("Attaque"); }
        }

    }
}
