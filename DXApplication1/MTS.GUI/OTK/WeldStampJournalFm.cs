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
using MTS.BLL.Infrastructure;

namespace MTS.GUI.OTK
{
    public partial class WeldStampJournalFm : DevExpress.XtraEditors.XtraForm
    {
        public IWeldStampsService weldStampsService;

        public BindingSource journalBS = new BindingSource();

        public UserTasksDTO _userTasksDTO;

        public WeldStampJournalFm(UserTasksDTO userTasksDTO)
        {
            InitializeComponent();

            _userTasksDTO = userTasksDTO;

            AuthorizatedUserAccess();
            
            beginDateEdit.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            endDateEdit.EditValue = DateTime.Now;

            splashScreenManager.ShowWaitForm();

            LoadJournalData((DateTime)beginDateEdit.EditValue, (DateTime)endDateEdit.EditValue, LaidOffCheckItem.Checked);

            splashScreenManager.CloseWaitForm();
        }

        #region Method's

        public void AuthorizatedUserAccess()
        {
            addBtn.Enabled = (_userTasksDTO.AccessRightId == 2);
            editBtn.Enabled = (_userTasksDTO.AccessRightId == 2);
            deleteBtn.Enabled = (_userTasksDTO.AccessRightId == 2);
        }

        private void LoadJournalData(DateTime beginDate, DateTime endDate, bool personJob)
        {
            weldStampsService = Program.kernel.Get<IWeldStampsService>();

            if(personJob)
                journalBS.DataSource = weldStampsService.GetWeldStampJournalByPeriod(beginDate, endDate);
            else
                journalBS.DataSource = weldStampsService.GetWeldStampJournalByPeriod(beginDate, endDate).Where(bd=>bd.EndDate == null).ToList();

            journalGrid.DataSource = journalBS;
        }

        private void EditWeldStamps(Utils.Operation operation, WeldStampJournalDTO model)
        {
            using (WeldStampJournalEditFm weldStampJournalEditFm = new WeldStampJournalEditFm(operation, model))
            {
                if (weldStampJournalEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int return_Id = weldStampJournalEditFm.Return();
                    journalGridView.BeginDataUpdate();
                    LoadJournalData((DateTime)beginDateEdit.EditValue, (DateTime)endDateEdit.EditValue, LaidOffCheckItem.Checked);
                    journalGridView.EndDataUpdate();
                    int rowHandle = journalGridView.LocateByValue("Id", return_Id);
                    journalGridView.FocusedRowHandle = rowHandle;
                }
            }
        }

        #endregion

        #region Event's

        private void showDataBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager.ShowWaitForm();
            
            journalGridView.BeginDataUpdate();
            LoadJournalData((DateTime)beginDateEdit.EditValue, (DateTime)endDateEdit.EditValue, LaidOffCheckItem.Checked);
            journalGridView.EndDataUpdate();
            
            splashScreenManager.CloseWaitForm();
        }

        private void addBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditWeldStamps(Utils.Operation.Add, new WeldStampJournalDTO());
        }

        private void editBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(journalBS.Count > 0)
                EditWeldStamps(Utils.Operation.Update, new WeldStampJournalDTO(){
                    Id = ((WeldStampJournalInfoDTO)journalBS.Current).Id,
                    WeldStampId = ((WeldStampJournalInfoDTO)journalBS.Current).WeldStampId,
                    EmployeeId = ((WeldStampJournalInfoDTO)journalBS.Current).EmployeeId,
                    BeginDate = ((WeldStampJournalInfoDTO)journalBS.Current).BeginDate,
                    EndDate = ((WeldStampJournalInfoDTO)journalBS.Current).EndDate
                });
        }

        private void deleteBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (journalBS.Count > 0)
            {
                if (MessageBox.Show("Видалити запис у журналі?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    weldStampsService = Program.kernel.Get<IWeldStampsService>();

                    journalGridView.BeginDataUpdate();

                    if (weldStampsService.RemoveWeldStampJournalById(((WeldStampJournalInfoDTO)journalBS.Current).Id))
                        journalBS.RemoveCurrent();

                    journalGridView.EndDataUpdate();
                }
            }
        }

        private void refreshBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            splashScreenManager.ShowWaitForm();

            journalGridView.BeginDataUpdate();
            LoadJournalData((DateTime)beginDateEdit.EditValue, (DateTime)endDateEdit.EditValue, LaidOffCheckItem.Checked);
            journalGridView.EndDataUpdate();

            splashScreenManager.CloseWaitForm();
        }

        private void barCheckItem1_CheckedChanged(object sender, ItemClickEventArgs e)
        {

                journalGridView.BeginDataUpdate();
                LoadJournalData((DateTime)beginDateEdit.EditValue, (DateTime)endDateEdit.EditValue, LaidOffCheckItem.Checked);
                journalGridView.EndDataUpdate();

        }

        #endregion

 
        
    }
}