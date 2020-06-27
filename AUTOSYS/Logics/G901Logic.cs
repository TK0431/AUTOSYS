using AUTOSYS.Models;
using AUTOSYS.Utility;
using AUTOSYS.ViewModels;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace AUTOSYS.Logics
{
    /// <summary>
    /// 登录
    /// </summary>
    public class G901Logic
    {
        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="model"></param>
        public void Login(G901ViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.UserId) || string.IsNullOrWhiteSpace(model.PassWord)) return;

            using (EntityUtility db = new EntityUtility())
            {
                List<MySqlParameter> para = new List<MySqlParameter>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("select * from tb_user");
                para.Add(new MySqlParameter("CD", model.UserId));
                sql.AppendLine("where CD = @CD");
                para.Add(new MySqlParameter("Password", model.PassWord));
                sql.AppendLine("  and Password = md5(@Password)");
                sql.AppendLine("  and DateStart <= CURDATE()");
                sql.AppendLine("  and CURDATE()  <= DateEnd");
                sql.AppendLine("  and DelFlg = '0'");

                TB_User user = db.FindSingle<TB_User>(sql.ToString(), para);

                if (user != null)
                {
                    App.LoginUser = user;
                    model.UserName = user.uname;
                }
            }
        }
    }
}
