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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mebel.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MaterialDirectorPage.xaml
    /// </summary>
    public partial class MaterialDirectorPage : Page
    {
        private List<Material> material = App.context.Material.ToList();
        private List<QualityMaterial> qualityMaterial = App.context.QualityMaterial.ToList();

        public MaterialDirectorPage()
        {
            InitializeComponent();
            Qty();

            MaterialLV.ItemsSource = material;

            qualityMaterial.Insert(0, new QualityMaterial() { Title = "Все качества" });
            MaterialLV.ItemsSource = material;

            QualityCmb.ItemsSource = qualityMaterial;

            QualityCmb.SelectedValuePath = "Id";
            QualityCmb.DisplayMemberPath = "Title";

        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

            var selectedMaterial = MaterialLV.SelectedItem as Material;
            if (selectedMaterial==null)
            {
                Feedback.Error("Ошибка получения");
                return;
            }
            if (!int.TryParse(EditTb.Text, out int newQuty) || newQuty<0)
            {
                Feedback.Error("Вы ввели неверное число");
                return;
            }
            var result = MessageBox.Show ($"Вы уверены, что хотите изменить количество?", "Подтверждение", MessageBoxButton.YesNo);

            if (result !=MessageBoxResult.Yes)
            {
                return;
            }
            try
            {
                selectedMaterial.Qty = newQuty;
                App.context.SaveChanges();
                Feedback.Information("Количество обновлено");

                MaterialLV.ItemsSource = App.context.Material.ToList();

                EditTb.Clear();
            }
            catch { }
        }

        private void DelitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialLV.SelectedItem == null)
            {
                Feedback.Information("Выберите материал для удаления");
                return;
            }

            Material selectedMaterial = MaterialLV.SelectedItem as Material;

            var res = MessageBox.Show($"Вы уверены, что хотите удалить?", "Подтверждение", MessageBoxButton.YesNo);

            if (res == MessageBoxResult.Yes)
            {
                App.context.Material.Remove(selectedMaterial);
                App.context.SaveChanges();
                Feedback.Information("Удалено");
                MaterialLV.ItemsSource = App.context.Material.ToList();
            }
            Qty();
        }

        private void MaterialLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Qty()
        {
            MaterialLV.ItemsSource = material;
            int count = MaterialLV.Items.Count;
            QtyTbl.Text = count.ToString();
        }

        private void QualityCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            QualityMaterial qualityMaterial = QualityCmb.SelectedItem as QualityMaterial;
            if (QualityCmb.SelectedIndex != 0)
            {
                MaterialLV.ItemsSource = material.Where(x => x.QualityMaterial.Id == qualityMaterial.Id);

            }
            else
            {
                MaterialLV.ItemsSource = material;
            }

        }

    }
}
