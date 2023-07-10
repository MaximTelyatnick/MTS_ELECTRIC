﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using Ninject;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.Interfaces;
using MTS.BLL.DTO.SelectedDTO;
using MTS.BLL.Infrastructure;

namespace MTS.GUI.Accounting
{
    public partial class CashBookFm : DevExpress.XtraEditors.XtraForm
    {
        private ICashBookService cashBookService;
        private IReportService reportService;

        private BindingSource cashBookBS = new BindingSource();
        private BindingSource cashBookRecordsBS = new BindingSource();

        List<CashBookPageDTO> cashBookPagesList = new List<CashBookPageDTO>();

        private UserTasksDTO userTasksDTO;
        private CashBookBalanceDTO cashBookBalanceDTO = new CashBookBalanceDTO();

        private DateTime currentDate;
        private DateTime stockDate = new DateTime(2018,12,31);

        private decimal beginDayPrice = 0.00m;
        private decimal endDayPrice = 0.00m;



        public CashBookFm(UserTasksDTO userTasksDTO)
        {
            InitializeComponent();

            this.userTasksDTO = userTasksDTO;

            yearEdit.EditValue = DateTime.Now;

            monthEdit.EditValue = DateTime.Now.Month;

            firstReportDateEdit.EditValue = new DateTime(DateTime.Now.Year, 1, 1);
            lastReportDateEdit.EditValue = new DateTime(DateTime.Now.Year, 12, 31);

            AuthorizatedUserAccess();

            this.currentDate = new DateTime(((DateTime)yearEdit.EditValue).Year, (int)monthEdit.EditValue, 1);

            LoadData(currentDate, currentDate.AddMonths(1).AddDays(-1));
        }

        #region Method's

        private void LoadData(DateTime beginDate, DateTime endDate)
        {
            splashScreenManager.ShowWaitForm();

            cashBookService = Program.kernel.Get<ICashBookService>();
            
            cashBookPagesList = cashBookService.GetPageByPeriod(beginDate, endDate).OrderByDescending(c => c.PageDate).ToList();

            if (cashBookPagesList.Count() > 0)
            {
                cashBookBS.DataSource = cashBookPagesList;

                cashBookPageGrid.DataSource = cashBookBS;

                LoadCashBookRecordsById(((CashBookPageDTO)cashBookBS.Current).Id, ((CashBookPageDTO)cashBookBS.Current).PageDate);

                cashBookRecordGrid.Refresh();
            }
            else
            {
                cashBookPageGrid.DataSource = null;
                cashBookRecordGrid.DataSource = null;
            }

            splashScreenManager.CloseWaitForm();
        }

        private void AuthorizatedUserAccess()
        {
            addBtn.Enabled = (userTasksDTO.AccessRightId == 2);
            editBtn.Enabled = (userTasksDTO.AccessRightId == 2);
            deleteBtn.Enabled = (userTasksDTO.AccessRightId == 2);
            showBtn.Enabled = (userTasksDTO.AccessRightId == 2);
            printCashBookPageBtn.Enabled = (userTasksDTO.AccessRightId == 2);
            printOrderCreditActBtn.Enabled = (userTasksDTO.AccessRightId == 2);
            printOrderDebitActBtn.Enabled = (userTasksDTO.AccessRightId == 2);
            printCashBookTittleBtn.Enabled = (userTasksDTO.AccessRightId == 2);
            printCashBookJournalRegistrationBtn.DropDownEnabled = (userTasksDTO.AccessRightId == 2);
        }

        private void showBtns_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            currentDate = new DateTime(((DateTime)yearEdit.EditValue).Year, (int)monthEdit.EditValue, 1);
            LoadData(currentDate, currentDate.AddMonths(1).AddDays(-1)); 
        }

        private void cashBookPageGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (cashBookBS.Count > 0)
            {
                LoadCashBookRecordsById(((CashBookPageDTO)cashBookBS.Current).Id, ((CashBookPageDTO)cashBookBS.Current).PageDate);
            }
        }

        private void LoadCashBookRecordsById(int id, DateTime currentDate)
        {
            cashBookService = Program.kernel.Get<ICashBookService>();
            cashBookRecordGrid.Refresh();
            var cashBookCurrentPagesRecords = cashBookService.GetCashBookRecords(id);
            cashBookRecordsBS.DataSource = cashBookCurrentPagesRecords;
            cashBookRecordGrid.DataSource = cashBookRecordsBS;


            if (cashBookRecordsBS.Count == 1)
            {
                if (((CashBookRecordJournalDTO)cashBookRecordsBS.Current).CurrencyTypeId == 0)
                {
                    printOrderDebitActBtn.Enabled = true;
                    printOrderCreditActBtn.Enabled = false;
                }
                else
                {
                    printOrderDebitActBtn.Enabled = false;
                    printOrderCreditActBtn.Enabled = true;
                }
            }
            

            var balanceByPeriod = cashBookService.GetCashBookBalanceByPeriod(stockDate, currentDate);

            cashBookBalanceDTO = balanceByPeriod.FirstOrDefault(bbp => bbp.Id == 1);
            cashBookBalanceDTO.SumBeginDay = cashBookBalanceDTO.FullSaldo;
            cashBookBalanceDTO.SumEndDay = cashBookBalanceDTO.FullSaldo;

            beginDayPriceEdit.EditValue = cashBookBalanceDTO.FullSaldo;

            foreach (var item in cashBookCurrentPagesRecords)
            {
                if (item.CurrencyTypeId == 0)
                    cashBookBalanceDTO.SumEndDay += item.Debit;
                else
                {
                    cashBookBalanceDTO.SumEndDay -= item.Credit;
                }
            }

            endDayPriceEdit.EditValue = cashBookBalanceDTO.SumEndDay;

        }

        private void DeleteCashBookPages()
        {
            if (cashBookBS.Count != 0)
            {
                if (MessageBox.Show("Видалити сторінку?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cashBookService = Program.kernel.Get<ICashBookService>();
                    if (cashBookService.CashBookPageDelete(((CashBookPageDTO)cashBookBS.Current).Id))
                    {
                        int rowHandle = cashBookPageGridView.FocusedRowHandle - 1;
                        cashBookPageGridView.BeginDataUpdate();

                        currentDate = new DateTime(((DateTime)yearEdit.EditValue).Year, (int)monthEdit.EditValue, 1);
                        LoadData(currentDate, currentDate.AddMonths(1).AddDays(-1));
                        
                        cashBookPageGridView.EndDataUpdate();
                        cashBookPageGridView.FocusedRowHandle = (cashBookPageGridView.IsValidRowHandle(rowHandle)) ? rowHandle : -1;
                    }
                }  
            }
        }

        private void EditCashBookPages(Utils.Operation operation, CashBookPageDTO model, List<CashBookRecordJournalDTO> cashBookrecordsList)
        {
            using (CashBookEditFm cashBookEditFm = new CashBookEditFm(operation, model, cashBookrecordsList))
            {
                if (cashBookEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    CashBookPageDTO return_Id = cashBookEditFm.Return();

                    cashBookPageGridView.BeginDataUpdate();

                    currentDate = new DateTime(((DateTime)yearEdit.EditValue).Year, (int)monthEdit.EditValue, 1);
                    LoadData(currentDate, currentDate.AddMonths(1).AddDays(-1));

                    cashBookPageGridView.EndDataUpdate();

                    int rowHandle = cashBookPageGridView.LocateByValue("Id", return_Id.Id);

                    cashBookPageGridView.FocusedRowHandle = rowHandle;

                    LoadCashBookRecordsById(((CashBookPageDTO)cashBookBS.Current).Id, ((CashBookPageDTO)cashBookBS.Current).PageDate);

                }
            }
        }

        



        #endregion

        #region Event's

        private void addBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditCashBookPages(Utils.Operation.Add, new CashBookPageDTO(), new List<CashBookRecordJournalDTO>());
        }

        private void editBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditCashBookPages(Utils.Operation.Update, (CashBookPageDTO)cashBookBS.Current, (List<CashBookRecordJournalDTO>)cashBookRecordsBS.DataSource);
        }

        private void deleteBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cashBookBS.Count > 0)
            {
                try
                {
                    DeleteCashBookPages();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("При видаленні виникла помилка. " + ex.Message, "Видалення", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cashBookRecordGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (cashBookRecordsBS.Count > 0)
            {
                if (((CashBookRecordJournalDTO)cashBookRecordsBS.Current).CurrencyTypeId == 0)
                {
                    printOrderDebitActBtn.Enabled = true;
                    printOrderCreditActBtn.Enabled = false;
                }
                else
                {
                    printOrderDebitActBtn.Enabled = false;
                    printOrderCreditActBtn.Enabled = true;
                }
            }

        }

        private void printOrderDebitActBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cashBookBS.Count > 0)
            {
                reportService = Program.kernel.Get<IReportService>();
                reportService.PrintCashBookDebitAct((CashBookPageDTO)cashBookBS.Current, (CashBookRecordJournalDTO)cashBookRecordsBS.Current);
            }
        }

        private void printOrderCreditActBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cashBookBS.Count > 0)
            {
                reportService = Program.kernel.Get<IReportService>();
                reportService.PrintCashBookCreditAct((CashBookPageDTO)cashBookBS.Current, (CashBookRecordJournalDTO)cashBookRecordsBS.Current);
            }
        }

        private void printCashBookPageBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cashBookRecordsBS.Count > 0)
            {
                reportService = Program.kernel.Get<IReportService>();
                reportService.PrintCashBookPage((CashBookPageDTO)cashBookBS.Current, (List<CashBookRecordJournalDTO>)cashBookRecordsBS.DataSource, cashBookBalanceDTO);
            }
        }

        private void printCashBookJournalRegistrationBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cashBookRecordsBS.Count > 0)
            {
                reportService = Program.kernel.Get<IReportService>();
                cashBookService = Program.kernel.Get<ICashBookService>();

                var balanceByPeriod = cashBookService.GetCashBookBalanceByPeriod(stockDate, (DateTime)firstReportDateEdit.EditValue);

                cashBookBalanceDTO = balanceByPeriod.FirstOrDefault(bbp => bbp.Id == 1);

                reportService.GetCashBookJournalRegistrationByPeriod((DateTime)firstReportDateEdit.EditValue, (DateTime)lastReportDateEdit.EditValue, cashBookBalanceDTO.FullSaldo);
            }
        }

        private void printCashBookTittleBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (cashBookBS.Count > 0)
            {
                reportService = Program.kernel.Get<IReportService>();

                cashBookPageGridView.PostEditor();

                reportService.PrintCashBookTittle(cashBookPagesList);
            }
        }

        #endregion

        private void printTrialSaldoBalanceBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

                reportService = Program.kernel.Get<IReportService>();

                if (firstReportDateEdit.EditValue != null || lastReportDateEdit.EditValue != null)
                    reportService.GetCashBookTrialBalanceByAccounts((DateTime)firstReportDateEdit.EditValue, (DateTime)lastReportDateEdit.EditValue);
                else
                    MessageBox.Show("Не вказана дата");
        }  
    }
}