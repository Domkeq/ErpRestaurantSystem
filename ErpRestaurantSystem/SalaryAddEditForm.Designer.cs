
namespace ErpRestaurantSystem
{
    partial class SalaryAddEditForm
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
            this.employeeComboBox = new System.Windows.Forms.ComboBox();
            this.startdatePicker = new System.Windows.Forms.DateTimePicker();
            this.enddatePicker = new System.Windows.Forms.DateTimePicker();
            this.hoursworkedTextBox = new System.Windows.Forms.TextBox();
            this.hourlyrateTextBox = new System.Windows.Forms.TextBox();
            this.bonusTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // employeeComboBox
            // 
            this.employeeComboBox.FormattingEnabled = true;
            this.employeeComboBox.Location = new System.Drawing.Point(48, 45);
            this.employeeComboBox.Name = "employeeComboBox";
            this.employeeComboBox.Size = new System.Drawing.Size(150, 21);
            this.employeeComboBox.TabIndex = 0;
            // 
            // startdatePicker
            // 
            this.startdatePicker.Location = new System.Drawing.Point(48, 87);
            this.startdatePicker.Name = "startdatePicker";
            this.startdatePicker.Size = new System.Drawing.Size(150, 20);
            this.startdatePicker.TabIndex = 1;
            // 
            // enddatePicker
            // 
            this.enddatePicker.Location = new System.Drawing.Point(48, 137);
            this.enddatePicker.Name = "enddatePicker";
            this.enddatePicker.Size = new System.Drawing.Size(150, 20);
            this.enddatePicker.TabIndex = 2;
            // 
            // hoursworkedTextBox
            // 
            this.hoursworkedTextBox.Location = new System.Drawing.Point(48, 185);
            this.hoursworkedTextBox.Name = "hoursworkedTextBox";
            this.hoursworkedTextBox.Size = new System.Drawing.Size(150, 20);
            this.hoursworkedTextBox.TabIndex = 3;
            this.hoursworkedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hoursworkedTextBox_KeyPress);
            // 
            // hourlyrateTextBox
            // 
            this.hourlyrateTextBox.Location = new System.Drawing.Point(48, 231);
            this.hourlyrateTextBox.Name = "hourlyrateTextBox";
            this.hourlyrateTextBox.Size = new System.Drawing.Size(150, 20);
            this.hourlyrateTextBox.TabIndex = 4;
            this.hourlyrateTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hourlyrateTextBox_KeyPress);
            // 
            // bonusTextBox
            // 
            this.bonusTextBox.Location = new System.Drawing.Point(48, 282);
            this.bonusTextBox.Name = "bonusTextBox";
            this.bonusTextBox.Size = new System.Drawing.Size(150, 20);
            this.bonusTextBox.TabIndex = 5;
            this.bonusTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bonusTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ФИО:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Начальная дата";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Конечная дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Кол-во отработанных часов:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ставка за час:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Премия:";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(242, 45);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(150, 39);
            this.submitButton.TabIndex = 12;
            this.submitButton.Text = "Сохранить";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(242, 95);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(150, 39);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // SalaryAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 450);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bonusTextBox);
            this.Controls.Add(this.hourlyrateTextBox);
            this.Controls.Add(this.hoursworkedTextBox);
            this.Controls.Add(this.enddatePicker);
            this.Controls.Add(this.startdatePicker);
            this.Controls.Add(this.employeeComboBox);
            this.Name = "SalaryAddEditForm";
            this.Text = "Управление заработной платой";
            this.Load += new System.EventHandler(this.SalaryAddEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox employeeComboBox;
        private System.Windows.Forms.DateTimePicker startdatePicker;
        private System.Windows.Forms.DateTimePicker enddatePicker;
        private System.Windows.Forms.TextBox hoursworkedTextBox;
        private System.Windows.Forms.TextBox hourlyrateTextBox;
        private System.Windows.Forms.TextBox bonusTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
    }
}