using Mebel.Model;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Mebel.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrWhiteSpace(FullnameTb.Text))
                mes += "Введите ФИО\n";
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
                mes += "Введите логин\n";
            if (mes != "")
            if (string.IsNullOrWhiteSpace(PasswordPb.Password))
                    mes += "Введите пароль\n";
            if (mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            User newUser = new User
            {
                Fullname = FullnameTb.Text,
                Login = LoginTb.Text,
                Password = PasswordPb.Password,
                RoleId = 3,
                Photo = "фото"
            };

            App.context.User.Add(newUser);
            App.context.SaveChanges();
            MessageBox.Show("Пользователь добавлен");

            FullnameTb.Text = " ";
            LoginTb.Text = " ";
            PasswordPb.Password = " ";

            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            Close();

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
