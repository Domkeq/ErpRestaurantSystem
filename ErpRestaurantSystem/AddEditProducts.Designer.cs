
namespace ErpRestaurantSystem
{
    partial class AddEditProducts
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
            this.addCategoryButton = new System.Windows.Forms.Button();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridView = new System.Windows.Forms.DataGridView();
            this.categoryBox = new System.Windows.Forms.GroupBox();
            this.removeCategoryButton = new System.Windows.Forms.Button();
            this.componentBox = new System.Windows.Forms.GroupBox();
            this.recipesComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.recipesCountTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.recipesDataGridView = new System.Windows.Forms.DataGridView();
            this.id_component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.availableCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataGridView)).BeginInit();
            this.categoryBox.SuspendLayout();
            this.componentBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recipesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addCategoryButton
            // 
            this.addCategoryButton.AutoSize = true;
            this.addCategoryButton.Location = new System.Drawing.Point(8, 48);
            this.addCategoryButton.Margin = new System.Windows.Forms.Padding(2);
            this.addCategoryButton.Name = "addCategoryButton";
            this.addCategoryButton.Size = new System.Drawing.Size(124, 23);
            this.addCategoryButton.TabIndex = 12;
            this.addCategoryButton.Text = "Добавить категорию";
            this.addCategoryButton.UseVisualStyleBackColor = true;
            this.addCategoryButton.Click += new System.EventHandler(this.addCategoryButton_Click_1);
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(71, 17);
            this.categoryComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(123, 21);
            this.categoryComboBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Категория";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 101.5229F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Код категории";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // categoryDataGridView
            // 
            this.categoryDataGridView.AllowUserToAddRows = false;
            this.categoryDataGridView.AllowUserToDeleteRows = false;
            this.categoryDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.categoryDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.categoryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categoryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.categoryDataGridView.Location = new System.Drawing.Point(8, 75);
            this.categoryDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.categoryDataGridView.MultiSelect = false;
            this.categoryDataGridView.Name = "categoryDataGridView";
            this.categoryDataGridView.ReadOnly = true;
            this.categoryDataGridView.RowHeadersVisible = false;
            this.categoryDataGridView.RowTemplate.Height = 24;
            this.categoryDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.categoryDataGridView.Size = new System.Drawing.Size(186, 387);
            this.categoryDataGridView.TabIndex = 12;
            // 
            // categoryBox
            // 
            this.categoryBox.Controls.Add(this.categoryDataGridView);
            this.categoryBox.Controls.Add(this.addCategoryButton);
            this.categoryBox.Controls.Add(this.categoryComboBox);
            this.categoryBox.Controls.Add(this.removeCategoryButton);
            this.categoryBox.Controls.Add(this.label6);
            this.categoryBox.Location = new System.Drawing.Point(306, 35);
            this.categoryBox.Margin = new System.Windows.Forms.Padding(2);
            this.categoryBox.Name = "categoryBox";
            this.categoryBox.Padding = new System.Windows.Forms.Padding(2);
            this.categoryBox.Size = new System.Drawing.Size(201, 473);
            this.categoryBox.TabIndex = 27;
            this.categoryBox.TabStop = false;
            this.categoryBox.Text = "Категории";
            // 
            // removeCategoryButton
            // 
            this.removeCategoryButton.AutoSize = true;
            this.removeCategoryButton.Location = new System.Drawing.Point(137, 48);
            this.removeCategoryButton.Margin = new System.Windows.Forms.Padding(2);
            this.removeCategoryButton.Name = "removeCategoryButton";
            this.removeCategoryButton.Size = new System.Drawing.Size(60, 23);
            this.removeCategoryButton.TabIndex = 13;
            this.removeCategoryButton.Text = "Удалить";
            this.removeCategoryButton.UseVisualStyleBackColor = true;
            this.removeCategoryButton.Click += new System.EventHandler(this.removeCategoryButton_Click_1);
            // 
            // componentBox
            // 
            this.componentBox.Controls.Add(this.recipesComboBox);
            this.componentBox.Controls.Add(this.label4);
            this.componentBox.Controls.Add(this.recipesCountTextBox);
            this.componentBox.Controls.Add(this.label5);
            this.componentBox.Controls.Add(this.recipesDataGridView);
            this.componentBox.Controls.Add(this.addButton);
            this.componentBox.Controls.Add(this.delButton);
            this.componentBox.Location = new System.Drawing.Point(11, 35);
            this.componentBox.Margin = new System.Windows.Forms.Padding(2);
            this.componentBox.Name = "componentBox";
            this.componentBox.Padding = new System.Windows.Forms.Padding(2);
            this.componentBox.Size = new System.Drawing.Size(290, 473);
            this.componentBox.TabIndex = 26;
            this.componentBox.TabStop = false;
            this.componentBox.Text = "Состав товара";
            // 
            // recipesComboBox
            // 
            this.recipesComboBox.FormattingEnabled = true;
            this.recipesComboBox.Location = new System.Drawing.Point(78, 17);
            this.recipesComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.recipesComboBox.Name = "recipesComboBox";
            this.recipesComboBox.Size = new System.Drawing.Size(132, 21);
            this.recipesComboBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Компонент";
            // 
            // recipesCountTextBox
            // 
            this.recipesCountTextBox.Location = new System.Drawing.Point(78, 46);
            this.recipesCountTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.recipesCountTextBox.Name = "recipesCountTextBox";
            this.recipesCountTextBox.Size = new System.Drawing.Size(76, 20);
            this.recipesCountTextBox.TabIndex = 7;
            this.recipesCountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.recipesCountTextBox_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Количество";
            // 
            // recipesDataGridView
            // 
            this.recipesDataGridView.AllowUserToAddRows = false;
            this.recipesDataGridView.AllowUserToDeleteRows = false;
            this.recipesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.recipesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.recipesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recipesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_component,
            this.name,
            this.quantity});
            this.recipesDataGridView.Location = new System.Drawing.Point(9, 103);
            this.recipesDataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.recipesDataGridView.MultiSelect = false;
            this.recipesDataGridView.Name = "recipesDataGridView";
            this.recipesDataGridView.ReadOnly = true;
            this.recipesDataGridView.RowHeadersVisible = false;
            this.recipesDataGridView.RowTemplate.Height = 24;
            this.recipesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.recipesDataGridView.Size = new System.Drawing.Size(272, 358);
            this.recipesDataGridView.TabIndex = 11;
            // 
            // id_component
            // 
            this.id_component.HeaderText = "Код компонента";
            this.id_component.Name = "id_component";
            this.id_component.ReadOnly = true;
            this.id_component.Visible = false;
            // 
            // name
            // 
            this.name.FillWeight = 101.5229F;
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.FillWeight = 98.47715F;
            this.quantity.HeaderText = "Количество";
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // addButton
            // 
            this.addButton.AutoSize = true;
            this.addButton.Location = new System.Drawing.Point(12, 76);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(125, 23);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Добавить компонент";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // delButton
            // 
            this.delButton.AutoSize = true;
            this.delButton.Location = new System.Drawing.Point(142, 76);
            this.delButton.Margin = new System.Windows.Forms.Padding(2);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(60, 23);
            this.delButton.TabIndex = 10;
            this.delButton.Text = "Удалить";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // availableCheckBox
            // 
            this.availableCheckBox.AutoSize = true;
            this.availableCheckBox.Checked = true;
            this.availableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.availableCheckBox.Location = new System.Drawing.Point(420, 12);
            this.availableCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.availableCheckBox.Name = "availableCheckBox";
            this.availableCheckBox.Size = new System.Drawing.Size(92, 17);
            this.availableCheckBox.TabIndex = 25;
            this.availableCheckBox.Text = "Доступность";
            this.availableCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.AutoSize = true;
            this.cancelButton.Location = new System.Drawing.Point(523, 99);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(117, 46);
            this.cancelButton.TabIndex = 24;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.AutoSize = true;
            this.okButton.Location = new System.Drawing.Point(523, 45);
            this.okButton.Margin = new System.Windows.Forms.Padding(2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(117, 44);
            this.okButton.TabIndex = 23;
            this.okButton.Text = "Сохранить";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 22;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(297, 13);
            this.priceTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(114, 20);
            this.priceTextBox.TabIndex = 21;
            this.priceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Стоимость";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(107, 13);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(114, 20);
            this.nameTextBox.TabIndex = 19;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Название товара";
            // 
            // AddEditProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 546);
            this.Controls.Add(this.categoryBox);
            this.Controls.Add(this.componentBox);
            this.Controls.Add(this.availableCheckBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "AddEditProducts";
            this.Text = "Управление продуктами";
            this.Load += new System.EventHandler(this.AddEditProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categoryDataGridView)).EndInit();
            this.categoryBox.ResumeLayout(false);
            this.categoryBox.PerformLayout();
            this.componentBox.ResumeLayout(false);
            this.componentBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recipesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addCategoryButton;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView categoryDataGridView;
        private System.Windows.Forms.GroupBox categoryBox;
        private System.Windows.Forms.Button removeCategoryButton;
        private System.Windows.Forms.GroupBox componentBox;
        private System.Windows.Forms.ComboBox recipesComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox recipesCountTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView recipesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_component;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.CheckBox availableCheckBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
    }
}