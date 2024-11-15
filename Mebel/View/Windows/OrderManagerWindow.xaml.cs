using Mebel.AppData;
using Mebel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для OrderManagerWindow.xaml
    /// </summary>
    public partial class OrderManagerWindow : Window
        
    {
        private ObservableCollection<ProductOrder> orderProd = new ObservableCollection<ProductOrder>();

        public OrderManagerWindow()
        {
            InitializeComponent();

            OrderLv.ItemsSource = orderProd; 

            CustomerCmb.DisplayMemberPath = "Title";
            CustomerCmb.SelectedValuePath = "Id";
            CustomerCmb.ItemsSource=App.context.User.ToList();

            ProductCmb.DisplayMemberPath = "Title";
            ProductCmb.SelectedValuePath = "Id";
            ProductCmb.ItemsSource=App.context.User.ToList();


        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order()
            {
                Number = Convert.ToInt32(NumberOrderTb.Text),
                Date = DateTime.Now,
                PlanDate = (DateTime)DateDp.SelectedDate,
                TitleOrder = NameOrdertb.Text,
                СustomerId = 3,
                StatusId = 1,
                ResponsibleManagerId = 1,
                Sceheme = null,
                ProductOrder = orderProd.Select(sp => new ProductOrder
                {
                    ProductId = sp.Product.Id,
                    Size = sp.Size,

                }
                ).ToList(), 

            };

            App.context.Order.Add(order);
            App.context.SaveChanges();

            Feedback.Information("Заказ добавлен");

            DialogResult = true;
            Close();


        }

        private void AddSize_Click(object sender, RoutedEventArgs e)
        {
            if (ProductCmb.SelectedItem is Product selectedProduct)
            {
                if (!string.IsNullOrWhiteSpace(SizeTb.Text))
                {
                    orderProd.Add(new ProductOrder
                    {
                        Product = selectedProduct,
                        Size = SizeTb.Text,
                    });
                    SizeTb.Text = string.Empty;


                }
                else
                {
                    Feedback.Warning("Введите корректный размер");
                }
            }

            else { Feedback.Warning("Выберите продукт"); }
            }
        
    }
}
