using Dereck_RPG.entities.bases;
using Dereck_RPG.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    public class Items : BaseDBEntity
    {
        private String nom;
        private String description;
        private ItemCategory categorie;
        private Stats statistique;
        private Rarete rarete;

        public Rarete Rarete
        {
            get { return rarete; }
            set { rarete = value; OnPropertyChanged("Rarete"); }
        }

        public Stats Statistique
        {
            get { return statistique; }
            set { statistique = value; OnPropertyChanged("Statistique"); }
        }

        public ItemCategory Categorie
        {
            get { return categorie; }
            set { categorie = value; OnPropertyChanged("Categorie"); }
        }

        public String Description
        {
            get { return description; }
            set { description = value; OnPropertyChanged("Description"); }
        }

        public String Nom
        {
            get { return nom; }
            set { nom = value; OnPropertyChanged("Nom"); }
        }

    }
}
