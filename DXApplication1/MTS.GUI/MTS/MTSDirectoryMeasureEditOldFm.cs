using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.Infrastructure;
using MTS.BLL.Interfaces;
using Ninject;

namespace MTS.GUI.MTS
{
    public partial class MTSDirectoryMeasureEditOldFm : DevExpress.XtraEditors.XtraForm
    {
        private Utils.Operation operation;
        private IMtsSpecificationsService mtsSpecificationsService;
        private BindingSource measureBS = new BindingSource();
        public MTSDirectoryMeasureEditOldFm(Utils.Operation operation, MTSMeasureDTO model)
        {
            InitializeComponent();
            mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();
            this.operation = operation;
            measureBS.DataSource = model;

            measureEdit.DataBindings.Add("EditValue", measureBS, "NAME", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void measureBtn_Click(object sender, EventArgs e)
        {


            if (operation == Utils.Operation.Add)
            {
                mtsSpecificationsService.MTSCreateMeasure((MTSMeasureDTO)measureBS.Current);

            }
            if (operation == Utils.Operation.Update)
                mtsSpecificationsService.MTSUpdateMeasure((MTSMeasureDTO)measureBS.Current);
            DialogResult = DialogResult.OK;
            this.Close();
        }
        public MTSMeasureDTO Return1()
        {
            return ((MTSMeasureDTO)measureBS.Current);
        }

        private void okBtn1_Click(object sender, EventArgs e)
        {


            if (operation == Utils.Operation.Add)
            {
                mtsSpecificationsService.MTSCreateMeasure((MTSMeasureDTO)measureBS.Current);

            }
            if (operation == Utils.Operation.Update)
                mtsSpecificationsService.MTSUpdateMeasure((MTSMeasureDTO)measureBS.Current);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region Validation

        private void measureValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.okBtn1.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void measureValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (measureValidationProvider.GetInvalidControls().Count == 0);
            this.okBtn1.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void measureEdit_EditValueChanged(object sender, EventArgs e)
        {
            
            measureValidationProvider.Validate((Control)sender);
        }

        private void measureEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
         //   measureEdit.Properties.m
        }

        #endregion

       
    }
}