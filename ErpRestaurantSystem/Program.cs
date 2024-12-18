using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErpRestaurantSystem
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                LoginForm loginForm = new LoginForm();
                DialogResult loginResult = loginForm.ShowDialog();

                if (loginResult == DialogResult.OK)
                {
                    int employeeId = loginForm.EmployeeId;
                    string role = loginForm.Role;
                    Application.Run(new Form1(employeeId, role));
                }
                else
                {
                    MessageBox.Show("Не удалось войти. Проверьте ваш PIN-код и попробуйте снова.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Произошла ошибка: {e.Message}\n\nStack Trace:\n{e.StackTrace}");
            }
        }
    }
}
