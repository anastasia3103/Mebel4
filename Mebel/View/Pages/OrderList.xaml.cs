using Mebel.AppData;
using Mebel.Model;
using Mebel.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;цукс
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mebel.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderList.xaml
    /// </summary>
    public partial class OrderList : Page
    {
        List<Order> order = App.context.Order.ToList();
        public OrderList()
        {
            InitializeComponent();

            OrderLv.ItemsSource = order;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderManagerWindow orderManagerWindow = new OrderManagerWindow();
            orderManagerWindow.ShowDialog();
        }
    }
}
