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
using System.Windows.Forms.DataVisualization.Charting;

namespace ErpRestaurantSystem
{
    public partial class ProfitabilityReportForm : Form
    {
        private SqlConnection sqlConnection;
string connectionString = @"Data Source=DESKTOP-7KBLIPI\SQLEXPRESS;Initial Catalog=ErpRestaurantSystem;Integrated Security=True;MultipleActiveResultSets=True";
        private Chart profitabilityChart;
        private DataTable dataTable;

        public ProfitabilityReportForm()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);

            profitabilityChart = new Chart();
            profitabilityChart.Visible = false;
            profitabilityChart.Dock = DockStyle.None;
            profitabilityChart.Size = new System.Drawing.Size(400, 300);
            profitabilityChart.Location = new System.Drawing.Point(750, 50);

            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
        }
        private void CalculateDishProfitability()
        {
            string query = @"
        SELECT 
            menu.name AS 'Dish',
            (menu.price - SUM(recipes.quantity * stocks.price_per_unit)) AS 'Profit'
        FROM 
            menu
        JOIN 
            recipes ON menu.id_menu = recipes.id_menu
        JOIN 
            stocks ON recipes.id_stocks = stocks.id_stocks
        GROUP BY 
            menu.name, menu.price";

            using (SqlCommand command = new SqlCommand(query, sqlConnection))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Переименовать столбцы
                dataTable.Columns["Dish"].ColumnName = "Блюдо";
                dataTable.Columns["Profit"].ColumnName = "Доходность";

                dgvDishProfitability.DataSource = dataTable; // DataGridView

                // Настроить график
                profitabilityChart.DataSource = dataTable;
                profitabilityChart.Series.Clear();
                profitabilityChart.Series.Add("Доходность");
                profitabilityChart.Series["Доходность"].ChartType = SeriesChartType.Column;
                profitabilityChart.Series["Доходность"].XValueMember = "Блюдо";
                profitabilityChart.Series["Доходность"].YValueMembers = "Доходность";
                profitabilityChart.ChartAreas.Clear();
                profitabilityChart.ChartAreas.Add(new ChartArea("MainArea"));
                profitabilityChart.ChartAreas["MainArea"].AxisX.Interval = 1; // Установить интервал между метками оси X
            }
        }



        private void ProfitabilityReportForm_Load(object sender, EventArgs e)
        {
            CalculateDishProfitability();

            // Автоматическое масштабирование столбцов
            dgvDishProfitability.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvDishProfitability.Columns[dgvDishProfitability.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvDishProfitability.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            Controls.Add(profitabilityChart); // Добавить график на форму
        }

        private bool isChartVisible = false; // Переменная для отслеживания состояния видимости элемента
        private void buttonShowChart_Click(object sender, EventArgs e)
        {
            profitabilityChart.Visible = !profitabilityChart.Visible;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBoxSearch.Text;

            if (!string.IsNullOrEmpty(searchValue))
            {
                DataView dataView = dataTable.DefaultView;
                dataView.RowFilter = $"[Блюдо] LIKE '%{searchValue}%'";

                dgvDishProfitability.DataSource = dataView;
            }
            else
            {
                DataView dataView = dataTable.DefaultView;
                dataView.RowFilter = string.Empty;

                dgvDishProfitability.DataSource = dataView;
            }
        }
        private void ExportDataTableToExcel(DataTable dataTable, string filePath)
        {
            // Create Excel Application
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.DisplayAlerts = false;

            // Create a new Workbook
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(Type.Missing);

            // Create a new Worksheet
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.ActiveSheet;

            // Set the DataTable data to the Worksheet
            worksheet.Name = "Profitability Report";

            // Записываем переименованные названия столбцов
            for (int i = 1; i <= dataTable.Columns.Count; i++)
            {
                worksheet.Cells[1, i] = GetLocalizedColumnName(dataTable.Columns[i - 1].ColumnName);
            }

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j].ToString();
                }
            }

            // Save the Workbook
            workbook.SaveAs(filePath);

            // Clean up resources
            workbook.Close();
            excel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);

            worksheet = null;
            workbook = null;
            excel = null;

            // Garbage collection
            GC.Collect();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        // Export DataTable to Excel
                        ExportDataTableToExcel(dataTable, filePath);

                        MessageBox.Show("Таблица успешно экспортирована!", "Экспорт завершен", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("В процессе экспорта произошла ошибка: " + ex.Message, "Ошибка экспорта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetLocalizedColumnName(string columnName)
        {
            // Метод для получения локализованного названия столбца
            switch (columnName)
            {
                case "Блюдо":
                    return "Dish";
                case "Доходность":
                    return "Profit";
                default:
                    return columnName;
            }
        }
    }
}
