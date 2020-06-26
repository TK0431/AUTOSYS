using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AUTOSYS.Models
{
    /// <summary>
    /// 项目表
    /// </summary>
    [Table("tb_project"), Serializable]
    public class TB_Project : BaseTable
    {
        [Display(Name = "项目号", Order = 1), Required, StringLength(20)]
        public string pid { get; set; }

        [Display(Name = "项目名", Order = 2), Required, StringLength(20)]
        public string pname { get; set; }

        [Display(Name = "项目期间(开始)", Order = 3)]
        public DateTime? pdfrom { get; set; }

        [Display(Name = "项目期间(终了)", Order = 4)]
        public DateTime? pdend { get; set; }

        [Display(Name = "项目说明", Order = 5)]
        public string pdetail { get; set; }
    }

    public class Map_TB_Project : EntityTypeConfiguration<TB_Project>
    {
        public Map_TB_Project():base()
        {
            // Index
            Property(t => t.pid).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("TB_Project_Index1") { IsUnique = true }));
        }
    }
}
