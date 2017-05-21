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
        private Position position;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public Position Position
        {
            get { return position; }
            set { position = value; }
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
