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
    public partial class SalaryAddEditForm : Form
    {
        private readonly SqlConnection _sqlConnection;
        private readonly int _id;
        public SalaryAddEditForm(SqlConnection connection, int idTransf = -1)
        {
            InitializeComponent();

            _sqlConnection = connection;
            _id = idTransf;

            LoadEmployees();

            Text = _id == -1 ? "Добавление записи зарплаты" : "Редактирование записи зарплаты";
            submitButton.Text = "Сохранить";
        }

        private async void LoadEmployees()
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-6GJA8NO;Initial Catalog=ErpRestaurantSystem;Integrated Security=True;MultipleActiveResultSets=True"))
            {
                await sqlConnection.OpenAsync();

                var getEmployeesCommand = new SqlCommand("SELECT [employee_id], [name] + ' ' + [surname] + ' ' + [patronymic] AS FullName FROM [employees]", sqlConnection);

                try
                {
                    using (var sqlReaderEmployees = await getEmployeesCommand.ExecuteReaderAsync())
                    {
                        var employees = new Dictionary<int, string>();

                        while (await sqlReaderEmployees.ReadAsync())
                        {
                            employees.Add(Convert.ToInt32(sqlReaderEmployees["employee_id"]), Convert.ToString(sqlReaderEmployees["FullName"]));
                        }

                        employeeComboBox.DataSource = new BindingSource(employees, null);
                        employeeComboBox.DisplayMember = "Value";
                        employeeComboBox.ValueMember = "Key";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Установите выбранного сотрудника здесь, после загрузки данных сотрудников
            if (_id != -1)
            {
                if (_sqlConnection.State == ConnectionState.Closed)
                {
                    await _sqlConnection.OpenAsync();
                }

                var loadSalary = new SqlCommand("SELECT * FROM [salaries] WHERE salaryId=@id", _sqlConnection);
                loadSalary.Parameters.AddWithValue("id", _id);

                try
                {
                    using (var sqlReaderSalary = await loadSalary.ExecuteReaderAsync())
                    {
                        if (await sqlReaderSalary.ReadAsync())
                        {
                            employeeComboBox.SelectedValue = Convert.ToInt32(sqlReaderSalary["employeeId"]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (_sqlConnection.State != ConnectionState.Closed)
                    {
                        _sqlConnection.Close();
                    }
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private decimal? ParseNullableDecimal(string text, string errorMessage)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            if (!decimal.TryParse(text, out var value))
            {
                MessageBox.Show(errorMessage, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception(errorMessage);
            }

            return value;
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            if (employeeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите сотрудника.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(hoursworkedTextBox.Text))
            {
                MessageBox.Show("Введите отработанные часы.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(hourlyrateTextBox.Text))
            {
                MessageBox.Show("Введите почасовую ставку.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                await _sqlConnection.OpenAsync();
            }

            try
            {
                var sqlCommand = _id == -1 ?
                    new SqlCommand("INSERT INTO [salaries] (employeeId, startdate, enddate, hoursworked, hourlyrate, bonus) VALUES (@employeeId, @startdate, @enddate, @hoursworked, @hourlyrate, @bonus)", _sqlConnection) :
                    new SqlCommand("UPDATE [salaries] SET employeeId=@employeeId, startdate=@startdate, enddate=@enddate, hoursworked=@hoursworked, hourlyrate=@hourlyrate, bonus=@bonus WHERE salaryId=@id", _sqlConnection);

                sqlCommand.Parameters.AddWithValue("employeeId", employeeComboBox.SelectedValue);
                sqlCommand.Parameters.AddWithValue("startdate", startdatePicker.Value);
                sqlCommand.Parameters.AddWithValue("enddate", enddatePicker.Value);
                sqlCommand.Parameters.AddWithValue("hoursworked", ParseFloat(hoursworkedTextBox.Text, "Неверное значение для отработанных часов."));
                sqlCommand.Parameters.AddWithValue("hourlyrate", ParseDecimal(hourlyrateTextBox.Text, "Неверное значение для почасовой ставки."));
                sqlCommand.Parameters.AddWithValue("bonus", ParseNullableDecimal(bonusTextBox.Text, "Неверное значение для бонуса.") ?? (object)DBNull.Value);

                if (_id != -1) sqlCommand.Parameters.AddWithValue("id", _id);

                await sqlCommand.ExecuteNonQueryAsync();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
            }
        }
        private float ParseFloat(string text, string errorMessage)
        {
            if (!float.TryParse(text, out var value))
            {
                MessageBox.Show(errorMessage, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception(errorMessage);
            }

            return value;
        }

        private decimal ParseDecimal(string text, string errorMessage)
        {
            if (!decimal.TryParse(text, out var value))
            {
                MessageBox.Show(errorMessage, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception(errorMessage);
            }

            return value;
        }
        private void SalaryAddEditForm_Load(object sender, EventArgs e)
        {
            if (_id == -1) return;

            try
            {
                if (_sqlConnection.State == ConnectionState.Closed)
                {
                    _sqlConnection.Open();
                }

                var loadSalary = new SqlCommand("SELECT * FROM [salaries] WHERE salaryId=@id", _sqlConnection);
                loadSalary.Parameters.AddWithValue("id", _id);

                using (var sqlReader = loadSalary.ExecuteReader())
                {
                    if (!sqlReader.Read()) return;

                    employeeComboBox.SelectedValue = Convert.ToInt32(sqlReader["employeeId"]);

                    startdatePicker.Value = Convert.ToDateTime(sqlReader["startdate"]);
                    enddatePicker.Value = Convert.ToDateTime(sqlReader["enddate"]);

                    hoursworkedTextBox.Text = Convert.ToString(sqlReader["hoursworked"]);
                    hourlyrateTextBox.Text = Convert.ToString(sqlReader["hourlyrate"]);

                    if (sqlReader["bonus"] != DBNull.Value)
                    {
                        bonusTextBox.Text = Convert.ToString(sqlReader["bonus"]);
                    }
                    else
                    {
                        bonusTextBox.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
            }
        }

        private void hoursworkedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только цифр, клавиш Backspace и Delete, и ограничиваем длину значения до 10 символов
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127 || hoursworkedTextBox.Text.Length >= 10)
            {
                e.Handled = true; // Запрещаем ввод символа
            }
        }

        private void hourlyrateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только цифр, клавиш Backspace и Delete, и ограничиваем длину значения до 10 символов
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127 || hourlyrateTextBox.Text.Length >= 10)
            {
                e.Handled = true; // Запрещаем ввод символа
            }
        }

        private void bonusTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только цифр, клавиш Backspace и Delete, и ограничиваем длину значения до 10 символов
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127 || bonusTextBox.Text.Length >= 10)
            {
                e.Handled = true; // Запрещаем ввод символа
            }
        }
    }
}
