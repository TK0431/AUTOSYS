using AUTOSYS.Models;
using AUTOSYS.Utility;
using AUTOSYS.ViewModels;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace AUTOSYS.Logics
{
    public class P01Logic
    {
        /// <summary>
        /// IP对应用户检索
        /// </summary>
        /// <param name="model"></param>
        public void Init(P01ViewModel model)
        {
            using (EntityUtility db = new EntityUtility())
            {
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
                    App.LoginUser = user;
                }
            }
        }
    }
}
