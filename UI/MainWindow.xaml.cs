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
using UI.Page;
using MahApps.Metro.Controls;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowTitleBrush = SystemParameters.WindowGlassBrush;
            this.GlowBrush = SystemParameters.WindowGlassBrush;
            Switcher.pageSwitcher = this;
            Switcher.Switch(new MainMenu());
        }

        public void Navigate(UserControl nextPage)
        {
            //UIHeader.CurrentPage = nextPage.GetType();
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;

            if (nextPage is ISwitchable s)
            {
                s.UtilizeState(state);
            }
            else
            {
                throw new ArgumentException("NextPage is not ISwitchable! " + nextPage.Name.ToString());
            }
        }
    }
}
