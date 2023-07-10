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
    public partial class MtsDirectoryGostEditOldFm : DevExpress.XtraEditors.XtraForm
    {
        private Utils.Operation operation;
        private IMtsSpecificationsService mtsSpecificationsService;
        private BindingSource gostBS = new BindingSource();
        private ObjectBase Item
        {
            get { return gostBS.Current as ObjectBase; }
            set
            {
                gostBS.DataSource = value;
                value.BeginEdit();
            }
        }
        public MtsDirectoryGostEditOldFm(Utils.Operation operation, MTSGostDTO model)
        {
            InitializeComponent();
            this.operation = operation;
            gostBS.DataSource = Item = model;
           
            gostEdit.DataBindings.Add("EditValue", gostBS, "NAME", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {

        }
        public MTSGostDTO Return()
        {
            return ((MTSGostDTO)Item);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();

            if (operation == Utils.Operation.Add)
                ((MTSGostDTO)Item).ID = mtsSpecificationsService.MTSCreateGost((MTSGostDTO)Item);
            else
                mtsSpecificationsService.MTSUpdateGost((MTSGostDTO)Item);

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cencelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

       
        private void gostValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.okButton.Enabled = false;
             this.gostLabel.Visible = true;
        }

        private void gostValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (gostValidationProvider.GetInvalidControls().Count == 0);
            this.okButton.Enabled = isValidate;
            this.gostLabel.Visible = !isValidate;
        }

        private void MtsDirectoryGostEditOldFm_Load(object sender, EventArgs e)
        {

        }

        private void gostEdit_EditValueChanged(object sender, EventArgs e)
        {
            gostValidationProvider.Validate((Control)sender);
        }
    }
}