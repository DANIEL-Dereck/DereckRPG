using Dereck_RPG.entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour ListRegionUC.xaml
    /// </summary>
    public partial class ListRegionUC : UserControl
    {
        public ListView ItemsList { get; set; }
        public ObservableCollection<Regions> Obs { get; set; }

        public ListRegionUC()
        {
            InitializeComponent();
            Obs = new ObservableCollection<Regions>();
            this.itemList.ItemsSource = Obs;
            this.ItemsList = this.itemList;
            this.ItemsList.SelectionMode = SelectionMode.Single;
        }

        public void LoadItems(List<Regions> items)
        {
            Obs.Clear();
            foreach (var item in items)
            {
                Obs.Add(item);
            }
        }

        public void AddItem(Regions item)
        {
            Obs.Add(item);
        }

        public void RemoveItem(Regions item)
        {
            Obs.Remove(item);
        }






    }
}
