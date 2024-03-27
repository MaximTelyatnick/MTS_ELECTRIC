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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraBars;
using Ninject;
using System.IO;
using System.Diagnostics;
using MTS.BLL.Infrastructure;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using MTS.BLL;
using DevExpress.Data.Filtering;
using System.Reflection;
using System.Collections;
using MTS.BLL.DTO.ReportsDTO;
using System.Globalization;
using System.Threading;
using MTS.GUI.Login;

namespace MTS.GUI.MTS
{
    public partial class MtsSpecificationOldFm : DevExpress.XtraEditors.XtraForm
    {
        //private UserTasksDTO userTaskDTO;

        private IMtsSpecificationsService mtsService;
        private IReportService reportService;
        private BindingSource specificBS = new BindingSource();
        private BindingSource detalsSpecificBS = new BindingSource();
        private BindingSource byusDetalsSpecificBS = new BindingSource();
        private BindingSource materialsSpecificBS = new BindingSource();
        //private UserTasksDTO userTasksDTO;
        private MTSAuthorizationUsersDTO mtsAthorizationUsersDTO;
        private int previousFocusedRowDetails = -1;
        private int previousFocusedRowBuyDetails = -1;
        private int previousFocusedRowMaterials = -1;

        public MtsSpecificationOldFm(MTSAuthorizationUsersDTO mtsAthorizationUsersDTO)
        {
            InitializeComponent();
            this.mtsAthorizationUsersDTO = mtsAthorizationUsersDTO;
            userNameBtn.Caption = mtsAthorizationUsersDTO.NAME;

            startDateItem.EditValue = new DateTime(DateTime.Now.Year - 3, 6, 5);
            endDateItem.EditValue = DateTime.Now;
            

            
            //CultureInfo ciUSA = new CultureInfo("ru-RU");
            UserAccess((int)mtsAthorizationUsersDTO.USER_GROUPS_ID);
            SetGridSetting();
            //specificGridView.BeginUpdate();
            //focusedRow = LoadData();
            LoadData();
            
            //settings.Styles.FocusedRow.BackColor = System.Drawing.Color.Red;

            //int rowHandle = specificGridView.LocateByValue("ID", focusedRow);
            //specificGridView.FocusedRowHandle = rowHandle;


        }

        

        private void UserAccess(int userGroupId)
        {
            switch (userGroupId)
            {
                case 1://technologs, CRUD operation, full access
                    break;
                case 2:
                case 3:
                case 5://other, only view
                    addAllSpeficBtn.Enabled = false;
                    addSpecificBtn.Enabled = false;
                    copySpecBtn.Enabled = false;
                    editSpecificBtn.Enabled = false;
                    deleteSpecificBtn.Enabled = false;
                    enableColorSpecificBtn.Enabled = false;
                    mainMenu.Items[0].Enabled = false;
                    mainMenu.Items[1].Enabled = false;
                    mainMenu.Items[2].Enabled = false;
                    mainMenu.Items[9].Enabled = false;
                    mainMenu.Items[10].Enabled = false;
                    addBuyDetailBarBtn.Enabled = false;
                    editBuyDetailBarBtn.Enabled = false;
                    deleteBuyDetailBarBtn.Enabled = false;
                    addDetailBarBtn.Enabled = false;
                    editDetailBarBtn.Enabled = false;
                    deleteDetailBarBtn.Enabled = false;
                    addMaterialDetailBarBtn.Enabled = false;
                    editMaterialDetailBarBtn.Enabled = false;
                    deleteMaterialDetailBarBtn.Enabled = false;
                    break;
                case 4: //admin, full access
                    break;
                

                default:
                    break;
            }
        }

        private bool CheckEditAcces()
        {
            if (mtsAthorizationUsersDTO.USER_GROUPS_ID == 1 || mtsAthorizationUsersDTO.USER_GROUPS_ID == 4)
                return true;
            else
                return false;
        }

        private int LoadData()
        {
            mtsService = Program.kernel.Get<IMtsSpecificationsService>();
            specificBS.DataSource = mtsService.GetAllSpecificationOldByPeriod((DateTime)startDateItem.EditValue, (DateTime)endDateItem.EditValue).OrderByDescending(ord => ord.ID).ToList();
            //specificBS.DataSource = mtsService.GetAllSpecificationOldByPeriod((DateTime)startDateItem.EditValue, (DateTime)endDateItem.EditValue).ToList();
            specificGrid.DataSource = specificBS;


            if (specificBS.Count > 0)
            {
                LoadSpecific(((MTSSpecificationsDTO)specificBS.Current).ID);
                LoadBuysDetalSpecific(((MTSSpecificationsDTO)specificBS.Current).ID);
                LoadMaterialsSpecific(((MTSSpecificationsDTO)specificBS.Current).ID);
            }
            else
            {
                detalsSpecificGrid.DataSource = null;
                buysDetalsSpecificGrid.DataSource = null;
                materialsSpecificGrid.DataSource = null;
            }

            return ((List<MTSSpecificationsDTO>)specificBS.List).Last().ID;
        }

        private void LoadSpecific(int detailId)
        {
            mtsService = Program.kernel.Get<IMtsSpecificationsService>();
            detalsSpecificBS.Clear();
            detalsSpecificBS.DataSource = mtsService.GetAllDetailsSpecific(detailId).OrderByDescending(ord => ord.ID).ToList();
            if (detalsSpecificBS.Count != 0)
                detalsSpecificGrid.DataSource = detalsSpecificBS;
            else
                detalsSpecificGrid.DataSource = null;
        }

        private void LoadBuysDetalSpecific(int detailId)
        {
            mtsService = Program.kernel.Get<IMtsSpecificationsService>();
            byusDetalsSpecificBS.Clear();
            byusDetalsSpecificBS.DataSource = mtsService.GetBuysDetalSpecific(detailId).OrderByDescending(ord => ord.ID).ToList();
            
            if (byusDetalsSpecificBS.Count != 0)
                buysDetalsSpecificGrid.DataSource = byusDetalsSpecificBS;
            else
                buysDetalsSpecificGrid.DataSource = null;
        }
        private void LoadMaterialsSpecific(int detailId)
        {

            mtsService = Program.kernel.Get<IMtsSpecificationsService>();
            materialsSpecificBS.Clear();
            materialsSpecificBS.DataSource = mtsService.GetMaterialsSpecific(detailId).OrderByDescending(ord => ord.ID).ToList();
            if (materialsSpecificBS.Count != 0)
                materialsSpecificGrid.DataSource = materialsSpecificBS;
            else
                materialsSpecificGrid.DataSource = null;
        }

        private void SpecificationCheckMark()
        {

            mtsService = Program.kernel.Get<IMtsSpecificationsService>();
            MTSSpecificationsDTO update = (MTSSpecificationsDTO)specificBS.Current;

            int rowHandle = specificGridView.LocateByValue("ID", update.ID);

            specificGridView.PostEditor();
            specificGridView.BeginDataUpdate();

            if (((MTSSpecificationsDTO)specificBS.Current).SET_COLOR == 0)
            {
                ((MTSSpecificationsDTO)specificBS.Current).SET_COLOR = 1;
                mtsService.MTSSpecificationUpdate((MTSSpecificationsDTO)specificBS.Current);
                FocusedRowChanged();
            }
            else
            {
                splashScreenManager.ShowWaitForm();
                List<MTSDetailsDTO> mtsDetailsList = new List<MTSDetailsDTO>();
                List<MTSPurchasedProductsDTO> mtsPurchasedProductsList = new List<MTSPurchasedProductsDTO>();
                List<MTSMaterialsDTO> mtsMaterialsList = new List<MTSMaterialsDTO>();

                ((MTSSpecificationsDTO)specificBS.Current).SET_COLOR = 0;
                mtsService.MTSSpecificationUpdate((MTSSpecificationsDTO)specificBS.Current);

                mtsDetailsList = mtsService.GetAllDetailsSpecific(((MTSSpecificationsDTO)specificBS.Current).ID).OrderByDescending(ord => ord.ID).ToList();
                if (mtsDetailsList.Count != 0)
                {
                    foreach (var item in mtsDetailsList)
                    {
                        item.CHANGES = 0;
                        mtsService.MTSDetailsUpdate(item);
                    }
                }

                mtsPurchasedProductsList = mtsService.GetBuysDetalSpecific(((MTSSpecificationsDTO)specificBS.Current).ID).OrderByDescending(ord => ord.ID).ToList();
                if (mtsPurchasedProductsList.Count != 0)
                {
                    foreach (var item in mtsPurchasedProductsList)
                    {
                        item.CHANGES = 0;
                        mtsService.MTSPurchasedProductsUpdate(item);
                    }
                }

                mtsMaterialsList = mtsService.GetMaterialsSpecific(((MTSSpecificationsDTO)specificBS.Current).ID).OrderByDescending(ord => ord.ID).ToList();
                if (mtsMaterialsList.Count != 0)
                {
                    foreach (var item in mtsMaterialsList)
                    {
                        item.CHANGES = 0;
                        mtsService.MTSMaterialUpdate(item);
                    }
                }    

                splashScreenManager.CloseWaitForm();
                FocusedRowChanged();
            }

            specificGridView.FocusedRowHandle = (specificGridView.IsValidRowHandle(rowHandle)) ? rowHandle : -1;
            specificGridView.EndDataUpdate();
        }

        private void specificGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // var model = (MTSSpecificationsDTO)specificGridView.GetRow(e.FocusedRowHandle) ?? null;

            FocusedRowChanged();
        }

        public void FocusedRowChanged()
        {
            previousFocusedRowDetails = -1;
            previousFocusedRowBuyDetails = -1;
            previousFocusedRowMaterials = -1;

            if (specificBS.Count > 0)
            {
                LoadSpecific(((MTSSpecificationsDTO)specificBS.Current).ID);
                LoadBuysDetalSpecific(((MTSSpecificationsDTO)specificBS.Current).ID);
                LoadMaterialsSpecific(((MTSSpecificationsDTO)specificBS.Current).ID);
            }
            else
                materialsSpecificGrid.DataSource = null;

            if (!CheckEditAcces())
                return;

            if (((MTSSpecificationsDTO)specificBS.Current).SET_COLOR == 1)
            {
                enableColorSpecificBtn.LargeGlyph = imageCollection.Images[0];
                enableColorSpecificBtn.Caption = "Зняти виділення";
                disableLabelMenuBtn.Enabled = true;
                enableLabelMenuBtn.Enabled = false;
            }
            else
            {
                enableColorSpecificBtn.LargeGlyph = imageCollection.Images[1];
                enableColorSpecificBtn.Caption = "Виділити";
                disableLabelMenuBtn.Enabled = false;
                enableLabelMenuBtn.Enabled = true;
            }
        }
            

        private ObjectBase ItemSpecification
        {
            get { return specificBS.Current as ObjectBase; }
            set
            {
                specificBS.DataSource = value;
                value.BeginEdit();
            }
        }

        private ObjectBase ItemDetail
        {
            get { return detalsSpecificBS.Current as ObjectBase; }
            set
            {
                detalsSpecificBS.DataSource = value;
                value.BeginEdit();
            }
        }


        private void AddSpecification(Utils.Operation operation, MTSSpecificationsDTO model, MTSAuthorizationUsersDTO mtsAthorizationUsersDTO)
        {
            model.SET_COLOR = 0;
            using (MtsSpecificationOldEditFm mtsSpecificationOldEditFm = new MtsSpecificationOldEditFm(operation, model, mtsAthorizationUsersDTO))
            {
                if (mtsSpecificationOldEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MTSSpecificationsDTO return_Id = mtsSpecificationOldEditFm.Return();
                    specificGridView.BeginDataUpdate();
                    LoadData();
                    specificGridView.EndDataUpdate();
                    int rowHandle = detalsSpecificGridView.LocateByValue("ID", return_Id.ID);
                    specificGridView.FocusedRowHandle = rowHandle;
                }
            }
        }

        private void AddSpecificationDetails(MTSSpecificationsDTO model, Utils.Operation operation, MTSAuthorizationUsersDTO mtsAuthorizationUsersDTO)
        {
            model.SET_COLOR = 0;
            using (MtsSpecificationOldDetailsFm mtsSpecificationOldDetailsFm = new MtsSpecificationOldDetailsFm(model, operation, mtsAuthorizationUsersDTO))
            {
                if (mtsSpecificationOldDetailsFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MTSSpecificationsDTO return_Id = mtsSpecificationOldDetailsFm.Return();
                    specificGridView.BeginDataUpdate();
                    LoadData();
                    specificGridView.EndDataUpdate();
                    int rowHandle = detalsSpecificGridView.LocateByValue("ID", return_Id.ID);
                    detalsSpecificGridView.FocusedRowHandle = rowHandle;
                }
            }
        }

        private void DeleteSpecification()
        {
            if (specificBS.Count != 0)
            {
                if (MessageBox.Show("Видалити запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    mtsService = Program.kernel.Get<IMtsSpecificationsService>();
                    if (mtsService.MTSSpecificationDelete(((MTSSpecificationsDTO)specificBS.Current).ID))
                    {
                        int rowHandle = specificGridView.FocusedRowHandle - 1;
                        specificGridView.BeginDataUpdate();
                        LoadData();
                        specificGridView.EndDataUpdate();
                        specificGridView.FocusedRowHandle = (specificGridView.IsValidRowHandle(rowHandle)) ? rowHandle : -1;
                    }
                }
            }
        }


        private void EditBuyDetail(Utils.Operation operation, MTSPurchasedProductsDTO model)
        {
            switch (operation)
            {
                case Utils.Operation.Add:
                    using (DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(new MTSNomenclaturesDTO(),false))
                    {
                        if (directoryBuyDetailEditOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            //MTSNomenclatureGroupsOldDTO return_Id = directoryBuyDetailEditOldFm.Return();
                            // =new MtsBuyDetailEditOldFm(Utils.Operation.Add,MTSNomenclaturesOldDTO nom);
                            MTSNomenclaturesDTO selectNomenclature = directoryBuyDetailEditOldFm.Returnl();

                            model.NOMENCLATURES_ID = selectNomenclature.ID;
                            model.GUAEGENAME = selectNomenclature.GUAGE;
                            model.NOMENCLATURESNAME = selectNomenclature.NAME;
                            model.CHANGES = ((MTSSpecificationsDTO)specificBS.Current).SET_COLOR == 1 ? 1 : 0;

                            using (MtsBuyDetailEditOldFm mtsBuyDetailEditOldFm = new MtsBuyDetailEditOldFm(operation, model))
                            //   DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(model);
                            {
                                if (mtsBuyDetailEditOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    MTSPurchasedProductsDTO returnMtsPurchasedProduct = mtsBuyDetailEditOldFm.Return();
                                    buysDetalsSpecificGridView.BeginDataUpdate();
                                    LoadData();
                                    buysDetalsSpecificGridView.EndDataUpdate();
                                    int rowHandle = buysDetalsSpecificGridView.LocateByValue("ID", returnMtsPurchasedProduct.ID);
                                    buysDetalsSpecificGridView.FocusedRowHandle = rowHandle;
                                }
                            }
                        }
                    }

                    break;
                case Utils.Operation.Update:
                    using (MtsBuyDetailEditOldFm mtsBuyDetailEditOldFm = new MtsBuyDetailEditOldFm(operation, model))
                    //   DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(model);
                    {
                        if (mtsBuyDetailEditOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            MTSPurchasedProductsDTO returnMtsPurchasedProduct = mtsBuyDetailEditOldFm.Return();
                            buysDetalsSpecificGridView.BeginDataUpdate();
                            LoadData();
                            buysDetalsSpecificGridView.EndDataUpdate();
                            int rowHandle = buysDetalsSpecificGridView.LocateByValue("ID", returnMtsPurchasedProduct.ID);
                            buysDetalsSpecificGridView.FocusedRowHandle = rowHandle;
                        }
                    }
                    break;

                default:
                    break;
            }


        }

        private void EditMaterial(Utils.Operation operation, MTSMaterialsDTO model)
        {
            switch (operation)
            {
                case Utils.Operation.Add:
                    using (DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(new MTSNomenclaturesDTO(),false))
                    {
                        if (directoryBuyDetailEditOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            //MTSNomenclatureGroupsOldDTO return_Id = directoryBuyDetailEditOldFm.Return();
                            // =new MtsBuyDetailEditOldFm(Utils.Operation.Add,MTSNomenclaturesOldDTO nom);
                            MTSNomenclaturesDTO selectNomenclature = directoryBuyDetailEditOldFm.Returnl();

                            model.NOMENCLATURES_ID = selectNomenclature.ID;
                            model.GUAGENAME = selectNomenclature.GUAGE;
                            model.NOMENCLATURESNAME = selectNomenclature.NAME;
                            model.CHANGES = ((MTSSpecificationsDTO)specificBS.Current).SET_COLOR == 1 ? 1 : 0;

                            using (MtsMaterialEditOldFm mtsMaterialEditOldFm = new MtsMaterialEditOldFm(operation, model))
                            //   DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(model);
                            {
                                if (mtsMaterialEditOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    MTSMaterialsDTO returnMtsMaterials = mtsMaterialEditOldFm.Return();
                                    materialsSpecificGridView.BeginDataUpdate();
                                    LoadData();
                                    materialsSpecificGridView.EndDataUpdate();
                                    int rowHandle = materialsSpecificGridView.LocateByValue("ID", returnMtsMaterials.ID);
                                    materialsSpecificGridView.FocusedRowHandle = rowHandle;
                                }
                            }
                        }
                    }

                    break;
                case Utils.Operation.Update:
                    using (MtsMaterialEditOldFm mtsMaterialEditOldFm = new MtsMaterialEditOldFm(operation, model))
                    //   DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(model);
                    {
                        if (mtsMaterialEditOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            MTSMaterialsDTO returnMtsMaterials = mtsMaterialEditOldFm.Return();
                            materialsSpecificGridView.BeginDataUpdate();
                            LoadData();
                            materialsSpecificGridView.EndDataUpdate();
                            int rowHandle = materialsSpecificGridView.LocateByValue("ID", returnMtsMaterials.ID);
                            materialsSpecificGridView.FocusedRowHandle = rowHandle;
                        }
                    }
                    break;

                default:
                    break;
            }


        }

        private void EditDetailSpecific(Utils.Operation operation, MTSDetailsDTO model)
        {

            model.CHANGES = ((MTSSpecificationsDTO)specificBS.Current).SET_COLOR == 1 ? 1 : 0;

            using (MtsDetailsEditOldFm mtsDetailsEditOldFm = new MtsDetailsEditOldFm(operation, model))
            {
                if (mtsDetailsEditOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MTSDetailsDTO return_Id = mtsDetailsEditOldFm.Return();
                    detalsSpecificGridView.BeginDataUpdate();
                    LoadData();//LoadSpecific(modelSpecific.ID);
                    detalsSpecificGridView.EndDataUpdate();
                }
            }
        }

        //private void DeleteDetail()
        //{
        //    if (specificBS.Count != 0)
        //    {
        //        if (MessageBox.Show("Видалити запис?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //        {
        //            mtsService = Program.kernel.Get<IMtsSpecificationsService>();
        //            if (mtsService.MTSCreateDetailsDelete(((MTSCreateDetalsDTO)detalsSpecificBS.Current).ID))
        //            {
        //                int rowHandle = detalsSpecificGridView.FocusedRowHandle - 1;
        //                detalsSpecificGridView.BeginDataUpdate();
        //                LoadData();
        //                detalsSpecificGridView.EndDataUpdate();
        //                detalsSpecificGridView.FocusedRowHandle = (detalsSpecificGridView.IsValidRowHandle(rowHandle)) ? rowHandle : -1;
        //            }
        //        }
        //    }
        //}

        #region Event's

        private void showBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        private void addSpecificBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddSpecification(Utils.Operation.Add, new MTSSpecificationsDTO(), mtsAthorizationUsersDTO);
        }
        private void editSpecificBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (specificBS.Count > 0)
            {
                MTSSpecificationsDTO model = new MTSSpecificationsDTO()
                {
                    ID = ((MTSSpecificationsDTO)ItemSpecification).ID,
                    AUTHORIZATION_USERS_ID = ((MTSSpecificationsDTO)ItemSpecification).AUTHORIZATION_USERS_ID,
                    NAME = ((MTSSpecificationsDTO)ItemSpecification).NAME,
                    QUANTITY = ((MTSSpecificationsDTO)ItemSpecification).QUANTITY,
                    WEIGHT = ((MTSSpecificationsDTO)ItemSpecification).WEIGHT,
                    CREATION_DATE = ((MTSSpecificationsDTO)ItemSpecification).CREATION_DATE,
                    DRAWING = ((MTSSpecificationsDTO)ItemSpecification).DRAWING,
                    AUTHORIZATION_USERS_NAME = ((MTSSpecificationsDTO)ItemSpecification).AUTHORIZATION_USERS_NAME,
                    COMPILATION_DRAWINGS = ((MTSSpecificationsDTO)ItemSpecification).COMPILATION_DRAWINGS,
                    CODIZD = ((MTSSpecificationsDTO)ItemSpecification).CODIZD,
                    COMPILATION_NAMES = ((MTSSpecificationsDTO)ItemSpecification).COMPILATION_NAMES,
                    COMPILATION_QUANTITIES = ((MTSSpecificationsDTO)ItemSpecification).COMPILATION_QUANTITIES,
                    LAST_MODIFICATION_DATE = ((MTSSpecificationsDTO)ItemSpecification).LAST_MODIFICATION_DATE,
                    DEVICE_ID = ((MTSSpecificationsDTO)ItemSpecification).DEVICE_ID,
                    Selected = ((MTSSpecificationsDTO)ItemSpecification).Selected,
                    SET_COLOR = ((MTSSpecificationsDTO)ItemSpecification).SET_COLOR,
                    USERS_ID = ((MTSSpecificationsDTO)ItemSpecification).USERS_ID
                };
                AddSpecification(Utils.Operation.Update, (MTSSpecificationsDTO)model, mtsAthorizationUsersDTO);
            }
            else MessageBox.Show("Помилка редагування специфікації! Створіть спочатку специфікацію!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void addAllSpeficBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddSpecificationDetails(new MTSSpecificationsDTO(), Utils.Operation.Add, mtsAthorizationUsersDTO);
        }

        private void deleteSpecificBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (specificBS.Count > 0)
                DeleteSpecification();
            else MessageBox.Show("Помилка видалення специфікації! Створіть спочатку специфікацію!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        private void DeleteDetail(int detailId)
        {
            if (MessageBox.Show("Видалити деталь?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mtsService = Program.kernel.Get<IMtsSpecificationsService>();

                mtsService.MTSDetailsDelete(detailId);

                detalsSpecificGridView.PostEditor();
                detalsSpecificGridView.BeginDataUpdate();
                LoadSpecific(((MTSSpecificationsDTO)specificBS.Current).ID);
                detalsSpecificGridView.EndDataUpdate();
            }
        }

        private void DeleteBuyDetail(int detailId)
        {
            if (MessageBox.Show("Видалити деталь?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mtsService = Program.kernel.Get<IMtsSpecificationsService>();

                mtsService.MTSPurchasedProductsDelete(detailId);

                buysDetalsSpecificGridView.PostEditor();
                buysDetalsSpecificGridView.BeginDataUpdate();
                LoadBuysDetalSpecific(((MTSSpecificationsDTO)specificBS.Current).ID);
                buysDetalsSpecificGridView.EndDataUpdate();
            }
        }
        private void DeleteBuyMaterial(int materialId)
        {
            if (MessageBox.Show("Видалити матеріал?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                mtsService = Program.kernel.Get<IMtsSpecificationsService>();

                mtsService.MTSMaterialDelete(materialId);
                materialsSpecificGridView.PostEditor();
                materialsSpecificGridView.BeginDataUpdate();
                //  LoadBuysDetalSpecific(((MTSSpecificationsDTO)specificBS.Current).ID);
                LoadData();
                materialsSpecificGridView.EndDataUpdate();
            }


        }

        #endregion

        #region Event's CRUD for MTSCreateDetails

        private void addDetailBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditDetailSpecific(Utils.Operation.Add, new MTSDetailsDTO() { SPECIFICATIONS_ID = ((MTSSpecificationsDTO)specificBS.Current).ID, PROCESSING_ID = 1 });
        }

        private void editDetailBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            //if (detalsSpecificBS.Count > 0)
            //{
            //    MTSCreateDetalsDTO model = new MTSCreateDetalsDTO()
            //    {
            //        ID = ((MTSCreateDetalsDTO)ItemDetail).ID,
            //        DRAWING = ((MTSCreateDetalsDTO)ItemDetail).DRAWING,
            //        NAME = ((MTSCreateDetalsDTO)ItemDetail).NAME,
            //        QUANTITY = ((MTSCreateDetalsDTO)ItemDetail).QUANTITY,
            //        HEIGHT = ((MTSCreateDetalsDTO)ItemDetail).HEIGHT,
            //        WIDTH = ((MTSCreateDetalsDTO)ItemDetail).WIDTH,
            //        CREATEDETALSNAME = ((MTSCreateDetalsDTO)ItemDetail).CREATEDETALSNAME,
            //        GUAEGENAME = ((MTSCreateDetalsDTO)ItemDetail).GUAEGENAME,
            //        QUANTITY_OF_BLANKS = ((MTSCreateDetalsDTO)ItemDetail).QUANTITY_OF_BLANKS,
            //        DETALSPROCESSING = ((MTSCreateDetalsDTO)ItemDetail).DETALSPROCESSING,
            //        PROCCESINGNAME = ((MTSCreateDetalsDTO)ItemDetail).PROCCESINGNAME,
            //        NOMENCLATURESNAME = ((MTSCreateDetalsDTO)ItemDetail).NOMENCLATURESNAME,
            //        PROCESSING_ID = ((MTSCreateDetalsDTO)ItemDetail).PROCESSING_ID

            //    };
            //    MTSDetailsDTO modelDetail = new MTSDetailsDTO()
            //    {
            //        SPECIFICATIONS_ID = 11//((MTSSpecificationsDTO)Item).ID
            //    };

            //    AddDetailSpecific(Utils.Operation.Update, (MTSCreateDetalsDTO)model, (MTSSpecificationsDTO)specificBS.Current, (MTSDetailsDTO)modelDetail);
            //}
            //else MessageBox.Show("Помилка редагування деталі! Створіть спочатку деталь!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (detalsSpecificBS.Count > 0)
                EditDetailSpecific(Utils.Operation.Update, ((MTSDetailsDTO)detalsSpecificBS.Current));
            else
             MessageBox.Show("Помилка видалення деталі! Створіть спочатку деталі!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void deleteDetailBtn_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void addDetailBarBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditDetailSpecific(Utils.Operation.Add, new MTSDetailsDTO() { SPECIFICATIONS_ID = ((MTSSpecificationsDTO)specificBS.Current).ID, PROCESSING_ID = 1 });
        }

        private void editDetailBarBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (detalsSpecificBS.Count > 0)
                EditDetailSpecific(Utils.Operation.Update, ((MTSDetailsDTO)detalsSpecificBS.Current));
            else
                MessageBox.Show("Помилка видалення деталі! Створіть спочатку деталі!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void deleteDetailBarBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (detalsSpecificBS.Count > 0)
                DeleteDetail(((MTSDetailsDTO)detalsSpecificBS.Current).ID);
            else
                MessageBox.Show("Помилка видалення деталі! Створіть спочатку деталі!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void додатиЗаписToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditDetailSpecific(Utils.Operation.Add, new MTSDetailsDTO() { SPECIFICATIONS_ID = ((MTSSpecificationsDTO)specificBS.Current).ID, PROCESSING_ID = 1 });
        }

        private void редагуватиЗаписToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditDetailSpecific(Utils.Operation.Update, ((MTSDetailsDTO)detalsSpecificBS.Current));
        }

        private void видалитиЗаписToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (detalsSpecificBS.Count > 0)
                DeleteDetail(((MTSCreateDetalsDTO)detalsSpecificBS.Current).ID);
            else
                MessageBox.Show("Помилка видалення деталі! Створіть спочатку деталі!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region Event's CRUD for MTSPurchasedProducts

        private void addBuyDetailBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditBuyDetail(Utils.Operation.Add, new MTSPurchasedProductsDTO() { SPECIFICATIONS_ID = ((MTSSpecificationsDTO)specificBS.Current).ID });
        }

        private void editBuyDetailBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditBuyDetail(Utils.Operation.Update, ((MTSPurchasedProductsDTO)byusDetalsSpecificBS.Current));
        }

        private void deleteBuyDetailBtn_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void addBuyDetailBarBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditBuyDetail(Utils.Operation.Add, new MTSPurchasedProductsDTO() { SPECIFICATIONS_ID = ((MTSSpecificationsDTO)specificBS.Current).ID });
        }

        private void editBuyDetailBarBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditBuyDetail(Utils.Operation.Update, ((MTSPurchasedProductsDTO)byusDetalsSpecificBS.Current));
        }

        private void deleteBuyDetailBarBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (byusDetalsSpecificBS.Count > 0)
                DeleteBuyDetail(((MTSPurchasedProductsDTO)byusDetalsSpecificBS.Current).ID);
        }

        private void додатиЗаписToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditBuyDetail(Utils.Operation.Add, new MTSPurchasedProductsDTO() { SPECIFICATIONS_ID = ((MTSSpecificationsDTO)specificBS.Current).ID });
        }

        private void редагуватиЗаписToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditBuyDetail(Utils.Operation.Update, ((MTSPurchasedProductsDTO)byusDetalsSpecificBS.Current));
        }

        private void видалитиЗаписToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (byusDetalsSpecificBS.Count > 0)
                DeleteBuyDetail(((MTSPurchasedProductsDTO)byusDetalsSpecificBS.Current).ID);
        }

        #endregion

        #region Event's CRUD for MTSMaterials

        private void addMaterialBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditMaterial(Utils.Operation.Add, new MTSMaterialsDTO() { SPECIFICATIONS_ID = ((MTSSpecificationsDTO)specificBS.Current).ID });
        }

        private void editMaterialBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (materialsSpecificBS.Count > 0)
                EditMaterial(Utils.Operation.Update, ((MTSMaterialsDTO)materialsSpecificBS.Current));
            else
                MessageBox.Show("Помилка видалення матеріалу! Створіть спочатку матеріал!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void deleteMaterialBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (materialsSpecificBS.Count > 0)
                // DeleteBuyDetail(((MTSMaterialsDTO)materialsSpecificBS.Current).ID); Было раньше
                DeleteBuyMaterial(((MTSMaterialsDTO)materialsSpecificBS.Current).ID);
        }

        private void addMaterialDetailBarBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            EditMaterial(Utils.Operation.Add, new MTSMaterialsDTO() { SPECIFICATIONS_ID = ((MTSSpecificationsDTO)specificBS.Current).ID });
        }

        private void editMaterialDetailBarBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (materialsSpecificBS.Count > 0)
                EditMaterial(Utils.Operation.Update, ((MTSMaterialsDTO)materialsSpecificBS.Current));
            else
                MessageBox.Show("Помилка видалення матеріалу! Створіть спочатку матеріал!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void deleteMaterialDetailBarBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (materialsSpecificBS.Count > 0)
            //    DeleteBuyDetail(((MTSMaterialsDTO)materialsSpecificBS.Current).ID); Было раньше
                 DeleteBuyMaterial(((MTSMaterialsDTO)materialsSpecificBS.Current).ID);
        }

        private void додатиЗаписToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            EditMaterial(Utils.Operation.Add, new MTSMaterialsDTO() { SPECIFICATIONS_ID = ((MTSSpecificationsDTO)specificBS.Current).ID });
        }

        private void редагуватиЗаписToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (materialsSpecificBS.Count > 0)
                EditMaterial(Utils.Operation.Update, ((MTSMaterialsDTO)materialsSpecificBS.Current));
            else
                MessageBox.Show("Помилка видалення матеріалу! Створіть спочатку матеріал!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void видалитиЗаписToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (materialsSpecificBS.Count > 0)
                DeleteBuyMaterial(((MTSMaterialsDTO)materialsSpecificBS.Current).ID);
        }

        #endregion

        #region Report's

        private void mapRouteTechProcessBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Properties.Settings.Default.UserFolderRoute == String.Empty)
            {
                MessageBox.Show("Необхідно у налаштуваннях додати директорію для збереження звітів!", "Неможливо зформувати звіт!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (detalsSpecificBS.Count > 0)
            {
                reportService = Program.kernel.Get<IReportService>();
                LoadData();
                reportService.PrintMapRouteTechProcess(((MTSSpecificationsDTO)specificBS.Current), (List<MTSDetailsDTO>)detalsSpecificBS.DataSource, Properties.Settings.Default.UserFolderRoute);
            }
        }

        private void showSpecificInFileBtb_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }


        private void PrintSummaryMapTechProcess()
        {




        }

        #endregion

        private void MtsSpecificationOldFm_KeyUp(object sender, KeyEventArgs e)
        {
            if (!CheckEditAcces())
                return;

            if (e.KeyCode == Keys.F3)
            {
                switch (xtraTabControl1.SelectedTabPageIndex)
                {
                    case 0:
                        EditDetailSpecific(Utils.Operation.Add, new MTSDetailsDTO() { SPECIFICATIONS_ID = ((MTSSpecificationsDTO)specificBS.Current).ID, PROCESSING_ID = 1 });
                        break;
                    case 1:
                        EditBuyDetail(Utils.Operation.Add, new MTSPurchasedProductsDTO() { SPECIFICATIONS_ID = ((MTSSpecificationsDTO)specificBS.Current).ID });
                        break;
                    case 2:
                        EditMaterial(Utils.Operation.Add, new MTSMaterialsDTO() { SPECIFICATIONS_ID = ((MTSSpecificationsDTO)specificBS.Current).ID });
                        break;
                    default:
                        break;
                }
            }
        }

        private void добавитьСпецификациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSpecification(Utils.Operation.Add, new MTSSpecificationsDTO(), mtsAthorizationUsersDTO);
        }

        private void добавитьСводнуюСпецификациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSpecificationDetails(new MTSSpecificationsDTO(), Utils.Operation.Add, mtsAthorizationUsersDTO);
        }

        private void редагуватиСпецифікаціюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (specificBS.Count > 0)
            {
                MTSSpecificationsDTO model = new MTSSpecificationsDTO()
                {
                    ID = ((MTSSpecificationsDTO)ItemSpecification).ID,
                    AUTHORIZATION_USERS_ID = ((MTSSpecificationsDTO)ItemSpecification).AUTHORIZATION_USERS_ID,
                    NAME = ((MTSSpecificationsDTO)ItemSpecification).NAME,
                    QUANTITY = ((MTSSpecificationsDTO)ItemSpecification).QUANTITY,
                    WEIGHT = ((MTSSpecificationsDTO)ItemSpecification).WEIGHT,
                    CREATION_DATE = ((MTSSpecificationsDTO)ItemSpecification).CREATION_DATE,
                    DRAWING = ((MTSSpecificationsDTO)ItemSpecification).DRAWING,
                    AUTHORIZATION_USERS_NAME = ((MTSSpecificationsDTO)ItemSpecification).AUTHORIZATION_USERS_NAME,
                    COMPILATION_DRAWINGS = ((MTSSpecificationsDTO)ItemSpecification).COMPILATION_DRAWINGS,
                    CODIZD = ((MTSSpecificationsDTO)ItemSpecification).CODIZD,
                    COMPILATION_NAMES = ((MTSSpecificationsDTO)ItemSpecification).COMPILATION_NAMES,
                    COMPILATION_QUANTITIES = ((MTSSpecificationsDTO)ItemSpecification).COMPILATION_QUANTITIES,
                    LAST_MODIFICATION_DATE = ((MTSSpecificationsDTO)ItemSpecification).LAST_MODIFICATION_DATE,
                    DEVICE_ID = ((MTSSpecificationsDTO)ItemSpecification).DEVICE_ID,
                    Selected = ((MTSSpecificationsDTO)ItemSpecification).Selected,
                    SET_COLOR = ((MTSSpecificationsDTO)ItemSpecification).SET_COLOR,
                    USERS_ID = ((MTSSpecificationsDTO)ItemSpecification).USERS_ID
                };
                AddSpecification(Utils.Operation.Update, (MTSSpecificationsDTO)model, mtsAthorizationUsersDTO);
            }
            else MessageBox.Show("Помилка редагування специфікації! Створіть спочатку специфікацію!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void видалитиСпецифікаціюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (specificBS.Count > 0)
                DeleteSpecification();
            else MessageBox.Show("Ошибка удаления! Создайте спецификацию, прежде чем удалить!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void відобразитиСпецифікаціюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //reportService = Program.kernel.Get<IReportService>();
            //reportService.SpecificationProcess(((MTSSpecificationsDTO)specificBS.Current), (List<MTSDetailsDTO>)detalsSpecificBS.DataSource, (List<MTSPurchasedProductsDTO>)byusDetalsSpecificBS.DataSource, (List<MTSMaterialsDTO>)materialsSpecificBS.DataSource);
            reportService = Program.kernel.Get<IReportService>();
            LoadData();

            reportService.SpecificationProcess(((MTSSpecificationsDTO)specificBS.Current), (List<MTSDetailsDTO>)detalsSpecificBS.DataSource, (List<MTSPurchasedProductsDTO>)byusDetalsSpecificBS.DataSource, (List<MTSMaterialsDTO>)materialsSpecificBS.DataSource, Properties.Settings.Default.UserFolderRoute);

        }

        private void mapTechProcessBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Properties.Settings.Default.UserFolderRoute == String.Empty)
            {
                MessageBox.Show("Необхідно у налаштуваннях додати директорію для збереження звітів!", "Неможливо зформувати звіт!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            reportService = Program.kernel.Get<IReportService>();
            LoadData();

            reportService.MapTechProcess(((MTSSpecificationsDTO)specificBS.Current), (List<MTSDetailsDTO>)detalsSpecificBS.DataSource, false, Properties.Settings.Default.UserFolderRoute);

        }

        private void enableColorSpecificBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            SpecificationCheckMark();
        }

        #region RowMarker

        private void specificGridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            //specificGridView.BeginUpdate();
            if (e.RowHandle > -1)
            {
                MTSSpecificationsDTO item = (MTSSpecificationsDTO)specificGridView.GetRow(e.RowHandle);
                if (item != null)
                {
                    if (item.SET_COLOR == 1)
                        e.Appearance.BackColor = Color.PaleTurquoise;
                }
            }
            //specificGridView.EndUpdate();
        }

        private void detalsSpecificGridView_RowStyle(object sender, RowStyleEventArgs e)
        {

            //detalsSpecificGridView.BeginUpdate();
            bool isRowSelected = detalsSpecificGridView.IsRowSelected(e.RowHandle);

            if (e.RowHandle > -1)
            {
                MTSDetailsDTO item = (MTSDetailsDTO)detalsSpecificGridView.GetRow(e.RowHandle);
                if (item != null)
                {
                    if (item.CHANGES == 1)
                        e.Appearance.BackColor = Color.PaleTurquoise;
                    if (item.lastFocusedRov)
                        e.Appearance.BackColor = Color.FromArgb(226, 234, 253);
                }
            }

            //detalsSpecificGridView.EndUpdate();
        }

        private void buysDetalsSpecificGridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            //buysDetalsSpecificGridView.BeginUpdate();
            if (e.RowHandle > -1)
            {
                MTSPurchasedProductsDTO item = (MTSPurchasedProductsDTO)buysDetalsSpecificGridView.GetRow(e.RowHandle);
                if (item != null)
                {
                    if (item.CHANGES == 1)
                        e.Appearance.BackColor = Color.PaleTurquoise;
                    if (item.lastFocusedRov)
                        e.Appearance.BackColor = Color.FromArgb(226, 234, 253);
                }
            }
            //buysDetalsSpecificGridView.EndUpdate();
        }

        private void materialsSpecificGridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            //materialsSpecificGridView.BeginUpdate();
            if (e.RowHandle > -1)
            {
                MTSMaterialsDTO item = (MTSMaterialsDTO)materialsSpecificGridView.GetRow(e.RowHandle);
                if (item != null)
                {
                    if (item.CHANGES == 1)
                        e.Appearance.BackColor = Color.PaleTurquoise;
                    if (item.lastFocusedRov)
                        e.Appearance.BackColor = Color.FromArgb(226, 234, 253);
                }
            }
            //materialsSpecificGridView.EndUpdate();
        }

        private void detalsSpecificGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            
            if (((MTSDetailsDTO)detalsSpecificBS.Current) != null)
            {
                detalsSpecificGridView.PostEditor();
                detalsSpecificGridView.BeginDataUpdate();

                if (previousFocusedRowDetails == -1)
                {
                    ((MTSDetailsDTO)detalsSpecificBS.Current).lastFocusedRov = true;
                    previousFocusedRowDetails = detalsSpecificGridView.FocusedRowHandle;
                }
                else if (detalsSpecificGridView.FocusedRowHandle >= -1 && previousFocusedRowDetails > -1)
                {
                    MTSDetailsDTO item = (MTSDetailsDTO)detalsSpecificGridView.GetRow(previousFocusedRowDetails);
                    if (item != null)
                    {
                        item.lastFocusedRov = false;
                        previousFocusedRowDetails = detalsSpecificGridView.FocusedRowHandle;
                        ((MTSDetailsDTO)detalsSpecificBS.Current).lastFocusedRov = true;
                    }
                }
                detalsSpecificGridView.EndDataUpdate();
            }
        }

        private void buysDetalsSpecificGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
                if (((MTSPurchasedProductsDTO)byusDetalsSpecificBS.Current) != null)
                {
                    buysDetalsSpecificGridView.PostEditor();
                    buysDetalsSpecificGridView.BeginDataUpdate();

                    if (previousFocusedRowBuyDetails == -1)
                    {
                            ((MTSPurchasedProductsDTO)byusDetalsSpecificBS.Current).lastFocusedRov = true;
                            previousFocusedRowBuyDetails = buysDetalsSpecificGridView.FocusedRowHandle;                
                    }
                    else if (buysDetalsSpecificGridView.FocusedRowHandle >= -1 && previousFocusedRowBuyDetails > -1)
                    {           
                        MTSPurchasedProductsDTO item = (MTSPurchasedProductsDTO)buysDetalsSpecificGridView.GetRow(previousFocusedRowBuyDetails);
                        if (item != null)
                        {
                            item.lastFocusedRov = false;
                            previousFocusedRowBuyDetails = buysDetalsSpecificGridView.FocusedRowHandle;
                            ((MTSPurchasedProductsDTO)byusDetalsSpecificBS.Current).lastFocusedRov = true;
                        }
                    }
                    buysDetalsSpecificGridView.EndDataUpdate();
                }
        }

        private void materialsSpecificGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (((MTSMaterialsDTO)materialsSpecificBS.Current) != null)
            {
                materialsSpecificGridView.PostEditor();
                materialsSpecificGridView.BeginDataUpdate();

                if (previousFocusedRowMaterials == -1)
                {
                    ((MTSMaterialsDTO)materialsSpecificBS.Current).lastFocusedRov = true;
                    previousFocusedRowMaterials = materialsSpecificGridView.FocusedRowHandle;
                }
                else if (materialsSpecificGridView.FocusedRowHandle >= -1 && previousFocusedRowMaterials > -1)
                {
                    MTSMaterialsDTO item = (MTSMaterialsDTO)materialsSpecificGridView.GetRow(previousFocusedRowMaterials);
                    if (item != null)
                    {
                        item.lastFocusedRov = false;
                        previousFocusedRowMaterials = materialsSpecificGridView.FocusedRowHandle;
                        ((MTSMaterialsDTO)materialsSpecificBS.Current).lastFocusedRov = true;
                    }

                }
                materialsSpecificGridView.EndDataUpdate();
            }
        }



        

        #endregion

        private void disableLabelMenuBtn_Click(object sender, EventArgs e)
        {
            SpecificationCheckMark();
        }

        private void enableLabelMenuBtn_Click(object sender, EventArgs e)
        {

            SpecificationCheckMark();
        }

        private void mapTechProcessByDateBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Properties.Settings.Default.UserFolderRoute == String.Empty)
            {
                MessageBox.Show("Необхідно у налаштуваннях додати директорію для збереження звітів!", "Неможливо зформувати звіт!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            reportService = Program.kernel.Get<IReportService>();
            LoadData();
            reportService.MapTechProcess(((MTSSpecificationsDTO)specificBS.Current), (List<MTSDetailsDTO>)detalsSpecificBS.DataSource, true, Properties.Settings.Default.UserFolderRoute);
        }

        private void mapAllTechProcessBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Properties.Settings.Default.UserFolderRoute == String.Empty)
            {
                MessageBox.Show("Необхідно у налаштуваннях додати директорію для збереження звітів!", "Неможливо зформувати звіт!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MtsSpecificationQuantityOldEditFm mtsSpecificationQuantityOldEditFm = new MtsSpecificationQuantityOldEditFm())
            {
                if (mtsSpecificationQuantityOldEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int quantitySummaryItems = mtsSpecificationQuantityOldEditFm.Return();
                    reportService = Program.kernel.Get<IReportService>();
                    LoadData();
                    reportService.MapTechProcess(((MTSSpecificationsDTO)specificBS.Current), (List<MTSDetailsDTO>)detalsSpecificBS.DataSource, true, Properties.Settings.Default.UserFolderRoute, quantitySummaryItems);
                }
            }
        }

        private void MtsSpecificationOldFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void nomenclatureShowBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(new MTSNomenclaturesDTO() , true)) 
            //   DirectoryBuyDetailEditOldFm directoryBuyDetailEditOldFm = new DirectoryBuyDetailEditOldFm(model);
            {
                if (directoryBuyDetailEditOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MTSNomenclaturesDTO r = directoryBuyDetailEditOldFm.Returnl();
                }

            }
        }

        private void detailsShowBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (DirectoryDetailOldFm directoryDetailOldFm = new DirectoryDetailOldFm())
            {
                if (directoryDetailOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                }
            }
        }

        private void gostShowBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (MtsDirectoryGostOldFm mtsDirectoryGostOldFm = new MtsDirectoryGostOldFm())
            {
                if (mtsDirectoryGostOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                }
            }
        }

        private void unitsShowBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (MTSDirectoryMeasureOldFm mtsDirectoryMeasureOldFm = new MTSDirectoryMeasureOldFm())
            {
                if (mtsDirectoryMeasureOldFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {

                }
            }
        }

        private void copySpecBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (specificBS.Count > 0)
            {
                MTSSpecificationsDTO model = new MTSSpecificationsDTO()
                {
                    ID = ((MTSSpecificationsDTO)ItemSpecification).ID,
                    AUTHORIZATION_USERS_ID = ((MTSSpecificationsDTO)ItemSpecification).AUTHORIZATION_USERS_ID,
                    NAME = ((MTSSpecificationsDTO)ItemSpecification).NAME,
                    QUANTITY = ((MTSSpecificationsDTO)ItemSpecification).QUANTITY,
                    WEIGHT = ((MTSSpecificationsDTO)ItemSpecification).WEIGHT,
                    CREATION_DATE = ((MTSSpecificationsDTO)ItemSpecification).CREATION_DATE,
                    DRAWING = ((MTSSpecificationsDTO)ItemSpecification).DRAWING,
                    AUTHORIZATION_USERS_NAME = ((MTSSpecificationsDTO)ItemSpecification).AUTHORIZATION_USERS_NAME


                };
                AddSpecification(Utils.Operation.Custom, (MTSSpecificationsDTO)model, mtsAthorizationUsersDTO);
            }
            else MessageBox.Show("Помилка редагування специфікації! Створіть спочатку специфікацію!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void відобразитиКартуТехПроцесуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportService = Program.kernel.Get<IReportService>();
            LoadData();

            reportService.MapTechProcess(((MTSSpecificationsDTO)specificBS.Current), (List<MTSDetailsDTO>)detalsSpecificBS.DataSource, false, Properties.Settings.Default.UserFolderRoute);
        }

        private void відобразитиКартуТехПроцесупоДатіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reportService = Program.kernel.Get<IReportService>();
            LoadData();
            reportService.MapTechProcess(((MTSSpecificationsDTO)specificBS.Current), (List<MTSDetailsDTO>)detalsSpecificBS.DataSource, true, Properties.Settings.Default.UserFolderRoute);
        }

        private void відобразитиЗведенуКартуТехПроцесуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (MtsSpecificationQuantityOldEditFm mtsSpecificationQuantityOldEditFm = new MtsSpecificationQuantityOldEditFm())
            {
                if (mtsSpecificationQuantityOldEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int quantitySummaryItems = mtsSpecificationQuantityOldEditFm.Return();
                    reportService = Program.kernel.Get<IReportService>();
                    LoadData();
                    reportService.MapTechProcess(((MTSSpecificationsDTO)specificBS.Current), (List<MTSDetailsDTO>)detalsSpecificBS.DataSource, true, Properties.Settings.Default.UserFolderRoute,quantitySummaryItems);
                }
            }
        }

        private void відобразитиКартуМаршрутногоТехПроцесуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (detalsSpecificBS.Count > 0)
            {
                reportService = Program.kernel.Get<IReportService>();
                LoadData();
                reportService.PrintMapRouteTechProcess(((MTSSpecificationsDTO)specificBS.Current), (List<MTSDetailsDTO>)detalsSpecificBS.DataSource, Properties.Settings.Default.UserFolderRoute);
            }
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }


        private void SetGridSetting()
        {
            gridColumn1.Width = Properties.Settings.Default.GridCol1;
            gridColumn2.Width = Properties.Settings.Default.GridCol2;
            gridColumn3.Width = Properties.Settings.Default.GridCol3;
            gridColumn4.Width = Properties.Settings.Default.GridCol4;
            gridColumn5.Width = Properties.Settings.Default.GridCol5;
            gridColumn6.Width = Properties.Settings.Default.GridCol6;
            gridColumn7.Width = Properties.Settings.Default.GridCol7;
            gridColumn8.Width = Properties.Settings.Default.GridCol8;
            gridColumn9.Width = Properties.Settings.Default.GridCol9;
            gridColumn10.Width = Properties.Settings.Default.GridCol10;
            gridColumn11.Width = Properties.Settings.Default.GridCol11;
            gridColumn12.Width = Properties.Settings.Default.GridCol12;
            gridColumn13.Width = Properties.Settings.Default.GridCol13;
            gridColumn14.Width = Properties.Settings.Default.GridCol14;
            gridColumn15.Width = Properties.Settings.Default.GridCol15;
            gridColumn16.Width = Properties.Settings.Default.GridCol16;
            gridColumn17.Width = Properties.Settings.Default.GridCol17;
            gridColumn18.Width = Properties.Settings.Default.GridCol18;
            gridColumn19.Width = Properties.Settings.Default.GridCol19;
        }

        private void specificGridView_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            Properties.Settings.Default.GridCol1 = gridColumn1.Width;
            Properties.Settings.Default.GridCol2 = gridColumn2.Width;
            Properties.Settings.Default.GridCol3 = gridColumn3.Width;
            Properties.Settings.Default.GridCol4 = gridColumn4.Width;
            Properties.Settings.Default.GridCol5 = gridColumn5.Width;
            Properties.Settings.Default.GridCol6 = gridColumn6.Width;
            Properties.Settings.Default.GridCol7 = gridColumn7.Width;

            Properties.Settings.Default.Save();
        }

        private void detalsSpecificGridView_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            Properties.Settings.Default.GridCol8 = gridColumn8.Width;
            Properties.Settings.Default.GridCol9 = gridColumn9.Width;
            Properties.Settings.Default.GridCol10 = gridColumn10.Width;
            Properties.Settings.Default.GridCol11 = gridColumn11.Width;
            Properties.Settings.Default.GridCol12 = gridColumn12.Width;
            Properties.Settings.Default.GridCol13 = gridColumn13.Width;
            Properties.Settings.Default.GridCol14 = gridColumn14.Width;
            Properties.Settings.Default.GridCol15 = gridColumn15.Width;
            Properties.Settings.Default.GridCol16 = gridColumn16.Width;
            Properties.Settings.Default.GridCol17 = gridColumn17.Width;
            Properties.Settings.Default.GridCol18 = gridColumn18.Width;
            Properties.Settings.Default.GridCol19 = gridColumn19.Width;

            Properties.Settings.Default.Save();
        }

        private void buysDetalsSpecificGridView_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            Properties.Settings.Default.GridCol20 = gridColumn20.Width;
            Properties.Settings.Default.GridCol21 = gridColumn21.Width;
            Properties.Settings.Default.GridCol22 = gridColumn22.Width;
            Properties.Settings.Default.GridCol23 = gridColumn23.Width;
            Properties.Settings.Default.GridCol24 = gridColumn24.Width;
            Properties.Settings.Default.GridCol25 = gridColumn25.Width;
            Properties.Settings.Default.GridCol26 = gridColumn26.Width;

            Properties.Settings.Default.Save();
        }

        private void materialsSpecificGridView_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            Properties.Settings.Default.GridCol27 = gridColumn27.Width;
            Properties.Settings.Default.GridCol28 = gridColumn28.Width;
            Properties.Settings.Default.GridCol29 = gridColumn29.Width;
            Properties.Settings.Default.GridCol30 = gridColumn30.Width;
            Properties.Settings.Default.GridCol31 = gridColumn31.Width;
            Properties.Settings.Default.GridCol32 = gridColumn32.Width;
            Properties.Settings.Default.GridCol33 = gridColumn33.Width;

            Properties.Settings.Default.Save();
        }

        private void detalsSpecificGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                detailMenu.Show(this, new System.Drawing.Point(Cursor.Position.X-170, Cursor.Position.Y-25));
        }

        private void buysDetalsSpecificGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                buyDetailMenu.Show(this, new System.Drawing.Point(Cursor.Position.X - 170, Cursor.Position.Y - 25));
        }

        private void materialsSpecificGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                materialMenu.Show(this, new System.Drawing.Point(Cursor.Position.X - 170, Cursor.Position.Y - 25));
        }

        private void sortByMaterialBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            //SpecificationProcess(MTSSpecificationsDTO mtsSpecification, List<MTSDetailsDTO> mtsDetailsList, List<MTSPurchasedProductsDTO> mtsBuyDetailsList, List<MTSMaterialsDTO> mtsMaterialsList);
            if (Properties.Settings.Default.UserFolderRoute == String.Empty)
            {
                MessageBox.Show("Необхідно у налаштуваннях додати директорію для збереження звітів!", "Неможливо зформувати звіт!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            reportService = Program.kernel.Get<IReportService>();
            LoadData();

            reportService.SpecificationProcess(((MTSSpecificationsDTO)specificBS.Current), (List<MTSDetailsDTO>)detalsSpecificBS.DataSource, (List<MTSPurchasedProductsDTO>)byusDetalsSpecificBS.DataSource, (List<MTSMaterialsDTO>)materialsSpecificBS.DataSource, Properties.Settings.Default.UserFolderRoute, false);
        }

        private void sortBySortamnetBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            //SpecificationProcess(MTSSpecificationsDTO mtsSpecification, List<MTSDetailsDTO> mtsDetailsList, List<MTSPurchasedProductsDTO> mtsBuyDetailsList, List<MTSMaterialsDTO> mtsMaterialsList);
            if (Properties.Settings.Default.UserFolderRoute == String.Empty)
            {
                MessageBox.Show("Необхідно у налаштуваннях додати директорію для збереження звітів!", "Неможливо зформувати звіт!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            reportService = Program.kernel.Get<IReportService>();
            LoadData();

            reportService.SpecificationProcess(((MTSSpecificationsDTO)specificBS.Current), (List<MTSDetailsDTO>)detalsSpecificBS.DataSource, (List<MTSPurchasedProductsDTO>)byusDetalsSpecificBS.DataSource, (List<MTSMaterialsDTO>)materialsSpecificBS.DataSource, Properties.Settings.Default.UserFolderRoute, true);
        }

        private void detalsSpecificGrid_EditorKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
                e.Handled = false;
            }
        }

        private void settingsBtn_ItemClick(object sender, ItemClickEventArgs e)
        {
            UserSettingsFm userSettingsFm = new UserSettingsFm();
            userSettingsFm.ShowDialog();
        }
    }
}