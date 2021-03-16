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
    public partial class LoadingPage : Page
    {
        public ObservableCollection<Loading> Loadings { get; set; }


        public LoadingPage()
        {
            InitializeComponent();

            Loadings = new ObservableCollection<Loading>(
                MainWindow.DB.Loadings
                .Include(s => s.Supplier)
                .Include(s => s.Product));

            loadingList.ItemsSource = Loadings;
        }


        private void LoadingList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0 ||
                e.AddedItems[0] is Loading == false)
            {
                detailedInfoWindow.Visibility = Visibility.Hidden;
                DataContext = null;

                return;
            }

            detailedInfoWindow.Visibility = Visibility.Visible;
            DataContext = e.AddedItems[0] as Loading;
        }


        private void BtnRemoveLoading_Click(object sender, RoutedEventArgs e)
        {
            var loading = DataContext as Loading;

            if (loading is Loading)
            {
                Loadings.Remove(loading);

                MainWindow.DB.Loadings.Remove(loading);
                MainWindow.DB.SaveChanges();
            }
        }


        private void BtnAddLoading_Click(object sender, RoutedEventArgs e)
        {
            var addLoadingWindow = new LoadingDescriptionWindow();

            if (addLoadingWindow.ShowDialog() == true)
            {
                var loading = new Loading
                {
                    Supplier = addLoadingWindow.cbSupplier.SelectedItem as Supplier,
                    Product = addLoadingWindow.cbProduct.SelectedItem as Product,
                    Count = int.Parse(addLoadingWindow.txtCount.Text)
                };

                var datetime = addLoadingWindow.dpDatetime.SelectedDate;
                if (datetime.HasValue)
                {
                    loading.Datetime = datetime.Value;
                }

                loading.Product.Count += loading.Count;

                MainWindow.DB.Loadings.Add(loading);
                MainWindow.DB.SaveChanges();

                Loadings.Add(loading);
            }
        }


        private void BtnEditLoading_Click(object sender, RoutedEventArgs e)
        {
            var loading = DataContext as Loading;

            if (loading is Loading)
            {
                loading.Product.Count -= loading.Count;

                var editLoadingWindow = new LoadingDescriptionWindow(loading);

                if (editLoadingWindow.ShowDialog() == true)
                {
                    var datetime = editLoadingWindow.dpDatetime.SelectedDate;
                    if (datetime.HasValue)
                    {
                        loading.Datetime = datetime.Value;
                    }

                    loading.Supplier = editLoadingWindow.cbSupplier.SelectedItem as Supplier;
                    loading.Product = editLoadingWindow.cbProduct.SelectedItem as Product;
                    loading.Count = int.Parse(editLoadingWindow.txtCount.Text);
                    loading.Product.Count += loading.Count;

                    // 'reset' the same object in observable collection
                    // to make it update
                    int index = Loadings.IndexOf(loading);
                    Loadings.Insert(index, loading);
                    Loadings.RemoveAt(index + 1);

                    loadingList.SelectedItem = loading;
                }
                else
                {
                    loading.Product.Count += loading.Count;
                }

                MainWindow.DB.SaveChanges();
            }
        }
    }
}
