namespace MTS.GUI.MTS
{
    partial class MTSDirectoryMeasureOldFm
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
            this.measureGrid = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.delToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.measureGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.measureGrid)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.measureGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // measureGrid
            // 
            this.measureGrid.ContextMenuStrip = this.contextMenuStrip;
            this.measureGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measureGrid.Location = new System.Drawing.Point(0, 0);
            this.measureGrid.MainView = this.measureGridView;
            this.measureGrid.Name = "measureGrid";
            this.measureGrid.Size = new System.Drawing.Size(716, 447);
            this.measureGrid.TabIndex = 0;
            this.measureGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.measureGridView});
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenu,
            this.EditToolStripMenu,
            this.delToolStripMenu});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(135, 70);
            // 
            // AddToolStripMenu
            // 
            this.AddToolStripMenu.Name = "AddToolStripMenu";
            this.AddToolStripMenu.Size = new System.Drawing.Size(134, 22);
            this.AddToolStripMenu.Text = "Додати";
            this.AddToolStripMenu.Click += new System.EventHandler(this.AddToolStripMenu_Click);
            // 
            // EditToolStripMenu
            // 
            this.EditToolStripMenu.Name = "EditToolStripMenu";
            this.EditToolStripMenu.Size = new System.Drawing.Size(134, 22);
            this.EditToolStripMenu.Text = "Редагувати";
            this.EditToolStripMenu.Click += new System.EventHandler(this.EditToolStripMenu_Click);
            // 
            // delToolStripMenu
            // 
            this.delToolStripMenu.Name = "delToolStripMenu";
            this.delToolStripMenu.Size = new System.Drawing.Size(134, 22);
            this.delToolStripMenu.Text = "Видалити";
            this.delToolStripMenu.Click += new System.EventHandler(this.delToolStripMenu_Click);
            // 
            // measureGridView
            // 
            this.measureGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.measureGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.measureGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID,
            this.NAME});
            this.measureGridView.GridControl = this.measureGrid;
            this.measureGridView.Name = "measureGridView";
            this.measureGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.measureGridView.OptionsView.ShowAutoFilterRow = true;
            this.measureGridView.OptionsView.ShowGroupPanel = false;
            // 
            // ID
            // 
            this.ID.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ID.AppearanceCell.Options.UseFont = true;
            this.ID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ID.AppearanceHeader.Options.UseFont = true;
            this.ID.AppearanceHeader.Options.UseTextOptions = true;
            this.ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ID.Caption = "№";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 0;
            this.ID.Width = 47;
            // 
            // NAME
            // 
            this.NAME.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NAME.AppearanceCell.Options.UseFont = true;
            this.NAME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NAME.AppearanceHeader.Options.UseFont = true;
            this.NAME.AppearanceHeader.Options.UseTextOptions = true;
            this.NAME.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NAME.Caption = "Найменування";
            this.NAME.FieldName = "NAME";
            this.NAME.Name = "NAME";
            this.NAME.OptionsColumn.AllowEdit = false;
            this.NAME.OptionsColumn.AllowFocus = false;
            this.NAME.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.NAME.Visible = true;
            this.NAME.VisibleIndex = 1;
            this.NAME.Width = 442;
            // 
            // MTSDirectoryMeasureOldFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 447);
            this.Controls.Add(this.measureGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MTSDirectoryMeasureOldFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Довідник одиниці вимірювання";
            ((System.ComponentModel.ISupportInitialize)(this.measureGrid)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.measureGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl measureGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView measureGridView;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn NAME;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenu;
    }
}