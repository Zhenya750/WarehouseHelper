using Microsoft.EntityFrameworkCore;
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

namespace WarehouseHelper
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //using (var db = new ApplicationContext())
            //{
            //    db.SaveChanges();
            //}


            //using (var db = new ApplicationContext())
            //{
            //    var ss = db.Shipments
            //        .Include(shipment => shipment.Client)
            //        .Include(shipment => shipment.Product)
            //        .ToList();

            //    foreach (var s in ss)
            //    {
            //        Console.WriteLine($"#{s.Id}:");
            //        Console.WriteLine($"\tClient: {s.Client.Name} {s.Client.Email}");
            //        Console.WriteLine($"\tProduct: {s.Product.Name} {s.Product.Count}");
            //        Console.WriteLine();
            //    }
            //}



        }
    }
}
