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

namespace AverinApp.Pages.AdminPages
{
    /// <summary>
    /// Interaction logic for AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        public AdminMenuPage()
        {
            InitializeComponent();
            DataContext = AppData.CurrentUser;
        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }

        private void BtnWarehouses_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WarehousesPage());
        }

        private void BtnOperators_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OperatorsPage());
        }

        private void BtnSupply_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSupplyPage());
        }
    }
}
