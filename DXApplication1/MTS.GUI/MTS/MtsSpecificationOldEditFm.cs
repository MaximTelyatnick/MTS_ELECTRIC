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
using MTS.BLL.Interfaces;
using MTS.BLL.Services;
using MTS.BLL.DTO;
using MTS.BLL.DTO.ModelsDTO;
using Ninject;

namespace MTS.GUI.MTS
{
    public partial class MtsSpecificationOldEditFm : DevExpress.XtraEditors.XtraForm
    {
        private Utils.Operation operation;
        private IMtsSpecificationsService mtsService;
        private BindingSource specificationBS = new BindingSource();
        private MTSAuthorizationUsersDTO mtsAthorizationUsersDTO;

        public MtsSpecificationOldEditFm(Utils.Operation operation, MTSSpecificationsDTO model, MTSAuthorizationUsersDTO mtsAthorizationUsersDTO)
        {
            InitializeComponent();
            this.operation = operation;
            this.mtsAthorizationUsersDTO = mtsAthorizationUsersDTO;
            specificationBS.DataSource = Item = model;

            ((MTSSpecificationsDTO)Item).AUTHORIZATION_USERS_ID = mtsAthorizationUsersDTO.ID;
            if (operation == Utils.Operation.Add)
            {
                model.CREATION_DATE = DateTime.Now;
                model.QUANTITY = 1;
            }



            nameSpecificationEdit.DataBindings.Add("EditValue", specificationBS, "NAME", true, DataSourceUpdateMode.OnPropertyChanged);
            drawingEdit.DataBindings.Add("EditValue", specificationBS, "DRAWING", true, DataSourceUpdateMode.OnPropertyChanged);
            quantityEdit.DataBindings.Add("EditValue", specificationBS, "QUANTITY", true, DataSourceUpdateMode.OnPropertyChanged);
            weightEdit.DataBindings.Add("EditValue", specificationBS, "WEIGHT", true, DataSourceUpdateMode.OnPropertyChanged);
            dateEdit.DataBindings.Add("EditValue", specificationBS, "CREATION_DATE", true, DataSourceUpdateMode.OnPropertyChanged);
      
        }
        #region Method's
         private ObjectBase Item
        {
            get { return specificationBS.Current as ObjectBase; }
            set
            {
                specificationBS.DataSource = value;
                value.BeginEdit();
            }
        }

        private bool SaveItem()
         {
             this.Item.EndEdit();
             mtsService = Program.kernel.Get<IMtsSpecificationsService>();

             if (quantityEdit.Text.Length <= 5)
             {
                 if (weightEdit.Text.Length <= 7)
                 {
                    if (operation == Utils.Operation.Add)
                    {
                        ((MTSSpecificationsDTO)Item).ID = 0;
                        ((MTSSpecificationsDTO)Item).NAME = nameSpecificationEdit.Text;
                        ((MTSSpecificationsDTO)Item).DEVICE_ID = null;
                        ((MTSSpecificationsDTO)Item).WEIGHT = (decimal)weightEdit.EditValue;
                        ((MTSSpecificationsDTO)Item).USERS_ID = null;
                        ((MTSSpecificationsDTO)Item).CREATION_DATE = (DateTime?)dateEdit.EditValue;
                        ((MTSSpecificationsDTO)Item).AUTHORIZATION_USERS_ID = mtsAthorizationUsersDTO.ID;
                        ((MTSSpecificationsDTO)Item).DRAWING = drawingEdit.Text;
                        ((MTSSpecificationsDTO)Item).QUANTITY = (int)quantityEdit.EditValue;
                        ((MTSSpecificationsDTO)Item).COMPILATION_NAMES = "";
                        ((MTSSpecificationsDTO)Item).COMPILATION_DRAWINGS = "";
                        ((MTSSpecificationsDTO)Item).COMPILATION_QUANTITIES = "";
                        ((MTSSpecificationsDTO)Item).SET_COLOR = 0;

                        ((MTSSpecificationsDTO)Item).ID = mtsService.MTSSpecificationCreate((MTSSpecificationsDTO)Item);

                    }
                    else if (operation == Utils.Operation.Update)
                    {
                        mtsService.MTSSpecificationUpdate((MTSSpecificationsDTO)Item);
                    }
                    else if(operation == Utils.Operation.Custom)
                    {
                        int mtsSpecificztionId = ((MTSSpecificationsDTO)Item).ID;

                        ((MTSSpecificationsDTO)Item).ID = 0;
                        ((MTSSpecificationsDTO)Item).NAME = nameSpecificationEdit.Text;
                        ((MTSSpecificationsDTO)Item).DEVICE_ID = null;
                        ((MTSSpecificationsDTO)Item).WEIGHT = (decimal)weightEdit.EditValue;
                        ((MTSSpecificationsDTO)Item).USERS_ID = null;
                        ((MTSSpecificationsDTO)Item).CREATION_DATE = DateTime.Now;
                        //((MTSSpecificationsDTO)Item).AUTHORIZATION_USERS_ID = mtsAthorizationUsersDTO.ID;
                        ((MTSSpecificationsDTO)Item).DRAWING = drawingEdit.Text;
                        ((MTSSpecificationsDTO)Item).QUANTITY = (int)quantityEdit.EditValue;
                        ((MTSSpecificationsDTO)Item).COMPILATION_NAMES = "";
                        ((MTSSpecificationsDTO)Item).COMPILATION_DRAWINGS = "";
                        ((MTSSpecificationsDTO)Item).COMPILATION_QUANTITIES = "";
                        ((MTSSpecificationsDTO)Item).SET_COLOR = 0;

                        ((MTSSpecificationsDTO)Item).ID = mtsService.MTSSpecificationCreate((MTSSpecificationsDTO)Item);

                        var detailsSpecific = mtsService.GetAllDetailsSpecificShort(mtsSpecificztionId);

                        if (detailsSpecific != null)
                        {
                            List<MTSDetailsDTO> mtsDetailsList = new List<MTSDetailsDTO>();

                            foreach (var itemDetailSpecific in detailsSpecific)
                            {
                                mtsDetailsList.Add(itemDetailSpecific);
                                mtsDetailsList.Last().SPECIFICATIONS_ID = ((MTSSpecificationsDTO)Item).ID;
                                mtsDetailsList.Last().QUANTITY = mtsDetailsList.Last().QUANTITY;
                                mtsDetailsList.Last().TIME_OF_ADD = DateTime.Now;
                            }
                            mtsService.MTSDetailsCreateRange(mtsDetailsList);
                        }

                        var detailsSpecificBuy = mtsService.GetBuysDetalSpecificShort(mtsSpecificztionId);

                        if (detailsSpecificBuy != null)
                        {
                            List<MTSPurchasedProductsDTO> mtsPurchasedList = new List<MTSPurchasedProductsDTO>();

                            foreach (var itemDetailSpecificBuy in detailsSpecificBuy)
                            {
                                mtsPurchasedList.Add(itemDetailSpecificBuy);
                                mtsPurchasedList.Last().SPECIFICATIONS_ID = ((MTSSpecificationsDTO)Item).ID;
                                mtsPurchasedList.Last().QUANTITY = mtsPurchasedList.Last().QUANTITY;
                                mtsPurchasedList.Last().TIME_OF_ADD = DateTime.Now;
                            }
                            mtsService.MTSPurchasedProductsCreateRange(mtsPurchasedList);
                        }

                        var detailsSpecificMaterials = mtsService.GetMaterialsSpecificShort(mtsSpecificztionId);

                        if (detailsSpecificMaterials != null)
                        {
                            List<MTSMaterialsDTO> mtsMaterialsList = new List<MTSMaterialsDTO>();

                            foreach (var itemDetailsSpecificMaterials in detailsSpecificMaterials)
                            {
                                mtsMaterialsList.Add(itemDetailsSpecificMaterials);
                                mtsMaterialsList.Last().SPECIFICATIONS_ID = ((MTSSpecificationsDTO)Item).ID;
                                mtsMaterialsList.Last().QUANTITY = mtsMaterialsList.Last().QUANTITY;
                                mtsMaterialsList.Last().TIME_OF_ADD = DateTime.Now;
                            }
                            mtsService.MTSMaterialCreateRange(mtsMaterialsList);
                        }
                    }

             return true;           
             }
            else
            {
                MessageBox.Show("Перевище максимальна довжина поля 'Вага!'", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            }
            else
            {
                MessageBox.Show("Перевище максимальна довжина поля 'Кількість!'", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        public MTSSpecificationsDTO Return()
        {
            return ((MTSSpecificationsDTO)Item);
        }
        #endregion

        #region Event's
        
        
        private void saveBtn_Click(object sender, EventArgs e)
        {if (operation == Utils.Operation.Update)
            {
                if (MessageBox.Show("Зберегти зміни?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (SaveItem())
                        {
                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("" + ex.Message, "Збереження заявки", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            else
            {
                try
                {
                    if (SaveItem())
                    {
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                { MessageBox.Show("" + ex.Message, "Збереження заявки", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Item.EndEdit();
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        #endregion

        private void dxValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveDBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void dxValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (dxValidationProvider.GetInvalidControls().Count == 0);
            this.saveDBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void nameSpecificationEdit_EditValueChanged(object sender, EventArgs e)
        {
            dxValidationProvider.Validate((Control)sender);
        }

        private void drawingEdit_EditValueChanged(object sender, EventArgs e)
        {
            dxValidationProvider.Validate((Control)sender);
        }

        private void quantityEdit_EditValueChanged(object sender, EventArgs e)
        {
            dxValidationProvider.Validate((Control)sender);
        }

        private void weightEdit_EditValueChanged(object sender, EventArgs e)
        {
            dxValidationProvider.Validate((Control)sender);
        }

        private void dateEdit_EditValueChanged(object sender, EventArgs e)
        {
            dxValidationProvider.Validate((Control)sender);
        }

        private bool ControlValidation()
        {
            return dxValidationProvider.Validate();
        }

        private void MtsSpecificationOldEditFm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ControlValidation())
                saveDBtn.PerformClick();
        }
    }
}