using Mebel.AppData;
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
using static System.Net.Mime.MediaTypeNames;

namespace Mebel.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для CapthaWindow.xaml
    /// </summary>
    public partial class CapthaWindow : Window
    {
        public CapthaWindow()
        {
            InitializeComponent();
            CapthaTbl.Text = AuthorizationHelper.Captcha;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextTb.Text == AuthorizationHelper.Captcha)
            {
                DialogResult = true;
            }
            else
            {
                DialogResult = false;
            }
        }
    }
}


   
