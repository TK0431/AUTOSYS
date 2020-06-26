using AUTOSYS.Models;
using AUTOSYS.ViewModels;
using System;
using System.Windows.Controls;

namespace AUTOSYS.Pages
{
    /// <summary>
    /// 主画面
    /// </summary>
    public partial class G010_01 : Page
    {
        /// <summary>
        /// Model
        /// </summary>
        private G010_01ViewModel _model;

        public G010_01()
        {
            InitializeComponent();

            _model = new G010_01ViewModel();
            this.DataContext = _model;
        }

        /// <summary>
        /// 选择下拉框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Project_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbx = sender as ComboBox;
            if (cbx == null) return;
            TB_Project project = cbx.SelectedItem as TB_Project;
            if (project == null) return;

            // 内容设置
            _model.ProjectName = project.pname;
            _model.DateFrom = project.pdfrom?.ToString("yyyy/M/d");
            _model.DateEnd = project.pdend?.ToString("yyyy/M/d");
            _model.Detail = project.pdetail;
        }

        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Next_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _model.BtnSave.Execute(_model);
            NavigationService.Navigate(new Uri("Pages/G010_02.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
