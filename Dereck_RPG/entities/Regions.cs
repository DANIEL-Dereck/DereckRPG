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
        private List<Donjon> donjon;

        public Regions()
        {
            this.donjon = new List<Donjon>();
        }

        public List<Donjon> Donjon
        {
            get { return donjon; }
            set { donjon = value; OnPropertyChanged("Donjon"); }
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

    }
}
