using Dereck_RPG.entities.bases;
using Dereck_RPG.entities.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    [Table("Monster")]
    public class Monster : EtreVivant
    {
        private MonsterRace monsterRace;

        public MonsterRace MonsterRace
        {
            get { return monsterRace; }
            set { monsterRace = value; OnPropertyChanged("MonsterRace"); }
        }
    }
}
