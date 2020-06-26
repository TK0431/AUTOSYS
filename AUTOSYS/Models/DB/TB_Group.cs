using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AUTOSYS.Models
{
    /// <summary>
    /// 组表
    /// </summary>
    [Table("tb_group"), Serializable]
    public class TB_Group : BaseTable
    {
        [Display(Name = "项目号", Order = 1), Required, StringLength(20)]
        public string pid { get; set; }

        [Display(Name = "组号", Order = 2), Required, StringLength(10)]
        public string gid { get; set; }

        [Display(Name = "组名", Order = 3), Required, StringLength(20)]
        public string gname { get; set; }
    }

    public class Map_TB_Group : EntityTypeConfiguration<TB_Group>
    {
        public Map_TB_Group() : base()
        {
            // Index
            Property(t => t.pid).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("TB_Group_Index1", 0) { IsUnique = true }));
            Property(t => t.gid).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("TB_Group_Index1", 1) { IsUnique = true }));
        }
    }
}
