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

namespace Decorator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IPizza _pizza;

        public MainWindow()
        {
            InitializeComponent();
            ResetOrder(null, null);
        }
        private void UpdatePizza()
        {
            DescriptionText.Text = _pizza.GetDescription();
            CostText.Text = $"Стоимость: {_pizza.GetCost()} руб.";
        }
        private void AddCheese(object sender, RoutedEventArgs e)
        {
            _pizza = new CheeseDecorator(_pizza);
            UpdatePizza();
        }
        private void AddMeat(object sender, RoutedEventArgs e)
        {
            _pizza = new MeatDecorator(_pizza);
            UpdatePizza();
        }
        private void AddVegetables(object sender, RoutedEventArgs e)
        {
            _pizza = new VegetablesDecorator(_pizza);
            UpdatePizza();
        }
        private void AddSauce(object sender, RoutedEventArgs e)
        {
            _pizza = new SauceDecorator(_pizza);
            UpdatePizza();
        }
        private void ResetOrder(object sender, RoutedEventArgs e)
        {
            _pizza = new MargheritaPizza();
            UpdatePizza();
        }
    }
}