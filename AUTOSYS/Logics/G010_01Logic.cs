using AUTOSYS.Models;
using AUTOSYS.Utility;
using AUTOSYS.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace AUTOSYS.Logics
{
    /// <summary>
    /// 项目情报
    /// </summary>
    public class G010_01Logic
    {
        /// <summary>
        /// 初期处理
        /// </summary>
        /// <param name="model"></param>
        public void Init(G010_01ViewModel model)
        {
            using (EntityUtility db = new EntityUtility())
            {
                Expression<Func<TB_Project, bool>> where = x => x.delflg == false;
                model.ProjectItems = new ObservableCollection<TB_Project>(db.FindAll(where));
            }
        }

        /// <summary>
        /// 废止
        /// </summary>
        /// <param name="model"></param>
        public void BtnDelete(G010_01ViewModel model)
        {
            using (EntityUtility db = new EntityUtility())
            {
                // tb_project数据删除
                List<MySqlParameter> param = new List<MySqlParameter>();
                param.Add(new MySqlParameter("pid", model.SelectedProjectItem.pid));
                string sql = "delete from tb_project where pid = @pid";
                db.DeleteAll(sql, param);

                // ...别的表数据删除

                // 删除List
                foreach (TB_Project item in model.ProjectItems)
                {
                    if (item.pid == model.SelectedProjectItem.pid)
                    { 
                        model.ProjectItems.Remove(item);
                        break;
                    }
                }

                // 当前画面清空
                model.ProjectName = "";
                model.DateFrom = "";
                model.DateEnd = "";
                model.Detail = "";
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        public void BtnSave(G010_01ViewModel model)
        {
            if (string.IsNullOrEmpty(model.ProjectId)) return;

            using (EntityUtility db = new EntityUtility())
            {
                Expression<Func<TB_Project, bool>> where = x => x.pid == model.ProjectId && x.delflg == false;
                TB_Project project = db.Find(where);

                if (project == null)
                {
                    // 项目表追加
                    project = new TB_Project()
                    {
                        pid = model.ProjectId,
                        pname = model.ProjectName,
                        pdfrom = string.IsNullOrEmpty(model.DateFrom) ? null : DateTime.Parse(model.DateFrom) as DateTime?,
                        pdend = string.IsNullOrEmpty(model.DateEnd) ? null : DateTime.Parse(model.DateEnd) as DateTime?,
                        pdetail = model.Detail,
                    };
                    db.AddData(project);

                    model.ProjectItems.Add(project);
                }
                else
                {
                    project.pname = model.ProjectName;
                    project.pdfrom = string.IsNullOrEmpty(model.DateFrom) ? null : DateTime.Parse(model.DateFrom) as DateTime?;
                    project.pdend = string.IsNullOrEmpty(model.DateEnd) ? null : DateTime.Parse(model.DateEnd) as DateTime?;
                    project.pdetail = model.Detail;
                    db.Update(project);

                    model.SelectedProjectItem = project;
                }
            }
        }
    }
}
