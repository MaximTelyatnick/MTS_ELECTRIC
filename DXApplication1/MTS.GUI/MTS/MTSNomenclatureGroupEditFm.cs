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
    public partial class MTSNomenclatureGroupEditFm : DevExpress.XtraEditors.XtraForm
    {
        private IMtsSpecificationsService mtsSpecificationsService;
        private IMtsNomenclaturesService mtsNomenclaturesService;

        private BindingSource mtsNomenclatureGroupBS = new BindingSource();
        private BindingSource additCalcWasteBS = new BindingSource();
        MTSNomenclaturesDTO model = new MTSNomenclaturesDTO();

        private Utils.Operation operation;

        private ObjectBase Item
        {
            get { return mtsNomenclatureGroupBS.Current as ObjectBase; }
            set
            {
                mtsNomenclatureGroupBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }
        public MTSNomenclatureGroupEditFm(Utils.Operation operation, MTSNomenclatureGroupsDTO model)
        {
            InitializeComponent();

            this.operation = operation;

            mtsNomenclatureGroupBS.DataSource = Item = model;

            mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();
            mtsNomenclaturesService = Program.kernel.Get<IMtsNomenclaturesService>();

            nomenclatureGroupNameEdit.DataBindings.Add("EditValue", mtsNomenclatureGroupBS, "NAME", true, DataSourceUpdateMode.OnPropertyChanged);
            ratOfWasteEdit.DataBindings.Add("EditValue", mtsNomenclatureGroupBS, "RATIO_OF_WASTE", true, DataSourceUpdateMode.OnPropertyChanged);
            activeCheck.DataBindings.Add("Checked", mtsNomenclatureGroupBS, "ADDIT_CALCULATION_ACTIVE", true, DataSourceUpdateMode.OnPropertyChanged);

            additCalcEdit.DataBindings.Add("EditValue", mtsNomenclatureGroupBS, "ADDIT_CALCULATION_ID", true, DataSourceUpdateMode.OnPropertyChanged);
            additCalcEdit.Properties.DataSource = mtsSpecificationsService.GetAdditCalculationUnits();
            additCalcEdit.Properties.ValueMember = "ID";
            additCalcEdit.Properties.DisplayMember = "Name";
            additCalcEdit.Properties.NullText = "Немає данних";

            if (activeCheck.Checked)
                additCalcEdit.Enabled = true;
            else
                additCalcEdit.Enabled = false;

            switch (operation)
            {
                case Utils.Operation.Add:
                    {
                        ((MTSNomenclatureGroupsDTO)Item).RATIO_OF_WASTE = (decimal?)0.000;
                        break;
                    }
            }



        }

        public MTSNomenclatureGroupsDTO Return()
        {
            return (MTSNomenclatureGroupsDTO)Item;
        }

        private void activeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (activeCheck.Checked)
            {
                additCalcEdit.Enabled = true;
            }
            else
            {
                additCalcEdit.Enabled = false;
                ((MTSNomenclatureGroupsDTO)Item).ADDIT_CALCULATION_ID = null;
            }
        }

        private void activeCheck_PropertiesChanged(object sender, EventArgs e)
        {

        }

        private void activeCheck_EditValueChanged(object sender, EventArgs e)
        {

        }

        private bool SaveItem()
        {

            this.Item.EndEdit();
            mtsNomenclatureGroupBS.EndEdit();

            mtsNomenclaturesService = Program.kernel.Get<IMtsNomenclaturesService>();

            if (FindDublicate((MTSNomenclatureGroupsDTO)this.Item))
            {
                MessageBox.Show("Така група вже існує!", "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            switch (operation)
            {
                case Utils.Operation.Add:
                    {
                        if (activeCheck.Checked)
                            ((MTSNomenclatureGroupsDTO)Item).ADDIT_CALCULATION_ACTIVE = true;


                        int m = mtsNomenclaturesService.GetLastSortPositionNomenclatureGroup() + 1;

                        ((MTSNomenclatureGroupsDTO)Item).CODPROD = m;
                        ((MTSNomenclatureGroupsDTO)Item).SORTPOSITION = m;


                        ((MTSNomenclatureGroupsDTO)Item).ID = mtsNomenclaturesService.NomenclatureGroupCreate((MTSNomenclatureGroupsDTO)Item);

                        return true;
                    }


                case Utils.Operation.Update:
                    {



                        mtsNomenclaturesService.NomenclarureGroupUpdate((MTSNomenclatureGroupsDTO)Item);
                        return true;
                    }





                    //create CalcWithBuyersSpec


                    //create CalcWithBuyersPaymentVat


                    //int cwbVatId = calcWithBuyersService.CalcWithBuyersPaymentVatCreate(cwbVatModel);

                    //return true;

                default:
                    return false;
            }

        }

        private bool FindDublicate(MTSNomenclatureGroupsDTO model)
        {
            mtsNomenclaturesService = Program.kernel.Get<IMtsNomenclaturesService>();
            return mtsNomenclaturesService.GetNomenclatureGroups().Any(s => s.NAME == model.NAME && s.ID != model.ID);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            this.Item.EndEdit();


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
                {
                    MessageBox.Show("При збереженні виникла помилка. " + ex.Message, "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void nomenclatureGroupNameEdit_EditValueChanged(object sender, EventArgs e)
        {
            dxValidationProvider.Validate((Control)sender);
        }

        private void ratOfWasteEdit_EditValueChanged(object sender, EventArgs e)
        {
            dxValidationProvider.Validate((Control)sender);
        }

        private void dxValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void dxValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (dxValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLabel.Visible = !isValidate;
        }
    }
}