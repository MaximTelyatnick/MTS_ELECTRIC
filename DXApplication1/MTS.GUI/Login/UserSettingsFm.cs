using System;
using System.Windows.Forms;

namespace MTS.GUI.Login
{
    public partial class UserSettingsFm : DevExpress.XtraEditors.XtraForm
    {
        public UserSettingsFm()
        {
            InitializeComponent();
            userRouteFolderEdit.DataBindings.Add("EditValue", Properties.Settings.Default, "UserFolderRoute", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void openFileBtn_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            string fileName = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                Properties.Settings.Default.UserFolderRoute = fbd.SelectedPath;
        }
    }
}