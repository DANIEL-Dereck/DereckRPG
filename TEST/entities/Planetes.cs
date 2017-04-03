using TEST.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.entities
{
    public class Planetes : BaseDBEntity
    {
        private String name;
        private List<Regions> region;
        private Position position;

        public Position Position
        {
            get { return position; }
            set { position = value; }
        }


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
