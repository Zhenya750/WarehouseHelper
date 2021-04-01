using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WarehouseHelper
{
    public partial class ProductPage : Page
    {
        public ObservableCollection<Product> Products { get; set; }


        public ProductPage()
        {
            InitializeComponent();

            Products = new ObservableCollection<Product>(MainWindow.DB.Products);

            productList.ItemsSource = Products;
        }


        private void ProductList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0 ||
                e.AddedItems[0] is Product == false)
            {
                detailedInfoWindow.Visibility = Visibility.Hidden;
                DataContext = null;

                return;
            }

            detailedInfoWindow.Visibility = Visibility.Visible;
            DataContext = e.AddedItems[0] as Product;
        }


        private void BtnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = DataContext as Product;

            if (product is Product)
            {
                Products.Remove(product);

                MainWindow.DB.Products.Remove(product);
                MainWindow.DB.SaveChanges();
            }
        }


        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProductDescriptionWindow();

            if (window.ShowDialog() == true)
            {
                var product = Product.CreateBuilder()
                    .SetName(window.txtName.Text)
                    .SetCount(int.Parse(window.txtCount.Text))
                    .SetMaxCount(int.Parse(window.txtMaxCount.Text))
                    .SetDescription(window.txtDescription.Text)
                    .Build();

                MainWindow.DB.Products.Add(product);
                MainWindow.DB.SaveChanges();

                Products.Add(product);
            }
        }


        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = DataContext as Product;

            if (product is Product)
            {
                var editProductWindow = new ProductDescriptionWindow(product);

                if (editProductWindow.ShowDialog() == true)
                {
                    product.Name = editProductWindow.txtName.Text;
                    product.Count = int.Parse(editProductWindow.txtCount.Text);
                    product.MaxCount = int.Parse(editProductWindow.txtMaxCount.Text);
                    product.Description = editProductWindow.txtDescription.Text;

                    MainWindow.DB.SaveChanges();

                    // 'reset' the same object in observable collection
                    // to make it update
                    int index = Products.IndexOf(product);
                    Products.Insert(index, product);
                    Products.RemoveAt(index + 1);

                    productList.SelectedItem = product;
                }
            }
        }
    }
}
