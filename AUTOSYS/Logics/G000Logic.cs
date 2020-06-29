using AUTOSYS.Models;
using AUTOSYS.Utility;
using AUTOSYS.ViewModels;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace AUTOSYS.Logics
{
    public class G000Logic
    {
        /// <summary>
        /// IP对应用户检索
        /// </summary>
        /// <param name="model"></param>
        public void Init(G000ViewModel model)
        {
            // 账户信息
            model.UName = App.LoginUser?.uname;
            model.UID = App.LoginUser?.uid;

            using (EntityUtility db = new EntityUtility())
            {
                // 获取项目
                model.PID= XmlUtility.GetXmValue("pid");

                if (!string.IsNullOrWhiteSpace(model.PID))
                {
                    Expression<Func<TB_Project, bool>> where = x =>
                        x.pid == model.PID;
                    TB_Project data = db.Find(where);
                    if (data != null)
                    {
                        model.PName = data.pname;
                        App.Project = data;
                    }
                }
            }
        }
    }
}
