using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AUTOSYS.Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("tb_user"), Serializable]
    public class TB_User : BaseTable
    {
        [Display(Name = "项目号"), Required, StringLength(20)]
        public string pid { get; set; }

        [Display(Name = "员工号", Order = 1), Required, StringLength(10)]
        public string uid { get; set; }

        [Display(Name = "用户名", Order = 2), Required, StringLength(10)]
        public string uname { get; set; }

        [Display(Name = "密码", Order = 3), Required, StringLength(32)]
        public string upassword { get; set; }

        [Display(Name = "IP", Order = 4), StringLength(15)]
        public string uip { get; set; }

        [Display(Name = "组号", Order = 5), StringLength(10)]
        public string gid { get; set; }

        [Display(Name = "权限", Order = 6), Required]
        public int ulevel { get; set; }

        [Display(Name = "期间(开始)", Order = 7)]
        public DateTime? udfrom { get; set; }

        [Display(Name = "期间(终了)", Order = 8)]
        public DateTime? udend { get; set; }
    }

    public class Map_TB_User : EntityTypeConfiguration<TB_User>
    {
        public Map_TB_User() : base()
        {
            // Index
            Property(t => t.pid).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("TB_User_Index1", 0)));
            Property(t => t.uid).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("TB_User_Index1", 1)));
            Property(t => t.uip).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("TB_User_Index2")));
        }
    }
}
