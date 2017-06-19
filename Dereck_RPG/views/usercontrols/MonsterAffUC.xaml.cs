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
    /// Logique d'interaction pour MonsterAffUC.xaml
    /// </summary>
    public partial class MonsterAffUC : UserControlBase
    {
        private Monster monster;
        private Stats stats;

        public  Stats Stats
        {
            get { return stats; }
            set
            {
                stats = value;
                base.OnPropertyChanged("Stats");
            }
        }

        public Monster Monster
        {
            get { return monster; }
            set
            {
                monster = value;
                base.OnPropertyChanged("Monster");
            }
        }

        public MonsterAffUC()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
