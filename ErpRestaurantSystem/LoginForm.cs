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
    public partial class LoginForm : Form
    {
        string connectionString = @"Data Source=DESKTOP-7KBLIPI\SQLEXPRESS;Initial Catalog=ErpRestaurantSystem;Integrated Security=True;MultipleActiveResultSets=True";
        public int EmployeeId { get; private set; }
        public string Role { get; private set; }
        private bool isClosing = false;
        private DateTime lastLoginAttempt = DateTime.MinValue;
        private int failedLoginAttempts = 0;

        public LoginForm()
        {
            InitializeComponent();
            txtPin.KeyPress += new KeyPressEventHandler(txtPin_KeyPress);
            this.FormClosing += new FormClosingEventHandler(LoginForm_FormClosing);
        }
        private void txtPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar);
        }

        private void AppendDigitToPin(string digit)
        {
            if (IsDigit(digit))
            {
                txtPin.AppendText(digit);
            }
        }

        private bool IsDigit(string text)
        {
            int number;
            return int.TryParse(text, out number);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppendDigitToPin("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AppendDigitToPin("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AppendDigitToPin("3");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AppendDigitToPin("4");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AppendDigitToPin("5");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AppendDigitToPin("6");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AppendDigitToPin("7");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AppendDigitToPin("8");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AppendDigitToPin("9");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtPin.Text.Length > 0)
            {
                txtPin.Text = txtPin.Text.Substring(0, txtPin.Text.Length - 1);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPin.Text = "";
        }
        private TimeSpan GetLockoutTime(int failedAttempts)
        {
            switch (failedAttempts)
            {
                case 6: return TimeSpan.FromHours(1);
                case 7: return TimeSpan.FromHours(6);
                default: return TimeSpan.FromDays(1);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                if (failedLoginAttempts >= 5) // Максимальное количество неудачных попыток
                {
                    var lockoutTime = GetLockoutTime(failedLoginAttempts);
                    if (DateTime.Now.Subtract(lastLoginAttempt) < lockoutTime)
                    {
                        MessageBox.Show($"Слишком много неудачных попыток входа. Пожалуйста, попробуйте через {lockoutTime.TotalMinutes} минут.");
                        return;
                    }
                    else
                    {
                        failedLoginAttempts = 0; // Сбрасываем счетчик после истечения времени блокировки
                    }
                }

                SqlCommand command = new SqlCommand("SELECT employee_id, role FROM employees WHERE pin_code = @pin_code", connection);
                command.Parameters.AddWithValue("@pin_code", txtPin.Text);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EmployeeId = reader.GetInt32(0);
                        Role = reader.GetString(1);
                    }
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (!isClosing) // Add this check
                    {
                        failedLoginAttempts++;
                        lastLoginAttempt = DateTime.Now;
                        MessageBox.Show("Неправильный PIN-код. Пожалуйста, попробуйте еще раз.");
                    }
                }
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                isClosing = true;
            }
        }
    }
}
