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
using WorldOfFantasy.entities;
using WorldOfFantasy.viewmodel.playviewmodel;
using WorldOfFantasy.views.usercontrols;

namespace WorldOfFantasy.views.administration.playadmin
{
    /// <summary>
    /// Logique d'interaction pour CombatAdmin.xaml
    /// </summary>
    public partial class CombatAdmin : Page
    {
        public CombatAdmin()
        {
            InitializeComponent();
            this.DataContext = new CombatAdminVM(this);
        }

        public CombatAdmin(Player currentPlayer, Monster currentMonster)
        {
            InitializeComponent();
            this.DataContext = new CombatAdminVM(this, currentPlayer, currentMonster);
        }
    }
}
