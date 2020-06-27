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
            
            using (EntityUtility db = new EntityUtility())
            {
                // 获取用户
                List<MySqlParameter> para = new List<MySqlParameter>();

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("select * from tb_user");
                para.Add(new MySqlParameter("uip", ComUtility.GetLocalIPV4().ToString()));
                sql.AppendLine("where uip = @uip");
                sql.AppendLine("  and udfrom <= CURDATE()");
                sql.AppendLine("  and CURDATE()  <= udend");
                sql.AppendLine("  and delflg = '0'");
                TB_User user = db.FindSingle<TB_User>(sql.ToString(), para);

                if (user != null)
                {
                    model.UID = user.uid;
                    model.UName = user.uname;
                    App.LoginUser = user;
                }

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
