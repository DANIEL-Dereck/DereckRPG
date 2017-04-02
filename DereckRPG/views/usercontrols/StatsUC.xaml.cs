using DereckRPG.entities;
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

namespace DereckRPG.views.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour StatsUC.xaml
    /// </summary>
    public partial class StatsUC : UserControlBase
    {

        private Stats stats;

        public Stats Stats
        {
            get { return stats; }
            set { stats = value;
                base.onPropartiesChange("Stats");
            }
        }


        public StatsUC()
        {
            InitializeComponent();
            base.dataContext = this;
        }
    }
}
