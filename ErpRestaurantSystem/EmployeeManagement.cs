using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ErpRestaurantSystem
{
    public partial class EmployeeManagement : Form
    {
string connectionString = @"Data Source=DESKTOP-7KBLIPI\SQLEXPRESS;Initial Catalog=ErpRestaurantSystem;Integrated Security=True;MultipleActiveResultSets=True";
        private SqlConnection sqlConnection;
        private string role;

        public EmployeeManagement(string role)
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            this.role = role;
            ConfigureRolePermissions();
        }
        private void ConfigureRolePermissions()
        {
            switch (role)
            {
                case "manager":
                    //menuStrip1.Visible = false;
                    menuStrip1.Enabled = false;
                    break;
                case "waiter":
                   // menuStrip1.Visible = false;
                    menuStrip1.Enabled = false;
                    break;
                case "accountant":
                    menuStrip1.Enabled = false;
                    break;
                case "it":
                    menuStrip1.Enabled = true;
                    break;
                default:
                    MessageBox.Show("Неизвестная роль, доступ к системе запрещен");
                    Application.Exit();
                    break;
            }
        }
        private void LoadEmployees(string searchQuery = null)
        {
            sqlConnection.Open();
            string query = "SELECT employee_id, name, surname, patronymic, role AS Должность, pin_code FROM employees";
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query += $" WHERE name LIKE @SearchQuery OR surname LIKE @SearchQuery OR patronymic LIKE @SearchQuery";
            }
            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    command.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");
                }

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    switch (row["Должность"].ToString())
                    {
                        case "manager":
                            row["Должность"] = "Менеджер";
                            break;
                        case "waiter":
                            row["Должность"] = "Официант";
                            break;
                        case "accountant":
                            row["Должность"] = "Бухгалтер";
                            break;
                        case "it":
                            row["Должность"] = "ИТ";
                            break;
                    }
                }

                dataGridViewEmployees.DataSource = dataTable;
                dataGridViewEmployees.Columns["pin_code"].Visible = false;
            }
            sqlConnection.Close();
        }

        private void EmployeeManagement_Load(object sender, EventArgs e)
        {
            LoadEmployees();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadEmployees(txtSearch.Text);
        }
        private Employee GetSelectedEmployee()
        {
            if (dataGridViewEmployees.SelectedRows.Count > 0)
            {
                var row = dataGridViewEmployees.SelectedRows[0];
                return new Employee(
                    (int)row.Cells["employee_id"].Value,
                    (string)row.Cells["name"].Value,
                    (string)row.Cells["surname"].Value,
                    (string)row.Cells["patronymic"].Value,
                    (string)row.Cells["Должность"].Value,
                    (int)row.Cells["pin_code"].Value);
            }
            return null;
        }

        private void UpdateEmployee(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("UPDATE employees SET name = @Name, surname = @Surname, patronymic = @Patronymic, role = @Role, pin_code = @PinCode WHERE employee_id = @Id", conn))
                {
                    command.Parameters.AddWithValue("@Id", employee.Id);
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Surname", employee.Surname);
                    command.Parameters.AddWithValue("@Patronymic", employee.Patronymic);
                    command.Parameters.AddWithValue("@Role", employee.Role);
                    command.Parameters.AddWithValue("@PinCode", employee.PinCode);

                    command.ExecuteNonQuery();
                }
            }
        }

        private async Task<bool> DoesPinExistAsync(int pin)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM employees WHERE pin_code = @PinCode", conn))
                {
                    command.Parameters.AddWithValue("@PinCode", pin);
                    int count = (int)await command.ExecuteScalarAsync();
                    return count > 0;
                }
            }
        }

        private void AddEmployee(Employee employee)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO employees (name, surname, patronymic, role, pin_code) VALUES (@Name, @Surname, @Patronymic, @Role, @PinCode)", conn))
                {
                    command.Parameters.AddWithValue("@Name", employee.Name);
                    command.Parameters.AddWithValue("@Surname", employee.Surname);
                    command.Parameters.AddWithValue("@Patronymic", employee.Patronymic);
                    command.Parameters.AddWithValue("@Role", employee.Role);
                    command.Parameters.AddWithValue("@PinCode", employee.PinCode);

                    command.ExecuteNonQuery();
                }
            }
        }

        private async void создатьУЗToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditEmployeeForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (await DoesPinExistAsync(form.NewEmployee.PinCode))
                    {
                        MessageBox.Show("Пин-код уже существует. Пожалуйста, введите другой.");
                        return;
                    }
                    AddEmployee(form.NewEmployee);
                    LoadEmployees();
                }
            }
        }

        private async void изменениеДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedEmployee = GetSelectedEmployee();
            if (selectedEmployee != null)
            {
                using (var form = new AddEditEmployeeForm())
                {
                    form.FillEmployeeData(selectedEmployee);
                    form.IsEditMode = true;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (await DoesPinExistAsync(form.NewEmployee.PinCode))
                        {
                            MessageBox.Show("Пин-код уже существует. Пожалуйста, введите другой.");
                            return;
                        }
                        UpdateEmployee(form.NewEmployee);
                        LoadEmployees();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для редактирования.");
            }
        }

        private void DeleteEmployee(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM employees WHERE employee_id = @Id", conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedEmployee = GetSelectedEmployee();
            if (selectedEmployee != null)
            {
                DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить этого сотрудника?", "Подтверждение удаления", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteEmployee(selectedEmployee.Id);
                    LoadEmployees();
                }
            }
            else
            {
                MessageBox.Show("Выберите сотрудника для удаления.");
            }
        }
    }
}
