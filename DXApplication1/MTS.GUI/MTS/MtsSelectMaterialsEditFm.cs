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
using MTS.GUI.Classifiers;

namespace MTS.GUI.MTS
{
    public partial class MtsSelectMaterialsEditFm : DevExpress.XtraEditors.XtraForm
    {
        private IMtsNomenclaturesService mtsNomenclatureService;

        private BindingSource materialsBS = new BindingSource();

        private List<MtsNomenclaturessDTO> selectedList = new List<MtsNomenclaturessDTO>();

        public MtsSelectMaterialsEditFm(List<MtsNomenclaturessDTO> source)
        {
            InitializeComponent();

            materialsBS.DataSource = source;
            materialsGrid.DataSource = materialsBS;
        }

        #region Method's

        public List<MtsNomenclaturessDTO> Return()
        {
            return selectedList;
        }

        private MtsNomenclaturessDTO GetSingleMtsNomenclature(long id)
        {
            mtsNomenclatureService = Program.kernel.Get<IMtsNomenclaturesService>();
            return mtsNomenclatureService.GetNomenclarures().SingleOrDefault(n => n.Id == id);
        }

        private void EditMtsNomenclature(Utils.Operation operation, MtsNomenclaturessDTO model)
        {
            using (MtsNomenclatureEditFm mtsNomenclatureEditFm = new MtsNomenclatureEditFm(operation, model))
            {
                if (mtsNomenclatureEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    long return_Id = mtsNomenclatureEditFm.Return();
                    
                    materialsGridView.BeginDataUpdate();

                    var currMaterial = GetSingleMtsNomenclature(return_Id);

                    if (operation == Utils.Operation.Add)
                    {
                        materialsBS.Add(currMaterial);
                    }
                    else
                    {
                        ((MtsNomenclaturessDTO)materialsBS.Current).Name = currMaterial.Name;
                        ((MtsNomenclaturessDTO)materialsBS.Current).AdditCalculationActive = currMaterial.AdditCalculationActive;
                        ((MtsNomenclaturessDTO)materialsBS.Current).AdditUnitLocalName = currMaterial.AdditUnitLocalName;
                        ((MtsNomenclaturessDTO)materialsBS.Current).Gauge = currMaterial.Gauge;
                        ((MtsNomenclaturessDTO)materialsBS.Current).GostName = currMaterial.GostName;
                        ((MtsNomenclaturessDTO)materialsBS.Current).GroupName = currMaterial.GroupName;
                        ((MtsNomenclaturessDTO)materialsBS.Current).MtsGostId = currMaterial.MtsGostId;
                        ((MtsNomenclaturessDTO)materialsBS.Current).MtsNomenclatureGroupId = currMaterial.MtsNomenclatureGroupId;
                        ((MtsNomenclaturessDTO)materialsBS.Current).Note = currMaterial.Note;
                        ((MtsNomenclaturessDTO)materialsBS.Current).Price = currMaterial.Price;
                        ((MtsNomenclaturessDTO)materialsBS.Current).RatioOfWaste = currMaterial.RatioOfWaste;
                        ((MtsNomenclaturessDTO)materialsBS.Current).UnitId = currMaterial.UnitId;
                        ((MtsNomenclaturessDTO)materialsBS.Current).UnitLocalName = currMaterial.UnitLocalName;
                        ((MtsNomenclaturessDTO)materialsBS.Current).Weight = currMaterial.Weight;
                    }

                    materialsBS.EndEdit();
                    materialsGridView.EndDataUpdate();
                    
                    int rowHandle = materialsGridView.LocateByValue("Id", return_Id);
                    materialsGridView.FocusedRowHandle = rowHandle;
                }
            }
        }

        public void DeleteMaterial()
        {
            if (MessageBox.Show("Видалити матеріал із довідника?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mtsNomenclatureService = Program.kernel.Get<IMtsNomenclaturesService>();

                if (mtsNomenclatureService.NomenclarureDelete(((MtsNomenclaturessDTO)materialsBS.Current).Id))
                {
                    int rowHandle = materialsGridView.FocusedRowHandle - 1;
                    
                    materialsGridView.BeginDataUpdate();
                    materialsBS.RemoveCurrent();
                    materialsBS.EndEdit();
                    materialsGridView.EndDataUpdate();
                }
            }
        }

        #endregion

        #region Event's

        private void okBtn_Click(object sender, EventArgs e)
        {
            materialsGridView.CloseEditor();

            selectedList = ((List<MtsNomenclaturessDTO>)materialsBS.DataSource).Where(s => s.CheckForSelected).ToList();

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void addBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            EditMtsNomenclature(Utils.Operation.Add, new MtsNomenclaturessDTO());
        }

        private void editBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (materialsBS.Count > 0)
                EditMtsNomenclature(Utils.Operation.Update, (MtsNomenclaturessDTO)materialsBS.Current);
        }

        private void deleteBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (materialsBS.Count > 0)
                DeleteMaterial();
        }

        #endregion
    }
}