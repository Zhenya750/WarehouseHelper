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
using System.Windows.Shapes;

namespace WarehouseHelper
{
    public partial class LoadingDescriptionWindow : Window
    {
        public LoadingDescriptionWindow()
        {
            InitializeComponent();

            cbSupplier.ItemsSource = MainWindow.DB.Suppliers.ToList();
            cbProduct.ItemsSource = MainWindow.DB.Products.ToList();
        }


        public LoadingDescriptionWindow(Loading loading)
        {
            InitializeComponent();

            cbSupplier.ItemsSource = MainWindow.DB.Suppliers.ToList();
            cbProduct.ItemsSource = MainWindow.DB.Products.ToList();

            dpDatetime.SelectedDate = loading.Datetime;
            cbSupplier.SelectedItem = loading.Supplier;
            cbProduct.SelectedItem = loading.Product;
            txtCount.Text = loading.Count.ToString();
        }


        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            // validate is here
            // ...

            if (IsValid() == false) return;

            DialogResult = true;
        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }


        private void TxtCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cbProduct.SelectedItem is Product)
            {
                txtCount.Background = IsValid() ? Brushes.White : Brushes.Pink;
            }
        }


        private void CbProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtCount.IsEnabled = e.AddedItems.Count > 0;

            if (e.AddedItems.Count > 0)
            {
                txtCount.Text = txtCount.Text;
            }
        }


        private bool IsValid()
        {
            if (cbProduct.SelectedItem is Product == false)
                return false;

            int maxCount = (cbProduct.SelectedItem as Product).MaxCount;
            int currentCount = (cbProduct.SelectedItem as Product).Count;
            int count = 0;

            return int.TryParse(txtCount.Text, out count) 
                && count > 0 
                && count + currentCount <= maxCount;
        }
    }
}
