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
    /// Logique d'interaction pour ListMonsterUC.xaml
    /// </summary>
    public partial class ListMonsterUC : UserControl
    {
        public ListView ItemsList { get; set; }
        public ObservableCollection<Monster> Obs { get; set; }

        public ListMonsterUC()
        {
            InitializeComponent();
            Obs = new ObservableCollection<Monster>();
            this.itemList.ItemsSource = Obs;
            this.ItemsList = this.itemList;
            this.ItemsList.SelectionMode = SelectionMode.Single;
        }

        public void LoadItems(List<Monster> items)
        {
            Obs.Clear();
            foreach (var item in items)
            {
                Obs.Add(item);
            }
        }

        public void AddItem(Monster item)
        {
            Obs.Add(item);
        }

        public void RemoveItem(Monster item)
        {
            Obs.Remove(item);
        }

    }
}

