using Dereck_RPG.entities.bases;
using Dereck_RPG.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{        
    public abstract class EtreVivant : BaseDBEntity
    {
        private String name;
        private int lvl;
        private List<Items> stuff;
        private Caracteristiques caracteristique;
        private Stats stats;
        private Race race;
        private Position position;

        public Stats Stats
        {
            get { return stats; }
            set { stats = value; }
        }


        public Position Position
        {
            get { return position; }
            set { position = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Lvl
        {
            get { return lvl; }
            set { lvl = value; }
        }
        public List<Items> Stuff
        {
            get { return stuff; }
            set { stuff = value; }
        }
        public Caracteristiques Caracteristique
        {
            get { return caracteristique; }
            set { caracteristique = value; }
        }
        public Race Race
        {
            get { return race; }
            set { race = value; }
        }

    }
}
