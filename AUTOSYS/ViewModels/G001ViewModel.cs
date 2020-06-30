using AUTOSYS.Logics;
using AUTOSYS.Pages;
using AUTOSYS.ViewModels.Base;
using System.Windows.Controls;
using System.Windows.Input;

namespace AUTOSYS.ViewModels
{
    /// <summary>
    /// 登录ViewModel
    /// </summary>
    public class G001ViewModel : BaseViewModel
    {
        /// <summary>
        /// Logic
        /// </summary>
        private G001Logic _logic = new G001Logic();

        /// <summary>
        /// 是否是登录页面
        /// </summary>
        public bool IsFlipper { get; set; }

        /// <summary>
        /// 工程选择后可点击
        /// </summary>
        public string UserName { get; set; } = App.LoginUser?.uname;

        /// <summary>
        /// 工程选择后可点击
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 工程选择后可点击
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 上传Excel
        /// </summary>
        public ICommand Login { get; set; }

        /// <summary>
        /// 初期化
        /// </summary>
        public G001ViewModel(G001 page)
        {
            this.GPage = page;
            _logic.Init(this);

            this.Login = new RelayTCommand<G001ViewModel>(_logic.Login);
        }
    }
}
