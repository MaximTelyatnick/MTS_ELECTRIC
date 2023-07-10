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
using DevExpress.XtraPrintingLinks;
using System.IO;


namespace MTS.GUI.Delivery
{
    public partial class DeliveryPaymentsFm : DevExpress.XtraEditors.XtraForm
    {
        private IDeliveryService deliveryService;
        private BindingSource paymentsBS = new BindingSource();
        private UserTasksDTO userTasksDTO;

        public DeliveryPaymentsFm(UserTasksDTO userTasksDTO)
        {
            InitializeComponent();
            this.userTasksDTO = userTasksDTO;
            DateTime begin_Date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); // год - месяц - день
            DateTime end_Date = DateTime.Today;
            beginDateEdit.EditValue = begin_Date;
            endDateEdit.EditValue = end_Date;

            LoadData(begin_Date, end_Date);
            AuthorizatedUserAccess();
        }

        private void LoadData(DateTime beginDate, DateTime endDate)
        {
            splashScreenManager.ShowWaitForm();
            deliveryService = Program.kernel.Get<IDeliveryService>();
            var payments = deliveryService.GetDeliveryPayments(beginDate, endDate);
            paymentsBS.DataSource = payments;
            deliveryPaymentsGrid.DataSource = paymentsBS;
            splashScreenManager.CloseWaitForm();
            deliveryPaymentsGridView.ExpandAllGroups();
            deliveryPaymentsGrid.Focus();
        }

        public void AuthorizatedUserAccess()
        {
            paymentPriceCol.Visible = (userTasksDTO.PriceAttribute == 1);
            paymentPriceCurrencyCol.Visible = (userTasksDTO.PriceAttribute == 1);
            currencyCodeCol.Visible = (userTasksDTO.PriceAttribute == 1);
            gridBand3.Visible = (userTasksDTO.PriceAttribute == 1);
            customerOrderCurrencyPriceCol.Visible = (userTasksDTO.PriceAttribute == 1);
            сustomerOrderPriceCol.Visible = (userTasksDTO.PriceAttribute == 1);

        }

        private void showPaymentsForDate_Click(object sender, EventArgs e)
        {
            DateTime begin_Date = (DateTime)beginDateEdit.EditValue;
            DateTime end_Date = (DateTime)endDateEdit.EditValue;
            LoadData(begin_Date, end_Date);
        }

        private void xlsBtn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2010)(.xlsx)|*.xlsx|Excel (2003) (.xls)|*.xls";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string exportFilePath = saveDialog.FileName;
                    //var printingSystem = new PrintingSystemBase();

                    var optionXls = new XlsExportOptions();
                    optionXls.ExportMode = XlsExportMode.SingleFile;
                    optionXls.SheetName = "Платежі";
                    optionXls.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;

                    var optionXlsx = new XlsxExportOptions();
                    optionXlsx.ExportMode = XlsxExportMode.SingleFile;
                    optionXlsx.SheetName = "Платежі";
                    optionXlsx.TextExportMode = DevExpress.XtraPrinting.TextExportMode.Text;

                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    //try
                    //{
                    //    deliveryPaymentsGrid.ExportToXls(exportFilePath);
                    //}
                    //catch (Exception)
                    //{
                    //    MessageBox.Show("Збереження файлу неможливе, документ вже відкритий! \n Закрийте документ і спробуйте ще.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    DevExpress.Export.ExportSettings.DefaultExportType = DevExpress.Export.ExportType.WYSIWYG;
                    switch (fileExtenstion)
                    {
                        case ".xls":
                            deliveryPaymentsGrid.ExportToXls(exportFilePath, optionXls);
                            break;
                        case ".xlsx":
                            deliveryPaymentsGrid.ExportToXlsx(exportFilePath, optionXlsx);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
     
        }

        private void deliveryPaymentsGridView_CellMerge(object sender, CellMergeEventArgs e)
        {
            GridView view = sender as GridView;
            DeliveryPaymentsDTO model1 = (DeliveryPaymentsDTO)view.GetRow(e.RowHandle1);
            DeliveryPaymentsDTO model2 = (DeliveryPaymentsDTO)view.GetRow(e.RowHandle2);

            if (e.Column.FieldName != "CustomerOrderNumber" && e.Column.FieldName != "CustomerOrderDate" && e.Column.FieldName != "CustomerOrderPrice" && e.Column.FieldName != "CustomerOrderCurrencyPrice")
            {
                if (model2 != null && model1 != null)
                {
                    e.Merge = (model1.PaymentDocument == model2.PaymentDocument);
                    e.Handled = true;
                }
            }
        }
    }
}