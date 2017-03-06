using DereckRPG.entities.bases;
using DereckRPG.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DereckRPG.entities
{
    public class EtreVivant : BaseDBEntity
    {
        private String name;
        private int lvl;
        private List<Items> stuff;
        private Caracteristiques caracteristique;
        private Race race;



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
