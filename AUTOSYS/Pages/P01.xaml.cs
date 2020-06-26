using AUTOSYS.Consts;
using AUTOSYS.Model;
using AUTOSYS.Utility;
using AUTOSYS.ViewModels;
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
using System.Windows.Shapes;

namespace AUTOSYS.Pages
{
    /// <summary>
    /// P01.xaml 的交互逻辑
    /// </summary>
    public partial class P01 : Window
    {
        /// <summary>
        /// Model
        /// </summary>
        private P01ViewModel _model;

        public P01()
        {
            InitializeComponent();

            _model = new P01ViewModel();
            this.DataContext = _model;
        }

        private void MenuList_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EnumItem selected = ((ListBox)sender).SelectedItem as EnumItem;

            if (selected != null)
            {
                switch ((PageEnum)selected.Index)
                {
                    case PageEnum.G010_01:
                        _model.MainPage = new G010_01();
                        break;
                    case PageEnum.G010_02:
                        _model.MainPage = new G010_02();
                        break;
                    case PageEnum.G010_03:
                        _model.MainPage = new G010_03();
                        break;
                    case PageEnum.G010_04:
                        _model.MainPage = new G010_04();
                        break;
                    case PageEnum.G010_05:
                        _model.MainPage = new G010_05();
                        break;
                    case PageEnum.G010_06:
                        _model.MainPage = new G010_06();
                        break;
                    case PageEnum.P08:
                        _model.MainPage = new P08();
                        break;
                    case PageEnum.P09:
                        _model.MainPage = new P09();
                        break;
                    case PageEnum.P10:
                        _model.MainPage = new P10();
                        break;
                    default:
                        break;
                }
            }

            // 收起Menu
            MenuToggleButton.IsChecked = false;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            List<EnumItem> list = typeof(PageEnum).GetList();
            _model.MenuItems = new ObservableCollection<EnumItem>(list.Where(x => x.Description.Contains(tb.Text)));
        }
    }
}
