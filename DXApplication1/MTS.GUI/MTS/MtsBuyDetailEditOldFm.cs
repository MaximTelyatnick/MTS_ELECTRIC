﻿using System;
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
    public partial class MtsBuyDetailEditOldFm : DevExpress.XtraEditors.XtraForm
    {
        private Utils.Operation operation;
        private IMtsSpecificationsService mtsService;
        private BindingSource mtsPurchasedProductsBS = new BindingSource();


        private ObjectBase Item
        {
            get { return mtsPurchasedProductsBS.Current as ObjectBase; }
            set
            {
                mtsPurchasedProductsBS.DataSource = value;
                value.BeginEdit();
            }
        }

        public MtsBuyDetailEditOldFm(Utils.Operation operation, MTSPurchasedProductsDTO mtsPurchasedProductsDTO)
        {
            InitializeComponent();
            
            this.operation = operation;
            mtsPurchasedProductsBS.DataSource = Item = mtsPurchasedProductsDTO;

            nameBuyDetailEdit.DataBindings.Add("EditValue", mtsPurchasedProductsBS, "NOMENCLATURESNAME", true, DataSourceUpdateMode.OnPropertyChanged);
            guageEdit.DataBindings.Add("EditValue", mtsPurchasedProductsBS, "GUAEGENAME", true, DataSourceUpdateMode.OnPropertyChanged);
            quantityEdit.DataBindings.Add("EditValue", mtsPurchasedProductsBS, "QUANTITY", true, DataSourceUpdateMode.OnPropertyChanged);

            //if (operation == Utils.Operation.Add)
            //    quantityEdit.Focus();
        }

        private bool Save()
        {

            this.Item.EndEdit();
            try
            {
                mtsService = Program.kernel.Get<IMtsSpecificationsService>();
                if (operation == Utils.Operation.Add)
                {
                    mtsService.MTSPurchasedProductsCreate((MTSPurchasedProductsDTO)Item);
                    return true;
                }
                else
                {
                    mtsService.MTSPurchasedProductsUpdate((MTSPurchasedProductsDTO)Item);
                    return true;
                }      
            }
            catch (Exception ex)
            {
                MessageBox.Show("При збереженні виникла помилка. " + ex.Message, "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public MTSPurchasedProductsDTO Return()
        {
            return ((MTSPurchasedProductsDTO)Item);
        }

        private void saveBtn_Click(object sender, EventArgs e)
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
                            // MessageBox.Show("Не вірний номер податкової.Такий номер вже існує.", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //numberAccountingEdit.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error" + ex.Message, "Збереження матеріалу", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        // MessageBox.Show("Не вірний номер податкової.Такий номер вже існує.", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //numberAccountingEdit.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message, "Збереження матеріалу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //this.Item.EndEdit();
            //DialogResult = DialogResult.Cancel;
            //this.Close();
        }

        private void ShowDirectoryBuyDetails(MTSNomenclaturesDTO model)
        {
            using (DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(model,false))
            //  DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(model);
            {
                if (directoryBuyDetailEditOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MTSNomenclaturesDTO getBuyDetail = directoryBuyDetailEditOldFm.Returnl();

                    ((MTSPurchasedProductsDTO)Item).NOMENCLATURES_ID = getBuyDetail.ID;
                    guageEdit.Text = getBuyDetail.GUAGE;
                    nameBuyDetailEdit.Text = getBuyDetail.NAME;

                }
            } 
        }

        private void directoryBuyDetailsBtn_Click(object sender, EventArgs e)
        {
           
            ShowDirectoryBuyDetails(new MTSNomenclaturesDTO());
        }

        private void quantityEdit_EditValueChanged(object sender, EventArgs e)
        {
            mtsBuyDetailValidationProvider.Validate((Control)sender);
        }

        private void mtsBuyDetailValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void mtsBuyDetailValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (mtsBuyDetailValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void saveBtn_Click_1(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click_1(object sender, EventArgs e)
        {
            this.Item.EndEdit();
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void directoryBuyDetailsBtn1_Click(object sender, EventArgs e)
        {
            ShowDirectoryBuyDetails(new MTSNomenclaturesDTO());
        }

        private bool ControlValidation()
        {
            return mtsBuyDetailValidationProvider.Validate();
        }

        private void MtsBuyDetailEditOldFm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ControlValidation())
                saveBtn.PerformClick();
        }
    }
}