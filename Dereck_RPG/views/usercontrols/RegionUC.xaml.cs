using Dereck_RPG.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dereck_RPG.views.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour RegionUC.xaml
    /// </summary>
    public partial class RegionUC : UserControlBase
    {
        private Regions regions;

        public Regions Regions
        {
            get { return regions; }
            set { regions = value;
                base.OnPropertyChanged("Regions");
            }
        }


        public RegionUC()
        {
            InitializeComponent();
            base.DataContext = this;

        }
    }
}
