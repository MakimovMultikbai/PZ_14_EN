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

            RefreshProductsList();
            RefreshCartList();
        }

        private void RefreshProductsList()
        {
            ProductsListBox.Items.Clear();
            foreach (var product in shopFacade.GetAllProducts())
            {
                ProductsListBox.Items.Add(product);
            }
        }

        private void RefreshCartList()
        {
            CartListBox.Items.Clear();
            foreach (var product in shopFacade.GetCartProducts())
            {
                CartListBox.Items.Add(product);
            }
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

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            var productName = Microsoft.VisualBasic.Interaction.InputBox("Enter product name:", "New Product", "");
            if (!string.IsNullOrWhiteSpace(productName))
            {
                shopFacade.AddProduct(new Product { Name = productName });
                RefreshProductsList();
            }
        }

        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsListBox.SelectedItem is Product product)
            {
                shopFacade.RemoveProduct(product);
                RefreshProductsList();
            }
        }

        private void PlaceOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if (shopFacade.PlaceOrder())
            {
                MessageBox.Show("Order placed successfully!");
                RefreshCartList();
            }
            else
            {
                MessageBox.Show("Cart is empty!");
            }
        }

        private void SaveToCsvButton_Click(object sender, RoutedEventArgs e)
        {
            shopFacade.SaveToCsv();
            MessageBox.Show("Data saved to CSV!");
        }

        private void LoadFromCsvButton_Click(object sender, RoutedEventArgs e)
        {
            shopFacade.LoadFromCsv();
            RefreshProductsList();
            RefreshCartList();
            MessageBox.Show("Data loaded from CSV!");
        }

        private void SaveToXmlButton_Click(object sender, RoutedEventArgs e)
        {
            shopFacade.SaveToXml();
            MessageBox.Show("Data saved to XML!");
        }

        private void LoadFromXmlButton_Click(object sender, RoutedEventArgs e)
        {
            shopFacade.LoadFromXml();
            RefreshProductsList();
            RefreshCartList();
            MessageBox.Show("Data loaded from XML!");
        }
    }
}