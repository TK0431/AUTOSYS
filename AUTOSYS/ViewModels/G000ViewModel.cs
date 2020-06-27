using AUTOSYS.Consts;
using AUTOSYS.Logics;
using AUTOSYS.Model;
using AUTOSYS.Pages;
using AUTOSYS.Utility;
using AUTOSYS.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace AUTOSYS.ViewModels
{
    /// <summary>
    /// 主画面
    /// </summary>
    public class G000ViewModel : BaseViewModel
    {
        /// <summary>
        /// Logic
        /// </summary>
        private G000Logic _logic = new G000Logic();

        /// <summary>
        /// 主Page
        /// </summary>
        public Page MainPage { get; set; } = new G001();

        /// <summary>
        /// 项目名
        /// </summary>
        public string PName { get; set; }

        /// <summary>
        /// 项目ID
        /// </summary>
        public string PID { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UName { get; set; }

        /// <summary>
        /// Wbs 菜单
        /// </summary>
        public ObservableCollection<EnumItem> MenuItems { get; set; }

        /// <summary>
        /// 上传Excel
        /// </summary>
        public ICommand Login { get; set; }

        /// <summary>
        /// 初期化
        /// </summary>
        public G000ViewModel()
        {
            // Wbs 菜单
            MenuItems = new ObservableCollection<EnumItem>()
            {
                PageEnum.P01.GetItem(), // 
                PageEnum.G010_01.GetItem(), //
                PageEnum.G010_02.GetItem(), //
                PageEnum.G010_03.GetItem(), //
                PageEnum.G010_04.GetItem(), //
                PageEnum.G010_05.GetItem(), //
                PageEnum.G010_06.GetItem(), //
                PageEnum.P08.GetItem(), //
                PageEnum.P09.GetItem(), //
                PageEnum.P10.GetItem(), //
            };

            _logic.Init(this);
        }
    }
}
