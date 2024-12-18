using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErpRestaurantSystem
{

    public partial class AddScheduleForm : Form
    {
string connectionString = @"Data Source=DESKTOP-7KBLIPI\SQLEXPRESS;Initial Catalog=ErpRestaurantSystem;Integrated Security=True;MultipleActiveResultSets=True";
        private SqlConnection sqlConnection;
        public AddScheduleForm(int? editingScheduleId = null)
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            EditingScheduleId = editingScheduleId;
            LoadEmployees();
        }

        public int? EditingScheduleId { get; set; }
        public delegate void ScheduleAddedEventHandler(object source, EventArgs args);
        public event ScheduleAddedEventHandler ScheduleAdded;

        protected virtual void OnScheduleAdded()
        {
            ScheduleAdded?.Invoke(this, EventArgs.Empty);
        }
        private void LoadScheduleData(int scheduleId)
        {
            string query = "SELECT employee_id, start_time, end_time, is_vacation FROM work_schedule WHERE schedule_id = @schedule_id";

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                command.Parameters.AddWithValue("@schedule_id", scheduleId);
                sqlConnection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    comboBoxEmployees.SelectedItem = comboBoxEmployees.Items.Cast<EmployeeItem>().FirstOrDefault(item => item.Value == reader.GetInt32(0));
                    dateTimePickerStart.Value = reader.GetDateTime(1);
                    dateTimePickerEnd.Value = reader.GetDateTime(2);
                    checkBoxVacation.Checked = reader.GetBoolean(3);
                }

                sqlConnection.Close();
            }
        }

        private void LoadEmployees()
        {
            string query = "SELECT employee_id, CONCAT(name, ' ', surname, ' ', patronymic) as FullName FROM employees";

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    // comboBoxEmployees - это элемент управления на форме для выбора сотрудника
                    // Значение каждого элемента - это employee_id, отображаемый текст - это полное имя сотрудника
                    comboBoxEmployees.Items.Add(new EmployeeItem { Value = reader.GetInt32(0), Text = reader.GetString(1) });
                }
                sqlConnection.Close();
            }

            if (EditingScheduleId != null)
            {
                LoadScheduleData((int)EditingScheduleId);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxEmployees.SelectedItem != null
                  && dateTimePickerStart.Value != null
                  && dateTimePickerEnd.Value != null
                  && checkBoxVacation.Checked != null)
            {
                int employeeId = (comboBoxEmployees.SelectedItem as EmployeeItem).Value;
                DateTime startTime = dateTimePickerStart.Value;
                DateTime endTime = dateTimePickerEnd.Value;
                bool isVacation = checkBoxVacation.Checked;

                string query;

                if (EditingScheduleId == null)
                {
                    query = "INSERT INTO work_schedule (employee_id, start_time, end_time, is_vacation) " +
                            "VALUES (@employee_id, @start_time, @end_time, @is_vacation)";
                }
                else
                {
                    query = "UPDATE work_schedule SET employee_id = @employee_id, start_time = @start_time, end_time = @end_time, is_vacation = @is_vacation WHERE schedule_id = @schedule_id";
                }

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    command.Parameters.AddWithValue("@employee_id", employeeId);
                    command.Parameters.AddWithValue("@start_time", startTime);
                    command.Parameters.AddWithValue("@end_time", endTime);
                    command.Parameters.AddWithValue("@is_vacation", isVacation);

                    if (EditingScheduleId != null)
                    {
                        command.Parameters.AddWithValue("@schedule_id", EditingScheduleId);
                    }

                    command.ExecuteNonQuery();
                    OnScheduleAdded();
                    sqlConnection.Close();
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
            }
        }

        private void AddScheduleForm_Load(object sender, EventArgs e)
        {
            dateTimePickerStart.CustomFormat = "yyyy-MM-dd HH:mm";
            dateTimePickerStart.Format = DateTimePickerFormat.Custom;

            dateTimePickerEnd.CustomFormat = "yyyy-MM-dd HH:mm";
            dateTimePickerEnd.Format = DateTimePickerFormat.Custom;
        }
    }
}
