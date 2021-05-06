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
    /// Interaction logic for SupplyPage.xaml
    /// </summary>
    public partial class SupplyPage : Page
    {
        private List<Supply> _supplies = new List<Supply>();
        private readonly Warehouse _warehouse;

        public SupplyPage(Warehouse warehouse)
        {
            InitializeComponent();
            _warehouse = warehouse;
            Title = "Оператор. Отгрузка товаров на " + _warehouse.Name.ToLower();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            AppData.Context.ChangeTracker.Entries<Supply>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<SupplyContract>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<SupplyOfProduct>().ToList().ForEach(i => i.Reload());

            _supplies = AppData.Context.Supply.ToList().Where(i => i.Warehouse == _warehouse).ToList();

            foreach (var item in _supplies.Where(i => i.StatusId == 6))
            {
                if (item.SupplyContract.Date < DateTime.Now)
                {
                    item.StatusId = 1;
                    AppData.Context.SaveChanges();
                }
            }

            int waited = _supplies.Count(i => i.StatusId == 1);
            int completed = _supplies.Count(i => i.StatusId == 3);
            int transist = _supplies.Count(i => i.StatusId == 6);
            int canceled = _supplies.Count(i => i.StatusId == 5);

            TbkWaited.Text = $"Ожидают ({waited})";
            TbkCompleted.Text = $"Отгруженные ({completed})";
            TbkTransist.Text = $"В пути ({transist})";
            TbkCanceled.Text = $"Отменённые ({canceled})";

            ICTransist.ItemsSource = ICWaited.ItemsSource = ICCanceled.ItemsSource = ICCompleted.ItemsSource = null;
            ICWaited.ItemsSource = _supplies.Where(i => i.StatusId == 1);
            ICCompleted.ItemsSource = _supplies.Where(i => i.StatusId == 3);
            ICTransist.ItemsSource = _supplies.Where(i => i.StatusId == 6);
            ICCanceled.ItemsSource = _supplies.Where(i => i.StatusId == 5);
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            Supply supply = (sender as Button).DataContext as Supply;
            foreach (var item in supply.SupplyOfProduct.ToList())
            {
                supply.Warehouse.WarehouseOfProduct.Add(new WarehouseOfProduct
                {
                    Warehouse = supply.Warehouse,
                    Product = item.Product,
                    Count = item.Count,
                });
            }
            supply.StatusId = 3;
            AppData.Context.SaveChanges();
            Update();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.Question("Вы уверены что хотите отменить отгрузку?") == MessageBoxResult.Yes)
            {
                ((sender as Button).DataContext as Supply).StatusId = 5;
                AppData.Context.SaveChanges();
                Update();
            }
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AcceptSupplyPage((sender as Button).DataContext as Supply));
        }
    }
}
