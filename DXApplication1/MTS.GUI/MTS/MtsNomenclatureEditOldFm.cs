using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MTS.BLL.DTO.ModelsDTO;
using DevExpress.XtraEditors;
using MTS.BLL.Infrastructure;
using MTS.BLL.Interfaces;
using Ninject;

namespace MTS.GUI.MTS
{
    public partial class MtsNomenclatureEditOldFm : DevExpress.XtraEditors.XtraForm
    {
        private Utils.Operation operation;
        private IMtsSpecificationsService mtsSpecificationsService;
        private IMtsNomenclaturesService mtsNomenclaturesService;
        private BindingSource mtsNomenclaturesBS = new BindingSource();
        private BindingSource nomenclaturesGropuBS = new BindingSource();
        MTSNomenclaturesDTO mtsNomenclaturesDTO = new MTSNomenclaturesDTO();
        
        private ObjectBase Item
        {
            get { return mtsNomenclaturesBS.Current as ObjectBase; }
            set
            {
                mtsNomenclaturesBS.DataSource = value;
                value.BeginEdit();
            }
        }
        public MtsNomenclatureEditOldFm(Utils.Operation operation, MTSNomenclaturesDTO model)
        {
            InitializeComponent();
            this.operation = operation;

            mtsNomenclaturesBS.DataSource = Item = model;// mtsNomenclaturesDTO;
            mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();
            mtsNomenclaturesService = Program.kernel.Get<IMtsNomenclaturesService>();

            //  nomenclaturesBS.DataSource = mtsNomenclaturesService.GetNomenclarures();
            nameNomenEdit.DataBindings.Add("EditValue", mtsNomenclaturesBS, "NAME", true, DataSourceUpdateMode.OnPropertyChanged);
            priceEdit.DataBindings.Add("EditValue", mtsNomenclaturesBS, "PRICE", true, DataSourceUpdateMode.OnPropertyChanged);
            weightEdit.DataBindings.Add("EditValue", mtsNomenclaturesBS, "WEIGHT", true, DataSourceUpdateMode.OnPropertyChanged);
            noteEdit.DataBindings.Add("EditValue", mtsNomenclaturesBS, "NOTE", true, DataSourceUpdateMode.OnPropertyChanged);
            guagesEdit.DataBindings.Add("EditValue", mtsNomenclaturesBS, "GUAGE", true, DataSourceUpdateMode.OnPropertyChanged);

            nomenGroupLookUpEdit.DataBindings.Add("EditValue", mtsNomenclaturesBS, "NOMENCLATUREGROUPS_ID", true, DataSourceUpdateMode.OnPropertyChanged);
            nomenGroupLookUpEdit.Properties.DataSource = mtsNomenclaturesService.GetNomenclatureGroups();
            nomenGroupLookUpEdit.Properties.ValueMember = "ID";
            nomenGroupLookUpEdit.Properties.DisplayMember = "NAME";
            nomenGroupLookUpEdit.Properties.NullText = "Немає данних";

            measureLookUpEdit.DataBindings.Add("EditValue", mtsNomenclaturesBS, "MEASURE_ID", true, DataSourceUpdateMode.OnPropertyChanged);
            measureLookUpEdit.Properties.DataSource = mtsSpecificationsService.GetAllMeasureOld();
            measureLookUpEdit.Properties.ValueMember = "ID";
            measureLookUpEdit.Properties.DisplayMember = "NAME";
            measureLookUpEdit.Properties.NullText = "Немає данних";

            gostLookUpEdit.DataBindings.Add("EditValue", mtsNomenclaturesBS, "GOST_ID", true, DataSourceUpdateMode.OnPropertyChanged);
            gostLookUpEdit.Properties.DataSource = mtsSpecificationsService.GetAllGostOld();
            gostLookUpEdit.Properties.ValueMember = "ID";
            gostLookUpEdit.Properties.DisplayMember = "NAME";
            gostLookUpEdit.Properties.NullText = "Немає данних";

            if (operation == Utils.Operation.Add)
            {
                ((MTSNomenclaturesDTO)Item).PRICE = 0;
            }

        }
        public MTSNomenclaturesDTO Return()
        {
            return ((MTSNomenclaturesDTO)Item);
        }

        public bool Save()
        {
            this.Item.EndEdit();
            try
            {
                mtsNomenclaturesService = Program.kernel.Get<IMtsNomenclaturesService>();
                if (operation == Utils.Operation.Add)
                {
                    ((MTSNomenclaturesDTO)Item).GUAGE_ID = 1;
                    ((MTSNomenclaturesDTO)Item).ID= mtsNomenclaturesService.NomenclatureCreate((MTSNomenclaturesDTO)Item);
                    return true;
                }
                else
                {
                    mtsNomenclaturesService.NomenclatureUpdate((MTSNomenclaturesDTO)Item);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("При збереженні виникла помилка. " + ex.Message, "Збереження", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Item.EndEdit();
            DialogResult = DialogResult.Cancel;
            this.Close();
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

        #region validation

        private void mtsNomenclatureValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }
      
        
        private void mtsNomenclatureValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (mtsNomenclatureValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void nameNomenEdit_EditValueChanged(object sender, EventArgs e)
        {
            mtsNomenclatureValidationProvider.Validate((Control)sender);
        }

        private void nomenGroupLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            mtsNomenclatureValidationProvider.Validate((Control)sender);
        }

        private void measureLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            mtsNomenclatureValidationProvider.Validate((Control)sender);
        }

        private void guagesLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
          //  mtsNomenclatureValidationProvider.Validate((Control)sender);
        }

        private void gostLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            mtsNomenclatureValidationProvider.Validate((Control)sender);
        }

        private void weightEdit_EditValueChanged(object sender, EventArgs e)
        {
            mtsNomenclatureValidationProvider.Validate((Control)sender);
        }

        private void priceEdit_EditValueChanged(object sender, EventArgs e)
        {
            mtsNomenclatureValidationProvider.Validate((Control)sender);
        }

        private void noteEdit_EditValueChanged(object sender, EventArgs e)
        {
            mtsNomenclatureValidationProvider.Validate((Control)sender);
        }

        private void guagesEdit_EditValueChanged(object sender, EventArgs e)
        {
            mtsNomenclatureValidationProvider.Validate((Control)sender);
        }


        #endregion

        private void measureLookUpEdit_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
        }

        private void measureLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();
            //businessTripsService = Program.kernel.Get<IBusinessTripsService>();
            switch (e.Button.Index)
            {
                case 1: //Додати
                    {
                        using (MTSDirectoryMeasureEditOldFm measureEditFm = new MTSDirectoryMeasureEditOldFm(Utils.Operation.Add, new MTSMeasureDTO()))
                        {
                            if (measureEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                long return_Id = measureEditFm.Return1().ID;
                                mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();
                                measureLookUpEdit.Properties.DataSource = mtsSpecificationsService.GetAllMeasureOld();
                                measureLookUpEdit.EditValue = return_Id;
                            }
                        }
                        break;
                    }
                case 2://Редагувати
                    {
                        if (measureLookUpEdit.EditValue == DBNull.Value)
                            return;

                        using (MTSDirectoryMeasureEditOldFm measureEditFm = new MTSDirectoryMeasureEditOldFm(Utils.Operation.Update, (MTSMeasureDTO)measureLookUpEdit.GetSelectedDataRow()))
                        {
                            if (measureEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                long return_Id = measureEditFm.Return1().ID;
                                mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();
                                measureLookUpEdit.Properties.DataSource = mtsSpecificationsService.GetAllMeasureOld();
                                measureLookUpEdit.EditValue = return_Id;


                            }
                        }
                        break;
                    }
                case 3://Видалити
                    {
                        if (measureLookUpEdit.EditValue == DBNull.Value)
                            return;

                        if (MessageBox.Show("Видалити?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            mtsSpecificationsService.MTSDeleteMeasure(((MTSMeasureDTO)measureLookUpEdit.GetSelectedDataRow()).ID);
                            mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();
                            measureLookUpEdit.Properties.DataSource = mtsSpecificationsService.GetAllMeasureOld();
                            measureLookUpEdit.EditValue = null;
                            measureLookUpEdit.Properties.NullText = "Немає данних";
                        }

                        break;
                    }
                //case 4://Очистити
                //    {
                //        purposeEdit.EditValue = null;
                //        purposeEdit.Properties.NullText = "Немає данних";
                //        break;
                //    }
            }
        }

        private void gostLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
                mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();
            //businessTripsService = Program.kernel.Get<IBusinessTripsService>();
            switch (e.Button.Index)
            {
                case 1: //Додати
                    {
                        using (MtsDirectoryGostEditOldFm gostEditFm = new MtsDirectoryGostEditOldFm(Utils.Operation.Add, new MTSGostDTO()))
                        {
                            if (gostEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                long return_Id = gostEditFm.Return().ID;
                                mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();
                                gostLookUpEdit.Properties.DataSource = mtsSpecificationsService.GetAllGostOld();
                                gostLookUpEdit.EditValue = return_Id;
                            }
                        }
                        break;
                    }
                case 2://Редагувати
                    {
                        if (gostLookUpEdit.EditValue == DBNull.Value)
                            return;

                        using (MtsDirectoryGostEditOldFm gostEditFm = new MtsDirectoryGostEditOldFm(Utils.Operation.Update, (MTSGostDTO)gostLookUpEdit.GetSelectedDataRow()))
                        {
                            if (gostEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                long return_Id = gostEditFm.Return().ID;
                                mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();
                                gostLookUpEdit.Properties.DataSource = mtsSpecificationsService.GetAllGostOld();
                                gostLookUpEdit.EditValue = return_Id;


                            }
                        }
                        break;
                    }
                case 3://Видалити
                    {
                        if (gostLookUpEdit.EditValue == DBNull.Value)
                            return;

                        if (MessageBox.Show("Видалити?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();
                            mtsSpecificationsService.MTSDeleteGost(((MTSGostDTO)gostLookUpEdit.GetSelectedDataRow()).ID);

                            gostLookUpEdit.Properties.DataSource = mtsSpecificationsService.GetAllGostOld();
                            gostLookUpEdit.EditValue = null;
                            gostLookUpEdit.Properties.NullText = "Немає данних";
                        }

                        break;
                    }
                    //case 4://Очистити
                    //    {
                    //        purposeEdit.EditValue = null;
                    //        purposeEdit.Properties.NullText = "Немає данних";
                    //        break;
                    //    }
            }
        }
    }
}