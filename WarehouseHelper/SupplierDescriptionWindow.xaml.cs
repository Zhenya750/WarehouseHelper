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
    public partial class SupplierDescriptionWindow : Window
    {
        public SupplierDescriptionWindow()
        {
            InitializeComponent();
        }


        public SupplierDescriptionWindow(Supplier supplier)
        {
            InitializeComponent();

            txtName.Text = supplier.Name;
        }


        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            // validation here
            // ...

            DialogResult = true;
        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
