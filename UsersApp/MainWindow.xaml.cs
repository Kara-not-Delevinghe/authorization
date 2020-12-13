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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();
            string role = textBoxRole.Text.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле введено не корректно!Не менее 5 символов.";
                textBoxLogin.Background = Brushes.PowderBlue;
            }
            else if (login.Length < 5)
            {
                passBox.ToolTip = "Это поле введено не корректно!";
                passBox.Background = Brushes.PowderBlue;
            }
            else if (pass != pass_2)
            {
                passBox_2.ToolTip = "Это поле введено не корректно!";
                passBox_2.Background = Brushes.PowderBlue;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Это поле введено не корректно!";
                textBoxEmail.Background = Brushes.PowderBlue;
            }
            else if (role.Length < 5 || !role.Contains("Администратор") || !role.Contains("Менеджер") || !role.Contains("Сотрудник"))
            {
                textBoxRole.ToolTip = "Это поле введено не корректно!";
                textBoxRole.Background = Brushes.PowderBlue;

                if (role == "Администратор")
                {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.Show();
                    Hide();
                }
                if (role == "Менеджер")
                {
                    ManagerWindow managerWindow = new ManagerWindow();
                    managerWindow.Show();
                    Hide();

                }

                if (role == "Сотрудник")
                {
                    EmployeeWindow employeeWindow = new EmployeeWindow();
                    employeeWindow.Show();
                    Hide();

                }


            }

            else {

                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;
                textBoxRole.ToolTip = "";
                textBoxRole.Background = Brushes.Transparent;


                MessageBox.Show("Все хорошо!");

                User user = new User(login, email, pass, role);

                db.Users.Add(user);
                db.SaveChanges();

            }


        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();

    }   }
}
