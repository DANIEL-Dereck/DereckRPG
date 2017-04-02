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
    /// Logique d'interaction pour CaracteristiqueUC.xaml
    /// </summary>
    public partial class CaracteristiqueUC : UserControlBase
    {
        private Caracteristiques caracteristique;

        public Caracteristiques Caracteristique
        {
            get { return caracteristique; }
            set { caracteristique = value;
                base.OnPropertyChanged("Caracteristique");
            }
        }

        public CaracteristiqueUC()
        {
            InitializeComponent();
            base.DataContext = this;
        }
    }
}
