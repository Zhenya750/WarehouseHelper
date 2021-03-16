using Microsoft.EntityFrameworkCore;
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
    public partial class ShipmentPage : Page
    {
        public ObservableCollection<Shipment> Shipments { get; set; }


        public ShipmentPage()
        {
            InitializeComponent();

            Shipments = new ObservableCollection<Shipment>(
                MainWindow.DB.Shipments
                .Include(s => s.Client)
                .Include(s => s.Product));

            shipmentList.ItemsSource = Shipments;
        }


        private void ShipmentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0 ||
                e.AddedItems[0] is Shipment == false)
            {
                detailedInfoWindow.Visibility = Visibility.Hidden;
                DataContext = null;

                return;
            }

            detailedInfoWindow.Visibility = Visibility.Visible;
            DataContext = e.AddedItems[0] as Shipment;
        }


        private void BtnRemoveShipment_Click(object sender, RoutedEventArgs e)
        {
            var shipment = DataContext as Shipment;

            if (shipment is Shipment)
            {
                Shipments.Remove(shipment);

                MainWindow.DB.Shipments.Remove(shipment);
                MainWindow.DB.SaveChanges();
            }
        }


        private void BtnAddShipment_Click(object sender, RoutedEventArgs e)
        {
            var addShipmentWindow = new ShipmentDescriptionWindow();

            if (addShipmentWindow.ShowDialog() == true)
            {
                var shipment = new Shipment
                {
                    Client = addShipmentWindow.cbClient.SelectedItem as Client,
                    Product = addShipmentWindow.cbProduct.SelectedItem as Product,
                    Count = int.Parse(addShipmentWindow.txtCount.Text)
                };

                var datetime = addShipmentWindow.dpDatetime.SelectedDate;
                if (datetime.HasValue)
                {
                    shipment.Datetime = datetime.Value;
                }

                shipment.Product.Count -= shipment.Count;

                MainWindow.DB.Shipments.Add(shipment);
                MainWindow.DB.SaveChanges();

                Shipments.Add(shipment);
            }
        }


        private void BtnEditShipment_Click(object sender, RoutedEventArgs e)
        {
            var shipment = DataContext as Shipment;

            if (shipment is Shipment)
            {
                shipment.Product.Count += shipment.Count;

                var editShipmentWindow = new ShipmentDescriptionWindow(shipment);

                if (editShipmentWindow.ShowDialog() == true)
                {
                    var datetime = editShipmentWindow.dpDatetime.SelectedDate;
                    if (datetime.HasValue)
                    {
                        shipment.Datetime = datetime.Value;
                    }

                    shipment.Client = editShipmentWindow.cbClient.SelectedItem as Client;
                    shipment.Product = editShipmentWindow.cbProduct.SelectedItem as Product;
                    shipment.Count = int.Parse(editShipmentWindow.txtCount.Text);
                    shipment.Product.Count -= shipment.Count;

                    MainWindow.DB.SaveChanges();

                    // 'reset' the same object in observable collection
                    // to make it update
                    int index = Shipments.IndexOf(shipment);
                    Shipments.Insert(index, shipment);
                    Shipments.RemoveAt(index + 1);

                    shipmentList.SelectedItem = shipment;
                }
            }
        }
    }
}
