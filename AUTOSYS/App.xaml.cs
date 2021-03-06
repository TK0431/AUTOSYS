﻿using AUTOSYS.Consts;
using AUTOSYS.Models;
using AUTOSYS.Pages;
using AUTOSYS.Utility;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Media.Animation;

namespace AUTOSYS
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 语言
        /// </summary>
        public static EnumLanguage Language { get; set; } = EnumLanguage.CN;

        /// <summary>
        /// 登录用户
        /// </summary>
        public static TB_User LoginUser { get; set; }

        /// <summary>
        /// 当前Project
        /// </summary>
        public static TB_Project Project { get; set; }

        /// <summary>
        /// 消息机制
        /// </summary>
        public static SnackbarMessageQueue MessageQueue { get; set; }

        /// <summary>
        /// 窗口启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // 语言获取
            switch (Enum.Parse(typeof(EnumLanguage), XmlUtility.GetXmValue("language")))
            {
                case EnumLanguage.EN:
                    Language = EnumLanguage.EN;
                    break;
                case EnumLanguage.JP:
                    Language = EnumLanguage.JP;
                    break;
                default:
                    Language = EnumLanguage.CN;
                    break;
            }

            // 更换语言包
            UpdateLanguage();

            // 启动主画面
            G000 win = new G000();
            this.MainWindow = win;
            win.Show();
        }

        /// <summary>
        /// 更换语言包
        /// </summary>
        public static void UpdateLanguage()
        {
            // 获取全部资源
            List<ResourceDictionary> dictionaryList = new List<ResourceDictionary>();
            foreach (ResourceDictionary dictionary in Current.Resources.MergedDictionaries)
            {
                dictionaryList.Add(dictionary);
            }

            // 需要语言资源
            string requestedLanguage = $@"Styles/Language{Language.GetValue()}.xaml";
            ResourceDictionary resourceDictionary = dictionaryList.FirstOrDefault(d => d.Source.OriginalString.Equals(requestedLanguage));

            if (resourceDictionary == null)
            {
                // 移除初期中文包
                ResourceDictionary resourceCN = dictionaryList.FirstOrDefault(d => d.Source.OriginalString.Equals(@"Styles/LanguageCN.xaml"));
                if (resourceCN != null) Current.Resources.MergedDictionaries.Remove(resourceCN);

                // 添加新语言包
                ResourceDictionary langRd = LoadComponent(new Uri(requestedLanguage, UriKind.Relative)) as ResourceDictionary;
                Current.Resources.MergedDictionaries.Add(langRd);
            }
        }
    }
}
