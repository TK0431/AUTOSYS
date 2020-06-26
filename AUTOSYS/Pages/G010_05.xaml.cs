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

namespace AUTOSYS.Pages
{
    /// <summary>
    /// P06.xaml 的交互逻辑
    /// </summary>
    public partial class G010_05 : Page
    {
        public G010_05()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/G010_04.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Pages/G010_06.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
