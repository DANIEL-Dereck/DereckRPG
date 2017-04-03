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
using TEST.entities;

namespace TEST.views.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour EtreVivantUC.xaml
    /// </summary>
    public partial class EtreVivantUC : UserControlBase
    {
        private EtreVivant etreVivant;

        public EtreVivant EtreVivant
        {
            get { return etreVivant; }
            set { etreVivant = value;
                base.OnPropertyChanged("EtreVivant");
            }
        }


        public EtreVivantUC()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
