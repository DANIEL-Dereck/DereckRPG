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
