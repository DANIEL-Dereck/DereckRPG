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
    /// Logique d'interaction pour ListDonjonUC.xaml
    /// </summary>
    public partial class ListDonjonUC : UserControl
{
    public ListView ItemsList { get; set; }
    public ObservableCollection<Donjon> Obs { get; set; }

    public ListDonjonUC()
    {
        InitializeComponent();
        Obs = new ObservableCollection<Donjon>();
        this.itemList.ItemsSource = Obs;
        this.ItemsList = this.itemList;
        this.ItemsList.SelectionMode = SelectionMode.Single;
    }

    public void LoadItems(List<Donjon> items)
    {
        Obs.Clear();
        foreach (var item in items)
        {
            Obs.Add(item);
        }
    }

    public void AddItem(Donjon item)
    {
        Obs.Add(item);
    }

    public void RemoveItem(Donjon item)
    {
        Obs.Remove(item);
    }

}
}
