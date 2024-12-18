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
using Excel = Microsoft.Office.Interop.Excel;

namespace ErpRestaurantSystem
{
    public partial class AccountingIngredientsForm : Form
    {
        private SqlConnection sqlConnection;
string connectionString = @"Data Source=DESKTOP-7KBLIPI\SQLEXPRESS;Initial Catalog=ErpRestaurantSystem;Integrated Security=True;MultipleActiveResultSets=True";
        private string dishFilter = "";
        private bool onlyAvailable = false;
        public AccountingIngredientsForm()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            txtDishFilter.TextChanged += TxtDishFilter_TextChanged;
            chkOnlyAvailable.CheckedChanged += ChkOnlyAvailable_CheckedChanged;
        }

        private void CalculateIngredientCosts()
        {
            sqlConnection.Open();

            string availabilityCondition = "";
            if (onlyAvailable)
            {
                availabilityCondition = "AND menu.available = 0";
            }

            string query = $@"
        SELECT 
            menu.name AS 'Блюдо',
            stocks.name AS 'Ингредиент', 
            recipes.quantity AS 'Количество',
            (recipes.quantity * stocks.price_per_unit) AS 'Стоимость'
        FROM 
            recipes
        JOIN 
            menu ON recipes.id_menu = menu.id_menu
        JOIN 
            stocks ON recipes.id_stocks = stocks.id_stocks
        WHERE 
            menu.name LIKE '%{dishFilter}%'
            {availabilityCondition}
        ORDER BY
            menu.ordinem";

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgvIngredientCosts.DataSource = dataTable;

                // Автоматическое масштабирование столбцов
                dgvIngredientCosts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvIngredientCosts.Columns[dgvIngredientCosts.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvIngredientCosts.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            sqlConnection.Close();
        }

        private void AccountingIngredientsForm_Load(object sender, EventArgs e)
        {
            CalculateIngredientCosts();
        }

        private void TxtDishFilter_TextChanged(object sender, EventArgs e)
        {
            dishFilter = txtDishFilter.Text;
            CalculateIngredientCosts();
        }

        private void ChkOnlyAvailable_CheckedChanged(object sender, EventArgs e)
        {
            onlyAvailable = !chkOnlyAvailable.Checked;
            CalculateIngredientCosts();
        }

        private void ExportToExcel(DataTable dataTable)
        {
            // Проверка наличия данных для экспорта
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта в Excel.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файлы Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Выберите место сохранения файла Excel";
            saveFileDialog.FileName = "Название файла.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.ActiveSheet;

                // Заполнение заголовков столбцов на русском языке
                string[] columnNames = { "Блюдо", "Ингредиент", "Количество", "Стоимость" };
                for (int i = 0; i < columnNames.Length; i++)
                {
                    worksheet.Cells[1, i + 1] = columnNames[i];
                }

                // Заполнение данных
                for (int row = 0; row < dataTable.Rows.Count; row++)
                {
                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        worksheet.Cells[row + 2, col + 1] = dataTable.Rows[row][col];
                    }
                }

                // Автоматическое масштабирование столбцов
                worksheet.Columns.AutoFit();

                // Сохранение файла Excel
                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();

                // Освобождение ресурсов
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

                MessageBox.Show("Файл успешно экспортирован.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            DataTable dataTable = (DataTable)dgvIngredientCosts.DataSource;
            ExportToExcel(dataTable);
        }
    }
}
