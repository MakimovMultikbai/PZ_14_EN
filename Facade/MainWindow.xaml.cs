using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Facade
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ShopFacade shopFacade;

        public MainWindow()
        {
            InitializeComponent();
            shopFacade = new ShopFacade();
            RefreshProductList();
            RefreshCartList();
        }

        private void RefreshProductList()
        {
            ProductsListBox.ItemsSource = null;
            ProductsListBox.ItemsSource = shopFacade.GetAllProducts();
        }

        private void RefreshCartList()
        {
            CartListBox.ItemsSource = null;
            CartListBox.ItemsSource = shopFacade.GetCartProducts();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(ProductPriceTextBox.Text, out decimal price))
            {
                MessageBox.Show("Введите корректную цену!");
                return;
            }

            var product = new Product
            {
                Id = shopFacade.GetAllProducts().Count + 1,
                Name = ProductNameTextBox.Text,
                Price = price
            };

            shopFacade.AddProduct(product);
            RefreshProductList();
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsListBox.SelectedItem is Product product)
            {
                shopFacade.AddToCart(product);
                RefreshCartList();
            }
        }

        private void RemoveFromCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (CartListBox.SelectedItem is Product product)
            {
                shopFacade.RemoveFromCart(product);
                RefreshCartList();
            }
        }

        private void SaveToCsvButton_Click(object sender, RoutedEventArgs e)
        {
            shopFacade.SaveProductsToCsv("products.csv");
            MessageBox.Show("Продукты сохранены в CSV!");
        }

        private void LoadFromCsvButton_Click(object sender, RoutedEventArgs e)
        {
            shopFacade.LoadProductsFromCsv("products.csv");
            RefreshProductList();
        }
        private void SaveToXmlButton_Click(object sender, RoutedEventArgs e)
        {
            shopFacade.SaveProductsToXml("products.xml");
            MessageBox.Show("Продукты сохранены в XML!");
        }

        private void LoadFromXmlButton_Click(object sender, RoutedEventArgs e)
        {
            shopFacade.LoadProductsFromXml("products.xml");
            RefreshProductList();
        }
    }
}