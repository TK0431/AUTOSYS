﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AUTOSYS.Models
{
    /// <summary>
    /// User Table
    /// </summary>
    [Table("tb_group"), Serializable]
    public class TB_Group : BaseTable
    {
        [Display(Name = "项目号"), Required, StringLength(20)]
        public string ProjectCD { get; set; }

        [Display(Name = "组号", Order = 1), Required, StringLength(10)]
        public string CD { get; set; }

        [Display(Name = "组名", Order = 2), Required, StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "负责人", Order = 3), StringLength(10)]
        public string UserCD { get; set; }

        [Display(Name = "期间(开始)", Order = 4)]
        public DateTime? DateFrom { get; set; }

        [Display(Name = "期间(终了)", Order = 5)]
        public DateTime? DateEnd { get; set; }
    }

    public class Map_TB_Group : EntityTypeConfiguration<TB_Group>
    {
        public Map_TB_Group() : base()
        {
            // Index
            Property(t => t.ProjectCD).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("TB_Group_Index1", 0) { IsUnique = true }));
            Property(t => t.CD).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("TB_Group_Index1", 1) { IsUnique = true }));
        }
    }
}
