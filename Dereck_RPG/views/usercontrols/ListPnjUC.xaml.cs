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
    /// Logique d'interaction pour ListPnjUC.xaml
    /// </summary>
    public partial class ListPnjUC : UserControl
    {
        public ListView ItemsList { get; set; }
        public ObservableCollection<Pnj> Obs { get; set; }

        public ListPnjUC()
        {
            InitializeComponent();
            Obs = new ObservableCollection<Pnj>();
            this.itemList.ItemsSource = Obs;
            this.ItemsList = this.itemList;
            this.ItemsList.SelectionMode = SelectionMode.Single;
        }

        public void LoadItems(List<Pnj> items)
        {
            Obs.Clear();
            foreach (var item in items)
            {
                Obs.Add(item);
            }
        }

        public void AddItem(Pnj item)
        {
            Obs.Add(item);
        }

        public void RemoveItem(Pnj item)
        {
            Obs.Remove(item);
        }
    }
}
