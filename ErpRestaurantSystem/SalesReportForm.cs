using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
namespace ErpRestaurantSystem
{
    public partial class SalesReportForm : Form
    {
string connectionString = @"Data Source=DESKTOP-7KBLIPI\SQLEXPRESS;Initial Catalog=ErpRestaurantSystem;Integrated Security=True;MultipleActiveResultSets=True";
        private SqlConnection sqlConnection;
        private BindingSource bindingSource = new BindingSource();
        public SalesReportForm()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
            txtSearch.TextChanged += txtSearch_TextChanged;
        }

        private void ExportToExcel()
        {
            // Check if there is data to export
            if (dgvSalesReport.DataSource == null || dgvSalesReport.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта.");
                return;
            }

            Excel.Application excelApp = new Excel.Application();
            if (excelApp != null)
            {
                Excel.Workbook excelWorkbook = excelApp.Workbooks.Add();
                Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Sheets[1];

                int startCol = 1;
                int startRow = 1;
                for (int j = 0; j < dgvSalesReport.Columns.Count; j++, startCol++)
                {
                    excelWorksheet.Cells[startRow, startCol] = dgvSalesReport.Columns[j].Name;
                }

                startRow++;

                for (int i = 0; i < dgvSalesReport.Rows.Count; i++)
                {
                    startCol = 1;
                    for (int j = 0; j < dgvSalesReport.Columns.Count; j++, startCol++)
                    {
                        if (dgvSalesReport.Rows[i].Cells[j].Value != null)
                            excelWorksheet.Cells[startRow + i, startCol] = dgvSalesReport.Rows[i].Cells[j].Value.ToString();
                        else
                            excelWorksheet.Cells[startRow + i, startCol] = "";
                    }
                }

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDialog.FilterIndex = 2;
                saveDialog.RestoreDirectory = true;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    excelWorkbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Экспорт выполнен успешно");
                }

                // Disable prompts and alerts
                excelApp.DisplayAlerts = false;
                excelApp.UserControl = false;

                excelWorkbook.Close(false);
                excelApp.Quit();
            }
        }

        private void SalesReportForm_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = sqlConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"
                    SELECT 
                        menu.name as 'Название', 
                        SUM(order_list.count) as 'Количество продаж', 
                        SUM(order_list.count * menu.price) as TotalSales
                    FROM 
                        order_list
                    JOIN 
                        menu ON order_list.id_menu = menu.id_menu
                    JOIN 
                        orders ON order_list.id_orders = orders.id_orders
                    WHERE 
                        orders.closed = 1
                    GROUP BY 
                        menu.name
                    ORDER BY 
                        TotalSales DESC";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                System.Data.DataTable dataTable = new System.Data.DataTable();
                dataAdapter.Fill(dataTable);

                bindingSource.DataSource = dataTable;
                dgvSalesReport.DataSource = bindingSource;

                dgvSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvSalesReport.Columns[dgvSalesReport.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSalesReport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            sqlConnection.Close();
        }

        private void UpdateReportByDate()
        {
            // Проверяем, выбран ли период
            if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
            {
                MessageBox.Show("Начальная дата больше конечной даты!");
                return;
            }

            string query = $@"SELECT menu.name AS 'Название', COUNT(menu.name) AS 'Количество продаж', 
    SUM(menu.price) AS 'Выручка' 
    FROM orders 
    JOIN order_list ON order_list.id_orders = orders.id_orders 
    JOIN menu ON menu.id_menu = order_list.id_menu 
    WHERE orders.time >= '{dtpStartDate.Value.Date}' 
    AND orders.time < '{dtpEndDate.Value.Date.AddDays(1)}' 
    GROUP BY menu.name";

            SqlCommand command = new SqlCommand(query, sqlConnection);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataAdapter.Fill(dataTable);
            dgvSalesReport.DataSource = dataTable;

            // Automatically resize DataGridView to fit the data
            dgvSalesReport.AutoResizeColumns();
            dgvSalesReport.AutoResizeRows();
        }
        private void btnSearchReport_Click(object sender, EventArgs e)
        {
            UpdateReportByDate();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void UpdateReportByFoodName(string foodName)
        {
            sqlConnection.Open();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = sqlConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"
                    SELECT 
                        menu.name as 'Название', 
                        SUM(order_list.count) as 'Количество продаж', 
                        SUM(order_list.count * menu.price) as TotalSales
                    FROM 
                        order_list
                    JOIN 
                        menu ON order_list.id_menu = menu.id_menu
                    JOIN 
                        orders ON order_list.id_orders = orders.id_orders
                    WHERE 
                        orders.closed = 1 AND
                        menu.name LIKE @foodName
                    GROUP BY 
                        menu.name
                    ORDER BY 
                        TotalSales DESC";

                command.Parameters.AddWithValue("@foodName", "%" + foodName + "%");
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                System.Data.DataTable dataTable = new System.Data.DataTable();
                dataAdapter.Fill(dataTable);

                // Автоматическое масштабирование столбцов
                dgvSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvSalesReport.Columns[dgvSalesReport.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSalesReport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            sqlConnection.Close();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindingSource.Filter = $"Название LIKE '%{txtSearch.Text}%'";
        }

        private void btnResetDate_Click(object sender, EventArgs e)
        {
            // Сброс выбранной даты
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;

            // Обновление отчета за все время
            sqlConnection.Open();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = sqlConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"
            SELECT 
                menu.name as 'Название', 
                SUM(order_list.count) as 'Количество продаж', 
                SUM(order_list.count * menu.price) as TotalSales
            FROM 
                order_list
            JOIN 
                menu ON order_list.id_menu = menu.id_menu
            JOIN 
                orders ON order_list.id_orders = orders.id_orders
            WHERE 
                orders.closed = 1
            GROUP BY 
                menu.name
            ORDER BY 
                TotalSales DESC";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                System.Data.DataTable dataTable = new System.Data.DataTable();
                dataAdapter.Fill(dataTable);

                bindingSource.DataSource = dataTable;
                dgvSalesReport.DataSource = bindingSource;

                dgvSalesReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvSalesReport.Columns[dgvSalesReport.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSalesReport.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            sqlConnection.Close();
        }
    }
}
