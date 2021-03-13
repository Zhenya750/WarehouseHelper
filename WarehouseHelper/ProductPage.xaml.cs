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

            //using (var db = new ApplicationContext())
            //{
            //    var ss = db.Shipments
            //        .Include(shipment => shipment.Client)
            //        .Include(shipment => shipment.Product)
            //        .ToList();

            //    foreach (var s in ss)
            //    {
            //        Console.WriteLine($"#{s.Id}:");
            //        Console.WriteLine($"\tClient: {s.Client.Name} {s.Client.Email}");
            //        Console.WriteLine($"\tProduct: {s.Product.Name} {s.Product.Count}");
            //        Console.WriteLine();
            //    }
            //}
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
            var addProductWindow = new AddProductWindow();

            if (addProductWindow.ShowDialog() == true)
            {
                var product = new Product
                {
                    Name = addProductWindow.txtName.Text,
                    Count = int.Parse(addProductWindow.txtCount.Text),
                    MaxCount = int.Parse(addProductWindow.txtMaxCount.Text),
                    Description = addProductWindow.txtDescription.Text
                };

                MainWindow.DB.Products.Add(product);
                MainWindow.DB.SaveChanges();

                Products.Add(product);
            }
        }
    }
}
