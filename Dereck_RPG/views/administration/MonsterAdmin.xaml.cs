using Dereck_RPG.database;
using Dereck_RPG.entities;
using Dereck_RPG.viewmodel;
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

namespace Dereck_RPG.views.administration
{
    /// <summary>
    /// Logique d'interaction pour MonsterAdmin.xaml
    /// </summary>
    public partial class MonsterAdmin : Page
    {
        public MonsterAdmin()
        {
            InitializeComponent();
            this.DataContext = new MonsterAdminVM(this);
            InitLists();
        }

        private async void InitLists()
        {
            MySQLManager<Monster> monsterManager = new MySQLManager<Monster>();
            this.ListMonsterUC.LoadItems((await monsterManager.Get()).ToList());
        }
    }
}
