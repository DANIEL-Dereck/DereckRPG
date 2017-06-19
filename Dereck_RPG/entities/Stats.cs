using Dereck_RPG.entities.bases;
using Faker;
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
            Stats stat = new Stats();
            stat.Attaque = Number.RandomNumber(100, 1000);
            stat.Defence = Number.RandomNumber(100, 1000);
            stat.Critique = Number.RandomNumber(1, 100);
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

        static int RandomNumber(int min, int max)
        {
            Random random = new Random(); return random.Next(min, max);

        }

    }
}
