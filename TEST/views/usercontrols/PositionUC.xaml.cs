using TEST.entities;
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

namespace TEST.views.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour PositionUC.xaml
    /// </summary>
    public partial class PositionUC : UserControlBase
    {
        private Position position;

        public Position Position
        {
            get { return position; }
            set {
                position = value;
                base.OnPropertyChanged("Position");
            }
        }

        public PositionUC()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
