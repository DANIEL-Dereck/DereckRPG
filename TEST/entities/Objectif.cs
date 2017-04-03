using TEST.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST.entities
{
    public class Objectif : BaseDBEntity
    {
        private String objectifName;
        private Boolean accomplie;

        public Boolean Accomplie
        {
            get { return accomplie; }
            set { accomplie = value; }
        }

        public String ObjectifName
        {
            get { return objectifName; }
            set { objectifName = value; }
        }
    }
}
