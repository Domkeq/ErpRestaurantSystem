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
    public partial class Categories : Form
    {
        private SqlConnection sqlConnection;
        bool sync = false;
        private int employeeId;
        private string role;
        public Categories(SqlConnection connection, string role)
        {
            InitializeComponent(); 
            sqlConnection = connection;
            this.role = role;
            ConfigureRolePermissions();
            listCategories.Sort(listCategories.Columns[0], ListSortDirection.Ascending);
        }
        private void ConfigureRolePermissions()
        {
            switch (role)
            {
                case "manager":
                    break;
                case "waiter":
                    addCategory.Enabled = false;
                    renameCategory.Enabled = false;
                    deleteCategory.Enabled = false;
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
        private async void Categories_Load(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
        }

        private async Task LoadCategoriesAsync()
        {
            SqlDataReader sqlReader = null;

            SqlCommand getCategoriesCommand = new SqlCommand("SELECT * FROM [categories]", sqlConnection);

            try
            {
                sqlReader = await getCategoriesCommand.ExecuteReaderAsync();

                listCategories.Rows.Clear();

                while (await sqlReader.ReadAsync())
                {
                    int rowNumber = listCategories.Rows.Add();
                    listCategories.Rows[rowNumber].Cells[0].Value = Convert.ToInt32(sqlReader["ordinem"]);
                    listCategories.Rows[rowNumber].Cells[1].Value = Convert.ToString(sqlReader["name"]);
                    listCategories.Rows[rowNumber].Cells[2].Value = Convert.ToInt32(sqlReader["id_category"]);
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
                listCategories.Sort(listCategories.Columns[0], ListSortDirection.Ascending);
            }
        }

        private async void addCategory_Click(object sender, EventArgs e)
        {
            AddEditCategories form = new AddEditCategories(sqlConnection);
            form.ShowDialog();
            await LoadCategoriesAsync();
        }

        private async void renameCategory_Click(object sender, EventArgs e)
        {
            if (listCategories.SelectedCells.Count > 0)
            {
                AddEditCategories form = new AddEditCategories(sqlConnection, Convert.ToInt32(listCategories.SelectedRows[0].Cells[0].Value));
                form.ShowDialog();
                await LoadCategoriesAsync();
            }
            else
            {
                MessageBox.Show("Не выделена ни одна строка", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void deleteCategory_Click(object sender, EventArgs e)
        {
            if (listCategories.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы действительно хотите удалить эту категорию?", "Удаление категории", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                {
                    SqlCommand deleteCategory = new SqlCommand("DELETE FROM [categories] WHERE id_category=@id; DELETE FROM [category_list] WHERE id_category=@id", sqlConnection);
                    deleteCategory.Parameters.AddWithValue("id", Convert.ToInt32(listCategories.SelectedRows[0].Cells[2].Value));

                    try
                    {
                        await deleteCategory.ExecuteNonQueryAsync();
                        await LoadCategoriesAsync();
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

        private async void updateCategoryList_Click(object sender, EventArgs e)
        {
            await LoadCategoriesAsync();
        }

        private async void categoryUpper_Click(object sender, EventArgs e)
        {
            while (sync) { }
            sync = true;
            if (listCategories.SelectedRows.Count > 0)
            {
                int item = Convert.ToInt32(listCategories.SelectedRows[0].Index);

                if (item > 0)
                {

                    try
                    {
                        SqlCommand setOrdinem = new SqlCommand("UPDATE [categories] SET ordinem=@ordinemA WHERE id_category=@idA; UPDATE [categories] SET ordinem=@ordinemB WHERE id_category=@idB;", sqlConnection);
                        setOrdinem.Parameters.AddWithValue("ordinemA", listCategories.Rows[item - 1].Cells[0].Value);
                        setOrdinem.Parameters.AddWithValue("idA", listCategories.Rows[item].Cells[2].Value);
                        setOrdinem.Parameters.AddWithValue("ordinemB", listCategories.Rows[item].Cells[0].Value);
                        setOrdinem.Parameters.AddWithValue("idB", listCategories.Rows[item - 1].Cells[2].Value);
                        await setOrdinem.ExecuteNonQueryAsync();

                        await LoadCategoriesAsync();
                        listCategories.Rows[item - 1].Selected = true;
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

        private async void categoryDowner_Click(object sender, EventArgs e)
        {
            while (sync) { }
            sync = true;
            if (listCategories.SelectedRows.Count > 0)
            {
                int item = Convert.ToInt32(listCategories.SelectedRows[0].Index);

                if (item < listCategories.Rows.Count - 1)
                {

                    try
                    {
                        SqlCommand setOrdinem = new SqlCommand("UPDATE [categories] SET ordinem=@ordinemA WHERE id_category=@idA; UPDATE [categories] SET ordinem=@ordinemB WHERE id_category=@idB;", sqlConnection);
                        setOrdinem.Parameters.AddWithValue("ordinemA", listCategories.Rows[item + 1].Cells[0].Value);
                        setOrdinem.Parameters.AddWithValue("idA", listCategories.Rows[item].Cells[2].Value);
                        setOrdinem.Parameters.AddWithValue("ordinemB", listCategories.Rows[item].Cells[0].Value);
                        setOrdinem.Parameters.AddWithValue("idB", listCategories.Rows[item + 1].Cells[2].Value);
                        await setOrdinem.ExecuteNonQueryAsync();

                        await LoadCategoriesAsync();
                        listCategories.Rows[item + 1].Selected = true;
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
    }
}
