using AverinApp.Classes;
using AverinApp.Entities;
using AverinApp.Windows.AdditionalWindows;
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
    /// Interaction logic for WarehousesPage.xaml
    /// </summary>
    public partial class WarehousesPage : Page
    {
        public WarehousesPage()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            List<Operator> operators = AppData.Context.Operator.ToList();
            operators.Insert(0, new Operator
            {
                LastName = "Все",
                FirstName = "пользователи"
            });
            operators.Insert(1, new Operator
            {
                LastName = "Не",
                FirstName = "назначен"
            });

            CbxOperator.ItemsSource = operators;
            CbxOperator.SelectedIndex = 0;
            Update();
        }

        private void Update()
        {
            List<Warehouse> warehouses = AppData.Context.Warehouse.ToList();

            if (!string.IsNullOrWhiteSpace(TbxSearch.Text))
                warehouses = warehouses.Where(i => 
                i.Name.ToLower().Contains(TbxSearch.Text.ToLower()) ||
                i.Address.ToLower().Contains(TbxSearch.Text.ToLower())).ToList();

            if (!string.IsNullOrWhiteSpace(TbxCapacity.Text))
                warehouses = warehouses.Where(i => i.Capacity == Decimal.Parse(TbxCapacity.Text)).ToList();

            if (CbxOperator.SelectedIndex == 1)
                warehouses = warehouses.Where(i => i.Operator == null).ToList();
            else if (CbxOperator.SelectedIndex > 1)
                warehouses = warehouses.Where(i => i.Operator == CbxOperator.SelectedItem as Operator).ToList();

            DGWarehouses.ItemsSource = null;
            DGWarehouses.ItemsSource = warehouses;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TbxCapacity.Text = TbxSearch.Text = "";
            CbxOperator.SelectedIndex = 0;
            Update();
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void TbxCapacity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            new HelperClass().InputOnlyDigit(e);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var warehouse = (sender as Button).DataContext as Warehouse;
            if (AppData.Message.Question($"Вы уверены что хотите удалить {warehouse.Name.ToLower()}?") == MessageBoxResult.Yes)
            {
                AppData.Context.Warehouse.Remove(warehouse);
                AppData.Context.SaveChanges();
                Update();
            }    
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddWarehouseWindow window = new AddWarehouseWindow((sender as Button).DataContext as Warehouse)
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
            Update();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWarehouseWindow window = new AddWarehouseWindow(null)
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
            Update();
        }
    }
}
