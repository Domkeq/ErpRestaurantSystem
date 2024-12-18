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
using Word = Microsoft.Office.Interop.Word;

namespace ErpRestaurantSystem
{
    public partial class SalaryManagementForm : Form
    {
string connectionString = @"Data Source=DESKTOP-7KBLIPI\SQLEXPRESS;Initial Catalog=ErpRestaurantSystem;Integrated Security=True;MultipleActiveResultSets=True";
        private SqlConnection sqlConnection;
        private string role;
        private int employeeId;
        private const decimal TaxRate = 0.13m;
        private List<int> selectedRows = new List<int>();
        public SalaryManagementForm(string role, int employeeId)
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            this.role = role;
            this.employeeId = employeeId;
            ConfigureRolePermissions();

        }
        private void ConfigureRolePermissions()
        {
            switch (role)
            {
                case "manager":
                case "accountant":
                case "it":
                    break;
                case "waiter":
                    menuStrip1.Enabled = false;
                    txtSearch.Visible = false; // Скрыть TextBox для роли "waiter"
                    btnExportToWord.Visible = false;
                    label1.Visible = false;
                    break;
                default:
                    MessageBox.Show("Неизвестная роль, доступ к системе запрещен");
                    Application.Exit();
                    break;
            }
        }

        private DataTable dataTable;
        private DataTable originalDataTable;

        private void LoadSalaries(string searchQuery = null)
        {
            sqlConnection.Open();
            string query = "SELECT S.SalaryId, CONCAT(E.name, ' ', E.surname, ' ', E.patronymic) AS 'ФИО', S.StartDate AS 'Дата начала', S.EndDate AS 'Дата окончания', S.HoursWorked AS 'Отработано часов', S.HourlyRate AS 'Часовая ставка', S.Bonus AS 'Премия' FROM Salaries S JOIN Employees E ON S.EmployeeId = E.employee_id";

            if (role == "waiter")
            {
                query += " WHERE S.EmployeeId = @EmployeeId";
            }
            else if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query += $" WHERE (E.name LIKE @SearchQuery OR E.surname LIKE @SearchQuery OR E.patronymic LIKE @SearchQuery)";
            }

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                if (role == "waiter")
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                }
                else if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                    command.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");
                }


                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataTable = new DataTable();
                originalDataTable = new DataTable();

                // Добавить новые столбцы в DataTable с нужной последовательностью
                dataTable.Columns.Add("ФИО", typeof(string));
                dataTable.Columns.Add("Дата начала", typeof(DateTime));
                dataTable.Columns.Add("Дата окончания", typeof(DateTime));
                dataTable.Columns.Add("Отработано часов", typeof(decimal));
                dataTable.Columns.Add("Часовая ставка", typeof(decimal));
                dataTable.Columns.Add("Зарплата (без вычета налогов)", typeof(decimal));
                dataTable.Columns.Add("Зарплата (с вычетом налогов)", typeof(decimal));
                dataTable.Columns.Add("Премия", typeof(decimal));

                originalDataTable = dataTable.Copy(); // Создаем копию исходной таблицы

                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    DateTime startDate = (DateTime)row["Дата начала"];
                    DateTime endDate = (DateTime)row["Дата окончания"];
                    decimal hoursWorked = (decimal)row["Отработано часов"];
                    decimal hourlyRate = (decimal)row["Часовая ставка"];

                    decimal bonus = 0;
                    if (row["Премия"] != DBNull.Value)
                    {
                        bonus = (decimal)row["Премия"];
                    }

                    decimal gross = hoursWorked * hourlyRate + bonus;
                    decimal net = gross * (1 - TaxRate);

                    row["Зарплата (без вычета налогов)"] = gross;
                    row["Зарплата (с вычетом налогов)"] = net;
                }

                dataGridViewSalaries.DataSource = dataTable;
                dataGridViewSalaries.Columns["SalaryId"].Visible = false;

                sqlConnection.Close();
                }
            }

        private void SalaryManagementForm_Load(object sender, EventArgs e)
        {
            LoadSalaries();
            // Автоматическое масштабирование столбцов
            dataGridViewSalaries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewSalaries.Columns[dataGridViewSalaries.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewSalaries.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private async void btnExportToWord_Click(object sender, EventArgs e)
        {
            DataTable filteredDataTable = dataTable.Copy();

            if (selectedRows.Count > 0)
            {
                DataView dataView = filteredDataTable.DefaultView;
                StringBuilder filter = new StringBuilder();
                filter.Append("SalaryId IN (");
                for (int i = 0; i < selectedRows.Count; i++)
                {
                    filter.Append(selectedRows[i]);
                    if (i < selectedRows.Count - 1)
                    {
                        filter.Append(",");
                    }
                }
                filter.Append(")");
                dataView.RowFilter = filter.ToString();
                filteredDataTable = dataView.ToTable();
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog.Title = "Сохранить расчетную ведомость";
            saveFileDialog.FileName = "SalaryReport.docx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Word.Application wordApp = new Word.Application();
                Word.Document doc = wordApp.Documents.Add();
                FormatDocument(doc);

                Word.Paragraph dataParagraph = doc.Content.Paragraphs.Add();
                dataParagraph.Range.Font.Name = "Times New Roman";
                dataParagraph.Range.Font.Size = 14;
                dataParagraph.Range.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;
                dataParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                dataParagraph.Range.Font.Bold = 0;
                dataParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;

                foreach (DataRow row in filteredDataTable.Rows)
                {
                    string fullName = row["ФИО"].ToString();
                    Word.Paragraph fullNameParagraph = doc.Content.Paragraphs.Add();
                    fullNameParagraph.Range.Text = $"ФИО: {fullName}";
                    fullNameParagraph.Range.Font.Name = "Times New Roman";
                    fullNameParagraph.Range.Font.Size = 14;
                    fullNameParagraph.Range.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;
                    fullNameParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                    fullNameParagraph.Range.Font.Bold = 0;
                    fullNameParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;

                    fullNameParagraph.Range.InsertParagraphAfter();

                    DateTime startDate = (DateTime)row["Дата начала"];
                    DateTime endDate = (DateTime)row["Дата окончания"];
                    Word.Paragraph periodParagraph = doc.Content.Paragraphs.Add();
                    periodParagraph.Range.Text = $"Период: с {startDate.ToShortDateString()} по {endDate.ToShortDateString()}";
                    periodParagraph.Range.Font.Name = "Times New Roman";
                    periodParagraph.Range.Font.Size = 14;
                    periodParagraph.Range.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;
                    periodParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                    periodParagraph.Range.Font.Bold = 0;
                    periodParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;

                    periodParagraph.Range.InsertParagraphAfter();

                    decimal hoursWorked = (decimal)row["Отработано часов"];
                    Word.Paragraph hoursWorkedParagraph = doc.Content.Paragraphs.Add();
                    hoursWorkedParagraph.Range.Text = $"Часов отработано: {hoursWorked}";
                    hoursWorkedParagraph.Range.Font.Name = "Times New Roman";
                    hoursWorkedParagraph.Range.Font.Size = 14;
                    hoursWorkedParagraph.Range.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;
                    hoursWorkedParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                    hoursWorkedParagraph.Range.Font.Bold = 0;
                    hoursWorkedParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;

                    hoursWorkedParagraph.Range.InsertParagraphAfter();

                    decimal hourlyRate = (decimal)row["Часовая ставка"];
                    Word.Paragraph hourlyRateParagraph = doc.Content.Paragraphs.Add();
                    hourlyRateParagraph.Range.Text = $"Часовая ставка: {hourlyRate}";
                    hourlyRateParagraph.Range.Font.Name = "Times New Roman";
                    hourlyRateParagraph.Range.Font.Size = 14;
                    hourlyRateParagraph.Range.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;
                    hourlyRateParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                    hourlyRateParagraph.Range.Font.Bold = 0;
                    hourlyRateParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;

                    hourlyRateParagraph.Range.InsertParagraphAfter();

                    decimal gross = (decimal)row["Зарплата (без вычета налогов)"];
                    Word.Paragraph grossParagraph = doc.Content.Paragraphs.Add();
                    grossParagraph.Range.Text = $"Зарплата (без вычета налогов): {gross}";
                    grossParagraph.Range.Font.Name = "Times New Roman";
                    grossParagraph.Range.Font.Size = 14;
                    grossParagraph.Range.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;
                    grossParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                    grossParagraph.Range.Font.Bold = 0;
                    grossParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;

                    grossParagraph.Range.InsertParagraphAfter();

                    decimal net = (decimal)row["Зарплата (с вычетом налогов)"];
                    Word.Paragraph netParagraph = doc.Content.Paragraphs.Add();
                    netParagraph.Range.Text = $"Зарплата (с учетом вычета налогов): {net}";
                    netParagraph.Range.Font.Name = "Times New Roman";
                    netParagraph.Range.Font.Size = 14;
                    netParagraph.Range.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;
                    netParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                    netParagraph.Range.Font.Bold = 0;
                    netParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;

                    netParagraph.Range.InsertParagraphAfter();

                    decimal? bonus = row.Field<decimal?>("Премия");
                    if (bonus.HasValue)
                    {
                        Word.Paragraph bonusParagraph = doc.Content.Paragraphs.Add();
                        bonusParagraph.Range.Text = $"Премия: {bonus.Value}";
                        bonusParagraph.Range.Font.Name = "Times New Roman";
                        bonusParagraph.Range.Font.Size = 14;
                        bonusParagraph.Range.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpace1pt5;
                        bonusParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                        bonusParagraph.Range.Font.Bold = 0;
                        bonusParagraph.Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;

                        bonusParagraph.Range.InsertParagraphAfter();
                    }

                    dataParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustify;
                }

                await Task.Run(() =>
                {
                    doc.SaveAs(saveFileDialog.FileName);
                    doc.Close();
                    wordApp.Quit();
                });

                foreach (DataGridViewRow row in dataGridViewSalaries.Rows)
                {
                    if (!row.IsNewRow && selectedRows.Contains(Convert.ToInt32(row.Cells["SalaryId"].Value)))
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
                selectedRows.Clear();

                MessageBox.Show("Расчетная ведомость сохранена успешно.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Нет данных для экспорта в Word.");
            }
        }

        private void FormatDocument(Word.Document doc)
        {
            // Форматирование заголовка "РАСЧЕТ ЗАРАБОТНОЙ ПЛАТЫ"
            Word.Paragraph titleParagraph = doc.Content.Paragraphs.Add();
            titleParagraph.Range.Text = "РАСЧЕТ ЗАРАБОТНОЙ ПЛАТЫ";
            titleParagraph.Range.Font.Name = "Times New Roman";
            titleParagraph.Range.Font.Size = 16;
            titleParagraph.Range.Font.Bold = 1;
            titleParagraph.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            titleParagraph.Range.InsertParagraphAfter();
        }

        private void dataGridViewSalaries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow selectedRow = dataGridViewSalaries.Rows[rowIndex];
                int salaryId = Convert.ToInt32(selectedRow.Cells["SalaryId"].Value);

                if (selectedRows.Contains(salaryId))
                {
                    selectedRows.Remove(salaryId);
                    selectedRow.DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    selectedRows.Add(salaryId);
                    selectedRow.DefaultCellStyle.BackColor = Color.LightBlue;
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    SalaryAddEditForm addForm = new SalaryAddEditForm(sqlConnection);
                    addForm.ShowDialog();

                    // Обновить данные в таблице после закрытия формы добавления
                    LoadSalaries();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewSalaries.SelectedRows.Count > 0)
            {
                int salaryId = Convert.ToInt32(dataGridViewSalaries.SelectedRows[0].Cells["SalaryId"].Value);

                try
                {
                    SqlConnection sqlConnection = new SqlConnection(connectionString);

                    sqlConnection.Open();

                    SalaryAddEditForm editForm = new SalaryAddEditForm(sqlConnection, salaryId);
                    editForm.ShowDialog();

                    // Обновить данные в таблице после закрытия формы редактирования
                    LoadSalaries();

                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования.");
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewSalaries.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                        {
                            sqlConnection.Open();

                            foreach (DataGridViewRow row in dataGridViewSalaries.SelectedRows)
                            {
                                int salaryId = Convert.ToInt32(row.Cells["SalaryId"].Value);

                                string deleteQuery = "DELETE FROM Salaries WHERE SalaryId = @SalaryId";

                                using (SqlCommand command = new SqlCommand(deleteQuery, sqlConnection))
                                {
                                    command.Parameters.AddWithValue("@SalaryId", salaryId);
                                    command.ExecuteNonQuery();
                                }
                            }

                            // Обновить данные в таблице после удаления записей
                            LoadSalaries();

                            MessageBox.Show("Выбранная запись успешно удалена.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите записи для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text;
            LoadSalaries(searchQuery);
        }
    }
}
