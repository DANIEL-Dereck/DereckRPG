using Dereck_RPG.entities;
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

namespace Dereck_RPG.views.play
{
    /// <summary>
    /// Logique d'interaction pour UIUC.xaml
    /// </summary>
    public partial class CombatUC : UserControl
    {
        const int tourMax = 666;

        public CombatUC()
        {
            InitializeComponent();
        }

        public CombatUC(Player player, Monster monster)
        {
            int tour = 0;

            while (tour++ < tourMax || player.Vie > 0 || monster.Vie > 0)
            {

            }
        }

        private int checkWin(Player player, Monster monster)
        {
            if (player.Vie <= 0)
            {
                
                return (2);
            } else if(monster.Vie <= 0) {
                return (1);
            } else
            {
                return (0);
            }
        }


    }
}
