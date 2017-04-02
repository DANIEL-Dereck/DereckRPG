using DereckRPG.entities;
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

namespace DereckRPG.views.usercontrols
{
    /// <summary>
    /// Logique d'interaction pour QuestUC.xaml
    /// </summary>
    public partial class QuestUC : UserControlBase
    {
        private Quest quest;

        public Quest Quest
        {
            get { return quest; }
            set {
                quest = value;
                base.onPropertiesChange("Quest");
            }
        }

        public QuestUC()
        {
            InitializeComponent();
            base.dataContext = this;
        }
    }
}
