using WorldOfFantasy.entities;
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

namespace WorldOfFantasy.views.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour ListStatsUC.xaml
    /// </summary>
    public partial class ListStatsUC : UserControl
    {
        public ListView ItemsList { get; set; }
        public ObservableCollection<Stats> Obs { get; set; }

        public ListStatsUC()
        {
            InitializeComponent();
            Obs = new ObservableCollection<Stats>();
            this.itemList.ItemsSource = Obs;
            this.ItemsList = this.itemList;
            this.ItemsList.SelectionMode = SelectionMode.Single;
        }

        public void LoadItems(List<Stats> items)
        {
            Obs.Clear();
            foreach (var item in items)
            {
                Obs.Add(item);
            }
        }

        public void AddItem(Stats item)
        {
            Obs.Add(item);
        }

        public void RemoveItem(Stats item)
        {
            Obs.Remove(item);
        }

    }
}
