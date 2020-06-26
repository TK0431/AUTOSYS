using System;
using System.ComponentModel.DataAnnotations;

namespace AUTOSYS.Models
{
    /// <summary>
    /// 表基础项目
    /// </summary>
    [Serializable]
    public class BaseTable
    {
        [Display(Name = "ID"), Key]
        public int id { get; set; }

        [Display(Name = "删除FLG")]
        public bool delflg { get; set; }

        [Display(Name = "登录者CD"), Required, StringLength(10)]
        public string insertercd { get; set; }

        [Display(Name = "登录日时")]
        public DateTime insertetime { get; set; }

        [Display(Name = "更新者CD"), Required, StringLength(10)]
        public string updatercd { get; set; }

        [Display(Name = "更新日时")]
        public DateTime updatetime { get; set; }
    }
}
