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
        public List<DB.ProductType> Type { get; set; }
        public MainPage()
        {
            InitializeComponent();

            prod.ItemsSource = bd_connection.connection.Product.ToList();

            
        }

        private void cb_productType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        public void Filter()
        {
            //FilterProduct = bd_connection.connection.Product.ToList();
            //var searchingText = tb_search.Text.ToLower();
            //var productType = cb_productType.SelectedItem as ProductType;

            ////FilterProduct = Products.FindAll(product => product.Name.ToLower().Contains(searchingText));

            //if (productType.Id != 0)
            //    FilterProduct = Products.FindAll(product => product.ProductType == productType);
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
