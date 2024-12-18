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
    public partial class Products : Form
    {
        private SqlConnection sqlConnection;
        bool sync = false;
        private string role;
        public Products(SqlConnection connection, string role)
        {
            InitializeComponent();
            sqlConnection = connection;

            listProducts.Sort(listProducts.Columns[0], ListSortDirection.Ascending);
            listProducts.Sort(listProducts.Columns[6], ListSortDirection.Descending);
            this.role = role;
            ConfigureRolePermissions();
        }

        private void ConfigureRolePermissions()
        {
            switch (role)
            {
                case "manager":

                    break;
                case "waiter":
                    // menuStrip1.Visible = false;
                    addProducts.Enabled = false;
                    renameProducts.Enabled = false;
                    deleteProducts.Enabled = false;
                    break;
                case "accountant":
                    break;
                case "it":
                    break;
                default:
                    MessageBox.Show("Неизвестная роль, доступ к системе запрещен");
                    Application.Exit();
                    break;
            }
        }

        private async Task LoadProductsAsync()
        {
            SqlDataReader sqlReader = null;

            SqlCommand getProductsCommand = new SqlCommand("SELECT * FROM [menu] ORDER BY available", sqlConnection);

            try
            {
                sqlReader = await getProductsCommand.ExecuteReaderAsync();

                listProducts.Rows.Clear();

                while (await sqlReader.ReadAsync())
                {
                    int rowNumber = listProducts.Rows.Add();
                    listProducts.Rows[rowNumber].Cells[0].Value = Convert.ToInt32(sqlReader["ordinem"]);
                    listProducts.Rows[rowNumber].Cells[1].Value = Convert.ToString(sqlReader["name"]);
                    listProducts.Rows[rowNumber].Cells[2].Value = Convert.ToString(sqlReader["price"]);
                    listProducts.Rows[rowNumber].Cells[5].Value = Convert.ToInt32(sqlReader["id_menu"]);
                    listProducts.Rows[rowNumber].Cells[6].Value = Convert.ToInt32(sqlReader["available"]);
                    if (!Convert.ToBoolean(sqlReader["available"]))
                        listProducts.Rows[rowNumber].DefaultCellStyle.BackColor = Color.LightGray;
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
                listProducts.Sort(listProducts.Columns[0], ListSortDirection.Ascending);
                listProducts.Sort(listProducts.Columns[6], ListSortDirection.Descending);
            }

            if (listProducts.Rows.Count > 0)
            {
                for (int i = 0; i < listProducts.Rows.Count; i++)
                {
                    string recipes = "";
                    SqlCommand getRecipesCommand = new SqlCommand("SELECT stocks.name, recipes.quantity FROM [recipes], [stocks] WHERE recipes.id_stocks = stocks.id_stocks AND recipes.id_menu = @id_menu", sqlConnection);
                    getRecipesCommand.Parameters.AddWithValue("id_menu", listProducts.Rows[i].Cells[5].Value);
                    SqlDataReader sqlReaderSecond = null;

                    try
                    {
                        sqlReaderSecond = await getRecipesCommand.ExecuteReaderAsync();

                        while (await sqlReaderSecond.ReadAsync())
                        {
                            recipes += Convert.ToString(sqlReaderSecond["name"]) + " Х " + Convert.ToString(sqlReaderSecond["quantity"]) + "; ";
                        }

                        listProducts.Rows[i].Cells[4].Value = recipes;
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
                for (int i = 0; i < listProducts.Rows.Count; i++)
                {
                    string category = "";
                    SqlCommand getCategoryCommand = new SqlCommand("SELECT categories.name FROM [categories], [category_list] WHERE category_list.id_category = categories.id_category AND category_list.id_menu = @id_menu", sqlConnection);
                    getCategoryCommand.Parameters.AddWithValue("id_menu", listProducts.Rows[i].Cells[5].Value);
                    SqlDataReader sqlReaderSecond = null;

                    try
                    {
                        sqlReaderSecond = await getCategoryCommand.ExecuteReaderAsync();

                        while (await sqlReaderSecond.ReadAsync())
                        {
                            category += Convert.ToString(sqlReaderSecond["name"]) + "; ";
                        }

                        listProducts.Rows[i].Cells[3].Value = category;
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

            listProducts.Sort(listProducts.Columns[0], ListSortDirection.Ascending);
            listProducts.Sort(listProducts.Columns[6], ListSortDirection.Descending);
        }

        private async void addProducts_Click(object sender, EventArgs e)
        {
            AddEditProducts form = new AddEditProducts(sqlConnection);
            form.ShowDialog();
            await LoadProductsAsync();
        }

        private async void renameProducts_Click(object sender, EventArgs e)
        {
            if (listProducts.SelectedCells.Count > 0)
            {
                AddEditProducts form = new AddEditProducts(sqlConnection, Convert.ToInt32(listProducts.SelectedRows[0].Cells[5].Value));
                form.ShowDialog();
                await LoadProductsAsync();
            }
            else
            {
                MessageBox.Show("Не выделена ни одна строка", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void deleteProducts_Click(object sender, EventArgs e)
        {
            if (listProducts.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить этот товар?", "Удаление товара", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    SqlCommand deleteProduct = new SqlCommand("DELETE FROM [menu] WHERE id_menu=@id; DELETE FROM [recipes] WHERE id_menu=@id;", sqlConnection);
                    deleteProduct.Parameters.AddWithValue("id", Convert.ToInt32(listProducts.SelectedRows[0].Cells[5].Value));

                    try
                    {
                        await deleteProduct.ExecuteNonQueryAsync();
                        await LoadProductsAsync();
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

        private async void updateProductsList_Click(object sender, EventArgs e)
        {
            await LoadProductsAsync();
        }

        private async void productsUpper_Click(object sender, EventArgs e)
        {
            while (sync) { }
            sync = true;
            if (listProducts.SelectedRows.Count > 0)
            {
                int item = Convert.ToInt32(listProducts.SelectedRows[0].Index);

                if (item > 0)
                {

                    try
                    {
                        SqlCommand setOrdinem = new SqlCommand("UPDATE [menu] SET ordinem=@ordinemA WHERE id_menu=@idA; UPDATE [menu] SET ordinem=@ordinemB WHERE id_menu=@idB;", sqlConnection);
                        setOrdinem.Parameters.AddWithValue("ordinemA", listProducts.Rows[item - 1].Cells[0].Value);
                        setOrdinem.Parameters.AddWithValue("idA", listProducts.Rows[item].Cells[5].Value);
                        setOrdinem.Parameters.AddWithValue("ordinemB", listProducts.Rows[item].Cells[0].Value);
                        setOrdinem.Parameters.AddWithValue("idB", listProducts.Rows[item - 1].Cells[5].Value);
                        await setOrdinem.ExecuteNonQueryAsync();

                        await LoadProductsAsync();
                        listProducts.Rows[item - 1].Selected = true;
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

            sync = false;
        }

        private async void productsDowner_Click(object sender, EventArgs e)
        {
            while (sync) { }
            sync = true;
            if (listProducts.SelectedRows.Count > 0)
            {
                int item = Convert.ToInt32(listProducts.SelectedRows[0].Index);

                if (item < listProducts.Rows.Count - 1)
                {

                    try
                    {
                        SqlCommand setOrdinem = new SqlCommand("UPDATE [menu] SET ordinem=@ordinemA WHERE id_menu=@idA; UPDATE [menu] SET ordinem=@ordinemB WHERE id_menu=@idB;", sqlConnection);
                        setOrdinem.Parameters.AddWithValue("ordinemA", listProducts.Rows[item + 1].Cells[0].Value);
                        setOrdinem.Parameters.AddWithValue("idA", listProducts.Rows[item].Cells[5].Value);
                        setOrdinem.Parameters.AddWithValue("ordinemB", listProducts.Rows[item].Cells[0].Value);
                        setOrdinem.Parameters.AddWithValue("idB", listProducts.Rows[item + 1].Cells[5].Value);
                        await setOrdinem.ExecuteNonQueryAsync();

                        await LoadProductsAsync();
                        listProducts.Rows[item + 1].Selected = true;
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

            sync = false;
        }

        private async void Products_Load(object sender, EventArgs e)
        {
            await LoadProductsAsync();
        }
    }
}
