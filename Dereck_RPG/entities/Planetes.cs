﻿using Dereck_RPG.entities.bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dereck_RPG.entities
{
    public class Planetes : BaseDBEntity
    {
        private String name;
        private List<Regions> region;

        public Planetes()
        {
            this.region = new List<Regions>();
        }

        public List<Regions> Region
        {
            get { return region; }
            set { region = value; OnPropertyChanged("Region"); }
        }

        public String Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
    }
}
