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
    /// Logique d'interaction pour PlaneteUC.xaml
    /// </summary>
    public partial class PlaneteUC : UserControlBase
    {
        private Planetes planete;

        public Planetes Planete
        {
            get { return planete; }
            set { planete = value;
                base.OnPropertyChanged("Planete");
            }
        }

        public PlaneteUC()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
