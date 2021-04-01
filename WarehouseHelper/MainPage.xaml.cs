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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WarehouseHelper.Reports;

namespace WarehouseHelper
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductPage());
        }


        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage());
        }


        private void BtnSuppliers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SupplierPage());
        }


        private void BtnShipments_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShipmentPage());
        }


        private void BtnLoadings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoadingPage());
        }


        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            CreateReport(MainWindow.DB.Clients);
            CreateReport(MainWindow.DB.Suppliers);
        }


        private void CreateReport(IEnumerable<IVisitable> visitables)
        {
            var visitor = new TextExportVisitor();

            foreach (var visitable in visitables)
                visitable.Accept(visitor);
        }
    }
}
