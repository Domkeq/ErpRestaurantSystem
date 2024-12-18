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
    public partial class WorkerScheduleForm : Form
    {
string connectionString = @"Data Source=DESKTOP-7KBLIPI\SQLEXPRESS;Initial Catalog=ErpRestaurantSystem;Integrated Security=True;MultipleActiveResultSets=True";
        private SqlConnection sqlConnection;
        private string role;
        // Объявляем глобальную переменную
        private bool isCalendarVisible = false;
        public WorkerScheduleForm(string role)
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            this.role = role;
            ConfigureRolePermissions();
            monthCalendar1.Visible = false; // скрываем календарь
            buttonToggleMode.Text = "Просмотр календаря";

            // Изначально скрываем контролы для поиска по диапазону дат
            dateTimeStart.Visible = false;
            dateTimeEnd.Visible = false;
            BtnSrc.Visible = false;
            label1.Visible = false;
            label2.Visible = false;

            // Задаем положение DataGridView
            dataGridViewSchedules.Top = dateTimeEnd.Bottom - 20;

            // Подписываемся на событие TextChanged
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // Устанавливаем текст по умолчанию
            searchTextBox.Text = "Поиск..";
            // Добавляем обработчики событий Enter и Leave
            searchTextBox.Enter += searchTextBox_Enter;
            searchTextBox.Leave += searchTextBox_Leave;
        }

        private void ConfigureRolePermissions()
        {
            switch (role)
            {
                case "manager":
                    //menuStrip1.Visible = false;
                    //addSchedule.Enabled = false;
                    break;
                case "waiter":
                    // menuStrip1.Visible = false;
                    addSchedule.Enabled = false;
                    renameSchedule.Enabled = false;
                    deleteSchedule.Enabled = false;
                    break;
                case "accountant":
                    //  menuStrip1.Visible = false;
                    // menuStrip1.Enabled = false;
                    break;
                case "it":
                    break;
                default:
                    MessageBox.Show("Неизвестная роль, доступ к системе запрещен");
                    Application.Exit();
                    break;
            }
        }

        void LoadWorkSchedules(DateTime? startDate = null, DateTime? endDate = null, string search = null)
        {
            string query = @"
    SELECT ws.schedule_id as 'Schedule ID',
           CONCAT(e.name, ' ', e.surname, ' ', e.patronymic) as 'ФИО', 
           ws.start_time as 'Дата с', ws.end_time as 'Дата по', ws.is_vacation as 'Отпуск' 
    FROM work_schedule ws
    JOIN employees e ON ws.employee_id = e.employee_id
    WHERE 1=1";

            if (startDate.HasValue && endDate.HasValue)
            {
                query += " AND ws.start_time <= @end_date AND ws.end_time >= @start_date";
            }

            if (!string.IsNullOrEmpty(search))
            {
                query += " AND CONCAT(e.name, ' ', e.surname, ' ', e.patronymic) LIKE @search";
            }

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                if (startDate.HasValue && endDate.HasValue)
                {
                    command.Parameters.AddWithValue("@start_date", startDate.Value);
                    endDate = endDate.Value.Date.AddDays(1).AddTicks(-1); // Это установит время окончания в 23:59:59 того же дня
                    command.Parameters.AddWithValue("@end_date", endDate.Value);
                }

                if (!string.IsNullOrEmpty(search))
                {
                    command.Parameters.AddWithValue("@search", "%" + search + "%");
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridViewSchedules.DataSource = dataTable;
                dataGridViewSchedules.Columns["Schedule ID"].Visible = false; // скрыть столбец 'Schedule ID'
            }
        }


        private void WorkerScheduleForm_Load(object sender, EventArgs e)
        {
            LoadWorkSchedules();
            dataGridViewSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewSchedules.Columns[dataGridViewSchedules.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewSchedules.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void OnScheduleAdded(object source, EventArgs e)
        {
            LoadWorkSchedules();
        }

        private void addSchedule_Click(object sender, EventArgs e)
        {
            AddScheduleForm form = new AddScheduleForm();
            form.ScheduleAdded += OnScheduleAdded;
            form.Show();
        }

        private void renameSchedule_Click(object sender, EventArgs e)
        {
            if (dataGridViewSchedules.SelectedRows.Count > 0)
            {
                int scheduleId = (int)dataGridViewSchedules.SelectedRows[0].Cells["Schedule ID"].Value;

                AddScheduleForm form = new AddScheduleForm(scheduleId);
                form.ScheduleAdded += OnScheduleAdded;
                form.Show();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите расписание для редактирования.");
            }
        }

        private void deleteSchedule_Click(object sender, EventArgs e)
        {
            if (dataGridViewSchedules.SelectedRows.Count > 0)
            {
                int scheduleId = (int)dataGridViewSchedules.SelectedRows[0].Cells["Schedule ID"].Value;

                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить расписание?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string query = "DELETE FROM work_schedule WHERE schedule_id = @schedule_id";

                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@schedule_id", scheduleId);

                        // Открываем подключение перед выполнением команды
                        sqlConnection.Open();

                        command.ExecuteNonQuery();

                        // Закрываем подключение после выполнения команды
                        sqlConnection.Close();
                    }

                    LoadWorkSchedules();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите расписание для удаления.");
            }
        }


        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (isCalendarVisible)
            {
                // Загружаем расписание за выбранный период, когда календарь видим
                LoadWorkSchedules(monthCalendar1.SelectionStart, monthCalendar1.SelectionEnd);
            }
        }

        private void buttonToggleMode_Click(object sender, EventArgs e)
        {
            isCalendarVisible = !isCalendarVisible;
            monthCalendar1.Visible = isCalendarVisible; // переключаем видимость календаря

            if (isCalendarVisible)
            {
                buttonToggleMode.Text = "Скрыть календарь";
            }
            else
            {
                buttonToggleMode.Text = "Просмотр календаря";
                LoadWorkSchedules(); // Загружаем расписание за весь период, когда календарь скрыт
            }
        }

        private void SrcPeriodDate_Click(object sender, EventArgs e)
        {
            // При нажатии на кнопку меняем видимость контролов для поиска по диапазону дат
            dateTimeStart.Visible = !dateTimeStart.Visible;
            dateTimeEnd.Visible = !dateTimeEnd.Visible;
            BtnSrc.Visible = !BtnSrc.Visible;
            dataGridViewSchedules.Top = BtnSrc.Visible ? BtnSrc.Bottom + 10 : dateTimeEnd.Bottom - 20;

            // Меняем текст кнопки в зависимости от текущего состояния
            SrcPeriodDate.Text = BtnSrc.Visible ? "Скрыть поиск" : "Поиск по диапазону";

            // Если элементы управления скрыты, сбросьте параметры поиска и отобразите все записи
            if (!dateTimeStart.Visible)
            {
                // Загружаем все записи, когда элементы управления поиска скрыты
                LoadWorkSchedules();
            }
        }

        private void BtnSrc_Click(object sender, EventArgs e)
        {
            // Загружаем расписание за выбранный диапазон дат
            DateTime endDate = dateTimeEnd.Value.Date.Add(new TimeSpan(23, 59, 59));
            LoadWorkSchedules(dateTimeStart.Value, endDate);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Запускаем поиск при каждом изменении текста
            if (dateTimeStart.Visible)
            {
                DateTime endDate = dateTimeEnd.Value.Date.Add(new TimeSpan(23, 59, 59));
                LoadWorkSchedules(dateTimeStart.Value, endDate, searchTextBox.Text);
            }
            else
            {
                LoadWorkSchedules(search: searchTextBox.Text);
            }
        }

        private void searchTextBox_Enter(object sender, EventArgs e)
        {
            if (searchTextBox.Text == "Поиск..")
            {
                searchTextBox.Text = "";
            }
        }

        private void searchTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchTextBox.Text))
            {
                searchTextBox.Text = "Поиск..";
            }
        }

        private void dataGridViewSchedules_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Проверяем, является ли редактируемая ячейка столбцом "Отпуск"
            if (e.ColumnIndex == dataGridViewSchedules.Columns["Отпуск"].Index)
            {
                // Отменяем редактирование ячейки
                e.Cancel = true;
            }
        }
    }
}
