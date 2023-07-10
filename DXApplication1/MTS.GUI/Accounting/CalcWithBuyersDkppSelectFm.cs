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
using MTS.BLL.DTO.ModelsDTO;
using Ninject;

namespace MTS.GUI.Accounting
{
    public partial class CalcWithBuyersDkppSelectFm : DevExpress.XtraEditors.XtraForm
    {
        private IAccountsService accountsService;

        private BindingSource dictionaryTreeBS = new BindingSource();

        private DictionaryDKPPDTO returnModel;

        public CalcWithBuyersDkppSelectFm()
        {
            InitializeComponent();

            accountsService = Program.kernel.Get<IAccountsService>();

            dictionaryTreeBS.DataSource = accountsService.GetDictionaryDKPP();
            dictionaryTree.DataSource = dictionaryTreeBS;
            dictionaryTree.KeyFieldName = "Id";
            dictionaryTree.ParentFieldName = "ParentId";
            dictionaryTree.ExpandAll();
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            returnModel = (DictionaryDKPPDTO)dictionaryTreeBS.Current;
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public DictionaryDKPPDTO Return()
        {
            return returnModel;
        }
    }
}