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
using MTS.BLL.Infrastructure;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.Interfaces;
using Ninject;

namespace MTS.GUI.MTS
{
    public partial class MtsMaterialEditOldFm : DevExpress.XtraEditors.XtraForm
    {
        private Utils.Operation operation;
        private IMtsSpecificationsService mtsService;
        private BindingSource mtsMaterialsBS = new BindingSource();


        private ObjectBase Item
        {
            get { return mtsMaterialsBS.Current as ObjectBase; }
            set
            {
                mtsMaterialsBS.DataSource = value;
                value.BeginEdit();
            }
        }

        public MtsMaterialEditOldFm(Utils.Operation operation, MTSMaterialsDTO mtsMaterialsDTO)
        {
            InitializeComponent();

            this.operation = operation;
            mtsMaterialsBS.DataSource = Item = mtsMaterialsDTO;

            nameBuyDetailEdit.DataBindings.Add("EditValue", mtsMaterialsBS, "NOMENCLATURESNAME", true, DataSourceUpdateMode.OnPropertyChanged);
            guageEdit.DataBindings.Add("EditValue", mtsMaterialsBS, "GUAGENAME", true, DataSourceUpdateMode.OnPropertyChanged);
            quantityEdit.DataBindings.Add("EditValue", mtsMaterialsBS, "QUANTITY", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private bool Save()
        {

            this.Item.EndEdit();
            try
            {
                mtsService = Program.kernel.Get<IMtsSpecificationsService>();
                if (operation == Utils.Operation.Add)
                {
                    mtsService.MTSMaterialCreate((MTSMaterialsDTO)Item);
                    return true;
                }
                else
                {
                    mtsService.MTSMaterialUpdate((MTSMaterialsDTO)Item);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("При збереженні виникла помилка. " + ex.Message, "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public MTSMaterialsDTO Return()
        {
            return ((MTSMaterialsDTO)Item);
        }

        private void ShowDirectoryBuyDetails(MTSNomenclaturesDTO model)
        {
            using (DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(model,false))
            //  DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(model);
            {
                if (directoryBuyDetailEditOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MTSNomenclaturesDTO getBuyDetail = directoryBuyDetailEditOldFm.Returnl();

                    ((MTSMaterialsDTO)Item).NOMENCLATURES_ID = getBuyDetail.ID;
                    guageEdit.Text = getBuyDetail.GUAGE;
                    nameBuyDetailEdit.Text = getBuyDetail.NAME;

                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Зберегти зміни?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (Save())
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не можливо зберегти, помилка при збереженні", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message, "Збереження матеріалу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Item.EndEdit();
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void quantityEdit_EditValueChanged(object sender, EventArgs e)
        {
            mtsMaterialValidationProvider.Validate((Control)sender);
        }

        private void mtsMaterialValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn1.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void mtsMaterialValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (mtsMaterialValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn1.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void directoryBuyDetailsBtn_Click(object sender, EventArgs e)
        {
            ShowDirectoryBuyDetails(new MTSNomenclaturesDTO());
        }

        private void saveBtn1_Click(object sender, EventArgs e)
        {
            if (operation == Utils.Operation.Update)
            {
                if (MessageBox.Show("Зберегти зміни?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (Save())
                        {
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Не можливо зберегти, помилка при збереженні", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка: " + ex.Message, "Збереження матеріалу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                try
                {
                    if (Save())
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не можливо зберегти, помилка при збереженні", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message, "Збереження матеріалу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelBtn2_Click(object sender, EventArgs e)
        {
            this.Item.EndEdit();
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void directoryBuyDetailsBtn_Click_1(object sender, EventArgs e)
        {
            ShowDirectoryBuyDetails(new MTSNomenclaturesDTO());
        }

        private void MtsMaterialEditOldFm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ControlValidation())
                saveBtn1.PerformClick();
        }

        private bool ControlValidation()
        {
            return mtsMaterialValidationProvider.Validate();
        }
    }
}