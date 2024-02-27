using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.Interfaces;
using Ninject;
using MTS.BLL.Services;
using DevExpress.XtraSplashScreen;
using System.Threading;
using MTS.GUI.MTS;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using MTS.GUI.Properties;

namespace MTS.GUI.Login
{
    public partial class AuthFm : DevExpress.XtraEditors.XtraForm
    {
        private IUserService userService;
        private MTSAuthorizationUsersDTO userInfo;
        private IEnumerable<UserTasksDTO> userAccess;
        public AuthFm()
        {

            InitializeComponent();
            setUserCheck.Checked = Properties.Settings.Default.MtsCheckUser;
            loginEdit.Text = Properties.Settings.Default.MtsLoginUser;
            if(setUserCheck.Checked)
                pwdEdit.Text = Properties.Settings.Default.MtsPassUser;

            //SkinHelper.InitSkinGallery(galleryControl1);
            UserLookAndFeel.Default.SkinName = Settings.Default["ApplicationSkinName"].ToString();

            userService = Program.kernel.Get<IUserService>();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(setUserCheck.Checked)
            {
                Properties.Settings.Default.MtsLoginUser = loginEdit.Text;
                Properties.Settings.Default.MtsPassUser = pwdEdit.Text;
                Properties.Settings.Default.Save();
            }

            if (!CheckAccess())
            {
                this.Show();
                return;
            }

                userInfo = UserService.AuthorizatedUser;


            

            using (MtsSpecificationOldFm mtsSpecificationOldFm = new MtsSpecificationOldFm(userInfo))
            {
                if (mtsSpecificationOldFm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
                    this.Close();
            }

        }

        private bool CheckAccess()
        {
            try
            {
                userService = Program.kernel.Get<IUserService>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Виникла проблема при підключенні до БД \n" + ex.Message, "Підключення до БД", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            

            SplashScreenManager.ShowForm(typeof(StartScreenFm));
            SplashScreenManager.Default.SendCommand(StartScreenFm.SplashScreenCommand.SetLabel, "Авторизація користувача...");
            Thread.Sleep(200);

            if (userService.TryAuthorize(loginEdit.Text, pwdEdit.Text))
            {
                
                SplashScreenManager.Default.SendCommand(StartScreenFm.SplashScreenCommand.SetLabel, "Налаштування прав доступу...");
                Thread.Sleep(200);
                SplashScreenManager.CloseForm();
                return true;
            }
            else
            {
                SplashScreenManager.CloseForm();
                MessageBox.Show("Вам не дозволено працювати в системі \nЗверніться до відділу АСУП. \n", "Авторизація користувача", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Load += (s, e) => Close();
                return false;
            }

        }



        private void setUserCheck_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MtsCheckUser = setUserCheck.Checked;
            Properties.Settings.Default.Save();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AuthFm_Load(object sender, EventArgs e)
        {
            SkinHelper.InitSkinPopupMenu(SkinsLink);
        }

        private void SkinsLink_ItemClick(object sender, ItemClickEventArgs e)
        {
            string data = e.Item.Caption;
        }

        private void barSubItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            string data = e.Item.Caption;
        }

        private void AuthFm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default["ApplicationSkinName"] = UserLookAndFeel.Default.SkinName;
            Settings.Default.Save();
        }

        private void AuthFm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                saveBtn.PerformClick();
        }
    }
}