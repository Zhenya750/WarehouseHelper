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
    public partial class ProductDescriptionWindow : Window
    {
        public ProductDescriptionWindow()
        {
            InitializeComponent();
        }

        public ProductDescriptionWindow(Product product)
        {
            InitializeComponent();

            txtName.Text = product.Name;
            txtCount.Text = product.Count.ToString();
            txtMaxCount.Text = product.MaxCount.ToString();
            txtDescription.Text = product.Description;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            // input data validation here
            // ...

            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
