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
    public partial class ClientDescriptionWindow : Window
    {
        public ClientDescriptionWindow()
        {
            InitializeComponent();
        }


        public ClientDescriptionWindow(Client client)
        {
            InitializeComponent();

            txtName.Text = client.Name;
            txtEmail.Text = client.Email;
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
