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
using DereckRPG.entities;

namespace DereckRPG.views.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour PlayerUC.xaml
    /// </summary>
    public partial class PlayerUC : UserControlBase
    {
        private Player player;

        public Player Player
        {
            get { return player; }
            set { player = value;
                base.OnPropertyChanged("Player");
            }
        }

        public PlayerUC()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
