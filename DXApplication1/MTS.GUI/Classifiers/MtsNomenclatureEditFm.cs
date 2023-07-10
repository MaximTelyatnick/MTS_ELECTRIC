﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MTS.BLL.Interfaces;
using MTS.BLL.Services;
using MTS.BLL.DTO;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using Ninject;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System.IO;
using DevExpress.XtraBars;
using System;
using MTS.BLL.Infrastructure;

namespace MTS.GUI.Classifiers
{
    public partial class MtsNomenclatureEditFm : DevExpress.XtraEditors.XtraForm
    {
        private IMtsNomenclaturesService mtsNomenclaturesService;
        private IMtsSpecificationsService mtsSpecificationsService;
        private IUnitsService unitsService;
        private BindingSource mtsNomenclaturesBS = new BindingSource();
        private BindingSource gostsBS = new BindingSource();
        private BindingSource unitsBS = new BindingSource();
        private BindingSource nomenclatureGroupsBS = new BindingSource();
        private Utils.Operation operation;
        
        private ObjectBase Item
        {
            get { return mtsNomenclaturesBS.Current as ObjectBase; }
            set
            {
                mtsNomenclaturesBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public MtsNomenclatureEditFm(Utils.Operation operation, MtsNomenclaturessDTO model)
        {
            InitializeComponent();
            LoadData();

            this.operation = operation;
            mtsNomenclaturesBS.DataSource = Item = model;

            nameTBox.DataBindings.Add("EditValue", mtsNomenclaturesBS, "Name", true, DataSourceUpdateMode.OnPropertyChanged);
            gaugeTBox.DataBindings.Add("EditValue", mtsNomenclaturesBS, "Gauge", true, DataSourceUpdateMode.OnPropertyChanged);
            weightTBox.DataBindings.Add("EditValue", mtsNomenclaturesBS, "Weight", true);
            priceTBox.DataBindings.Add("EditValue", mtsNomenclaturesBS, "Price", true, DataSourceUpdateMode.OnPropertyChanged);
            noteTBox.DataBindings.Add("EditValue", mtsNomenclaturesBS, "Note", true, DataSourceUpdateMode.OnPropertyChanged);

            gostsEdit.Properties.DataSource = gostsBS;
            gostsEdit.Properties.ValueMember = "Id";
            gostsEdit.Properties.DisplayMember = "Name";
            gostsEdit.Properties.NullText = "Немає данних";

            unitsEdit.Properties.DataSource = unitsBS;
            unitsEdit.Properties.ValueMember = "UnitId";
            unitsEdit.Properties.DisplayMember = "UnitLocalName";
            unitsEdit.Properties.NullText = "Немає данних";

            nomenclatureGroupsEdit.Properties.DataSource = nomenclatureGroupsBS;
            nomenclatureGroupsEdit.Properties.ValueMember = "Id";
            nomenclatureGroupsEdit.Properties.DisplayMember = "Name";
            nomenclatureGroupsEdit.Properties.NullText = "Немає данних";

            if (this.operation == Utils.Operation.Update)
            {
                unitsEdit.EditValue = ((MtsNomenclaturessDTO)Item).UnitId;
                gostsEdit.EditValue = ((MtsNomenclaturessDTO)Item).MtsGostId;
                nomenclatureGroupsEdit.EditValue = ((MtsNomenclaturessDTO)Item).MtsNomenclatureGroupId;
            }
            else
            {
                unitsEdit.EditValue = null;
                gostsEdit.EditValue = null;
                nomenclatureGroupsEdit.EditValue = null;
                model.Weight = 0.000m;
                model.Weight = 0.00m;
                Item = model;
            }
            nameTBox.Focus();
            nomenclatureValidationProvider.Validate();
        }

  
        #region Metod's

        private void LoadData()
        {
            mtsNomenclaturesService = Program.kernel.Get<IMtsNomenclaturesService>();
            mtsSpecificationsService = Program.kernel.Get<IMtsSpecificationsService>();

            gostsBS.DataSource = mtsNomenclaturesService.GetGosts();
            nomenclatureGroupsBS.DataSource = mtsSpecificationsService.GetAllNomenclatureGroupsOld();
            //unitsBS.DataSource = mtsNomenclaturesService.GetUnits();
        }

        public long Return()
        {
            return ((MtsNomenclaturessDTO)Item).Id;
        }

        private void SaveNomenclature()
        {
            this.Item.EndEdit();

            ((MtsNomenclaturessDTO)Item).MtsGostId = ((MtsGostsDTO)gostsEdit.GetSelectedDataRow()).Id;
            ((MtsNomenclaturessDTO)Item).UnitId = ((UnitsDTO)unitsEdit.GetSelectedDataRow()).UnitId;
            ((MtsNomenclaturessDTO)Item).MtsNomenclatureGroupId = ((MtsNomenclatureGroupssDTO)nomenclatureGroupsEdit.GetSelectedDataRow()).Id;

            //if (this.operation == Utils.Operation.Add)
            //{
            //    ((MtsNomenclaturessDTO)Item).Id = mtsNomenclaturesService.NomenclarureCreate((MtsNomenclaturessDTO)mtsNomenclaturesBS.Current);
            //}
            //else
            //{
            //    mtsNomenclaturesService.NomenclarureUpdate(((MtsNomenclaturessDTO)mtsNomenclaturesBS.Current));
            //}

            DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #region Event's

        private void saveBtn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Зберегти зміни?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SaveNomenclature();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Item.EndEdit();
            this.Close();
        }

        private void gostsEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 1: //ДОБАВИТЬ
                    {
                        new MtsGostEditFm(Utils.Operation.Add, new MtsGostsDTO()).ShowDialog();
                        LoadData();
                        break;
                    }
                case 2://РЕДАКТИРОВАТЬ
                    {
                        new MtsGostEditFm(Utils.Operation.Update, (MtsGostsDTO)gostsEdit.GetSelectedDataRow()).ShowDialog();
                        LoadData();
                        break;
                    }
                case 3://УДАЛИТЬ
                    {
                        if (gostsBS.Count != 0)
                        {
                            if (MessageBox.Show("Видалити?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                mtsNomenclaturesService.GostDelete(((MtsGostsDTO)gostsEdit.GetSelectedDataRow()).Id);
                                LoadData();
                                gostsEdit.EditValue = null;
                                gostsEdit.Properties.NullText = "Немає данних";
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void unitsEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 1: //ДОБАВИТЬ
                    {
                        new UnitEditFm(Utils.Operation.Add, new UnitsDTO()).ShowDialog();
                        LoadData();
                        break;
                    }
                case 2://РЕДАКТИРОВАТЬ
                    {
                        new UnitEditFm(Utils.Operation.Update, (UnitsDTO)unitsEdit.GetSelectedDataRow()).ShowDialog();
                        LoadData();
                        break;
                    }
                case 3://УДАЛИТЬ
                    {
                        if (unitsBS.Count != 0)
                        {
                            if (MessageBox.Show("Видалити?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                unitsService.UnitDelete(((UnitsDTO)unitsEdit.GetSelectedDataRow()).UnitId);
                                LoadData();
                                unitsEdit.EditValue = null;
                                unitsEdit.Properties.NullText = "Немає данних";
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void nomenclatureGroupsEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)
            {
                case 1: //ДОБАВИТЬ
                    {
                        new MtsNomenclatureGroupEditFm(Utils.Operation.Add, new MtsNomenclatureGroupssDTO()).ShowDialog();
                        LoadData();
                        break;
                    }
                case 2://РЕДАКТИРОВАТЬ
                    {
                        new MtsNomenclatureGroupEditFm(Utils.Operation.Update, (MtsNomenclatureGroupssDTO)nomenclatureGroupsEdit.GetSelectedDataRow()).ShowDialog();
                        LoadData();
                        break;
                    }
                case 3://УДАЛИТЬ
                    {
                        if (nomenclatureGroupsBS.Count != 0)
                        {
                            if (MessageBox.Show("Видалити?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                mtsNomenclaturesService.NomenclarureGroupDelete(((MtsNomenclatureGroupssDTO)nomenclatureGroupsEdit.GetSelectedDataRow()).Id);
                                LoadData();
                                nomenclatureGroupsEdit.EditValue = null;
                                nomenclatureGroupsEdit.Properties.NullText = "Немає данних";
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        #endregion

        #region Validate event's

        private void nameTBox_TextChanged(object sender, EventArgs e)
        {
            nomenclatureValidationProvider.Validate((Control)sender);
        }

        private void nomenclatureGroupsEdit_EditValueChanged(object sender, EventArgs e)
        {
            nomenclatureValidationProvider.Validate((Control)sender);
        }

        private void gostsEdit_EditValueChanged(object sender, EventArgs e)
        {
            nomenclatureValidationProvider.Validate((Control)sender);
        }


        private void unitsEdit_EditValueChanged(object sender, EventArgs e)
        {
            nomenclatureValidationProvider.Validate((Control)sender);
        }

        private void nomenclatureValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (nomenclatureValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void nomenclatureValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;

        }

        #endregion

    }    
}