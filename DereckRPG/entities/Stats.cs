using DereckRPG.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DereckRPG.entities
{
    public class Stats : BaseDBEntity
    {
        private int attaque;
        private int defence;
        private int critique;

        public int Critique
        {
            get { return critique; }
            set { critique = value; }
        }

        public int Defence
        {
            get { return defence; }
            set { defence = value; }
        }

        public int Attaque
        {
            get { return attaque; }
            set { attaque = value; }
        }

    }
}
