using Dereck_RPG.entities.bases;
using Dereck_RPG.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    public class Regions : BaseDBEntity
    {
        private String name;
        private Climate climate;
        private List<Monster> monster;

        public Regions()
        {
            this.monster = new List<Monster>();
        }

        public Climate Climate
        {
            get { return  climate; }
            set {  climate = value; OnPropertyChanged("Climate"); }
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
    }
}
