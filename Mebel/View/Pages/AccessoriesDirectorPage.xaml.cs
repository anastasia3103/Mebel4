using Mebel.AppData;
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
    /// Логика взаимодействия для AccessoriesDirectorPage.xaml
    /// </summary>
    public partial class AccessoriesDirectorPage : Page
    {
        private List<Accessories> accessories = App.context.Accessories.ToList();

        public AccessoriesDirectorPage()
        {

            InitializeComponent();
            AccessoriesLv.ItemsSource = accessories;


            var sum = accessories.Sum(item => item.PurchasePrice);
            SumTbl.Text = sum.ToString();

            int count = AccessoriesLv.Items.Count;
            QtyTbl.Text = count.ToString();
        }

        private void AccessoriesLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedAccessories = AccessoriesLv.SelectedItem as Accessories;
            if (selectedAccessories == null)
            {
                Feedback.Error("Ошибка получения");
                return;
            }
            if (!int.TryParse(EditTb.Text, out int newQuty) || newQuty < 0)
            {
                Feedback.Error("Вы ввели неверное число");
                return;
            }
            var result = MessageBox.Show($"Вы уверены, что хотите изменить количество?", "Подтверждение", MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            try
            {
                selectedAccessories.Qty = newQuty;
                App.context.SaveChanges();
                Feedback.Information("Количество обновлено");

                AccessoriesLv.ItemsSource = App.context.Accessories.ToList();

                EditTb.Clear();
            }
            catch { }
        }

        private void DelitBtn_Click(object sender, RoutedEventArgs e)
        {
            if(AccessoriesLv.SelectedItem == null)
            {
                Feedback.Information("Выберите фурнитуру для удаления");
                return;
            }

            Accessories selectedAcc = AccessoriesLv.SelectedItem as Accessories;

            var res = MessageBox.Show($"Вы уверены, что хотите удалить?", "Подтверждение", MessageBoxButton.YesNo);

            if (res == MessageBoxResult.Yes)
            {
                    App.context.Accessories.Remove(selectedAcc);
                App.context.SaveChanges();
                    Feedback.Information("Удалено");
                    AccessoriesLv.ItemsSource = App.context.Accessories.ToList();
            }
            Qty();


        }

        private void Qty()
        {
            AccessoriesLv.ItemsSource = App.context.Accessories.ToList(); ;
            int count = AccessoriesLv.Items.Count;
            QtyTbl.Text = count.ToString();
        }
    }
}
