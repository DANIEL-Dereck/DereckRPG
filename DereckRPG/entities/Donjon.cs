using DereckRPG.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DereckRPG.entities
{
    public class Donjon : BaseDBEntity
    {
        private Monster boss;
        private Monster miniBoss;
        private List<Monster> monster;
        private List<Pnj> pnjDonjon;
        private Position position;

        public Position Position
        {
            get { return position; }
            set { position = value; }
        }


        public List<Pnj> PnjDonjon
        {
            get { return pnjDonjon; }
            set { pnjDonjon = value; }
        }

        public List<Monster> Monster
        {
            get { return monster; }
            set { monster = value; }
        }

        public Monster MiniBoss
        {
            get { return miniBoss; }
            set { miniBoss = value; }
        }

        public Monster Boss
        {
            get { return boss; }
            set { boss = value; }
        }
    }
}
