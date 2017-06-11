using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities.bases
{
    public class BaseDBEntity : BaseEntity
    {
        private Int32 id;

        [Key]
        public Int32 Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
    }
}
