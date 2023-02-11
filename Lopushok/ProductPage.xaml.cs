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
using Lopushok.DB;
using System.IO;
using Microsoft.Win32;

namespace Lopushok
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public static DB.Product product { get; set; }
        public List<ProductType> Types { get; set; }
        public List<Workshop> Workshops { get; set; }
        public ProductPage(DB.Product prod)
        {
            InitializeComponent();

            product = prod;

            Types = bd_connection.connection.ProductType.ToList();
            Workshops = bd_connection.connection.Workshop.ToList();
            this.DataContext = this;
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            if(product.Id == 0)
                bd_connection.connection.Product.Add(product);
            bd_connection.connection.SaveChanges();
            NavigationService.Navigate(new MainPage());
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_addImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.jpg|*.jpg|*.png|*.png"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                product.Image = File.ReadAllBytes(openFile.FileName);
                img_product.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }
    }
}
