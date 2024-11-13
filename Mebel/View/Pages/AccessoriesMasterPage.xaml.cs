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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mebel.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для AccessoriesMasterPage.xaml
    /// </summary>
    public partial class AccessoriesMasterPage : Page
    {

        private List<Accessories> accessories = App.context.Accessories.ToList();

        public AccessoriesMasterPage()
        {
            InitializeComponent();

            AccessoriesLv.ItemsSource = accessories;


            var sum = accessories.Sum(item => item.PurchasePrice);
            SumTbl.Text = sum.ToString();


            int count = AccessoriesLv.Items.Count;
            QtyTbl.Text = count.ToString();



        }

        private void MaterialLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void QualityCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelitBtn_Click(object sender, RoutedEventArgs e)
        {

        }


        private void Qty()
        {
            AccessoriesLv.ItemsSource = accessories;
            int count = AccessoriesLv.Items.Count;
            QtyTbl.Text = count.ToString();
        }
    }
}
