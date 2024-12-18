using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErpRestaurantSystem
{
    public partial class AddEditEmployeeForm : Form
    {
        public Employee NewEmployee { get; set; }
        public bool IsEditMode { get; set; }

        public AddEditEmployeeForm()
        {
            InitializeComponent();
            maskedTextBoxPin.PasswordChar = '*';
            maskedTextBoxConfirmPin.PasswordChar = '*';
            // Заполнение списка ролей
            comboBoxRole.Items.AddRange(new string[] { "manager", "waiter", "accountant", "it" });
            comboBoxRole.SelectedIndex = 1; // По умолчанию выбран "waiter"
        }
        public void FillEmployeeData(Employee employee)
        {
            NewEmployee = employee;
            textBoxName.Text = employee.Name;
            textBoxSurname.Text = employee.Surname;
            textBoxPatronymic.Text = employee.Patronymic;
            comboBoxRole.SelectedItem = employee.Role;
            maskedTextBoxPin.Text = employee.PinCode.ToString();
            maskedTextBoxConfirmPin.Text = employee.PinCode.ToString();
        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            // Проверка ввода
            if (string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxSurname.Text) ||
                string.IsNullOrWhiteSpace(maskedTextBoxPin.Text) ||
                comboBoxRole.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            // Проверка PIN-кода
            string pinCode = maskedTextBoxPin.Text;
            if (!IsValidPinCode(pinCode))
            {
                MessageBox.Show("PIN-код должен состоять из 4-6 цифр.");
                return;
            }

            if (pinCode != maskedTextBoxConfirmPin.Text)
            {
                MessageBox.Show("PIN-коды не совпадают.");
                return;
            }

            // Создание нового сотрудника или обновление существующего
            if (NewEmployee == null)
            {
                NewEmployee = new Employee()
                {
                    Name = textBoxName.Text,
                    Surname = textBoxSurname.Text,
                    Patronymic = textBoxPatronymic.Text,
                    Role = comboBoxRole.SelectedItem.ToString(),
                    PinCode = int.Parse(pinCode)
                };
            }
            else
            {
                NewEmployee.Name = textBoxName.Text;
                NewEmployee.Surname = textBoxSurname.Text;
                NewEmployee.Patronymic = textBoxPatronymic.Text;
                NewEmployee.Role = comboBoxRole.SelectedItem.ToString();
                NewEmployee.PinCode = int.Parse(pinCode);
            }

            // Закрытие формы с результатом DialogResult.OK
            this.DialogResult = DialogResult.OK;
        }

        // Проверка валидности PIN-кода
        private bool IsValidPinCode(string pinCode)
        {
            return Regex.IsMatch(pinCode, @"^\d{4,6}$");
        }

        // Обработка изменения состояния CheckBox
        private void checkBoxShowPin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPin.Checked)
            {
                maskedTextBoxPin.PasswordChar = '\0';
                maskedTextBoxConfirmPin.PasswordChar = '\0';
            }
            else
            {
                maskedTextBoxPin.PasswordChar = '*';
                maskedTextBoxConfirmPin.PasswordChar = '*';
            }
        }

        // Обработка ввода в поле PIN-кода
        private void maskedTextBoxPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешить ввод только цифр
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Обработка ввода в поле PIN-кода
        private void maskedTextBoxConfirmPin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешить ввод только цифр
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
