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
    public partial class MtsDetailsEditOldFm : DevExpress.XtraEditors.XtraForm
    {
        private Utils.Operation operation;
        private IMtsSpecificationsService mtsSpecificationsService;
        private BindingSource detailsBS = new BindingSource();
        private BindingSource createDetailsBS = new BindingSource();
        private MTSSpecificationsDTO specificDTO = new MTSSpecificationsDTO();
        private MTSDetailsDTO detailDTO = new MTSDetailsDTO();
        private MTSNomenclaturesDTO nomenclaturesDTO = new MTSNomenclaturesDTO();

        private ObjectBase Item
        {
            get { return detailsBS.Current as ObjectBase; }
            set
            {
                detailsBS.DataSource = value;
                value.BeginEdit();
            }
        }

        public MtsDetailsEditOldFm(Utils.Operation operation, MTSDetailsDTO modelDetail)
        {
            InitializeComponent();
            this.operation=operation;
            detailsBS.DataSource = modelDetail;
            //this.specificDTO = modelSpecific;
            //this.detailDTO = modelDetail;
            mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();



            detalsProccesingLookUpEdit.DataBindings.Add("EditValue", detailsBS, "PROCESSING_ID", true, DataSourceUpdateMode.OnPropertyChanged);
            createDetailsBS.DataSource = mtsSpecificationsService.GetDetailsProccesing();
            detalsProccesingLookUpEdit.Properties.DataSource = createDetailsBS;
            detalsProccesingLookUpEdit.Properties.ValueMember = "ID";
            detalsProccesingLookUpEdit.Properties.DisplayMember = "NAME";
            detalsProccesingLookUpEdit.Properties.NullText = "Немає данних";

            numberDrawingEdit.DataBindings.Add("EditValue", detailsBS, "DRAWING", true, DataSourceUpdateMode.OnPropertyChanged);
            nameEdit.DataBindings.Add("EditValue", detailsBS, "NAME", true, DataSourceUpdateMode.OnPropertyChanged);
            quantityEdit.DataBindings.Add("EditValue", detailsBS, "QUANTITY", true, DataSourceUpdateMode.OnPropertyChanged);
            nomenclatureNameEdit.DataBindings.Add("EditValue", detailsBS, "NOMENCLATURESNAME", true, DataSourceUpdateMode.OnPropertyChanged);
            guageEdit.DataBindings.Add("EditValue", detailsBS, "GUAEGENAME", true, DataSourceUpdateMode.OnPropertyChanged);
            heightEdit.DataBindings.Add("EditValue", detailsBS, "HEIGHT", true, DataSourceUpdateMode.OnPropertyChanged);
            widthEdit.DataBindings.Add("EditValue", detailsBS, "WIDTH", true, DataSourceUpdateMode.OnPropertyChanged);
            quantityOfBlankEdit.DataBindings.Add("EditValue", detailsBS, "QUANTITY_OF_BLANKS", true, DataSourceUpdateMode.OnPropertyChanged);
           




            if(operation==Utils.Operation.Add)
            {
                //numberDrawingEdit.EditValue = model.DRAWING;
                //nameEdit.EditValue = model.NAME;
                //quantityEdit.EditValue = model.QUANTITY;
                //nomenclatureNameEdit.EditValue = model.NOMENCLATURESNAME;
                //guageEdit.EditValue = model.GUAEGENAME;
                //heightEdit.EditValue = model.HEIGHT;
                //widthEdit.EditValue = model.WIDTH;
                //quantityOfBlankEdit.EditValue = model.QUANTITY_OF_BLANKS;
                //detalsProccesingLookUpEdit.EditValue = model.DETALSPROCESSING;
                ((MTSDetailsDTO)detailsBS.Current).QUANTITY_OF_BLANKS = 1;
                ((MTSDetailsDTO)detailsBS.Current).WIDTH = 0;
                ((MTSDetailsDTO)detailsBS.Current).HEIGHT = 0;
                //detalsProccesingLookUpEdit.EditValue = 2;
                //((MTSDetailsDTO)detailsBS.Current).PROCESSING_ID = 2;
                ((MTSDetailsDTO)Item).PROCESSING_ID = 2;
                //(int)detalsProccesingLookUpEdit.EditValue
            }

            ControlValidation();
        }


        public MTSDetailsDTO Return()
        {
            return ((MTSDetailsDTO)Item);
        }
        private bool Save()
        {
            mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();
            if (operation == Utils.Operation.Add)
            {
                if (((MTSDetailsDTO)Item).CREATED_DETAILS_ID != null)
                {
                    MTSCreateDetalsDTO updateCreateDetails = new MTSCreateDetalsDTO();
                    updateCreateDetails.ID = (int)((MTSDetailsDTO)Item).CREATED_DETAILS_ID;
                    updateCreateDetails.NOMENCLATURE_ID = (int)((MTSDetailsDTO)Item).NOMENCLATURE_ID;
                    updateCreateDetails.PROCESSING_ID = (int)((MTSDetailsDTO)Item).PROCESSING_ID;
                    updateCreateDetails.NAME = ((MTSDetailsDTO)Item).NAME;
                    updateCreateDetails.DRAWING = ((MTSDetailsDTO)Item).DRAWING;
                    updateCreateDetails.WIDTH = ((MTSDetailsDTO)Item).WIDTH;
                    updateCreateDetails.HEIGHT = ((MTSDetailsDTO)Item).HEIGHT;
                    mtsSpecificationsService.MTSCreateDetalsUpdate(updateCreateDetails);
                }
                else
                {
                    MTSCreateDetalsDTO createCreateDetails = new MTSCreateDetalsDTO();
                    createCreateDetails.NOMENCLATURE_ID = this.nomenclaturesDTO.ID;
                    createCreateDetails.PROCESSING_ID = ((MTSDetailsDTO)Item).PROCESSING_ID;
                    createCreateDetails.NAME = ((MTSDetailsDTO)Item).NAME;

                    createCreateDetails.DRAWING = ((MTSDetailsDTO)Item).DRAWING;
                    createCreateDetails.WIDTH = ((MTSDetailsDTO)Item).WIDTH;
                    createCreateDetails.HEIGHT = ((MTSDetailsDTO)Item).HEIGHT;
                    ((MTSDetailsDTO)Item).CREATED_DETAILS_ID = mtsSpecificationsService.MTSCreateDetalsCreate(createCreateDetails);
                }
                mtsSpecificationsService.MTSDetailCreate((MTSDetailsDTO)Item);
                return true;
            }
            else
            {
                MTSCreateDetalsDTO updateCreateDetails = new MTSCreateDetalsDTO();
                updateCreateDetails.ID = (int)((MTSDetailsDTO)Item).CREATED_DETAILS_ID;
                updateCreateDetails.NOMENCLATURE_ID = (int)((MTSDetailsDTO)Item).NOMENCLATURE_ID;
                updateCreateDetails.PROCESSING_ID = (int)((MTSDetailsDTO)Item).PROCESSING_ID;
                updateCreateDetails.NAME = ((MTSDetailsDTO)Item).NAME;
                updateCreateDetails.DRAWING = ((MTSDetailsDTO)Item).DRAWING;
                updateCreateDetails.WIDTH = ((MTSDetailsDTO)Item).WIDTH;
                updateCreateDetails.HEIGHT = ((MTSDetailsDTO)Item).HEIGHT;
                mtsSpecificationsService.MTSCreateDetalsUpdate(updateCreateDetails);

                mtsSpecificationsService.MTSDetailUpdate((MTSDetailsDTO)Item);
                return true;
            }
            


                //MTSCreateDetalsDTO createDetailsItem = new MTSCreateDetalsDTO()
                //{
                //    NOMENCLATURE_ID = specificDTO.ID,//((MTSCreateDetalsDTO)Item).NOMENCLATURE_ID,
                //    PROCESSING_ID = ((MTSCreateDetalsDTO)Item).PROCESSING_ID,
                //    NAME = ((MTSCreateDetalsDTO)Item).NAME,
                //    DRAWING = ((MTSCreateDetalsDTO)Item).DRAWING,
                //    WIDTH = ((MTSCreateDetalsDTO)Item).WIDTH,
                //    HEIGHT = ((MTSCreateDetalsDTO)Item).HEIGHT,

                //    QUANTITY = ((MTSCreateDetalsDTO)Item).QUANTITY,
                //    NOMENCLATURESNAME = specificDTO.NAME,//((MTSCreateDetalsDTO)Item).NOMENCLATURESNAME,
                //    GUAEGENAME = ((MTSCreateDetalsDTO)Item).GUAEGENAME,
                //    CREATEDETALSNAME = ((MTSCreateDetalsDTO)Item).CREATEDETALSNAME,
                //    QUANTITY_OF_BLANKS = ((MTSCreateDetalsDTO)Item).QUANTITY_OF_BLANKS,
                //    DETALSPROCESSING = ((MTSCreateDetalsDTO)Item).DETALSPROCESSING,
                //    PROCCESINGNAME = ((MTSCreateDetalsDTO)Item).PROCCESINGNAME
                //};
                //mtsService.MTSCreateDetailsCreate(createDetailsItem);
               // ((MTSCreateDetalsDTO)Item).ID=mtsService.MTSCreateDetailsCreate(((MTSCreateDetalsDTO)Item));

                //MTSDetailsDTO detailItem = new MTSDetailsDTO()
                //{
                //    SPECIFICATIONS_ID = specificDTO.ID,
                //    CREATED_DETAILS_ID = createDetailsItem.ID,
                //    QUANTITY_OF_BLANKS = createDetailsItem.QUANTITY_OF_BLANKS,
                //    QUANTITY = createDetailsItem.QUANTITY
                //};
                //mtsService.MTSDetailCreate(detailItem);
            
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
                        MessageBox.Show("Не вірний номер.Такий номер вже існує.", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //numberAccountingEdit.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при збереженні " + ex.Message, "Збереження матеріалу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Item.EndEdit();
            DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void AddDirectoryDetail(MTSNomenclaturesDTO model)
        {
            using (DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(model,false))
            //   DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(model);
            {
                if (directoryBuyDetailEditOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.nomenclaturesDTO = directoryBuyDetailEditOldFm.Returnl();

                    //MTSNomenclatureGroupsOldDTO return_Id = directoryBuyDetailEditOldFm.Return();
                    ((MTSDetailsDTO)Item).NOMENCLATURE_ID = this.nomenclaturesDTO.ID;

                    nomenclatureNameEdit.EditValue = this.nomenclaturesDTO.NAME;
                    guageEdit.EditValue = this.nomenclaturesDTO.GUAGE;
                      

                }

            }
        }

        private void directoryBuyDetailBtn_Click(object sender, EventArgs e)
        {
            AddDirectoryDetail(new MTSNomenclaturesDTO());
        }

        private void numberDrawingEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
           // Utils.OnlyNumbers(e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (CheckDetail(numberDrawingEdit.Text))
                    quantityEdit.Focus();
                else
                    nameEdit.Focus();
            }
        }

        private bool CheckDetail(string drawingNumber)
        {
            mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();

            if (operation == Utils.Operation.Add)
            {
                var detailByDrawingName = mtsSpecificationsService.GetCreateDetalsByDrawingNumber(drawingNumber);
                if (detailByDrawingName != null)
                {
                    nameEdit.EditValue = ((MTSCreateDetalsDTO)detailByDrawingName).NAME;
                    nomenclatureNameEdit.EditValue = ((MTSCreateDetalsDTO)detailByDrawingName).NOMENCLATURESNAME;
                    guageEdit.EditValue = ((MTSCreateDetalsDTO)detailByDrawingName).GUAEGENAME;
                    detalsProccesingLookUpEdit.EditValue = ((MTSCreateDetalsDTO)detailByDrawingName).PROCESSING_ID;
                    heightEdit.EditValue = ((MTSCreateDetalsDTO)detailByDrawingName).HEIGHT;
                    widthEdit.EditValue = ((MTSCreateDetalsDTO)detailByDrawingName).WIDTH;
                    quantityOfBlankEdit.EditValue = 1;

                    ((MTSDetailsDTO)Item).CREATED_DETAILS_ID = detailByDrawingName.ID;
                    ((MTSDetailsDTO)Item).NOMENCLATURE_ID = detailByDrawingName.NOMENCLATURE_ID;
                    DialogResult = DialogResult.None;
                    return true;

                }
                else
                {
                    ((MTSDetailsDTO)Item).CREATED_DETAILS_ID = null;

                    DialogResult = DialogResult.None;
                    return false;
                }

            }
            else
            {
                return false;
            }  
        }

        private void detalsProccesingLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            switch ((int)detalsProccesingLookUpEdit.EditValue)
            {
                case 1:
                    processLabel.Text = "Розмір";
                    xlabel.Visible = false;
                    widthEdit.Visible = false;
                    ((MTSDetailsDTO)detailsBS.Current).WIDTH = 0;
                    break;

                case 2:
                    processLabel.Text = "Розмір";
                    xlabel.Visible = true;
                    widthEdit.Visible = true;
                    break;

                case 3:
                    processLabel.Text = "Діаметр";
                    xlabel.Visible = false;
                    widthEdit.Visible = false;
                    ((MTSDetailsDTO)detailsBS.Current).WIDTH = 0;
                    break;

                default:
                    break;
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nameEdit_EditValueChanged(object sender, EventArgs e)
        {
            dxValidationProvider.Validate((Control)sender);
        }

        private bool CheckProcessDetails()
        {
            switch ((int)detalsProccesingLookUpEdit.EditValue)
            {
                case 1:
                    
                    if ((decimal)heightEdit.EditValue > 0)
                        return true;
                    else
                        return false;
                case 2:
                    
                    if ((decimal)widthEdit.EditValue > 0 && (decimal)heightEdit.EditValue > 0)
                        return true;
                    else
                        return false;

                case 3:
                    if ((decimal)heightEdit.EditValue > 0)
                        return true;
                    else
                        return false;

                default:
                    break;
            }
            return false;
        }

        private void saveBtn1_Click(object sender, EventArgs e)
        {
            if (!CheckProcessDetails())
            {
                MessageBox.Show("Не вказано розмір деталі", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


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
                            MessageBox.Show("Не вірний номер.Такий номер вже існує.", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //numberAccountingEdit.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при збереженні " + ex.Message, "Збереження матеріалу", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        MessageBox.Show("Не вірний номер.Такий номер вже існує.", "Підтвердження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //numberAccountingEdit.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при збереженні " + ex.Message, "Збереження матеріалу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelBtn1_Click(object sender, EventArgs e)
        {
            this.Item.EndEdit();
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MtsDetailsEditOldFm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && CheckProcessDetails() && ControlValidation())
                saveBtn1.PerformClick();
        }

        private void dxValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn1.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void dxValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (dxValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn1.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void numberDrawingEdit_EditValueChanged(object sender, EventArgs e)
        {
            dxValidationProvider.Validate((Control)sender);
        }

        private void quantityEdit_EditValueChanged(object sender, EventArgs e)
        {
            dxValidationProvider.Validate((Control)sender);
        }

        private void nomenclatureNameEdit_EditValueChanged(object sender, EventArgs e)
        {
            dxValidationProvider.Validate((Control)sender);
        }

        private void quantityOfBlankEdit_EditValueChanged(object sender, EventArgs e)
        {
            dxValidationProvider.Validate((Control)sender);
        }

        private void heightEdit_EditValueChanged(object sender, EventArgs e)
        {
            dxValidationProvider.Validate((Control)sender);
        }

        private void widthEdit_EditValueChanged(object sender, EventArgs e)
        {
        }

        private bool ControlValidation()
        {
            return dxValidationProvider.Validate();
        }
    }
}