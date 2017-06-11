using Dereck_RPG.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    public class Donjon : BaseDBEntity
    {
        private String name;
        private Monster boss;
        private Monster miniBoss;
        private List<Monster> monster;

        public Donjon()
        {
            this.monster = new List<Monster>();
        }

        public String Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        public List<Monster> Monster
        {
            get { return monster; }
            set { monster = value; OnPropertyChanged("Monster"); }
        }

        public Monster MiniBoss
        {
            get { return miniBoss; }
            set { miniBoss = value; OnPropertyChanged("MiniBoss"); }
        }

        public Monster Boss
        {
            get { return boss; }
            set { boss = value; OnPropertyChanged("Boss"); }
        }
    }
}
