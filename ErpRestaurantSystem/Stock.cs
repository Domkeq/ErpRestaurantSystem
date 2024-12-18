using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ErpRestaurantSystem
{
    public partial class Stock : Form
    {
        private SqlConnection sqlConnection;
        public Stock(SqlConnection connection)
        {
            InitializeComponent();
            sqlConnection = connection;
        }
        private async Task LoadStocksAsync()
        {
            SqlDataReader sqlReader = null;

            SqlCommand getStocksCommand = new SqlCommand("SELECT * FROM [stocks]", sqlConnection);

            try
            {
                sqlReader = await getStocksCommand.ExecuteReaderAsync();

                listStoks.Rows.Clear();

                while (await sqlReader.ReadAsync())
                {
                    int rowNumber = listStoks.Rows.Add();
                    listStoks.Rows[rowNumber].Cells[0].Value = Convert.ToString(sqlReader["name"]);
                    listStoks.Rows[rowNumber].Cells[1].Value = Convert.ToString(sqlReader["count"]);
                    listStoks.Rows[rowNumber].Cells[2].Value = Convert.ToInt32(sqlReader["id_stocks"]);

                    if (sqlReader["price_per_unit"] != DBNull.Value) // Проверка на DBNull
                    {
                        listStoks.Rows[rowNumber].Cells[3].Value = Convert.ToDouble(sqlReader["price_per_unit"]);
                    }
                    else
                    {
                        listStoks.Rows[rowNumber].Cells[3].Value = 0.0; // Значение по умолчанию, если значение равно DBNull
                    }

                    if (Convert.ToDouble(sqlReader["count"]) < Convert.ToDouble(sqlReader["threshold"]))
                    {
                        listStoks.Rows[rowNumber].Cells[1].Style.BackColor = Color.Red;
                        listStoks.Rows[rowNumber].Cells[3].Value = 1;
                    }
                    else
                        listStoks.Rows[rowNumber].Cells[3].Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                    sqlReader.Close();
                listStoks.Sort(listStoks.Columns[0], ListSortDirection.Ascending);
                listStoks.Sort(listStoks.Columns[3], ListSortDirection.Descending);
            }
        }

        private async void addStocks_Click(object sender, EventArgs e)
        {
            AddEditStock form = new AddEditStock(sqlConnection);
            form.ShowDialog();
            await LoadStocksAsync();
        }

        private async void editStocks_Click(object sender, EventArgs e)
        {
            if (listStoks.SelectedCells.Count > 0)
            {
                AddEditStock form = new AddEditStock(sqlConnection, Convert.ToInt32(listStoks.SelectedRows[0].Cells[2].Value));
                form.ShowDialog();
                await LoadStocksAsync();
            }
            else
            {
                MessageBox.Show("Не выделена ни одна строка", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void deleteStocks_Click(object sender, EventArgs e)
        {
            if (listStoks.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить ресурс?", "Удаление ресурса", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    SqlCommand deleteStock = new SqlCommand("DELETE FROM [stocks] WHERE id_stocks=@id; DELETE FROM [recipes] WHERE id_stocks=@id;", sqlConnection);
                    deleteStock.Parameters.AddWithValue("id", Convert.ToInt32(listStoks.SelectedRows[0].Cells[2].Value));

                    try
                    {
                        await deleteStock.ExecuteNonQueryAsync();
                        await LoadStocksAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выделена ни одна строка", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void updateStocksList_Click(object sender, EventArgs e)
        {
            await LoadStocksAsync();
        }

        private async void Stock_Load(object sender, EventArgs e)
        {
            await LoadStocksAsync();
        }
    }
}
