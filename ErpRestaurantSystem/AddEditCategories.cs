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
    public partial class AddEditCategories : Form
    {
        private SqlConnection sqlConnection;
        private int id;
        public AddEditCategories(SqlConnection connection, int idTransf = -1)
        {
            InitializeComponent();

            sqlConnection = connection;
            id = idTransf;
            if (id == -1)
            {
                this.Text = "Добавление категории";
                okButton.Text = "Сохранить";
            }
            else
            {
                this.Text = "Редактирование категории";
                okButton.Text = "Сохранить";
            }
        }

        private async void okButton_Click(object sender, EventArgs e)
        {
            if (nameText.Text.Length > 0)
            {
                if (id == -1)
                {
                    SqlCommand addCategory = new SqlCommand("INSERT INTO [categories] (name, ordinem) VALUES (@name, IDENT_CURRENT('categories') )", sqlConnection);
                    addCategory.Parameters.AddWithValue("name", nameText.Text);

                    try
                    {
                        await addCategory.ExecuteNonQueryAsync();
                        Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    SqlCommand renameCategory = new SqlCommand("UPDATE [categories] SET name=@name WHERE id_category=@id", sqlConnection);
                    renameCategory.Parameters.AddWithValue("name", nameText.Text);
                    renameCategory.Parameters.AddWithValue("id", id);

                    try
                    {
                        await renameCategory.ExecuteNonQueryAsync();
                        Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Имя не может быть пустым", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void addedit_Load(object sender, EventArgs e)
        {
            if (id > -1)
            {
                SqlCommand loadNameCategory = new SqlCommand("SELECT name FROM [categories] WHERE id_category=@id", sqlConnection);
                loadNameCategory.Parameters.AddWithValue("id", id);

                try
                {
                    SqlDataReader sqlReader = await loadNameCategory.ExecuteReaderAsync();
                    await sqlReader.ReadAsync();

                    nameText.Text = Convert.ToString(sqlReader["name"]);

                    if (sqlReader != null && !sqlReader.IsClosed)
                        sqlReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void nameText_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ограничиваем длину значения до 50 символов
            if (nameText.Text.Length >= 50)
            {
                e.Handled = true; // Запрещаем ввод символа
            }
        }
    }
}
