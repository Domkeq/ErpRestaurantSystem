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

namespace ErpRestaurantSystem
{
    public partial class AddEditStock : Form
    {
        private SqlConnection sqlConnection;
        private int id;
        public AddEditStock(SqlConnection connection, int idTransf = -1)
        {
            InitializeComponent();

            sqlConnection = connection;
            id = idTransf;
            if (id == -1)
            {
                this.Text = "Добавление ресурса";
                submitButton.Text = "Сохранить";
            }
            else
            {
                this.Text = "Редактирование ресурса";
                submitButton.Text = "Сохранить";
            }
        }

        private async void submitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text) || string.IsNullOrEmpty(countTextBox.Text) ||
    string.IsNullOrEmpty(minCountTextBox.Text) || string.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Неполные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (id == -1)
            {
                SqlCommand addStock = new SqlCommand("INSERT INTO [stocks] (name, count, threshold, price_per_unit) VALUES (@name, @count, @threshold, @price)", sqlConnection);
                addStock.Parameters.AddWithValue("name", nameTextBox.Text);
                addStock.Parameters.AddWithValue("count", countTextBox.Text);
                addStock.Parameters.AddWithValue("threshold", minCountTextBox.Text);
                addStock.Parameters.AddWithValue("price", priceTextBox.Text);

                try
                {
                    await addStock.ExecuteNonQueryAsync();
                    Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                SqlCommand updateStock = new SqlCommand("UPDATE [stocks] SET name=@name, count=@count, threshold=@threshold, price_per_unit=@price WHERE id_stocks=@id", sqlConnection);
                updateStock.Parameters.AddWithValue("name", nameTextBox.Text);
                updateStock.Parameters.AddWithValue("count", countTextBox.Text);
                updateStock.Parameters.AddWithValue("threshold", minCountTextBox.Text);
                updateStock.Parameters.AddWithValue("price", priceTextBox.Text);
                updateStock.Parameters.AddWithValue("id", id);

                try
                {
                    await updateStock.ExecuteNonQueryAsync();
                    Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void AddEditStock_Load(object sender, EventArgs e)
        {
            if (id != -1)
            {
                SqlCommand loadStock = new SqlCommand("SELECT * FROM [stocks] WHERE id_stocks=@id", sqlConnection);
                loadStock.Parameters.AddWithValue("id", id);

                try
                {
                    SqlDataReader sqlReader = await loadStock.ExecuteReaderAsync();
                    await sqlReader.ReadAsync();

                    nameTextBox.Text = Convert.ToString(sqlReader["name"]);
                    countTextBox.Text = Convert.ToString(sqlReader["count"]);
                    minCountTextBox.Text = Convert.ToString(sqlReader["threshold"]);

                    // Проверка на DBNull и установка значения в priceTextBox
                    if (sqlReader["price_per_unit"] != DBNull.Value)
                    {
                        priceTextBox.Text = Convert.ToString(sqlReader["price_per_unit"]);
                    }

                    if (sqlReader != null && !sqlReader.IsClosed)
                        sqlReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void countTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только цифр, клавиш Backspace и Delete, и ограничиваем длину значения до 10 символов
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127 || countTextBox.Text.Length >= 10)
            {
                e.Handled = true; // Запрещаем ввод символа
            }
        }

        private void minCountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только цифр, клавиш Backspace и Delete, и ограничиваем длину значения до 10 символов
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127 || minCountTextBox.Text.Length >= 10)
            {
                e.Handled = true; // Запрещаем ввод символа
            }
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только цифр, клавиш Backspace и Delete, и ограничиваем длину значения до 10 символов
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127 || priceTextBox.Text.Length >= 10)
            {
                e.Handled = true; // Запрещаем ввод символа
            }
        }

        private void nameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Ограничиваем длину значения до 50 символов
            if (nameTextBox.Text.Length >= 50)
            {
                e.Handled = true; // Запрещаем ввод символа
            }
        }
    }
}
