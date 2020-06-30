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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AUTOSYS.Pages
{
    /// <summary>
    /// 登录
    /// </summary>
    public partial class G001 : Page
    {
        /// <summary>
        /// Model
        /// </summary>
        private G001ViewModel _model;

        public G001()
        {
            InitializeComponent();

            _model = new G001ViewModel(this);
            this.DataContext = _model;
        }
    }
}
