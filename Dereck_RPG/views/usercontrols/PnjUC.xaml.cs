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
    /// Logique d'interaction pour PnjUC.xaml
    /// </summary>
    public partial class PnjUC : UserControlBase
    {
        private Pnj pnj;

        public Pnj Pnj
        {
            get { return pnj; }
            set { pnj = value;
                base.OnPropertyChanged("Pnj");
            }
        }

        public PnjUC()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
