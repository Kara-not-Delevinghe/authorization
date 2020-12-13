using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string role = textBoxRole.Text.Trim();


            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле введено не корректно!";
                textBoxLogin.Background = Brushes.PowderBlue;
            }
            else if (login.Length < 5)
            {
                passBox.ToolTip = "Это поле введено не корректно!";
                passBox.Background = Brushes.PowderBlue;
            }
            else if (role.Length < 5 )
            {
                textBoxRole.ToolTip = "Это поле введено не корректно!";
                textBoxRole.Background = Brushes.PowderBlue;
            }

            else if (role == "Администратор")
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                Hide();
            }
            else if (role == "Менеджер")
            {
                ManagerWindow managerWindow = new ManagerWindow();
                managerWindow.Show();
                Hide();

            }

            else if (role == "Сотрудник")
            {
                EmployeeWindow employeeWindow = new EmployeeWindow();
                employeeWindow.Show();
                Hide();

            }

            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                textBoxRole.ToolTip = "";
                textBoxRole.Background = Brushes.Transparent;




                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                {

                    authUser = db.Users.Where(b => b.Login == login && b.Pass ==
                    pass && b.Role == role).FirstOrDefault();

                }

                if (authUser != null)
                    MessageBox.Show("Все хорошо!");
                else
                    MessageBox.Show("Вы ввели что-то некорректно!");

            }
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide();
            
        }
    }
}
