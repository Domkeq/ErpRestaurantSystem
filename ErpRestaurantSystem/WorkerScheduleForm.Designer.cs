
namespace ErpRestaurantSystem
{
    partial class WorkerScheduleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkerScheduleForm));
            this.dataGridViewSchedules = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addSchedule = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.renameSchedule = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSchedule = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.searchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SrcPeriodDate = new System.Windows.Forms.ToolStripLabel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.buttonToggleMode = new System.Windows.Forms.Button();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSrc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchedules)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSchedules
            // 
            this.dataGridViewSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSchedules.Location = new System.Drawing.Point(12, 79);
            this.dataGridViewSchedules.Name = "dataGridViewSchedules";
            this.dataGridViewSchedules.Size = new System.Drawing.Size(548, 150);
            this.dataGridViewSchedules.TabIndex = 0;
            this.dataGridViewSchedules.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewSchedules_CellBeginEdit);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSchedule,
            this.toolStripSeparator4,
            this.renameSchedule,
            this.toolStripSeparator2,
            this.deleteSchedule,
            this.toolStripSeparator1,
            this.searchTextBox,
            this.toolStripSeparator3,
            this.SrcPeriodDate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(860, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addSchedule
            // 
            this.addSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addSchedule.Image = ((System.Drawing.Image)(resources.GetObject("addSchedule.Image")));
            this.addSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addSchedule.Name = "addSchedule";
            this.addSchedule.Size = new System.Drawing.Size(63, 22);
            this.addSchedule.Text = "&Добавить";
            this.addSchedule.Click += new System.EventHandler(this.addSchedule_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // renameSchedule
            // 
            this.renameSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.renameSchedule.Image = ((System.Drawing.Image)(resources.GetObject("renameSchedule.Image")));
            this.renameSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameSchedule.Name = "renameSchedule";
            this.renameSchedule.Size = new System.Drawing.Size(65, 22);
            this.renameSchedule.Text = "&Изменить";
            this.renameSchedule.Click += new System.EventHandler(this.renameSchedule_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // deleteSchedule
            // 
            this.deleteSchedule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteSchedule.Image = ((System.Drawing.Image)(resources.GetObject("deleteSchedule.Image")));
            this.deleteSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteSchedule.Name = "deleteSchedule";
            this.deleteSchedule.Size = new System.Drawing.Size(55, 22);
            this.deleteSchedule.Text = "&Удалить";
            this.deleteSchedule.Click += new System.EventHandler(this.deleteSchedule_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(100, 25);
            this.searchTextBox.Enter += new System.EventHandler(this.searchTextBox_Enter);
            this.searchTextBox.Leave += new System.EventHandler(this.searchTextBox_Leave);
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // SrcPeriodDate
            // 
            this.SrcPeriodDate.Name = "SrcPeriodDate";
            this.SrcPeriodDate.Size = new System.Drawing.Size(119, 22);
            this.SrcPeriodDate.Text = "Поиск по диапазону";
            this.SrcPeriodDate.Click += new System.EventHandler(this.SrcPeriodDate_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(588, 79);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // buttonToggleMode
            // 
            this.buttonToggleMode.Location = new System.Drawing.Point(588, 34);
            this.buttonToggleMode.Name = "buttonToggleMode";
            this.buttonToggleMode.Size = new System.Drawing.Size(87, 36);
            this.buttonToggleMode.TabIndex = 5;
            this.buttonToggleMode.Text = "Просмотр календаря";
            this.buttonToggleMode.UseVisualStyleBackColor = true;
            this.buttonToggleMode.Click += new System.EventHandler(this.buttonToggleMode_Click);
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Location = new System.Drawing.Point(32, 40);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(121, 20);
            this.dateTimeStart.TabIndex = 6;
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Location = new System.Drawing.Point(195, 40);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(116, 20);
            this.dateTimeEnd.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "С:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "По:";
            // 
            // BtnSrc
            // 
            this.BtnSrc.Image = ((System.Drawing.Image)(resources.GetObject("BtnSrc.Image")));
            this.BtnSrc.Location = new System.Drawing.Point(327, 33);
            this.BtnSrc.Name = "BtnSrc";
            this.BtnSrc.Size = new System.Drawing.Size(37, 37);
            this.BtnSrc.TabIndex = 10;
            this.BtnSrc.UseVisualStyleBackColor = true;
            this.BtnSrc.Click += new System.EventHandler(this.BtnSrc_Click);
            // 
            // WorkerScheduleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 450);
            this.Controls.Add(this.BtnSrc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimeEnd);
            this.Controls.Add(this.dateTimeStart);
            this.Controls.Add(this.buttonToggleMode);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridViewSchedules);
            this.Name = "WorkerScheduleForm";
            this.Text = "График сотрудников";
            this.Load += new System.EventHandler(this.WorkerScheduleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSchedules)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSchedules;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton addSchedule;
        private System.Windows.Forms.ToolStripButton renameSchedule;
        private System.Windows.Forms.ToolStripButton deleteSchedule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button buttonToggleMode;
        private System.Windows.Forms.ToolStripLabel SrcPeriodDate;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSrc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox searchTextBox;
    }
}