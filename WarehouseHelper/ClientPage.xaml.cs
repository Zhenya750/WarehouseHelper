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
    public partial class ClientPage : Page
    {
        public ObservableCollection<Client> Clients { get; set; }

        public ClientPage()
        {
            InitializeComponent();

            Clients = new ObservableCollection<Client>(MainWindow.DB.Clients);
            clientList.ItemsSource = Clients;
        }


        private void ClientList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0 ||
                e.AddedItems[0] is Client == false)
            {
                detailedInfoWindow.Visibility = Visibility.Hidden;
                DataContext = null;

                return;
            }

            detailedInfoWindow.Visibility = Visibility.Visible;
            DataContext = e.AddedItems[0] as Client;
        }


        private void BtnRemoveClient_Click(object sender, RoutedEventArgs e)
        {
            var client = DataContext as Client;

            if (client is Client)
            {
                Clients.Remove(client);

                MainWindow.DB.Clients.Remove(client);
                MainWindow.DB.SaveChanges();
            }
        }


        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            var addClientWindow = new AddClientWindow();

            if (addClientWindow.ShowDialog() == true)
            {
                var client = new Client
                {
                    Name = addClientWindow.txtName.Text,
                    Email = addClientWindow.txtEmail.Text
                };

                MainWindow.DB.Clients.Add(client);
                MainWindow.DB.SaveChanges();

                Clients.Add(client);
            }
        }
    }
}
