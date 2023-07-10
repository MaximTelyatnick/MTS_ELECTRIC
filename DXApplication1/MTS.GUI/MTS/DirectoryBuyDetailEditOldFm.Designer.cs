namespace MTS.GUI.MTS
{
    partial class DirectoryBuyDetailEditOldFm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.nomenclatureGroupsGrid = new DevExpress.XtraGrid.GridControl();
            this.groupContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addGroupItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editGroupItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGroupItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nomenclatureGroupsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nomenGroupNumberCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nomenGroupNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoForGroupNameEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.nomenGroupRatOfWasteCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nomenclatureGrid = new DevExpress.XtraGrid.GridControl();
            this.nomenclatureMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNomenclatureItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editNomenclatureItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteNomenclatureItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nomenclatureGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.nomenNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoNameEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.nomenGuageCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nomenGostCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nomenNoteCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nomenWeightCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nomenPriceCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.nomenMeasureCol = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureGroupsGrid)).BeginInit();
            this.groupContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureGroupsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoForGroupNameEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureGrid)).BeginInit();
            this.nomenclatureMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoNameEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.splitContainer1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1395, 648);
            this.panelControl1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.nomenclatureGroupsGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.nomenclatureGrid);
            this.splitContainer1.Size = new System.Drawing.Size(1391, 644);
            this.splitContainer1.SplitterDistance = 515;
            this.splitContainer1.TabIndex = 0;
            // 
            // nomenclatureGroupsGrid
            // 
            this.nomenclatureGroupsGrid.ContextMenuStrip = this.groupContextMenu;
            this.nomenclatureGroupsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode2.RelationName = "Level1";
            this.nomenclatureGroupsGrid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.nomenclatureGroupsGrid.Location = new System.Drawing.Point(0, 0);
            this.nomenclatureGroupsGrid.MainView = this.nomenclatureGroupsGridView;
            this.nomenclatureGroupsGrid.Name = "nomenclatureGroupsGrid";
            this.nomenclatureGroupsGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoForGroupNameEdit});
            this.nomenclatureGroupsGrid.Size = new System.Drawing.Size(515, 644);
            this.nomenclatureGroupsGrid.TabIndex = 0;
            this.nomenclatureGroupsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.nomenclatureGroupsGridView});
            // 
            // groupContextMenu
            // 
            this.groupContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addGroupItem,
            this.editGroupItem,
            this.deleteGroupItem});
            this.groupContextMenu.Name = "groupContextMenu";
            this.groupContextMenu.Size = new System.Drawing.Size(169, 70);
            // 
            // addGroupItem
            // 
            this.addGroupItem.Name = "addGroupItem";
            this.addGroupItem.Size = new System.Drawing.Size(168, 22);
            this.addGroupItem.Text = "Додати групу";
            this.addGroupItem.Click += new System.EventHandler(this.addGroupItem_Click);
            // 
            // editGroupItem
            // 
            this.editGroupItem.Name = "editGroupItem";
            this.editGroupItem.Size = new System.Drawing.Size(168, 22);
            this.editGroupItem.Text = "Редагувати групу";
            this.editGroupItem.Click += new System.EventHandler(this.editGroupItem_Click);
            // 
            // deleteGroupItem
            // 
            this.deleteGroupItem.Name = "deleteGroupItem";
            this.deleteGroupItem.Size = new System.Drawing.Size(168, 22);
            this.deleteGroupItem.Text = "Видалити групу";
            this.deleteGroupItem.Click += new System.EventHandler(this.deleteGroupItem_Click);
            // 
            // nomenclatureGroupsGridView
            // 
            this.nomenclatureGroupsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.nomenGroupNumberCol,
            this.nomenGroupNameCol,
            this.nomenGroupRatOfWasteCol});
            this.nomenclatureGroupsGridView.GridControl = this.nomenclatureGroupsGrid;
            this.nomenclatureGroupsGridView.Name = "nomenclatureGroupsGridView";
            this.nomenclatureGroupsGridView.OptionsView.RowAutoHeight = true;
            this.nomenclatureGroupsGridView.OptionsView.ShowAutoFilterRow = true;
            this.nomenclatureGroupsGridView.OptionsView.ShowGroupPanel = false;
            this.nomenclatureGroupsGridView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.nomenclatureGroupsGridView_FocusedRowChanged);
            // 
            // nomenGroupNumberCol
            // 
            this.nomenGroupNumberCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenGroupNumberCol.AppearanceCell.Options.UseFont = true;
            this.nomenGroupNumberCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenGroupNumberCol.AppearanceHeader.Options.UseFont = true;
            this.nomenGroupNumberCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nomenGroupNumberCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nomenGroupNumberCol.Caption = "№";
            this.nomenGroupNumberCol.FieldName = "ID";
            this.nomenGroupNumberCol.Name = "nomenGroupNumberCol";
            this.nomenGroupNumberCol.OptionsColumn.AllowEdit = false;
            this.nomenGroupNumberCol.OptionsColumn.AllowFocus = false;
            this.nomenGroupNumberCol.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.nomenGroupNumberCol.OptionsColumn.AllowMove = false;
            this.nomenGroupNumberCol.OptionsColumn.AllowSize = false;
            this.nomenGroupNumberCol.Visible = true;
            this.nomenGroupNumberCol.VisibleIndex = 0;
            this.nomenGroupNumberCol.Width = 38;
            // 
            // nomenGroupNameCol
            // 
            this.nomenGroupNameCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenGroupNameCol.AppearanceCell.Options.UseFont = true;
            this.nomenGroupNameCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenGroupNameCol.AppearanceHeader.Options.UseFont = true;
            this.nomenGroupNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nomenGroupNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nomenGroupNameCol.Caption = "Найменування";
            this.nomenGroupNameCol.ColumnEdit = this.repositoryItemMemoForGroupNameEdit;
            this.nomenGroupNameCol.FieldName = "NAME";
            this.nomenGroupNameCol.Name = "nomenGroupNameCol";
            this.nomenGroupNameCol.OptionsColumn.AllowEdit = false;
            this.nomenGroupNameCol.OptionsColumn.AllowFocus = false;
            this.nomenGroupNameCol.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.nomenGroupNameCol.OptionsColumn.AllowMove = false;
            this.nomenGroupNameCol.OptionsColumn.AllowSize = false;
            this.nomenGroupNameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.nomenGroupNameCol.Visible = true;
            this.nomenGroupNameCol.VisibleIndex = 1;
            this.nomenGroupNameCol.Width = 336;
            // 
            // repositoryItemMemoForGroupNameEdit
            // 
            this.repositoryItemMemoForGroupNameEdit.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoForGroupNameEdit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoForGroupNameEdit.Name = "repositoryItemMemoForGroupNameEdit";
            // 
            // nomenGroupRatOfWasteCol
            // 
            this.nomenGroupRatOfWasteCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenGroupRatOfWasteCol.AppearanceCell.Options.UseFont = true;
            this.nomenGroupRatOfWasteCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenGroupRatOfWasteCol.AppearanceHeader.Options.UseFont = true;
            this.nomenGroupRatOfWasteCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nomenGroupRatOfWasteCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nomenGroupRatOfWasteCol.Caption = "Коєф.відходів";
            this.nomenGroupRatOfWasteCol.FieldName = "RATIO_OF_WASTE";
            this.nomenGroupRatOfWasteCol.Name = "nomenGroupRatOfWasteCol";
            this.nomenGroupRatOfWasteCol.OptionsColumn.AllowEdit = false;
            this.nomenGroupRatOfWasteCol.OptionsColumn.AllowFocus = false;
            this.nomenGroupRatOfWasteCol.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.nomenGroupRatOfWasteCol.OptionsColumn.AllowMove = false;
            this.nomenGroupRatOfWasteCol.OptionsColumn.AllowSize = false;
            this.nomenGroupRatOfWasteCol.Visible = true;
            this.nomenGroupRatOfWasteCol.VisibleIndex = 2;
            this.nomenGroupRatOfWasteCol.Width = 103;
            // 
            // nomenclatureGrid
            // 
            this.nomenclatureGrid.ContextMenuStrip = this.nomenclatureMenuStrip;
            this.nomenclatureGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nomenclatureGrid.Location = new System.Drawing.Point(0, 0);
            this.nomenclatureGrid.MainView = this.nomenclatureGridView;
            this.nomenclatureGrid.Name = "nomenclatureGrid";
            this.nomenclatureGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoNameEdit});
            this.nomenclatureGrid.Size = new System.Drawing.Size(872, 644);
            this.nomenclatureGrid.TabIndex = 0;
            this.nomenclatureGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.nomenclatureGridView});
            // 
            // nomenclatureMenuStrip
            // 
            this.nomenclatureMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNomenclatureItem,
            this.editNomenclatureItem,
            this.deleteNomenclatureItem});
            this.nomenclatureMenuStrip.Name = "nomenclatureMenuStrip";
            this.nomenclatureMenuStrip.Size = new System.Drawing.Size(217, 70);
            // 
            // addNomenclatureItem
            // 
            this.addNomenclatureItem.Name = "addNomenclatureItem";
            this.addNomenclatureItem.Size = new System.Drawing.Size(216, 22);
            this.addNomenclatureItem.Text = "Додати номенклатуру";
            this.addNomenclatureItem.Click += new System.EventHandler(this.addNomenclatureItem_Click);
            // 
            // editNomenclatureItem
            // 
            this.editNomenclatureItem.Name = "editNomenclatureItem";
            this.editNomenclatureItem.Size = new System.Drawing.Size(216, 22);
            this.editNomenclatureItem.Text = "Редагувати номенклатуру";
            this.editNomenclatureItem.Click += new System.EventHandler(this.editNomenclatureItem_Click);
            // 
            // deleteNomenclatureItem
            // 
            this.deleteNomenclatureItem.Name = "deleteNomenclatureItem";
            this.deleteNomenclatureItem.Size = new System.Drawing.Size(216, 22);
            this.deleteNomenclatureItem.Text = "Видалити номенклатуру";
            this.deleteNomenclatureItem.Click += new System.EventHandler(this.deleteNomenclatureItem_Click);
            // 
            // nomenclatureGridView
            // 
            this.nomenclatureGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.nomenNameCol,
            this.nomenGuageCol,
            this.nomenGostCol,
            this.nomenNoteCol,
            this.nomenWeightCol,
            this.nomenPriceCol,
            this.nomenMeasureCol});
            this.nomenclatureGridView.GridControl = this.nomenclatureGrid;
            this.nomenclatureGridView.Name = "nomenclatureGridView";
            this.nomenclatureGridView.OptionsView.RowAutoHeight = true;
            this.nomenclatureGridView.OptionsView.ShowAutoFilterRow = true;
            this.nomenclatureGridView.OptionsView.ShowGroupPanel = false;
            this.nomenclatureGridView.DoubleClick += new System.EventHandler(this.nomenclatureGridView_DoubleClick);
            // 
            // nomenNameCol
            // 
            this.nomenNameCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenNameCol.AppearanceCell.Options.UseFont = true;
            this.nomenNameCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenNameCol.AppearanceHeader.Options.UseFont = true;
            this.nomenNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nomenNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nomenNameCol.Caption = "Найменування";
            this.nomenNameCol.ColumnEdit = this.repositoryItemMemoNameEdit;
            this.nomenNameCol.FieldName = "NAME";
            this.nomenNameCol.Name = "nomenNameCol";
            this.nomenNameCol.OptionsColumn.AllowEdit = false;
            this.nomenNameCol.OptionsColumn.AllowFocus = false;
            this.nomenNameCol.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.nomenNameCol.OptionsColumn.AllowMove = false;
            this.nomenNameCol.OptionsColumn.AllowSize = false;
            this.nomenNameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.nomenNameCol.Visible = true;
            this.nomenNameCol.VisibleIndex = 0;
            this.nomenNameCol.Width = 245;
            // 
            // repositoryItemMemoNameEdit
            // 
            this.repositoryItemMemoNameEdit.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoNameEdit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoNameEdit.Name = "repositoryItemMemoNameEdit";
            // 
            // nomenGuageCol
            // 
            this.nomenGuageCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenGuageCol.AppearanceCell.Options.UseFont = true;
            this.nomenGuageCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenGuageCol.AppearanceHeader.Options.UseFont = true;
            this.nomenGuageCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nomenGuageCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nomenGuageCol.Caption = "Сортамент";
            this.nomenGuageCol.FieldName = "GUAGE";
            this.nomenGuageCol.Name = "nomenGuageCol";
            this.nomenGuageCol.OptionsColumn.AllowEdit = false;
            this.nomenGuageCol.OptionsColumn.AllowFocus = false;
            this.nomenGuageCol.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.nomenGuageCol.OptionsColumn.AllowMove = false;
            this.nomenGuageCol.OptionsColumn.AllowSize = false;
            this.nomenGuageCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.nomenGuageCol.Visible = true;
            this.nomenGuageCol.VisibleIndex = 1;
            this.nomenGuageCol.Width = 118;
            // 
            // nomenGostCol
            // 
            this.nomenGostCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenGostCol.AppearanceCell.Options.UseFont = true;
            this.nomenGostCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenGostCol.AppearanceHeader.Options.UseFont = true;
            this.nomenGostCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nomenGostCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nomenGostCol.Caption = "ГОСТ, ТУ";
            this.nomenGostCol.FieldName = "GOST";
            this.nomenGostCol.Name = "nomenGostCol";
            this.nomenGostCol.OptionsColumn.AllowEdit = false;
            this.nomenGostCol.OptionsColumn.AllowFocus = false;
            this.nomenGostCol.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.nomenGostCol.OptionsColumn.AllowMove = false;
            this.nomenGostCol.OptionsColumn.AllowSize = false;
            this.nomenGostCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.nomenGostCol.Visible = true;
            this.nomenGostCol.VisibleIndex = 2;
            this.nomenGostCol.Width = 154;
            // 
            // nomenNoteCol
            // 
            this.nomenNoteCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenNoteCol.AppearanceCell.Options.UseFont = true;
            this.nomenNoteCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenNoteCol.AppearanceHeader.Options.UseFont = true;
            this.nomenNoteCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nomenNoteCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nomenNoteCol.Caption = "Примітки";
            this.nomenNoteCol.FieldName = "NOTE";
            this.nomenNoteCol.Name = "nomenNoteCol";
            this.nomenNoteCol.OptionsColumn.AllowEdit = false;
            this.nomenNoteCol.OptionsColumn.AllowFocus = false;
            this.nomenNoteCol.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.nomenNoteCol.OptionsColumn.AllowMove = false;
            this.nomenNoteCol.OptionsColumn.AllowSize = false;
            this.nomenNoteCol.Visible = true;
            this.nomenNoteCol.VisibleIndex = 3;
            this.nomenNoteCol.Width = 128;
            // 
            // nomenWeightCol
            // 
            this.nomenWeightCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenWeightCol.AppearanceCell.Options.UseFont = true;
            this.nomenWeightCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenWeightCol.AppearanceHeader.Options.UseFont = true;
            this.nomenWeightCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nomenWeightCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nomenWeightCol.Caption = "Вага";
            this.nomenWeightCol.FieldName = "WEIGHT";
            this.nomenWeightCol.Name = "nomenWeightCol";
            this.nomenWeightCol.OptionsColumn.AllowEdit = false;
            this.nomenWeightCol.OptionsColumn.AllowFocus = false;
            this.nomenWeightCol.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.nomenWeightCol.OptionsColumn.AllowMove = false;
            this.nomenWeightCol.OptionsColumn.AllowSize = false;
            this.nomenWeightCol.Visible = true;
            this.nomenWeightCol.VisibleIndex = 4;
            // 
            // nomenPriceCol
            // 
            this.nomenPriceCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenPriceCol.AppearanceCell.Options.UseFont = true;
            this.nomenPriceCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenPriceCol.AppearanceHeader.Options.UseFont = true;
            this.nomenPriceCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nomenPriceCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nomenPriceCol.Caption = "Ціна";
            this.nomenPriceCol.FieldName = "PRICE";
            this.nomenPriceCol.Name = "nomenPriceCol";
            this.nomenPriceCol.OptionsColumn.AllowEdit = false;
            this.nomenPriceCol.OptionsColumn.AllowFocus = false;
            this.nomenPriceCol.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.nomenPriceCol.OptionsColumn.AllowMove = false;
            this.nomenPriceCol.OptionsColumn.AllowSize = false;
            this.nomenPriceCol.Visible = true;
            this.nomenPriceCol.VisibleIndex = 5;
            this.nomenPriceCol.Width = 45;
            // 
            // nomenMeasureCol
            // 
            this.nomenMeasureCol.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenMeasureCol.AppearanceCell.Options.UseFont = true;
            this.nomenMeasureCol.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nomenMeasureCol.AppearanceHeader.Options.UseFont = true;
            this.nomenMeasureCol.AppearanceHeader.Options.UseTextOptions = true;
            this.nomenMeasureCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.nomenMeasureCol.Caption = "Од.вимір.";
            this.nomenMeasureCol.FieldName = "MEASURE";
            this.nomenMeasureCol.Name = "nomenMeasureCol";
            this.nomenMeasureCol.OptionsColumn.AllowEdit = false;
            this.nomenMeasureCol.OptionsColumn.AllowFocus = false;
            this.nomenMeasureCol.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.nomenMeasureCol.OptionsColumn.AllowMove = false;
            this.nomenMeasureCol.OptionsColumn.AllowSize = false;
            this.nomenMeasureCol.Visible = true;
            this.nomenMeasureCol.VisibleIndex = 6;
            this.nomenMeasureCol.Width = 89;
            // 
            // DirectoryBuyDetailEditOldFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 648);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DirectoryBuyDetailEditOldFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Довідник номенклатур";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DirectoryBuyDetailEditOldFm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureGroupsGrid)).EndInit();
            this.groupContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureGroupsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoForGroupNameEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureGrid)).EndInit();
            this.nomenclatureMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nomenclatureGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoNameEdit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl nomenclatureGroupsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView nomenclatureGroupsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn nomenGroupNumberCol;
        private DevExpress.XtraGrid.Columns.GridColumn nomenGroupNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn nomenGroupRatOfWasteCol;
        private DevExpress.XtraGrid.GridControl nomenclatureGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView nomenclatureGridView;
        private DevExpress.XtraGrid.Columns.GridColumn nomenNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn nomenGuageCol;
        private DevExpress.XtraGrid.Columns.GridColumn nomenGostCol;
        private DevExpress.XtraGrid.Columns.GridColumn nomenNoteCol;
        private DevExpress.XtraGrid.Columns.GridColumn nomenWeightCol;
        private DevExpress.XtraGrid.Columns.GridColumn nomenPriceCol;
        private DevExpress.XtraGrid.Columns.GridColumn nomenMeasureCol;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoForGroupNameEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoNameEdit;
        private System.Windows.Forms.ContextMenuStrip groupContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addGroupItem;
        private System.Windows.Forms.ToolStripMenuItem editGroupItem;
        private System.Windows.Forms.ToolStripMenuItem deleteGroupItem;
        private System.Windows.Forms.ContextMenuStrip nomenclatureMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem addNomenclatureItem;
        private System.Windows.Forms.ToolStripMenuItem editNomenclatureItem;
        private System.Windows.Forms.ToolStripMenuItem deleteNomenclatureItem;
    }
}