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
    public partial class MainWindow : Window
    {
        public static ApplicationContext DB { get; private set; }

        public MainWindow()
        {
            InitializeComponent();

            frame.Navigate(new MainPage());

            DB = new ApplicationContext();
        }

        private void FillDatabaseByClients(int count)
        {
            if (DB is null) return;

            while (count-- > 0)
            {
                DB.Clients.Add(new Client
                {
                    Name = "Client_" + count,
                    Email = Name + "@mail.ru"
                });
            }

            DB.SaveChanges();
        }
    }
}
