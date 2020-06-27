using AUTOSYS.Logics;
using AUTOSYS.ViewModels.Base;
using System.Windows.Input;

namespace AUTOSYS.ViewModels
{
    /// <summary>
    /// 登录ViewModel
    /// </summary>
    public class G901ViewModel : BaseViewModel
    {
        /// <summary>
        /// Logic
        /// </summary>
        private G901Logic _logic = new G901Logic();

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
        public G901ViewModel()
        {
            this.Login = new RelayTCommand<G901ViewModel>(_logic.Login);
        }
    }
}
