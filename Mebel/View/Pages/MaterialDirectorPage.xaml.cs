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

        }

        private void DelitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MaterialLV.SelectedIndex != -1)
            {
                string selectedItem = MaterialLV.SelectedValue as string;
                material.Remove(selectedItem);
            }
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

        }
    }
}
