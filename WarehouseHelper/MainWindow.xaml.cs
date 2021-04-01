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
using WarehouseHelper.ContentGenerators;


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

            //FillDataBaseByClients(new ProxyGeneratorLogger(new DBContentGenerator()), 5);
        }


        private static void FillDataBaseByClients(IDBContentGenerator generator, int count)
        {
            DB.Clients.AddRange(generator.GenerateClients(count));
            DB.SaveChanges();
        }
    }
}
