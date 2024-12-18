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
    public partial class History_of_orders : Form
    {
        private SqlConnection sqlConnection;
        private string role;
        public History_of_orders(SqlConnection connection, string role)
        {
            InitializeComponent();

            sqlConnection = connection;
            this.role = role;
            ConfigureRolePermissions();
            loadOrderGrid();
        }

        private void ConfigureRolePermissions()
        {
            switch (role)
            {
                case "manager":
                    break;
                case "waiter":
                    // menuStrip1.Visible = false;
                    deleteOrder.Enabled = false;
                    break;
                case "accountant":
                    deleteOrder.Enabled = false;
                    break;
                case "it":
                    break;
                default:
                    MessageBox.Show("Неизвестная роль, доступ к системе запрещен");
                    Application.Exit();
                    break;
            }
        }

        private void loadOrderGrid()
        {
            SqlDataReader sqlReader = null;
            SqlCommand getOrders = new SqlCommand("SELECT * FROM [orders] WHERE closed='1' ORDER BY id_orders DESC", sqlConnection);

            try
            {
                sqlReader = getOrders.ExecuteReader();

                listOrder.Rows.Clear();

                while (sqlReader.Read())
                {
                    int rowNumber = listOrder.Rows.Add();
                    listOrder.Rows[rowNumber].Cells[0].Value = Convert.ToInt32(sqlReader["id_orders"]);
                    listOrder.Rows[rowNumber].Cells[1].Value = Convert.ToString(sqlReader["name"]);
                    listOrder.Rows[rowNumber].Cells[3].Value = Convert.ToDateTime(sqlReader["time"]);
                    listOrder.Rows[rowNumber].Cells[4].Value = Convert.ToDouble(sqlReader["sum"]);
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
            }

            if (listOrder.RowCount > 0)
            {
                for (int i = 0; i < listOrder.Rows.Count; i++)
                {
                    string composition = "";
                    SqlCommand getRecipesCommand = new SqlCommand("SELECT order_list.count, menu.name FROM [order_list], [menu] WHERE order_list.id_menu = menu.id_menu AND order_list.id_orders = @id_orders", sqlConnection);
                    getRecipesCommand.Parameters.AddWithValue("id_orders", listOrder.Rows[i].Cells[0].Value);
                    SqlDataReader sqlReaderSecond = null;

                    try
                    {
                        sqlReaderSecond = getRecipesCommand.ExecuteReader();

                        while (sqlReaderSecond.Read())
                        {
                            composition += Convert.ToString(sqlReaderSecond["name"]) + " Х " + Convert.ToString(sqlReaderSecond["count"]) + "; ";
                        }

                        listOrder.Rows[i].Cells[2].Value = composition;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (sqlReaderSecond != null && !sqlReaderSecond.IsClosed)
                            sqlReaderSecond.Close();
                    }
                }
            }
        }

        private void deleteOrder_Click(object sender, EventArgs e)
        {
            if (listOrder.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить этот заказ?", "Удаление заказа", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    SqlCommand delOrders = new SqlCommand("DELETE FROM [orders] WHERE id_orders=@id; DELETE FROM [order_list] WHERE id_orders=@id", sqlConnection);
                    delOrders.Parameters.AddWithValue("id", Convert.ToInt32(listOrder.SelectedRows[0].Cells[0].Value));

                    try
                    {
                        delOrders.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                loadOrderGrid();
            }
            else
                MessageBox.Show("Не выделена ни одна строка", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void updateOrderList_Click(object sender, EventArgs e)
        {
            loadOrderGrid();
        }
    }
}
