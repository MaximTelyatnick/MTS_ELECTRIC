namespace MTS.GUI.MTS
{
    partial class MtsDirectoryGostEditOldFm
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.gostEdit = new DevExpress.XtraEditors.TextEdit();
            this.okButton = new DevExpress.XtraEditors.SimpleButton();
            this.cencelButton = new DevExpress.XtraEditors.SimpleButton();
            this.gostControl = new DevExpress.XtraEditors.LabelControl();
            this.gostValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.gostLabel = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gostEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gostValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gostEdit
            // 
            this.gostEdit.Location = new System.Drawing.Point(12, 32);
            this.gostEdit.Name = "gostEdit";
            this.gostEdit.Size = new System.Drawing.Size(274, 20);
            this.gostEdit.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Не вказано гост";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.gostValidationProvider.SetValidationRule(this.gostEdit, conditionValidationRule1);
            this.gostEdit.EditValueChanged += new System.EventHandler(this.gostEdit_EditValueChanged);
            // 
            // okButton
            // 
            this.okButton.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.okButton.Appearance.Options.UseFont = true;
            this.okButton.Location = new System.Drawing.Point(12, 79);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Додати";
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cencelButton
            // 
            this.cencelButton.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cencelButton.Appearance.Options.UseFont = true;
            this.cencelButton.Location = new System.Drawing.Point(211, 81);
            this.cencelButton.Name = "cencelButton";
            this.cencelButton.Size = new System.Drawing.Size(75, 23);
            this.cencelButton.TabIndex = 3;
            this.cencelButton.Text = "Відміна";
            this.cencelButton.Click += new System.EventHandler(this.cencelButton_Click);
            // 
            // gostControl
            // 
            this.gostControl.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gostControl.Location = new System.Drawing.Point(12, 12);
            this.gostControl.Name = "gostControl";
            this.gostControl.Size = new System.Drawing.Size(26, 16);
            this.gostControl.TabIndex = 4;
            this.gostControl.Text = "Гост";
            // 
            // gostValidationProvider
            // 
            this.gostValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.gostValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.gostValidationProvider_ValidationFailed);
            this.gostValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.gostValidationProvider_ValidationSucceeded);
            // 
            // gostLabel
            // 
            this.gostLabel.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.gostLabel.Location = new System.Drawing.Point(12, 58);
            this.gostLabel.Name = "gostLabel";
            this.gostLabel.Size = new System.Drawing.Size(77, 13);
            this.gostLabel.TabIndex = 5;
            this.gostLabel.Text = "Не внесені дані";
            this.gostLabel.Visible = false;
            // 
            // MtsDirectoryGostEditOldFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 109);
            this.Controls.Add(this.gostLabel);
            this.Controls.Add(this.gostControl);
            this.Controls.Add(this.cencelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.gostEdit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MtsDirectoryGostEditOldFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редагування ГОСТів";
            this.Load += new System.EventHandler(this.MtsDirectoryGostEditOldFm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gostEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gostValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit gostEdit;
        private DevExpress.XtraEditors.SimpleButton okButton;
        private DevExpress.XtraEditors.SimpleButton cencelButton;
        private DevExpress.XtraEditors.LabelControl gostControl;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider gostValidationProvider;
        private DevExpress.XtraEditors.LabelControl gostLabel;
    }
}