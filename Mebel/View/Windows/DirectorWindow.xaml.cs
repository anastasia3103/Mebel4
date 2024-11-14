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

namespace Mebel.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для DirectorWindow.xaml
    /// </summary>
    public partial class DirectorWindow : Window
    {
        public DirectorWindow()
        {
            InitializeComponent();
        }

        private void MaterialBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.DirectorFrame = DirectorFrame;
            DirectorFrame.Navigate(new View.Pages.MaterialDirectorPage());
        }

        private void AccessoriesBtn_Click(object sender, RoutedEventArgs e)
        {

            FrameHelper.DirectorFrame = DirectorFrame;
            DirectorFrame.Navigate(new View.Pages.AccessoriesDirectorPage());
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            Close();
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameHelper.DirectorFrame = DirectorFrame;

            DirectorFrame.Navigate(new View.Pages.OrderList());

        }
    }
}

