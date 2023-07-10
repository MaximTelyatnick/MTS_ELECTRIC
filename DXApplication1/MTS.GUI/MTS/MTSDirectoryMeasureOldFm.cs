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
using MTS.BLL.Interfaces;
using Ninject;
using MTS.BLL.Infrastructure;
using MTS.BLL.DTO.ModelsDTO;


namespace MTS.GUI.MTS
{
    public partial class MTSDirectoryMeasureOldFm : DevExpress.XtraEditors.XtraForm
    {

        private IMtsSpecificationsService mtsService;
        private BindingSource measureBS = new BindingSource();
        public MTSDirectoryMeasureOldFm()
        {
            InitializeComponent();
        
            LoadData();
        }
        private void LoadData()
        {
            mtsService = Program.kernel.Get<IMtsSpecificationsService>();
            measureBS.DataSource = mtsService.GetAllMeasureOld().OrderBy(ord => ord.ID).ToList();
            measureGrid.DataSource = measureBS;

        }
        private void AddToolStripMenu_Click(object sender, EventArgs e)
        {
            EditMeasure(Utils.Operation.Add, new MTSMeasureDTO());
        }

       

        private void EditToolStripMenu_Click(object sender, EventArgs e)
        {
            EditMeasure(Utils.Operation.Update, ((MTSMeasureDTO)measureBS.Current));
        }

        private void delToolStripMenu_Click(object sender, EventArgs e)
        {
            DeleteMeasure(((MTSMeasureDTO)measureBS.Current).ID);
        }
        private void EditMeasure(Utils.Operation operation, MTSMeasureDTO model)
        {
            using (MTSDirectoryMeasureEditOldFm mtsDirectoryMeasureEditOldFm = new MTSDirectoryMeasureEditOldFm(operation, model))
            {
                if (mtsDirectoryMeasureEditOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MTSMeasureDTO return_Id = mtsDirectoryMeasureEditOldFm.Return1();
                    measureGridView.PostEditor();
                    measureGridView.BeginDataUpdate();
                    LoadData();
                    measureGridView.EndDataUpdate();

                    int rowHandle = measureGridView.LocateByValue("ID", return_Id.ID);
                   measureGridView.FocusedRowHandle = rowHandle;
                }
            }
        }
        private void DeleteMeasure(int Id)
        {
            if (MessageBox.Show("Видалити Гост?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mtsService = Program.kernel.Get<IMtsSpecificationsService>();

                mtsService.MTSDeleteMeasure(Id);

                measureGridView.PostEditor();
                measureGridView.BeginDataUpdate();
                LoadData();
                measureGridView.EndDataUpdate();
            }
        }
    }
}