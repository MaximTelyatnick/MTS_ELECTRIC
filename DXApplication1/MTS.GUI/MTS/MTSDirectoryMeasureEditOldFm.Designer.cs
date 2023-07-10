namespace MTS.GUI.MTS
{
    partial class MTSDirectoryMeasureEditOldFm
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
            this.measureEdit = new DevExpress.XtraEditors.TextEdit();
            this.okBtn1 = new DevExpress.XtraEditors.SimpleButton();
            this.measureValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.measureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.measureValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // measureEdit
            // 
            this.measureEdit.Location = new System.Drawing.Point(42, 12);
            this.measureEdit.Name = "measureEdit";
            this.measureEdit.Properties.Mask.SaveLiteral = false;
            this.measureEdit.Properties.Mask.ShowPlaceHolders = false;
            this.measureEdit.Size = new System.Drawing.Size(214, 20);
            this.measureEdit.TabIndex = 0;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater;
            conditionValidationRule1.ErrorText = "This value is not valid";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            conditionValidationRule1.Value1 = "<Null>";
            conditionValidationRule1.Value2 = "<Null>";
            conditionValidationRule1.Values.Add(",/3");
            this.measureValidationProvider.SetValidationRule(this.measureEdit, conditionValidationRule1);
            this.measureEdit.EditValueChanged += new System.EventHandler(this.measureEdit_EditValueChanged);
            this.measureEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.measureEdit_KeyPress);
            // 
            // okBtn1
            // 
            this.okBtn1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.okBtn1.Appearance.Options.UseFont = true;
            this.okBtn1.Location = new System.Drawing.Point(43, 65);
            this.okBtn1.Name = "okBtn1";
            this.okBtn1.Size = new System.Drawing.Size(75, 23);
            this.okBtn1.TabIndex = 2;
            this.okBtn1.Text = "Додати";
            this.okBtn1.Click += new System.EventHandler(this.okBtn1_Click);
            // 
            // measureValidationProvider
            // 
            this.measureValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            this.measureValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.measureValidationProvider_ValidationFailed);
            this.measureValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.measureValidationProvider_ValidationSucceeded);
            // 
            // validateLbl
            // 
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(42, 38);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(176, 13);
            this.validateLbl.TabIndex = 49;
            this.validateLbl.Text = "*Для збереження, заповніть  поле";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelBtn.Appearance.Options.UseFont = true;
            this.cancelBtn.Location = new System.Drawing.Point(181, 66);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 50;
            this.cancelBtn.Text = "Відміна";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // MTSDirectoryMeasureEditOldFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 101);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.okBtn1);
            this.Controls.Add(this.measureEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MTSDirectoryMeasureEditOldFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Одиниці вимірювання";
            ((System.ComponentModel.ISupportInitialize)(this.measureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.measureValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit measureEdit;
        private DevExpress.XtraEditors.SimpleButton okBtn1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider measureValidationProvider;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
    }
}