using AUTOSYS.Logics;
using AUTOSYS.Models;
using AUTOSYS.ViewModels.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AUTOSYS.ViewModels
{
    /// <summary>
    /// 项目情报
    /// </summary>
    public class G010_01ViewModel : BaseViewModel
    {
        /// <summary>
        /// Logic
        /// </summary>
        private G010_01Logic _logic = new G010_01Logic();

        /// <summary>
        /// 项目下拉框
        /// </summary>
        public ObservableCollection<TB_Project> ProjectItems { get; set; } 

        /// <summary>
        /// 被选中项目
        /// </summary>
        public TB_Project SelectedProjectItem { get; set; }

        /// <summary>
        /// 项目ID
        /// </summary>
        public string ProjectId { get; set; }

        /// <summary>
        /// 项目名
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// 项目区间（开始）
        /// </summary>
        public string DateFrom { get; set; }

        /// <summary>
        /// 项目区间（终了）
        /// </summary>
        public string DateEnd { get; set; }

        /// <summary>
        /// 项目详细
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// 废止
        /// </summary>
        public ICommand BtnDelete { get; set; }

        /// <summary>
        /// 保存
        /// </summary>
        public ICommand BtnSave { get; set; }

        /// <summary>
        /// 下一步
        /// </summary>
        public ICommand BtnNext { get; set; }

        /// <summary>
        /// 初期化
        /// </summary>
        public G010_01ViewModel()
        {
            // 初期处理
            _logic.Init(this);
            // 废止
            this.BtnDelete = new RelayTCommand<G010_01ViewModel>(_logic.BtnDelete);
            // 保存
            this.BtnSave = new RelayTCommand<G010_01ViewModel>(_logic.BtnSave);
        }
    }
}
