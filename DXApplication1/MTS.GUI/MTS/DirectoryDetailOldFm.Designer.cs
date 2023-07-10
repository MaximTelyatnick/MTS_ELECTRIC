namespace MTS.GUI.MTS
{
    partial class DirectoryDetailOldFm
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
            this.detailGrid = new DevExpress.XtraGrid.GridControl();
            this.detailGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DRAWING = new DevExpress.XtraGrid.Columns.GridColumn();
            this.detalContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.delToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailGridView)).BeginInit();
            this.detalContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // detailGrid
            // 
            this.detailGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailGrid.Location = new System.Drawing.Point(0, 0);
            this.detailGrid.MainView = this.detailGridView;
            this.detailGrid.Name = "detailGrid";
            this.detailGrid.Size = new System.Drawing.Size(716, 447);
            this.detailGrid.TabIndex = 1;
            this.detailGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.detailGridView});
            // 
            // detailGridView
            // 
            this.detailGridView.Appearance.FilterPanel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailGridView.Appearance.FilterPanel.Options.UseFont = true;
            this.detailGridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.detailGridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.detailGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NAME,
            this.DRAWING});
            this.detailGridView.GridControl = this.detailGrid;
            this.detailGridView.Name = "detailGridView";
            this.detailGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.detailGridView.OptionsFind.AlwaysVisible = true;
            this.detailGridView.OptionsView.ShowAutoFilterRow = true;
            this.detailGridView.OptionsView.ShowGroupPanel = false;
            // 
            // NAME
            // 
            this.NAME.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NAME.AppearanceCell.Options.UseFont = true;
            this.NAME.AppearanceCell.Options.UseTextOptions = true;
            this.NAME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NAME.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NAME.AppearanceHeader.Options.UseFont = true;
            this.NAME.AppearanceHeader.Options.UseTextOptions = true;
            this.NAME.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NAME.Caption = "Найменування";
            this.NAME.FieldName = "NAME";
            this.NAME.Name = "NAME";
            this.NAME.OptionsColumn.AllowEdit = false;
            this.NAME.OptionsColumn.AllowFocus = false;
            this.NAME.Visible = true;
            this.NAME.VisibleIndex = 0;
            // 
            // DRAWING
            // 
            this.DRAWING.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DRAWING.AppearanceCell.Options.UseFont = true;
            this.DRAWING.AppearanceCell.Options.UseTextOptions = true;
            this.DRAWING.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DRAWING.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DRAWING.AppearanceHeader.Options.UseFont = true;
            this.DRAWING.AppearanceHeader.Options.UseTextOptions = true;
            this.DRAWING.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DRAWING.Caption = "Креслення";
            this.DRAWING.FieldName = "DRAWING";
            this.DRAWING.Name = "DRAWING";
            this.DRAWING.OptionsColumn.AllowEdit = false;
            this.DRAWING.OptionsColumn.AllowFocus = false;
            this.DRAWING.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.DRAWING.Visible = true;
            this.DRAWING.VisibleIndex = 1;
            // 
            // detalContextMenuStrip
            // 
            this.detalContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.delToolStripMenuItem});
            this.detalContextMenuStrip.Name = "detalContextMenuStrip";
            this.detalContextMenuStrip.Size = new System.Drawing.Size(119, 26);
            // 
            // delToolStripMenuItem
            // 
            this.delToolStripMenuItem.Name = "delToolStripMenuItem";
            this.delToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.delToolStripMenuItem.Text = "Удалить";
            this.delToolStripMenuItem.Click += new System.EventHandler(this.delToolStripMenuItem_Click);
            // 
            // DirectoryDetailOldFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 447);
            this.ContextMenuStrip = this.detalContextMenuStrip;
            this.Controls.Add(this.detailGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DirectoryDetailOldFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Довідник деталів";
            ((System.ComponentModel.ISupportInitialize)(this.detailGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailGridView)).EndInit();
            this.detalContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl detailGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView detailGridView;
        private DevExpress.XtraGrid.Columns.GridColumn NAME;
        private DevExpress.XtraGrid.Columns.GridColumn DRAWING;
        private System.Windows.Forms.ContextMenuStrip detalContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem delToolStripMenuItem;
    }
}