﻿
using AbstractSyshiBarBusinessLogic.BusinessLogics;
using AbstractSyshiBarBusinessLogic.Interfaces;
using AbstractSyshiBarBusinessLogic.HelperModels;
using SushiBarDatabaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using System.Threading;
using System.Configuration;
using ЭкзаменBusinessLogic.Attributes;
using ЭкзаменBusinessLogic.ViewModels;
using System.Collections.Generic;
using View;

namespace View
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            MailLogic.MailConfig(new MailConfig
            {
                SmtpClientHost = ConfigurationManager.AppSettings["SmtpClientHost"],
                SmtpClientPort =
           Convert.ToInt32(ConfigurationManager.AppSettings["SmtpClientPort"]),
                MailLogin = ConfigurationManager.AppSettings["MailLogin"],
                MailPassword = ConfigurationManager.AppSettings["MailPassword"],
            });
            var timer = new System.Threading.Timer(new TimerCallback(MailCheck), new
           MailCheckInfo
            {
                PopHost = ConfigurationManager.AppSettings["PopHost"],
                PopPort = Convert.ToInt32(ConfigurationManager.AppSettings["PopPort"]),
               
            }, 0, 100000);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IСтатьяLogic, СтатьяLogic>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IАвторLogic, АвторLogic>(new
           HierarchicalLifetimeManager());
     
            currentContainer.RegisterType<BackUpAbstractLogic, BackUpLogic>(new
                HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(new
           HierarchicalLifetimeManager());
            return currentContainer;
        }
        private static void MailCheck(object obj)
        {
            MailLogic.MailCheck((MailCheckInfo)obj);
        }
        public static void ConfigGrid<T>(List<T> data, DataGridView grid)
        {
            var type = typeof(T);
            if (type.BaseType == typeof(BaseViewModel))
            {
        
                object obj = Activator.CreateInstance(type);
            
                var method = type.GetMethod("Properties");

                var config = (List<string>)method.Invoke(obj, null);
                grid.Columns.Clear();
                foreach (var conf in config)
                {

                    var prop = type.GetProperty(conf);
                    if (prop != null)
                    {
                        // получаем список атрибутов
                        var attributes =
                        prop.GetCustomAttributes(typeof(ColumnAttribute), true);
                        if (attributes != null && attributes.Length > 0)
                        {
                            foreach (var attr in attributes)
                            {
                                if (attr is ColumnAttribute columnAttr)
                                {
                                    var column = new DataGridViewTextBoxColumn
                                    {
                                        Name = conf,
                                        ReadOnly = true,
                                        HeaderText = columnAttr.Title,
                                        Visible = columnAttr.Visible,
                                        Width = columnAttr.Width
                                    };
                                    if (columnAttr.GridViewAutoSize !=
                                    GridViewAutoSize.None)
                                    {
                                        column.AutoSizeMode =
                                       (DataGridViewAutoSizeColumnMode)Enum.Parse(typeof(DataGridViewAutoSizeColumnMode),
                                       columnAttr.GridViewAutoSize.ToString());
                                    }
                                    grid.Columns.Add(column);
                                }
                            }
                        }
                    }
                }
                foreach (var elem in data)
                {
                    List<object> objs = new List<object>();
                    foreach (var conf in config)
                    {
                        var value = elem.GetType().GetProperty(conf).GetValue(elem);
                        objs.Add(value);
                    }
                    grid.Rows.Add(objs.ToArray());
                }
            }
        }
    }
}
