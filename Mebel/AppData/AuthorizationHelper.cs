using Mebel.Model;
using Mebel.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mebel.AppData
{
    internal class AuthorizationHelper
    {

        public static User CurrentUser { get; set; }
        public static string Captcha { get; set; }

        public static bool CheckDate(string login, string password)
        {

            //Получаем одну запись по условию из таблицы БД
            CurrentUser = App.context.User.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (CurrentUser != null)
            {

                //Вызывем метод для генерации капчи 
                // Если тру, то открываем страницы (каптча введена правильно)
                if (GenerateCaptcha() == true)
                {
                    MessageBox.Show("Пользователь авторизирован");
                    //Реализовать открытие разных страниц в зависимости от роли 
                    //Реализовать с помощью конструкции switch
                    switch (CurrentUser.RoleId)
                    {
                        case 1:

                            ManagerWindow managerWindow = new ManagerWindow();
                            managerWindow.Show();
                            break;
                        case 2:

                            DeputyDirectorWindow deputyDirectorWindow = new DeputyDirectorWindow();
                            deputyDirectorWindow.Show();
                            break;
                        case 3:

                            CustomerWindow сustomerWindow = new CustomerWindow();
                            сustomerWindow.Show();
                            break;
                        case 4:
                            DirectorWindow directorWindow = new DirectorWindow();
                            directorWindow.Show();
                            break;
                        case 5: 
                            MasterWindow masterWindow = new MasterWindow();
                            masterWindow.Show();
                            break;
                    }

                    return true;
                }
                else
                {
                    MessageBox.Show("Капча введена неправильно");
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
            return false;
        }


        public static bool GenerateCaptcha()
        {

            //Создадим генератор чисел
            Random random = new Random();
            //Очищаем поле с капчей
            Captcha = string.Empty;

            for (int i = 1; i < 5; i++)
            {
                char character = Convert.ToChar(random.Next(65, 91));

                Captcha += character;
            }

            CapthaWindow captchaWindow = new CapthaWindow();
            if (captchaWindow.ShowDialog() == true)
            {
                return true;
            }
            return false;

        }
    }
}

