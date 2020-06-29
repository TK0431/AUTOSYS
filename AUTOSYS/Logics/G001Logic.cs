using AUTOSYS.Models;
using AUTOSYS.Utility;
using AUTOSYS.ViewModels;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace AUTOSYS.Logics
{
    /// <summary>
    /// 登录
    /// </summary>
    public class G001Logic
    {
        /// <summary>
        /// 初期登录
        /// </summary>
        /// <param name="model"></param>
        public void Init(G001ViewModel model)
        {
            if(App.LoginUser == null) Login(model, true);
        }

        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="model"></param>
        public void Login(G001ViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.UserId) || string.IsNullOrWhiteSpace(model.PassWord)) return;

            Login(model,false);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        private void Login(G001ViewModel model, bool initFlg = false)
        {
            using (EntityUtility db = new EntityUtility())
            {
                List<MySqlParameter> para = new List<MySqlParameter>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("select * from tb_user");
                // 初期IP登录
                if (initFlg)
                {
                    para.Add(new MySqlParameter("uip", ComUtility.GetLocalIPV4().ToString()));
                    sql.AppendLine("where uip = @uip");
                }
                // 登录按钮
                else
                {
                    para.Add(new MySqlParameter("uid", model.UserId));
                    sql.AppendLine("where uid = @uid");
                    para.Add(new MySqlParameter("upassword", model.PassWord));
                    sql.AppendLine("  and upassword = md5(@upassword)");
                }
                sql.AppendLine("  and udfrom <= CURDATE()");
                sql.AppendLine("  and CURDATE()  <= udend");
                sql.AppendLine("  and delflg = '0'");

                TB_User user = db.FindSingle<TB_User>(sql.ToString(), para);

                if (user != null)
                {
                    App.LoginUser = user;
                    model.IsFlipper = false;
                    model.UserName = user.uname;

                    // 登录按钮更换用户头
                    if (!initFlg)
                    {            // 更换头项目
                        var win = Window.GetWindow(model.GPage);
                        if (win != null)
                        {
                            G000ViewModel winModel = win.DataContext as G000ViewModel;
                            if (winModel != null)
                            {
                                winModel.UID = user.uid;
                                winModel.UName = user.uname;
                            }
                        }
                    }
                }
            }
        }
    }
}
