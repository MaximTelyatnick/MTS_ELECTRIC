namespace MTS.GUI.MTS
{
    partial class MTSNomenclatureGroupEditFm
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
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule1 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule conditionValidationRule2 = new DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.additCalcEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.activeCheck = new DevExpress.XtraEditors.CheckEdit();
            this.ratOfWasteEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.validateLbl = new DevExpress.XtraEditors.LabelControl();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            this.nomenclatureGroupNameEdit = new DevExpress.XtraEditors.MemoEdit();
            this.dxValidationProvider = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider();
            this.validateLabel = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.additCalcEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratOfWasteEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureGroupNameEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.additCalcEdit);
            this.groupControl1.Controls.Add(this.activeCheck);
            this.groupControl1.Location = new System.Drawing.Point(12, 92);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(456, 86);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Дод. розрахунок";
            // 
            // additCalcEdit
            // 
            this.additCalcEdit.Location = new System.Drawing.Point(120, 36);
            this.additCalcEdit.Name = "additCalcEdit";
            this.additCalcEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.additCalcEdit.Properties.Appearance.Options.UseFont = true;
            this.additCalcEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.additCalcEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Одиниці вимірювань")});
            this.additCalcEdit.Size = new System.Drawing.Size(324, 22);
            this.additCalcEdit.TabIndex = 1;
            // 
            // activeCheck
            // 
            this.activeCheck.Location = new System.Drawing.Point(21, 36);
            this.activeCheck.Name = "activeCheck";
            this.activeCheck.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.activeCheck.Properties.Appearance.Options.UseFont = true;
            this.activeCheck.Properties.Caption = "Активно";
            this.activeCheck.Size = new System.Drawing.Size(75, 20);
            this.activeCheck.TabIndex = 0;
            this.activeCheck.CheckedChanged += new System.EventHandler(this.activeCheck_CheckedChanged);
            this.activeCheck.PropertiesChanged += new System.EventHandler(this.activeCheck_PropertiesChanged);
            this.activeCheck.EditValueChanged += new System.EventHandler(this.activeCheck_EditValueChanged);
            // 
            // ratOfWasteEdit
            // 
            this.ratOfWasteEdit.Location = new System.Drawing.Point(132, 64);
            this.ratOfWasteEdit.Name = "ratOfWasteEdit";
            this.ratOfWasteEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ratOfWasteEdit.Properties.Appearance.Options.UseFont = true;
            this.ratOfWasteEdit.Properties.Mask.EditMask = "n3";
            this.ratOfWasteEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.ratOfWasteEdit.Size = new System.Drawing.Size(336, 22);
            this.ratOfWasteEdit.TabIndex = 2;
            conditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule1.ErrorText = "Не вказано коефіцієнт відходів";
            conditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider.SetValidationRule(this.ratOfWasteEdit, conditionValidationRule1);
            this.ratOfWasteEdit.EditValueChanged += new System.EventHandler(this.ratOfWasteEdit_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 16);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Найменування";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl2.Location = new System.Drawing.Point(12, 67);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(114, 16);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Коефіцієнт відходів";
            // 
            // validateLbl
            // 
            this.validateLbl.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLbl.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLbl.Location = new System.Drawing.Point(-902, 284);
            this.validateLbl.Name = "validateLbl";
            this.validateLbl.Size = new System.Drawing.Size(249, 13);
            this.validateLbl.TabIndex = 50;
            this.validateLbl.Text = "*Для збереження, заповніть всі обов\'язкові поля";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelBtn.Appearance.Options.UseFont = true;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(390, 188);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 49;
            this.cancelBtn.Text = "Відміна";
            // 
            // saveBtn
            // 
            this.saveBtn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveBtn.Appearance.Options.UseFont = true;
            this.saveBtn.Location = new System.Drawing.Point(309, 188);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 48;
            this.saveBtn.Text = "Зберегти";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // nomenclatureGroupNameEdit
            // 
            this.nomenclatureGroupNameEdit.Location = new System.Drawing.Point(132, 9);
            this.nomenclatureGroupNameEdit.Name = "nomenclatureGroupNameEdit";
            this.nomenclatureGroupNameEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenclatureGroupNameEdit.Properties.Appearance.Options.UseFont = true;
            this.nomenclatureGroupNameEdit.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nomenclatureGroupNameEdit.Size = new System.Drawing.Size(336, 49);
            this.nomenclatureGroupNameEdit.TabIndex = 1;
            conditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank;
            conditionValidationRule2.ErrorText = "Не вказано назву групу";
            conditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical;
            this.dxValidationProvider.SetValidationRule(this.nomenclatureGroupNameEdit, conditionValidationRule2);
            this.nomenclatureGroupNameEdit.EditValueChanged += new System.EventHandler(this.nomenclatureGroupNameEdit_EditValueChanged);
            // 
            // dxValidationProvider
            // 
            this.dxValidationProvider.ValidationFailed += new DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventHandler(this.dxValidationProvider_ValidationFailed);
            this.dxValidationProvider.ValidationSucceeded += new DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventHandler(this.dxValidationProvider_ValidationSucceeded);
            // 
            // validateLabel
            // 
            this.validateLabel.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.validateLabel.Appearance.ForeColor = System.Drawing.Color.OrangeRed;
            this.validateLabel.Location = new System.Drawing.Point(12, 194);
            this.validateLabel.Name = "validateLabel";
            this.validateLabel.Size = new System.Drawing.Size(249, 13);
            this.validateLabel.TabIndex = 51;
            this.validateLabel.Text = "*Для збереження, заповніть всі обов\'язкові поля";
            // 
            // MTSNomenclatureGroupEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 223);
            this.Controls.Add(this.validateLabel);
            this.Controls.Add(this.validateLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ratOfWasteEdit);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.nomenclatureGroupNameEdit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MTSNomenclatureGroupEditFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редагування групи номенклатуры";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.additCalcEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.activeCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ratOfWasteEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureGroupNameEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit additCalcEdit;
        private DevExpress.XtraEditors.CheckEdit activeCheck;
        private DevExpress.XtraEditors.TextEdit ratOfWasteEdit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl validateLbl;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
        private DevExpress.XtraEditors.MemoEdit nomenclatureGroupNameEdit;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider;
        private DevExpress.XtraEditors.LabelControl validateLabel;
    }
}