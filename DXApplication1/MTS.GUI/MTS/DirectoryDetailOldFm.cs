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
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.Infrastructure;

namespace MTS.GUI.MTS
{
    public partial class DirectoryDetailOldFm : DevExpress.XtraEditors.XtraForm
    {
        private IMtsSpecificationsService mtsService;
        private BindingSource detailBS = new BindingSource();

        public DirectoryDetailOldFm()
        {
            InitializeComponent();
          //  nameEdit.DataBindings.Add("EditValue", detailBS, "NAME", true, DataSourceUpdateMode.OnPropertyChanged);
            LoadDetail();
        }
        private void LoadDetail()
        {
            mtsService = Program.kernel.Get<IMtsSpecificationsService>();
            detailBS.DataSource = mtsService.GetAllCreateDetals();
            detailGrid.DataSource = detailBS;
       
        }

        private void okBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (nameEdit.EditValue != null)
            //{
            //    detailGridView.BeginDataUpdate();
            //    detailBS.DataSource = mtsService.GetAllCreateDetals().Where(nam => nam.NAME == (string)(nameEdit.EditValue));
            //    detailGridView.EndDataUpdate();
            //}
            //if (drawingEdit.EditValue != null)
            //{
            //    detailGridView.BeginDataUpdate();
            //    detailBS.DataSource = mtsService.GetAllCreateDetals().Where(nam => nam.DRAWING == (string)(drawingEdit.EditValue));
            //    detailGridView.EndDataUpdate();
            //}
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // EditDetail(Utils.Operation.Add, new MTSDetailsDTO());// { SPECIFICATIONS_ID = ((MTSDetailsDTO)detailBS.Current).ID, PROCESSING_ID = 1 });
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  EditDetail(Utils.Operation.Update, ((MTSDetailsDTO)detailBS.Current));
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteDetail(((MTSCreateDetalsDTO)detailBS.Current).ID);
        }
        private void EditDetail(Utils.Operation operation, MTSDetailsDTO model)
        {
        //    using (MtsDetailsEditOldFm mtsDetailsEditOldFm = new MtsDetailsEditOldFm(operation, model))
        //    {
        //        if (mtsDetailsEditOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            MTSDetailsDTO return_Id = mtsDetailsEditOldFm.Return();
        //            detailGridView.BeginDataUpdate();
        //            LoadDetail();
        //            detailGridView.EndDataUpdate();
        //        }
        //    }
        }
        private void DeleteDetail(int detailId)
        {
            if (MessageBox.Show("Видалити деталь?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mtsService = Program.kernel.Get<IMtsSpecificationsService>();

                mtsService.MTSCreateDetailsDelete(detailId);

                detailGridView.PostEditor();
                detailGridView.BeginDataUpdate();
                LoadDetail();
                detailGridView.EndDataUpdate();
            }
        }
    }
}

   
