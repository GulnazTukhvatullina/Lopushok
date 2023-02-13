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

namespace Lopushok
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public List<DB.Product> Products { get; set; }
        public List<DB.Product> FilterProduct { get; set; }
       // public List<DB.ProductType> Type { get; set; }
        public MainPage()
        {
            InitializeComponent();

            prod.ItemsSource = bd_connection.connection.Product.ToList();

            var allTypes = bd_connection.connection.ProductType.ToList();
            allTypes.Insert(0, new ProductType
            {
                Name = "Все типы"
            });
            cb_productType.ItemsSource = allTypes;

            cb_productType.SelectedIndex = 0;

            var currentProduct = bd_connection.connection.Product.ToList();
            prod.ItemsSource = currentProduct;
        }

        private void cb_productType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        public void Filter()
        {
            var currentProduct = bd_connection.connection.Product.ToList();

            if (cb_productType.SelectedIndex > 0)
                currentProduct = currentProduct.Where(a => a.ProductType == cb_productType.SelectedItem as ProductType).ToList();

            currentProduct = currentProduct.Where(p => p.Name.ToLower().Contains(tb_search.Text.ToLower())).ToList();

            prod.ItemsSource = currentProduct.OrderBy(p => p.Article).ToList();
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void prod_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void prod_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ProductPage(prod.SelectedItem as DB.Product));
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductPage(new DB.Product()));
        }
    }
}
