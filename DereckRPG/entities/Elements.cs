using DereckRPG.entities.bases;
using DereckRPG.entities.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DereckRPG.entities
{
    public class Elements : BaseDBEntity
    {
        private Elements fort;
        private Elements faible;

        public Elements Faible
        {
            get { return faible; }
            set { faible = value; }
        }

        public Elements Fort
        {
            get { return fort; }
            set { fort = value; }
        }

    }
}
