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
using MTS.BLL.DTO.ModelsDTO;
using MTS.BLL.Interfaces;
using Ninject;

namespace MTS.GUI.Classifiers
{
    public partial class DictionaryUktvFm : DevExpress.XtraEditors.XtraForm
    {

        private IAccountsService accountsService;

        private BindingSource dictionaryTreeBS = new BindingSource();

        private UserTasksDTO _userTasksDTO;


        public DictionaryUktvFm(UserTasksDTO userTasksDTO)
        {
            InitializeComponent();

            accountsService = Program.kernel.Get<IAccountsService>();

            dictionaryTreeBS.DataSource = accountsService.GetDictionaryUKTV();
            dictionaryTree.DataSource = dictionaryTreeBS;
            dictionaryTree.KeyFieldName = "Id";
            dictionaryTree.ParentFieldName = "ParentId";
            dictionaryTree.ExpandAll();
        }
    }
}