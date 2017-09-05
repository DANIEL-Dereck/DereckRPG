using WorldOfFantasy.entities;
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

namespace WorldOfFantasy.views.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour PlayerAffUC.xaml
    /// </summary>
    public partial class PlayerAffUC : UserControlBase
    {
        private Player player;
        private Stats stats;

        public Stats Stats
        {
            get { return stats; }
            set
            {
                stats = value;
                base.OnPropertyChanged("Stats");
            }
        }

        public Player Player
        {
            get { return player; }
            set
            {
                player = value;
                base.OnPropertyChanged("Player");
            }
        }

        public PlayerAffUC()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
