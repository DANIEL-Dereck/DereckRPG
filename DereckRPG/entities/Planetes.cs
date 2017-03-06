using DereckRPG.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DereckRPG.entities
{
    public class Planetes : BaseDBEntity
    {
        private String name;
        private List<Regions> region;

        public List<Regions> Region
        {
            get { return region; }
            set { region = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
