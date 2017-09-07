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
using DragonLib;

namespace UI.Page
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
            Menu.Background = SystemParameters.WindowGlassBrush;
            BuildInfo.Content = "Build: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            BuildInfo.Content += ", Library: " + DragonLibVersion.GetVersion();
        }
    }
}
