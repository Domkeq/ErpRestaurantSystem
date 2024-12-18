
namespace ErpRestaurantSystem
{
    partial class AddEditEmployeeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSurname = new System.Windows.Forms.TextBox();
            this.textBoxPatronymic = new System.Windows.Forms.TextBox();
            this.comboBoxRole = new System.Windows.Forms.ComboBox();
            this.maskedTextBoxPin = new System.Windows.Forms.TextBox();
            this.maskedTextBoxConfirmPin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAddEmployee = new System.Windows.Forms.Button();
            this.checkBoxShowPin = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Роль:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "PIN code:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(15, 42);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(121, 20);
            this.textBoxName.TabIndex = 5;
            // 
            // textBoxSurname
            // 
            this.textBoxSurname.Location = new System.Drawing.Point(156, 42);
            this.textBoxSurname.Name = "textBoxSurname";
            this.textBoxSurname.Size = new System.Drawing.Size(121, 20);
            this.textBoxSurname.TabIndex = 6;
            // 
            // textBoxPatronymic
            // 
            this.textBoxPatronymic.Location = new System.Drawing.Point(291, 40);
            this.textBoxPatronymic.Name = "textBoxPatronymic";
            this.textBoxPatronymic.Size = new System.Drawing.Size(121, 20);
            this.textBoxPatronymic.TabIndex = 7;
            // 
            // comboBoxRole
            // 
            this.comboBoxRole.FormattingEnabled = true;
            this.comboBoxRole.Location = new System.Drawing.Point(16, 90);
            this.comboBoxRole.Name = "comboBoxRole";
            this.comboBoxRole.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRole.TabIndex = 8;
            // 
            // maskedTextBoxPin
            // 
            this.maskedTextBoxPin.Location = new System.Drawing.Point(16, 139);
            this.maskedTextBoxPin.Name = "maskedTextBoxPin";
            this.maskedTextBoxPin.Size = new System.Drawing.Size(121, 20);
            this.maskedTextBoxPin.TabIndex = 9;
            this.maskedTextBoxPin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBoxPin_KeyPress);
            // 
            // maskedTextBoxConfirmPin
            // 
            this.maskedTextBoxConfirmPin.Location = new System.Drawing.Point(17, 183);
            this.maskedTextBoxConfirmPin.Name = "maskedTextBoxConfirmPin";
            this.maskedTextBoxConfirmPin.Size = new System.Drawing.Size(120, 20);
            this.maskedTextBoxConfirmPin.TabIndex = 10;
            this.maskedTextBoxConfirmPin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBoxConfirmPin_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Подтвердите PIN:";
            // 
            // buttonAddEmployee
            // 
            this.buttonAddEmployee.Location = new System.Drawing.Point(15, 220);
            this.buttonAddEmployee.Name = "buttonAddEmployee";
            this.buttonAddEmployee.Size = new System.Drawing.Size(122, 35);
            this.buttonAddEmployee.TabIndex = 12;
            this.buttonAddEmployee.Text = "Применить";
            this.buttonAddEmployee.UseVisualStyleBackColor = true;
            this.buttonAddEmployee.Click += new System.EventHandler(this.buttonAddEmployee_Click);
            // 
            // checkBoxShowPin
            // 
            this.checkBoxShowPin.AutoSize = true;
            this.checkBoxShowPin.Location = new System.Drawing.Point(145, 141);
            this.checkBoxShowPin.Name = "checkBoxShowPin";
            this.checkBoxShowPin.Size = new System.Drawing.Size(98, 17);
            this.checkBoxShowPin.TabIndex = 13;
            this.checkBoxShowPin.Text = "Просмотр PIN";
            this.checkBoxShowPin.UseVisualStyleBackColor = true;
            this.checkBoxShowPin.CheckedChanged += new System.EventHandler(this.checkBoxShowPin_CheckedChanged);
            // 
            // AddEditEmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 380);
            this.Controls.Add(this.checkBoxShowPin);
            this.Controls.Add(this.buttonAddEmployee);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedTextBoxConfirmPin);
            this.Controls.Add(this.maskedTextBoxPin);
            this.Controls.Add(this.comboBoxRole);
            this.Controls.Add(this.textBoxPatronymic);
            this.Controls.Add(this.textBoxSurname);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddEditEmployeeForm";
            this.Text = "Управление сотрудниками";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxSurname;
        private System.Windows.Forms.TextBox textBoxPatronymic;
        private System.Windows.Forms.ComboBox comboBoxRole;
        private System.Windows.Forms.TextBox maskedTextBoxPin;
        private System.Windows.Forms.TextBox maskedTextBoxConfirmPin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonAddEmployee;
        private System.Windows.Forms.CheckBox checkBoxShowPin;
    }
}