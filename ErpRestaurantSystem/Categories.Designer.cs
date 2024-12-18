
namespace ErpRestaurantSystem
{
    partial class Categories
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Categories));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addCategory = new System.Windows.Forms.ToolStripButton();
            this.renameCategory = new System.Windows.Forms.ToolStripButton();
            this.deleteCategory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.updateCategoryList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.categoryUpper = new System.Windows.Forms.ToolStripButton();
            this.categoryDowner = new System.Windows.Forms.ToolStripButton();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordinem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listCategories = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCategory,
            this.renameCategory,
            this.deleteCategory,
            this.toolStripSeparator1,
            this.updateCategoryList,
            this.toolStripSeparator2,
            this.categoryUpper,
            this.categoryDowner});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 26);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addCategory
            // 
            this.addCategory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addCategory.Image = ((System.Drawing.Image)(resources.GetObject("addCategory.Image")));
            this.addCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addCategory.Name = "addCategory";
            this.addCategory.Size = new System.Drawing.Size(63, 23);
            this.addCategory.Text = "&Добавить";
            this.addCategory.Click += new System.EventHandler(this.addCategory_Click);
            // 
            // renameCategory
            // 
            this.renameCategory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.renameCategory.Image = ((System.Drawing.Image)(resources.GetObject("renameCategory.Image")));
            this.renameCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameCategory.Name = "renameCategory";
            this.renameCategory.Size = new System.Drawing.Size(98, 23);
            this.renameCategory.Text = "&Переименовать";
            this.renameCategory.Click += new System.EventHandler(this.renameCategory_Click);
            // 
            // deleteCategory
            // 
            this.deleteCategory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteCategory.Image = ((System.Drawing.Image)(resources.GetObject("deleteCategory.Image")));
            this.deleteCategory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteCategory.Name = "deleteCategory";
            this.deleteCategory.Size = new System.Drawing.Size(55, 23);
            this.deleteCategory.Text = "&Удалить";
            this.deleteCategory.Click += new System.EventHandler(this.deleteCategory_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // updateCategoryList
            // 
            this.updateCategoryList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.updateCategoryList.Image = ((System.Drawing.Image)(resources.GetObject("updateCategoryList.Image")));
            this.updateCategoryList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateCategoryList.Name = "updateCategoryList";
            this.updateCategoryList.Size = new System.Drawing.Size(65, 23);
            this.updateCategoryList.Text = "&Обновить";
            this.updateCategoryList.Click += new System.EventHandler(this.updateCategoryList_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // categoryUpper
            // 
            this.categoryUpper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.categoryUpper.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.categoryUpper.Image = ((System.Drawing.Image)(resources.GetObject("categoryUpper.Image")));
            this.categoryUpper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.categoryUpper.Name = "categoryUpper";
            this.categoryUpper.Size = new System.Drawing.Size(23, 23);
            this.categoryUpper.Text = "&↑";
            this.categoryUpper.Click += new System.EventHandler(this.categoryUpper_Click);
            // 
            // categoryDowner
            // 
            this.categoryDowner.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.categoryDowner.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.categoryDowner.Image = ((System.Drawing.Image)(resources.GetObject("categoryDowner.Image")));
            this.categoryDowner.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.categoryDowner.Name = "categoryDowner";
            this.categoryDowner.Size = new System.Drawing.Size(23, 23);
            this.categoryDowner.Text = "&↓";
            this.categoryDowner.Click += new System.EventHandler(this.categoryDowner_Click);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Название";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // ordinem
            // 
            this.ordinem.HeaderText = "№";
            this.ordinem.Name = "ordinem";
            this.ordinem.ReadOnly = true;
            this.ordinem.Visible = false;
            // 
            // listCategories
            // 
            this.listCategories.AllowUserToAddRows = false;
            this.listCategories.AllowUserToDeleteRows = false;
            this.listCategories.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.listCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ordinem,
            this.name,
            this.id});
            this.listCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listCategories.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listCategories.Location = new System.Drawing.Point(0, 0);
            this.listCategories.Margin = new System.Windows.Forms.Padding(2);
            this.listCategories.MultiSelect = false;
            this.listCategories.Name = "listCategories";
            this.listCategories.ReadOnly = true;
            this.listCategories.RowHeadersVisible = false;
            this.listCategories.RowTemplate.Height = 24;
            this.listCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listCategories.Size = new System.Drawing.Size(800, 450);
            this.listCategories.TabIndex = 3;
            // 
            // Categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listCategories);
            this.Name = "Categories";
            this.Text = "Категории блюд";
            this.Load += new System.EventHandler(this.Categories_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listCategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addCategory;
        private System.Windows.Forms.ToolStripButton renameCategory;
        private System.Windows.Forms.ToolStripButton deleteCategory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton updateCategoryList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton categoryUpper;
        private System.Windows.Forms.ToolStripButton categoryDowner;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordinem;
        private System.Windows.Forms.DataGridView listCategories;
    }
}