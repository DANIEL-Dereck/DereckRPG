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
    /// Logique d'interaction pour DonjonUC.xaml
    /// </summary>
    public partial class DonjonUC : UserControlBase
    {
        private Donjon donjon;

        public Donjon Donjon
        {
            get { return donjon; }
            set { donjon = value;
                base.OnPropertyChanged("Donjon");
            }
        }

        public DonjonUC()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
