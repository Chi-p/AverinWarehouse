using AverinApp.Entities;
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

namespace AverinApp.Pages.OperatorPages
{
    /// <summary>
    /// Interaction logic for AcceptSupplyPage.xaml
    /// </summary>
    public partial class AcceptSupplyPage : Page
    {
        private Supply _supply;

        public AcceptSupplyPage(Supply supply)
        {
            InitializeComponent();
            _supply = supply;
            Load();
        }

        private void Load()
        {
            AppData.Context.ChangeTracker.Entries<WarehouseOfProduct>().ToList().ForEach(i => i.Reload());
            ICProducts.ItemsSource = _supply.SupplyOfProduct.ToList();
            DataContext = _supply;
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in _supply.SupplyOfProduct.ToList())
            {
                _supply.Warehouse.WarehouseOfProduct.Add(new WarehouseOfProduct
                {
                    Warehouse = _supply.Warehouse,
                    Product = item.Product,
                    Count = item.Count,
                });
            }
            _supply.StatusId = 3;
            AppData.Context.SaveChanges();
            NavigationService.GoBack();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
