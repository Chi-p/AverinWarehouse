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
    /// Interaction logic for OperatorsPage.xaml
    /// </summary>
    public partial class OperatorsPage : Page
    {
        public OperatorsPage()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            List<Warehouse> warehouses = AppData.Context.Warehouse.ToList();
            warehouses.Insert(0, new Warehouse
            {
                Name = "Все склады",
            });
            warehouses.Insert(1, new Warehouse
            {
                Name = "Не назначен",
            });

            CbxWarehouse.ItemsSource = warehouses;
            CbxWarehouse.SelectedIndex = 0;
            Update();
        }

        private void Update()
        {
            AppData.Context.ChangeTracker.Entries<Warehouse>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<Operator>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<User>().ToList().ForEach(i => i.Reload());

            List<User> operators = AppData.Context.User.ToList().Where(i => i.Operator != null).ToList();

            if (!string.IsNullOrWhiteSpace(TbxSearch.Text))
                operators = operators.Where(i =>
                i.Operator.FirstName.ToLower().Contains(TbxSearch.Text.ToLower()) ||
                i.Operator.LastName.ToLower().Contains(TbxSearch.Text.ToLower()) ||
                i.Operator.Patronymic.ToLower().Contains(TbxSearch.Text.ToLower()) ||
                i.Operator.FullName.ToLower().Contains(TbxSearch.Text.ToLower())).ToList();

            if (CbxWarehouse.SelectedIndex == 1)
                operators = operators.Where(i => i.Operator.Warehouse.Count == 0).ToList();
            else if (CbxWarehouse.SelectedIndex > 1)
                operators = operators.Where(i=>i.Operator.Warehouse.Count != 0).Where(i => 
                i.Operator.Warehouse.First() == CbxWarehouse.SelectedItem as Warehouse).ToList();

            DGOperators.ItemsSource = null;
            DGOperators.ItemsSource = operators;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            Update();

        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TbxSearch.Text = "";
            CbxWarehouse.SelectedIndex = 0;
            Update();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddOperatorWindow window = new AddOperatorWindow((sender as Button).DataContext as User, "Operator")
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
            Update();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = (sender as Button).DataContext as User;
                if (AppData.Message.Question($"Вы уверены что хотите удалить оператора \n{user.Operator.FullName}?") == MessageBoxResult.Yes)
                {
                    AppData.Context.User.Remove(user);
                    AppData.Context.SaveChanges();
                    Update();
                }
            }
            catch
            {
                AppData.Message.Error("Невозможно удалить оператора, т.к. он фигурирует в других записях.");
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddOperatorWindow window = new AddOperatorWindow(null, "Operator")
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
            Update();
        }
    }
}
