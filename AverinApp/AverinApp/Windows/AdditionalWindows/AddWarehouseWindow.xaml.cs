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
using System.Windows.Shapes;

namespace AverinApp.Windows.AdditionalWindows
{
    /// <summary>
    /// Interaction logic for AddWarehouseWindow.xaml
    /// </summary>
    public partial class AddWarehouseWindow : Window
    {
        private Warehouse _warehouse = new Warehouse();

        public AddWarehouseWindow(Warehouse warehouse)
        {
            InitializeComponent();

            _warehouse = warehouse;
            Load();
        }

        private void Load()
        {
            LoadOperators();

            if (_warehouse != null)
            {
                Title = "Окно редактирования. " + _warehouse.Name;
                TbxName.Text = _warehouse.Name;
                TbxAdress.Text = _warehouse.Address;
                TbxCapacity.Text = _warehouse.Capacity.ToString();
                if (_warehouse.Operator == null)
                    CbxOperator.SelectedIndex = 0;
                else
                    CbxOperator.SelectedItem = _warehouse.Operator;
            }
            else
            {
                Title = "Окно добавления. Новый склад";
                CbxOperator.SelectedIndex = 0;
            }
        }

        private void LoadOperators()
        {
            AppData.Context.ChangeTracker.Entries<Operator>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<User>().ToList().ForEach(i => i.Reload());

            List<Operator> operators = AppData.Context.Operator.ToList();
            operators.Insert(0, new Operator
            {
                LastName = "Не",
                FirstName = "назначен"
            });

            CbxOperator.ItemsSource = operators;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbxName.Text) || string.IsNullOrWhiteSpace(TbxAdress.Text) || Decimal.Parse(TbxCapacity.Text) == 0
                || AppData.Context.Warehouse.ToList().FirstOrDefault(i => i.Address == TbxAdress.Text && i.Address != _warehouse.Address) != null
                || AppData.Context.Warehouse.ToList().FirstOrDefault(i => i.Operator == CbxOperator.SelectedItem as Operator && i.Operator != _warehouse.Operator) != null
                || AppData.Context.Warehouse.ToList().FirstOrDefault(i => i.Name == _warehouse.Name && i.Name != _warehouse.Name) != null || string.IsNullOrWhiteSpace(TbxCapacity.Text))
            {
                string error = "Ошибки ввода:\n";

                if (string.IsNullOrWhiteSpace(TbxName.Text))
                    error += "Название склада не может быть пустым\n";
                else if (AppData.Context.Warehouse.ToList().FirstOrDefault(i => i.Name == TbxName.Text && i.Name != _warehouse.Name) != null)
                    error += "Склад с таким названием уже сущуствует\n";

                if (string.IsNullOrWhiteSpace(TbxAdress.Text))
                    error += "Адрес склада не может быть пустым\n";
                else if (AppData.Context.Warehouse.ToList().FirstOrDefault(i => i.Address == TbxAdress.Text && i.Address != _warehouse.Address) != null)
                    error += "Склад с таким адресом уже сущуствует\n";

                if (string.IsNullOrWhiteSpace(TbxCapacity.Text))
                    error += "Вместимость склада не может быть пустой\n";
                else if (Decimal.Parse(TbxCapacity.Text) == 0)
                    error += "Вместимость не может быть равна 0\n";

                if (AppData.Context.Warehouse.ToList().FirstOrDefault(i => i.Operator == CbxOperator.SelectedItem as Operator && i.Operator != _warehouse.Operator) != null)
                    error += "Оператор уже работает на другом складе";

                AppData.Message.Error(error);
            }
            else
            {
                if (CbxOperator.SelectedIndex == 0)
                    CbxOperator.SelectedItem = null;

                if (_warehouse == null)
                {
                    _warehouse = new Warehouse
                    {
                        Name = TbxName.Text,
                        Address = TbxAdress.Text,
                        Capacity = (Decimal.Parse(TbxCapacity.Text)),
                        Operator = CbxOperator.SelectedItem as Operator
                    };
                    AppData.Context.Warehouse.Add(_warehouse);
                }
                else
                {
                    _warehouse.Name = TbxName.Text;
                    _warehouse.Address = TbxAdress.Text;
                    _warehouse.Capacity = (Decimal.Parse(TbxCapacity.Text));
                    _warehouse.Operator = CbxOperator.SelectedItem as Operator;
                }
                AppData.Context.SaveChanges();
                Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.Question("Вы уверены? Не сохранённые данные будут утеряны.") == MessageBoxResult.Yes)
                Close();
        }

        private void TbxCapacity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text[0] == '.' && TbxCapacity.Text.Contains('.'))
                e.Handled = true;
            else if (e.Text[0] != '.' && !Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }
    }
}
