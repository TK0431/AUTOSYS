using AUTOSYS.ViewModels;
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
using System.Windows.Shapes;

namespace AUTOSYS.Pages
{
    /// <summary>
    /// 登录页面
    /// </summary>
    public partial class G901 : Window
    {
        /// <summary>
        /// Model
        /// </summary>
        private G901ViewModel _model;

        public G901()
        {
            InitializeComponent();

            _model = new G901ViewModel();
            DataContext = _model;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
