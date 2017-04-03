using TEST.entities.bases;
using TEST.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.entities
{
    public class Regions : BaseDBEntity
    {
        private String name;
        private Climate climate;
        private List<Donjon> donjon;
        private Position position;

        public Position Position
        {
            get { return position; }
            set { position = value; }
        }


        public List<Donjon> Donjon
        {
            get { return donjon; }
            set { donjon = value; }
        }

        public Climate Climate
        {
            get { return  climate; }
            set {  climate = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
