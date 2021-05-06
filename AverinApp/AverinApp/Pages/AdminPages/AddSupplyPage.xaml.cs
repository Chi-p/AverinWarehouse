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
    /// Interaction logic for AddSupplyPage.xaml
    /// </summary>
    public partial class AddSupplyPage : Page
    {
        private Supply _supply;

        public AddSupplyPage()
        {
            InitializeComponent();

            Load();
            Update();
            CreateSupply();
        }

        #region UpdateLoadData
        private void Load()
        {
            List<Country> countries = AppData.Context.Country.ToList();
            countries.Insert(0, new Country
            {
                Name = "Все страны",
            });

            CbxCountry.ItemsSource = countries;
            CbxCountry.SelectedIndex = 0;

            DGClients.ItemsSource = AppData.Context.Client.ToList();
            CbxWarehouse.ItemsSource = AppData.Context.Warehouse.ToList();
            DGProviders.ItemsSource = CbxProvider.ItemsSource = AppData.Context.Provider.ToList();
        }

        private void Update()
        {
            AppData.Context.ChangeTracker.Entries<Client>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<Provider>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<Product>().ToList().ForEach(i => i.Reload());

            DGClients.ItemsSource = DGProviders.ItemsSource = null;
            CbxProvider.ItemsSource = CbxWarehouse.ItemsSource = null;
            DGClients.ItemsSource = AppData.Context.Client.ToList();
            CbxWarehouse.ItemsSource = AppData.Context.Warehouse.ToList();
            DGProviders.ItemsSource = CbxProvider.ItemsSource = AppData.Context.Provider.ToList();
        }

        private void CreateSupply()
        {
            int count = AppData.Context.Supply.ToList().Count + 1;
            string cnt = "";
            if (count < 10)
                cnt = "0" + count;
            string number = $"{cnt}{DateTime.Now:ddMMyyyyHHmmss}";

            _supply = new Supply
            {
                SupplyContractNumber = number,
                SupplyContract = new SupplyContract
                {
                    Number = number
                },
                StatusId = 6,
            };

            List<SupplyOfProduct> supplyOfProducts = new List<SupplyOfProduct>();
            foreach (var item in AppData.Context.Product.ToList())
            {
                supplyOfProducts.Add(new SupplyOfProduct
                {
                    Product = item,
                    ProductNumber = item.Number,
                    Count = 0
                });
            }
            _supply.SupplyOfProduct = supplyOfProducts;

            ICProducts.ItemsSource = null;
            ICProducts.ItemsSource = supplyOfProducts;
            DataContext = _supply;
        }

        private void UpdateContext()
        {
            DataContext = null;
            DataContext = _supply;
        }
        #endregion

        #region Client
        private void UpdateClient()
        {
            AppData.Context.ChangeTracker.Entries<Client>().ToList().ForEach(i => i.Reload());
            List<Client> clients = AppData.Context.Client.ToList();

            if (!string.IsNullOrWhiteSpace(TbxClientSearch.Text))
                clients = clients.Where(i =>
                i.Name.ToLower().Contains(TbxClientSearch.Text) ||
                i.Address.ToLower().Contains(TbxClientSearch.Text) ||
                i.Phone.ToLower().Contains(TbxClientSearch.Text)).ToList();

            DGClients.ItemsSource = null;
            DGClients.ItemsSource = clients;
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow window = new AddClientWindow(null)
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
            Update();
        }

        private void BtnClientSearch_Click(object sender, RoutedEventArgs e)
        {
            UpdateClient();
        }

        private void BtnClientClear_Click(object sender, RoutedEventArgs e)
        {
            TbxClientSearch.Text = "";
            UpdateClient();
        }

        private void BtnClientEdit_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow window = new AddClientWindow((sender as Button).DataContext as Client)
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
            Update();
        }

        private void BtnClientDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var client = (sender as Button).DataContext as Client;
                if (AppData.Message.Question($"Вы уверены что хотите удалить выбранного клиента?") == MessageBoxResult.Yes)
                {
                    AppData.Context.Client.Remove(client);
                    AppData.Context.SaveChanges();
                    Update();
                }
            }
            catch
            {
                AppData.Message.Error("Невозможно удалить клиента, т.к. он фигурирует в других записях.");
            }
        }
        #endregion

        #region Provider
        private void UpdateProvider()
        {
            AppData.Context.ChangeTracker.Entries<Provider>().ToList().ForEach(i => i.Reload());
            List<Provider> providers = AppData.Context.Provider.ToList();

            if (!string.IsNullOrWhiteSpace(TbxProviderSearch.Text))
                providers = providers.Where(i =>
                i.Name.ToLower().Contains(TbxProviderSearch.Text) ||
                i.Address.ToLower().Contains(TbxProviderSearch.Text) ||
                i.Phone.ToLower().Contains(TbxProviderSearch.Text)).ToList();

            if (CbxCountry.SelectedIndex > 0)
                providers = providers.Where(i => i.Country == CbxCountry.SelectedItem as Country).ToList();

            DGProviders.ItemsSource = null;
            DGProviders.ItemsSource = providers;
        }

        private void BtnProviderSearch_Click(object sender, RoutedEventArgs e)
        {
            UpdateProvider();
        }

        private void BtnProviderClear_Click(object sender, RoutedEventArgs e)
        {
            TbxProviderSearch.Text = "";
            CbxCountry.SelectedItem = null;
            UpdateProvider();
        }

        private void BtnAddProvider_Click(object sender, RoutedEventArgs e)
        {
            AddProviderWindow window = new AddProviderWindow(null)
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
            Update();
        }

        private void BtnProviderEdit_Click(object sender, RoutedEventArgs e)
        {
            AddProviderWindow window = new AddProviderWindow((sender as Button).DataContext as Provider)
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
            Update();
        }

        private void BtnProviderDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var provider = (sender as Button).DataContext as Provider;
                if (AppData.Message.Question($"Вы уверены что хотите удалить выбранного поставщика?") == MessageBoxResult.Yes)
                {
                    AppData.Context.Provider.Remove(provider);
                    AppData.Context.SaveChanges();
                    Update();
                }
            }
            catch
            {
                AppData.Message.Error("Невозможно удалить поставщика, т.к. он фигурирует в других записях.");
            }
        }
        #endregion

        #region Data

        private void TbxPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text[0] == '.' && (sender as TextBox).Text.Contains('.'))
                e.Handled = true;
            else if (e.Text[0] != '.' && !Char.IsDigit(e.Text, 0))
                e.Handled = true;
        }

        #region Time
        private void TbxHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            new HelperClass().InputOnlyDigit(e);
        }

        private void TbxMinutes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            new HelperClass().InputOnlyDigit(e);
        }

        private void TbxMinutes_TextChanged(object sender, TextChangedEventArgs e)
        {
            HoursAndMinutes(TbxMinutes, 59);
        }

        private void TbxHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            HoursAndMinutes(TbxHours, 23);
        }

        private void HoursAndMinutes(TextBox Tbx, int digit)
        {
            if (Tbx != null)
            {
                if (string.IsNullOrWhiteSpace(Tbx.Text))
                {
                    Tbx.Text = "0";
                    Tbx.SelectAll();
                }
                if (int.Parse(Tbx.Text) > digit)
                {
                    Tbx.Text = digit.ToString();
                    Tbx.SelectionStart = Tbx.Text.Length;
                }
            }
        }
        #endregion

        #region Product
        private void TbxProductCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tbx = sender as TextBox;

            if (string.IsNullOrWhiteSpace(tbx.Text))
            {
                tbx.Text = "0";
                return;
            }

            (tbx.DataContext as SupplyOfProduct).Count = Convert.ToDecimal(tbx.Text);
            UpdateContext();
        }

        private void TbxProductCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            new HelperClass().InputOnlyDigit(e);
        }

        #endregion

        #endregion

        #region Actions
        private void BtnCreateSupply_Click(object sender, RoutedEventArgs e)
        {
            if (DPDate.SelectedDate == null || string.IsNullOrWhiteSpace(TbxPrice.Text) || CbxProvider.SelectedItem == null
                || CbxWarehouse.SelectedItem == null || string.IsNullOrWhiteSpace(TbxHours.Text) || string.IsNullOrWhiteSpace(TbxMinutes.Text))
            {
                string error = "Ошибки ввода:\n";

                if (string.IsNullOrWhiteSpace(TbxPrice.Text))
                    error += "Поле 'Цена' не может быть пустым\n";
                if (DPDate.SelectedDate == null)
                    error += "Поле 'Дата' не может быть пустым\n";
                if (string.IsNullOrWhiteSpace(TbxHours.Text))
                    error += "Поле 'Часы' не может быть пустым\n";
                if (string.IsNullOrWhiteSpace(TbxMinutes.Text))
                    error += "Поле 'Минуты' не может быть пустым\n";
                if (CbxProvider.SelectedItem == null)
                    error += "Поле 'Поставщик' не может быть пустым\n";
                if (CbxWarehouse.SelectedItem == null)
                    error += "Поле 'Склад' не может быть пустым\n";

                AppData.Message.Error(error);
            }
            else
            {
                if (Convert.ToInt32(TbxPrice.Text) == 0)
                {
                    AppData.Message.Error("Цена не может равняться 0.");
                    return;
                }
                if (_supply.TotalWeight == 0)
                {
                    AppData.Message.Error("Пожалуйста, выберите продукты.");
                    return;
                }

                if (AppData.Message.Question("Вы уверены в введённых данных?") == MessageBoxResult.Yes)
                {
                    DateTime date = new DateTime(
                        DPDate.SelectedDate.Value.Year, DPDate.SelectedDate.Value.Month, DPDate.SelectedDate.Value.Day,
                        Convert.ToInt32(TbxHours.Text), Convert.ToInt32(TbxMinutes.Text), 0);

                    _supply.SupplyContract.Date = date;
                    _supply.SupplyContract.Price = Convert.ToDecimal(TbxPrice.Text);
                    _supply.Provider = CbxProvider.SelectedItem as Provider;
                    _supply.Warehouse = CbxWarehouse.SelectedItem as Warehouse;
                    for (int i = 0; i < _supply.SupplyOfProduct.Count; i++)
                    {
                        var item = _supply.SupplyOfProduct.ToList()[i];
                        if (item.Count == 0)
                            _supply.SupplyOfProduct.Remove(item);
                    }

                    AppData.Context.Supply.Add(_supply);
                    AppData.Context.SaveChanges();
                    AppData.Message.Info($"Товар успешно отправлен на {_supply.Warehouse.Name}");
                    NavigationService.GoBack();
                }
            }
        }

        private void BtnSupplyClear_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.Question("Вы уверены?") == MessageBoxResult.Yes)
            {
                Update();
                CreateSupply();
            }
        } 
        #endregion
    }
}
