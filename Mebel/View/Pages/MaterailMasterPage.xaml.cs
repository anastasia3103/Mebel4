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
    /// Логика взаимодействия для MaterailMasterPage.xaml
    /// </summary>
    public partial class MaterailMasterPage : Page
    {
        private List<Material> material = App.context.Material.ToList();
        private List<QualityMaterial> qualityMaterial = App.context.QualityMaterial.ToList();

        public MaterailMasterPage()
        {
            InitializeComponent();

            MaterialLV.ItemsSource = material;

            qualityMaterial.Insert(0, new QualityMaterial() { Title = "Все качества" });
            MaterialLV.ItemsSource = material;

            QualityCmb.ItemsSource = qualityMaterial;

            QualityCmb.SelectedValuePath = "Id";
            QualityCmb.DisplayMemberPath = "Title";  
            

        }

        private void MaterialLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void

    }
}
