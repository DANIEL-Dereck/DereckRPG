using DereckRPG.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DereckRPG.entities
{
    public class Position : BaseDBEntity
    {
        private int posX;
        private int posY;

        public int PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        public int PosX
        {
            get { return posX; }
            set { posX = value; }
        }

    }
}
