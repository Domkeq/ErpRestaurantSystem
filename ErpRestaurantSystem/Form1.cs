using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErpRestaurantSystem
{
    public partial class Form1 : Form
    {
        private string role;
        private int employeeId;
        //Data Source=DESKTOP-6GJA8NO;Initial Catalog=Restaurant_DB;Integrated Security=True
        private SqlConnection sqlConnection = null;
        int oldOrderId = -1;
        bool loading = true;
        bool listSync = false;
        public Form1(int employeeId, string role)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            this.role = role;
            ConfigureRolePermissions();
        }

        class ComboboxValue
        {
            public int Id { get; private set; }
            public string Name { get; private set; }

            public ComboboxValue(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private void ConfigureRolePermissions()
        {
            switch (role)
            {
                case "manager":
                    // Включите или отключите элементы управления, доступные для менеджеров
                    break;
                case "waiter":
                    toolStripSeparator2.Visible = false;
                    exitToolStripMenuItem.Visible = false;
                    складToolStripMenuItem.Visible = false;
                    toolStripSeparator5.Visible = false;
                    toolStripSeparator4.Visible = false;;
                    break;
                case "accountant":
                    складToolStripMenuItem.Visible = false;
                    менюToolStripMenuItem.Visible = false;
                    графикРаботыToolStripMenuItem.Visible = false;
                    информацияОСотрудникахToolStripMenuItem.Visible = false;
                    closeOrderButton.Enabled = false;
                    addOrderButton.Enabled = false;
                    menuDataGridView.Enabled = false;
                    listOrderDataGridView.Enabled = false;
                    orderDataGridView.Enabled = false;
                    toolStripSeparator5.Visible = false;
                    menuFilterComboBox.Enabled = false;
                    menuFilterTextBox.Enabled = false;
                    break;
                case "it":
                    // Включите или отключите элементы управления, доступные для сотрудников IT
                    break;
                default:
                    MessageBox.Show("Неизвестная роль, доступ к системе запрещен");
                    Application.Exit();
                    break;
            }
        }

        private void loadMenuList()
        {

            menuDataGridView.Rows.Clear();

            SqlDataReader sqlReader = null;

            string query = "";

            if (menuFilterTextBox.TextLength != 0 && menuFilterComboBox.SelectedIndex == 0)
            {
                query = "SELECT * FROM [menu] WHERE UPPER(name) like UPPER(@name)+'%' AND available='1' ORDER BY ordinem";
            }
            if (menuFilterTextBox.TextLength == 0 && menuFilterComboBox.SelectedIndex != 0)
            {
                query = "SELECT menu.* FROM [menu], [category_list] WHERE category_list.id_category=@categoryID AND category_list.id_menu=menu.id_menu AND menu.available='1' ORDER BY ordinem";
            }
            if (menuFilterTextBox.TextLength != 0 && menuFilterComboBox.SelectedIndex != 0)
            {
                query = "SELECT menu.* FROM [menu], [category_list] WHERE category_list.id_category=@categoryID AND category_list.id_menu=menu.id_menu AND UPPER(name) like UPPER(@name)+'%' AND menu.available='1' ORDER BY ordinem";
            }
            if (menuFilterTextBox.TextLength == 0 && menuFilterComboBox.SelectedIndex == 0)
            {
                query = "SELECT * FROM [menu] WHERE available='1' ORDER BY ordinem";
            }

            SqlCommand loadCategoryList = new SqlCommand(query, sqlConnection);

            if (menuFilterTextBox.TextLength != 0)
                loadCategoryList.Parameters.AddWithValue("name", menuFilterTextBox.Text);
            if (menuFilterComboBox.SelectedIndex != 0)
            {
                ComboboxValue combo = (ComboboxValue)menuFilterComboBox.SelectedItem;
                loadCategoryList.Parameters.AddWithValue("categoryID", combo.Id);
            }

            try
            {
                sqlReader = loadCategoryList.ExecuteReader();

                menuDataGridView.Rows.Clear();

                while (sqlReader.Read())
                {
                    int rowNumber = menuDataGridView.Rows.Add();
                    menuDataGridView.Rows[rowNumber].Cells[0].Value = Convert.ToInt32(sqlReader["id_menu"]);
                    menuDataGridView.Rows[rowNumber].Cells[1].Value = Convert.ToString(sqlReader["name"]);
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
        }

        private void loadCategoryComboBox()
        {
            SqlDataReader sqlReader = null;

            SqlCommand loadCategoryList = new SqlCommand("SELECT * FROM [categories] ORDER BY ordinem", sqlConnection);

            try
            {
                sqlReader = loadCategoryList.ExecuteReader();

                for (int i = menuFilterComboBox.Items.Count - 1; i > 0; i--)
                    menuFilterComboBox.Items.RemoveAt(i);

                while (sqlReader.Read())
                {
                    menuFilterComboBox.Items.Add(new ComboboxValue(Convert.ToInt32(sqlReader["id_category"]), Convert.ToString(sqlReader["name"])));
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
        }
        private void loadOrderGrid()
        {
            SqlDataReader sqlReader = null;
            SqlCommand getOrderGrid = new SqlCommand("SELECT * FROM orders WHERE closed='0'", sqlConnection);

            try
            {

                sqlReader = getOrderGrid.ExecuteReader();

                orderDataGridView.Rows.Clear();


                while (sqlReader.Read())
                {
                    int rowNumber = orderDataGridView.Rows.Add();
                    orderDataGridView.Rows[rowNumber].Cells[0].Value = Convert.ToInt32(sqlReader["id_orders"]);
                    orderDataGridView.Rows[rowNumber].Cells[1].Value = Convert.ToString(sqlReader["name"]);
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
        }
        private void updateListOrder()
        {
            string query = "";
            for (int i = 0; i < listOrderDataGridView.RowCount; i++)
                if (Convert.ToInt32(listOrderDataGridView.Rows[i].Cells[5].Value) == 1)
                    query += "UPDATE [order_list] SET count=@count" + Convert.ToString(i) + " WHERE id_order_list=@id" + Convert.ToString(i) + ";";

            if (query != "")
            {
                SqlCommand updateOrderList = new SqlCommand(query, sqlConnection);
                for (int i = 0; i < listOrderDataGridView.RowCount; i++)
                    if (Convert.ToInt32(listOrderDataGridView.Rows[i].Cells[5].Value) == 1)
                    {
                        updateOrderList.Parameters.AddWithValue("@count" + Convert.ToString(i), Convert.ToInt32(listOrderDataGridView.Rows[i].Cells[3].Value));
                        updateOrderList.Parameters.AddWithValue("@id" + Convert.ToString(i), Convert.ToInt32(listOrderDataGridView.Rows[i].Cells[0].Value));
                    }

                try
                {
                    updateOrderList.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string conectionString = ConfigurationManager.ConnectionStrings["ErpRestaurantSystem"].ConnectionString;
            sqlConnection = new SqlConnection(conectionString + ";MultipleActiveResultSets=True");

            sqlConnection.Open();

            menuFilterComboBox.Items.Add(new ComboboxValue(Convert.ToInt32(-1), Convert.ToString("Все")));
            menuFilterComboBox.SelectedIndex = 0;
            loadCategoryComboBox();
        }


        private void addOrderButton_Click_1(object sender, EventArgs e)
        {
            SqlCommand createOrder = new SqlCommand($"INSERT INTO [orders] (employee_id, time, closed, name) VALUES({employeeId}, GETDATE(), '0', IDENT_CURRENT('orders'))", sqlConnection);

            try
            {
                createOrder.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loadOrderGrid();
            orderDataGridView.CurrentCell = orderDataGridView.Rows[orderDataGridView.RowCount - 1].Cells[1];
            orderDataGridView.BeginEdit(true);
        }

        private void closeOrderButton_Click(object sender, EventArgs e)
        {
            if (orderDataGridView.SelectedCells.Count > 0)
            {
                delayUpdateOrderTimer.Stop();
                updateListOrder();

                ClosingOrder form;
                if (listOrderDataGridView.RowCount > 0)
                    form = new ClosingOrder(sqlConnection, Convert.ToInt32(orderDataGridView.SelectedRows[0].Cells[0].Value));
                else
                    form = new ClosingOrder(sqlConnection, Convert.ToInt32(orderDataGridView.SelectedRows[0].Cells[0].Value), true);
                form.ShowDialog();
                listSync = true;
                loadOrderGrid();
                listSync = false;
                listOrderDataGridView.Rows.Clear();
            }
            else
                MessageBox.Show("Заказ не выбран", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void menuFilterComboBox_DropDown(object sender, EventArgs e)
        {
            loadCategoryComboBox();
        }

        private void menuFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            loadMenuList();
        }

        private void menuFilterComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadMenuList();
        }

        private void menuTimer_Tick(object sender, EventArgs e)
        {
            loadMenuList();
            menuTimer.Stop();
        }

        private void menuDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            delayUpdateOrderTimer.Stop();

            if (orderDataGridView.SelectedCells.Count > 0)
            {
                int id = Convert.ToInt32(menuDataGridView.Rows[e.RowIndex].Cells[0].Value);
                int listIndex = -1;

                for (int i = 0; i < listOrderDataGridView.RowCount; i++)
                    if (Convert.ToInt32(listOrderDataGridView.Rows[i].Cells[6].Value) == id)
                        listIndex = i;

                if (listIndex == -1)
                {
                    listIndex = listOrderDataGridView.Rows.Add();
                    listOrderDataGridView.Rows[listIndex].Cells[1].Value = menuDataGridView.Rows[e.RowIndex].Cells[1].Value;
                    listOrderDataGridView.Rows[listIndex].Cells[3].Value = 1;
                    listOrderDataGridView.Rows[listIndex].Cells[2] = new DataGridViewButtonCell();
                    listOrderDataGridView.Rows[listIndex].Cells[2].Value = "-";
                    listOrderDataGridView.Rows[listIndex].Cells[4] = new DataGridViewButtonCell();
                    listOrderDataGridView.Rows[listIndex].Cells[4].Value = "+";
                    listOrderDataGridView.Rows[listIndex].Cells[5].Value = 0;
                    listOrderDataGridView.Rows[listIndex].Cells[6].Value = Convert.ToInt32(menuDataGridView.Rows[e.RowIndex].Cells[0].Value);
                    listOrderDataGridView.Rows[listIndex].Cells[3].Selected = true;
                    listOrderDataGridView.BeginEdit(true);

                    SqlDataReader sqlReader = null;
                    SqlCommand addOrderList = new SqlCommand("INSERT INTO [order_list] (id_orders, id_menu, count) VALUES(@id_orders, @id_menu, 1); SELECT IDENT_CURRENT('order_list') AS 'id'", sqlConnection);
                    addOrderList.Parameters.AddWithValue("id_orders", Convert.ToInt32(orderDataGridView.SelectedRows[0].Cells[0].Value));
                    addOrderList.Parameters.AddWithValue("id_menu", Convert.ToInt32(menuDataGridView.Rows[e.RowIndex].Cells[0].Value));

                    try
                    {
                        sqlReader = addOrderList.ExecuteReader();
                        sqlReader.Read();

                        listOrderDataGridView.Rows[listIndex].Cells[0].Value = Convert.ToInt32(sqlReader["id"]);
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
                }
                else
                {
                    listOrderDataGridView.Rows[listIndex].Cells[3].Value = Convert.ToInt32(listOrderDataGridView.Rows[listIndex].Cells[3].Value) + 1;
                    listOrderDataGridView.Rows[listIndex].Cells[5].Value = 1;
                    listOrderDataGridView.Rows[listIndex].Cells[3].Selected = true;
                    listOrderDataGridView.BeginEdit(true);
                }
            }
            else
                MessageBox.Show("Перед добавлением позиции выберите заказ", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            delayUpdateOrderTimer.Start();
        }

        private void ordersTimer_Tick(object sender, EventArgs e)
        {
            ordersTimer.Stop();
            loadOrderGrid();
            orderDataGridView.ClearSelection();
            loading = false;
        }

        private void orderDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SqlCommand updateNameOrder = new SqlCommand("UPDATE [orders] SET name=@name WHERE id_orders=@id", sqlConnection);

            updateNameOrder.Parameters.AddWithValue("name", Convert.ToString(orderDataGridView.Rows[e.RowIndex].Cells[1].Value));
            updateNameOrder.Parameters.AddWithValue("id", Convert.ToInt32(orderDataGridView.Rows[e.RowIndex].Cells[0].Value));

            try
            {
                updateNameOrder.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void orderDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (!loading && !listSync)
            {
                if (oldOrderId != -1)
                {
                    delayUpdateOrderTimer.Stop();
                    updateListOrder();
                }

                // Если нет выбранных строк, прекратить выполнение метода
                if (orderDataGridView.SelectedRows.Count == 0)
                {
                    return;
                }

                oldOrderId = Convert.ToInt32(orderDataGridView.SelectedRows[0].Cells[0].Value);

                SqlDataReader sqlReader = null;

                SqlCommand getOrderList = new SqlCommand("SELECT menu.name, order_list.count, order_list.id_menu, order_list.id_order_list FROM [order_list], [menu] WHERE order_list.id_orders=@id AND menu.id_menu=order_list.id_menu", sqlConnection);

                getOrderList.Parameters.AddWithValue("id", Convert.ToInt32(orderDataGridView.SelectedRows[0].Cells[0].Value));

                try
                {
                    sqlReader = getOrderList.ExecuteReader();

                    listOrderDataGridView.Rows.Clear();

                    while (sqlReader.Read())
                    {
                        int rowNumber = listOrderDataGridView.Rows.Add();
                        listOrderDataGridView.Rows[rowNumber].Cells[0].Value = Convert.ToInt32(sqlReader["id_order_list"]);
                        listOrderDataGridView.Rows[rowNumber].Cells[1].Value = Convert.ToString(sqlReader["name"]);
                        listOrderDataGridView.Rows[rowNumber].Cells[3].Value = Convert.ToInt32(sqlReader["count"]);
                        listOrderDataGridView.Rows[rowNumber].Cells[2] = new DataGridViewButtonCell();
                        listOrderDataGridView.Rows[rowNumber].Cells[2].Value = "-";
                        listOrderDataGridView.Rows[rowNumber].Cells[4] = new DataGridViewButtonCell();
                        listOrderDataGridView.Rows[rowNumber].Cells[4].Value = "+";
                        listOrderDataGridView.Rows[rowNumber].Cells[5].Value = 0;
                        listOrderDataGridView.Rows[rowNumber].Cells[6].Value = Convert.ToInt32(sqlReader["id_menu"]);
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
            }
        }

        private void delayUpdateOrderTimer_Tick(object sender, EventArgs e)
        {
            delayUpdateOrderTimer.Stop();
            updateListOrder();
        }

        private void listOrderDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            delayUpdateOrderTimer.Stop();
            listOrderDataGridView.Rows[e.RowIndex].Cells[5].Value = 1;
        }

        private void listOrderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            delayUpdateOrderTimer.Stop();

            if (e.RowIndex >= 0) // Проверяем, что событие происходит для обычной ячейки, а не для шапки таблицы
            {
                if (e.ColumnIndex == 2) // Нажата кнопка "-"
                {
                    int rowIndex = e.RowIndex;
                    int quantity = Convert.ToInt32(listOrderDataGridView.Rows[rowIndex].Cells[3].Value) - 1;
                    if (quantity < 1)
                    {
                        // Введенное значение количества меньше 1, удаляем позицию из заказа
                        int orderListId = Convert.ToInt32(listOrderDataGridView.Rows[rowIndex].Cells[0].Value);
                        SqlCommand delOrderList = new SqlCommand("DELETE FROM [order_list] WHERE id_order_list=@id", sqlConnection);
                        delOrderList.Parameters.AddWithValue("id", orderListId);
                        try
                        {
                            delOrderList.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        listOrderDataGridView.Rows.RemoveAt(rowIndex);
                    }
                    else
                    {
                        listOrderDataGridView.Rows[rowIndex].Cells[3].Value = quantity;
                        listOrderDataGridView.Rows[rowIndex].Cells[5].Value = 1; // Устанавливаем флаг изменения
                    }
                }
                else if (e.ColumnIndex == 4) // Нажата кнопка "+"
                {
                    int rowIndex = e.RowIndex;
                    int quantity = Convert.ToInt32(listOrderDataGridView.Rows[rowIndex].Cells[3].Value) + 1;
                    if (quantity > 100)
                    {
                        // Введенное значение количества больше 100, устанавливаем максимальное значение равным 100
                        MessageBox.Show("Количество не может быть больше 100. Установлено максимальное значение равным 100.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        quantity = 100;
                    }
                    listOrderDataGridView.Rows[rowIndex].Cells[3].Value = quantity;
                    listOrderDataGridView.Rows[rowIndex].Cells[5].Value = 1; // Устанавливаем флаг изменения
                }
            }

            delayUpdateOrderTimer.Start();
        }

        private void listOrderDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int quantity = Convert.ToInt32(listOrderDataGridView.Rows[rowIndex].Cells[3].Value);

            if (quantity < 1)
            {
                // Введенное значение количества меньше 1, удаляем позицию из заказа
                int orderListId = Convert.ToInt32(listOrderDataGridView.Rows[rowIndex].Cells[0].Value);
                SqlCommand delOrderList = new SqlCommand("DELETE FROM [order_list] WHERE id_order_list=@id", sqlConnection);
                delOrderList.Parameters.AddWithValue("id", orderListId);

                try
                {
                    delOrderList.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                listOrderDataGridView.Rows.RemoveAt(rowIndex);
            }
            else if (quantity > 100)
            {
                // Введенное значение количества больше 100, устанавливаем максимальное значение равным 100
                MessageBox.Show("Количество не может быть больше 100. Установлено максимальное значение равным 100.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                listOrderDataGridView.Rows[rowIndex].Cells[3].Value = 100;
            }

            delayUpdateOrderTimer.Start();
        }

        private void категорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categories form = new Categories(sqlConnection, this.role);
            form.Show();
        }

        private void orderHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            History_of_orders form = new History_of_orders(sqlConnection, this.role);
            form.Show();
        }

        private void складToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock form = new Stock(sqlConnection);
            form.Show();
        }

        private void товарыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products form = new Products(sqlConnection, this.role);
            form.Show();
        }

        private void учетПродажToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesReportForm form = new SalesReportForm();
            form.Show();
        }

        private void учетЗатратНаИнгредиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountingIngredientsForm form = new AccountingIngredientsForm();
            form.Show();
        }

        private void отчетДоходностиБлюдToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfitabilityReportForm form = new ProfitabilityReportForm();
            form.Show();
        }

        private void информацияОСотрудникахToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeManagement form = new EmployeeManagement(this.role);
            form.Show();
        }

        private void графикРаботыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkerScheduleForm form = new WorkerScheduleForm(this.role);
            form.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide(); // скрыть текущую форму
            LoginForm loginForm = new LoginForm();
            DialogResult loginResult = loginForm.ShowDialog();

            if (loginResult == DialogResult.OK)
            {
                int employeeId = loginForm.EmployeeId;
                string role = loginForm.Role;
                Form1 mainForm = new Form1(employeeId, role);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Не удалось войти. Проверьте ваш PIN-код и попробуйте снова.");
            }
        }

        private void расчетЗПToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalaryManagementForm form = new SalaryManagementForm(this.role, this.employeeId);
            form.Show();
        }
    }
}
