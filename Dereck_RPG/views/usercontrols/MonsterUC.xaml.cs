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
using Dereck_RPG.entities;

namespace Dereck_RPG.views.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour MonsterUC.xaml
    /// </summary>
    public partial class MonsterUC : UserControlBase
    {
        private Monster monster;

        public Monster Monster
        {
            get { return monster; }
            set { monster = value;
                base.OnPropertyChanged("Monster");
            }
        }


        public MonsterUC()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
