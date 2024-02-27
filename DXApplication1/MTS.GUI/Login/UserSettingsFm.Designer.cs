namespace MTS.GUI.Login
{
    partial class UserSettingsFm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSettingsFm));
            this.userRouteFolderEdit = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.userRouteFolderEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // userRouteFolderEdit
            // 
            this.userRouteFolderEdit.Enabled = false;
            this.userRouteFolderEdit.Location = new System.Drawing.Point(86, 12);
            this.userRouteFolderEdit.Name = "userRouteFolderEdit";
            this.userRouteFolderEdit.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.Black;
            this.userRouteFolderEdit.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.userRouteFolderEdit.Size = new System.Drawing.Size(246, 20);
            this.userRouteFolderEdit.TabIndex = 79;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Папка звітів:";
            // 
            // openFileBtn
            // 
            this.openFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("openFileBtn.Image")));
            this.openFileBtn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.openFileBtn.Location = new System.Drawing.Point(338, 10);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(29, 23);
            this.openFileBtn.TabIndex = 80;
            this.openFileBtn.ToolTip = "Вибрати файл";
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // UserSettingsFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 113);
            this.Controls.Add(this.openFileBtn);
            this.Controls.Add(this.userRouteFolderEdit);
            this.Controls.Add(this.label2);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserSettingsFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Налаштування додатку";
            ((System.ComponentModel.ISupportInitialize)(this.userRouteFolderEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit userRouteFolderEdit;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton openFileBtn;
    }
}