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
using MTS.BLL.Services;
using MTS.BLL.DTO;
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.DTO.SelectedDTO;
using DevExpress.XtraEditors.Controls;
using Ninject;
using System.Web;
using MTS.BLL.Infrastructure;

namespace MTS.GUI.OTK
{
    public partial class WeldAttestationPersonsFm : DevExpress.XtraEditors.XtraForm
    {
        private BindingSource personsBS = new BindingSource();

        private List<WeldAttestationPersonsInfoDTO> returnPersonsList = new List<WeldAttestationPersonsInfoDTO>();

        public WeldAttestationPersonsFm(List<WeldAttestationPersonsInfoDTO> source)
        {
            InitializeComponent();
                        
            personsBS.DataSource = source;
            personsGrid.DataSource = personsBS;
        }

        public List<WeldAttestationPersonsInfoDTO> Return()
        {
            return returnPersonsList;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            personsGridView.CloseEditor();

            returnPersonsList = ((List<WeldAttestationPersonsInfoDTO>)personsBS.DataSource).Where(s => s.CheckForDelete).ToList();

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}