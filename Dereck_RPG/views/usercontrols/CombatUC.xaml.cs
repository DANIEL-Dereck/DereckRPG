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
    /// Logique d'interaction pour CombatUC.xaml
    /// </summary>
    public partial class CombatUC : UserControlBase
    {
        public CombatUC()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
