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
    /// Logique d'interaction pour ListPlayerUC.xaml
    /// </summary>
    public partial class ListPlayerUC : UserControl
    {
        public ListView ItemsList { get; set; }
        public ObservableCollection<Player> Obs { get; set; }

        public ListPlayerUC()
        {
            InitializeComponent();
            Obs = new ObservableCollection<Player>();
            this.itemList.ItemsSource = Obs;
            this.ItemsList = this.itemList;
            this.ItemsList.SelectionMode = SelectionMode.Single;
        }

        public void LoadItems(List<Player> items)
        {
            Obs.Clear();
            foreach (var item in items)
            {
                Obs.Add(item);
            }
        }

        public void AddItem(Player item)
        {
            Obs.Add(item);
        }

        public void RemoveItem(Player item)
        {
            Obs.Remove(item);
        }
    }
}
