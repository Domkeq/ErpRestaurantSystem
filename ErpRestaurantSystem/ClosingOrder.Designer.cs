
namespace ErpRestaurantSystem
{
    partial class ClosingOrder
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
            this.submitButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.deliveryLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cashTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sumLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 150);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(144, 34);
            this.submitButton.TabIndex = 8;
            this.submitButton.Text = "Подтвердить заказ";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(12, 201);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(144, 34);
            this.delButton.TabIndex = 10;
            this.delButton.Text = "Удалить заказ";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // deliveryLabel
            // 
            this.deliveryLabel.AutoSize = true;
            this.deliveryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deliveryLabel.Location = new System.Drawing.Point(7, 111);
            this.deliveryLabel.Name = "deliveryLabel";
            this.deliveryLabel.Size = new System.Drawing.Size(77, 25);
            this.deliveryLabel.TabIndex = 13;
            this.deliveryLabel.Text = "0 руб.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Сдача:";
            // 
            // cashTextBox
            // 
            this.cashTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cashTextBox.Location = new System.Drawing.Point(12, 66);
            this.cashTextBox.Name = "cashTextBox";
            this.cashTextBox.Size = new System.Drawing.Size(143, 20);
            this.cashTextBox.TabIndex = 6;
            this.cashTextBox.TextChanged += new System.EventHandler(this.cashTextBox_TextChanged);
            this.cashTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cashTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Наличными";
            // 
            // sumLabel
            // 
            this.sumLabel.AutoSize = true;
            this.sumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sumLabel.Location = new System.Drawing.Point(151, 16);
            this.sumLabel.Name = "sumLabel";
            this.sumLabel.Size = new System.Drawing.Size(77, 25);
            this.sumLabel.TabIndex = 9;
            this.sumLabel.Text = "0 руб.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Сумма заказа составляет:";
            // 
            // ClosingOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 315);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.deliveryLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cashTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sumLabel);
            this.Controls.Add(this.label1);
            this.Name = "ClosingOrder";
            this.Text = "Закрытие заказа";
            this.Load += new System.EventHandler(this.ClosingOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Label deliveryLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cashTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label sumLabel;
        private System.Windows.Forms.Label label1;
    }
}