﻿using AverinApp.Entities;
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
using System.Windows.Threading;

namespace AverinApp.Pages.OperatorPages
{
    /// <summary>
    /// Interaction logic for OperatorMenuPage.xaml
    /// </summary>
    public partial class OperatorMenuPage : Page
    {
        DispatcherTimer _timer = new DispatcherTimer();
        public OperatorMenuPage()
        {
            InitializeComponent();

            DataContext = AppData.CurrentUser.Operator;
            _timer.Interval = new TimeSpan(0, 0, 10);
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            AppData.Context.ChangeTracker.Entries<Supply>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<SupplyContract>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<Shipment>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<Warehouse>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<Operator>().ToList().ForEach(i => i.Reload());

            if (AppData.CurrentUser.Operator.Warehouse.Count == 0)
            {
                BtnSupply.IsEnabled = BtnShipment.IsEnabled = false;
                TbkErrorMessage.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                BtnSupply.IsEnabled = BtnShipment.IsEnabled = true;
                TbkErrorMessage.Visibility = Visibility.Hidden;
            }

            TbkOfBtnSupply.Text = $"Отгрузка товаров\n на {AppData.CurrentUser.Operator.Warehouse.First().Name.ToLower()}";
            TbkOfBtnShipment.Text = $"Погрузка товаров\n со {AppData.CurrentUser.Operator.Warehouse.First().Name.ToLower()}";

            foreach (var item in AppData.Context.Supply.ToList().Where(i => i.Status.Name == "В пути"))
            {
                if (item.SupplyContract.Date < DateTime.Now)
                {
                    item.StatusId = 1;
                    AppData.Context.SaveChanges();
                }
            }

            int supply = AppData.Context.Supply.ToList().Count(i => i.Status.Name == "Ожидает отгрузки");
            int shipment = AppData.Context.Shipment.ToList().Count(i => i.Status.Name == "Ожидает погрузки");
            if (supply != 0)
            {
                BdrSupplyCount.Visibility = Visibility.Visible;
                TbkSupplyCount.Text = supply.ToString();
            }
            else
            {
                BdrSupplyCount.Visibility = Visibility.Collapsed;
                TbkSupplyCount.Text = "";
            }
            if (shipment != 0)
            {
                BdrShipmentCount.Visibility = Visibility.Visible;
                TbkShipmentCount.Text = shipment.ToString();
            }
            else
            {
                BdrShipmentCount.Visibility = Visibility.Collapsed;
                TbkShipmentCount.Text = "";
            }
        }

        private void BtnSupply_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SupplyPage());
        }

        private void BtnShipment_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ShipmentPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _timer.Start();
            Timer_Tick(null, null);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }
    }
}