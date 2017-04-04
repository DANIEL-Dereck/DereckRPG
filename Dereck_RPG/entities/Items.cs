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
            set { rarete = value; }
        }

        public Stats Statistique
        {
            get { return statistique; }
            set { statistique = value; }
        }

        public ItemCategory Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

    }
}
