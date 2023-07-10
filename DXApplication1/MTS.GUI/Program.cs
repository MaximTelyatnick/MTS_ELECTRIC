﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Threading;
using Ninject;
using MTS.BLL.Infrastructure;
using DevExpress.XtraEditors.Controls;
using System.Globalization;
using MTS.GUI.Login;

namespace MTS.GUI
{
    static class Program
    {
        public static IKernel kernel = new StandardKernel(new ServiceModule());
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-UA");

            Localizer.Active = Localizer.CreateDefaultLocalizer();

            bool flag = true;//false;
            Mutex mutex = new Mutex(false, "MTS", out flag);
            
            if (!flag)
            {
                MessageBox.Show("Программа уже запущена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            BonusSkins.Register();

            SkinManager.EnableFormSkins();
            try
            {
                Application.Run(new AuthFm());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла ошибка. " + ex.Message, "Інфо", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            mutex.Close();
        }
    }
}
