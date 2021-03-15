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
    public partial class SupplierPage : Page
    {
        public ObservableCollection<Supplier> Suppliers { get; set; }


        public SupplierPage()
        {
            InitializeComponent();

            Suppliers = new ObservableCollection<Supplier>(MainWindow.DB.Suppliers);
            supplierList.ItemsSource = Suppliers;
        }


        private void SupplierList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0 ||
                e.AddedItems[0] is Supplier == false)
            {
                detailedInfoWindow.Visibility = Visibility.Hidden;
                DataContext = null;

                return;
            }

            detailedInfoWindow.Visibility = Visibility.Visible;
            DataContext = e.AddedItems[0] as Supplier;
        }


        private void BtnRemoveSupplier_Click(object sender, RoutedEventArgs e)
        {
            var supplier = DataContext as Supplier;

            if (supplier is Supplier)
            {
                Suppliers.Remove(supplier);

                MainWindow.DB.Suppliers.Remove(supplier);
                MainWindow.DB.SaveChanges();
            }
        }


        private void BtnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            var addSupplierWindow = new SupplierDescriptionWindow();

            if (addSupplierWindow.ShowDialog() == true)
            {
                var supplier = new Supplier
                {
                    Name = addSupplierWindow.txtName.Text,
                };

                MainWindow.DB.Suppliers.Add(supplier);
                MainWindow.DB.SaveChanges();

                Suppliers.Add(supplier);
            }
        }


        private void BtnEditSupplier_Click(object sender, RoutedEventArgs e)
        {
            var supplier = DataContext as Supplier;

            if (supplier is Supplier)
            {
                var editSupplierWindow = new SupplierDescriptionWindow(supplier);

                if (editSupplierWindow.ShowDialog() == true)
                {
                    supplier.Name = editSupplierWindow.txtName.Text;

                    MainWindow.DB.SaveChanges();

                    // 'reset' the same object in observable collection
                    // to make it update
                    int index = Suppliers.IndexOf(supplier);
                    Suppliers.Insert(index, supplier);
                    Suppliers.RemoveAt(index + 1);

                    supplierList.SelectedItem = supplier;
                }
            }
        }
    }
}
