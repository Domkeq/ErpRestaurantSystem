
namespace ErpRestaurantSystem
{
    partial class AccountingIngredientsForm
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
            this.dgvIngredientCosts = new System.Windows.Forms.DataGridView();
            this.txtDishFilter = new System.Windows.Forms.TextBox();
            this.chkOnlyAvailable = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientCosts)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvIngredientCosts
            // 
            this.dgvIngredientCosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredientCosts.Location = new System.Drawing.Point(21, 25);
            this.dgvIngredientCosts.Name = "dgvIngredientCosts";
            this.dgvIngredientCosts.Size = new System.Drawing.Size(577, 257);
            this.dgvIngredientCosts.TabIndex = 0;
            // 
            // txtDishFilter
            // 
            this.txtDishFilter.Location = new System.Drawing.Point(6, 36);
            this.txtDishFilter.Name = "txtDishFilter";
            this.txtDishFilter.Size = new System.Drawing.Size(141, 20);
            this.txtDishFilter.TabIndex = 11;
            this.txtDishFilter.TextChanged += new System.EventHandler(this.TxtDishFilter_TextChanged);
            // 
            // chkOnlyAvailable
            // 
            this.chkOnlyAvailable.AutoSize = true;
            this.chkOnlyAvailable.Checked = true;
            this.chkOnlyAvailable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyAvailable.Location = new System.Drawing.Point(6, 28);
            this.chkOnlyAvailable.Name = "chkOnlyAvailable";
            this.chkOnlyAvailable.Size = new System.Drawing.Size(141, 30);
            this.chkOnlyAvailable.TabIndex = 13;
            this.chkOnlyAvailable.Text = "Просмотреть товары, \r\nкоторых нет в наличии";
            this.chkOnlyAvailable.UseVisualStyleBackColor = true;
            this.chkOnlyAvailable.CheckedChanged += new System.EventHandler(this.ChkOnlyAvailable_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExportToExcel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDishFilter);
            this.groupBox1.Location = new System.Drawing.Point(613, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 154);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Управление данными";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(6, 80);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(141, 40);
            this.btnExportToExcel.TabIndex = 12;
            this.btnExportToExcel.Text = "Экспорт в Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Поиск:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkOnlyAvailable);
            this.groupBox2.Location = new System.Drawing.Point(613, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 75);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Фильтрация";
            // 
            // AccountingIngredientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvIngredientCosts);
            this.Name = "AccountingIngredientsForm";
            this.Text = "Затраты на ингредиенты";
            this.Load += new System.EventHandler(this.AccountingIngredientsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredientCosts)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIngredientCosts;
        private System.Windows.Forms.TextBox txtDishFilter;
        private System.Windows.Forms.CheckBox chkOnlyAvailable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}