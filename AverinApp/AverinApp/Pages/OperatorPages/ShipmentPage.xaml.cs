using AverinApp.Classes;
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
    /// Interaction logic for ShipmentPage.xaml
    /// </summary>
    public partial class ShipmentPage : Page
    {
        private Shipment _shipment;

        public ShipmentPage()
        {
            InitializeComponent();

            Update();
            CreateShipment();
        }

        #region UpdateLoadData
        private void Update()
        {
            AppData.Context.ChangeTracker.Entries<Client>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<Provider>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<Product>().ToList().ForEach(i => i.Reload());

            CbxProvider.ItemsSource = CbxClient.ItemsSource = null;
            CbxClient.ItemsSource = AppData.Context.Client.ToList();
            CbxProvider.ItemsSource = AppData.Context.Provider.ToList();
        }

        private void CreateShipment()
        {
            int count = AppData.Context.Shipment.ToList().Count + 1;
            string cnt = "";
            if (count < 10)
                cnt = "0" + count;
            string number = $"{cnt}{DateTime.Now:ddMMyyyyHHmmss}";

            _shipment = new Shipment
            {
                ShipmentContractNumber = number,
                Warehouse = AppData.CurrentUser.Operator.Warehouse.First(),
                WarehouseId = AppData.CurrentUser.Operator.Warehouse.First().Id,
                ShipmentContract = new ShipmentContract
                {
                    Number = number,
                },
            };

            List<ShipmentOfProduct> shipmentOfProducts = new List<ShipmentOfProduct>();
            List<IGrouping<Product, WarehouseOfProduct>> products = AppData.Context.WarehouseOfProduct.ToList().GroupBy(i => i.Product).ToList();
            foreach (var item in products)
            {
                shipmentOfProducts.Add(new ShipmentOfProduct
                {
                    Product = item.Key,
                    ProductNumber = item.Key.Number,
                    TotalCount = item.First().TotalCount,
                    Count = 0,
                });
            }
            _shipment.ShipmentOfProduct = shipmentOfProducts;

            ICProducts.ItemsSource = null;
            ICProducts.ItemsSource = shipmentOfProducts;
            DataContext = _shipment;
        }

        private void UpdateContext()
        {
            DataContext = null;
            DataContext = _shipment;
        } 
        #endregion

        #region Actions
        private void BtnCreateShipment_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbxPrice.Text) || CbxProvider.SelectedItem == null || CbxClient.SelectedItem == null)
            {
                string error = "Ошибки ввода:\n";

                if (string.IsNullOrWhiteSpace(TbxPrice.Text))
                    error += "Поле 'Цена' не может быть пустым\n";
                if (CbxProvider.SelectedItem == null)
                    error += "Поле 'Поставщик' не может быть пустым\n";
                if (CbxClient.SelectedItem == null)
                    error += "Поле 'Клиент' не может быть пустым\n";

                AppData.Message.Error(error);
            }
            else
            {
                if (Convert.ToInt32(TbxPrice.Text) == 0)
                {
                    AppData.Message.Error("Цена не может равняться 0.");
                    return;
                }
                if (_shipment.TotalWeight == 0)
                {
                    AppData.Message.Error("Пожалуйста, выберите продукты.");
                    return;
                }

                if (AppData.Message.Question("Вы уверены в введённых данных?") == MessageBoxResult.Yes)
                {

                    _shipment.ShipmentContract.Date = DateTime.Now;
                    _shipment.ShipmentContract.Price = Convert.ToDecimal(TbxPrice.Text);
                    _shipment.Provider = CbxProvider.SelectedItem as Provider;
                    _shipment.Client = CbxClient.SelectedItem as Client;

                    foreach (var item in _shipment.ShipmentOfProduct.ToList())
                    {
                        decimal count = item.Count;
                        while (count != 0)
                        {
                            foreach (var item2 in _shipment.Warehouse.WarehouseOfProduct.ToList().Where(i => i.Product == item.Product).ToList())
                            {
                                if (item2.Count <= count)
                                {
                                    count -= item2.Count;
                                    item2.Count = 0;
                                }
                                else
                                {
                                    item2.Count -= count;
                                    count = 0;
                                }
                            }
                        }
                    }

                    _shipment.ShipmentOfProduct.ToList().RemoveAll(i => i.Count == 0);

                    foreach (var item in _shipment.Warehouse.WarehouseOfProduct.ToList().Where(i => i.Count == 0).ToList())
                        AppData.Context.WarehouseOfProduct.Remove(item);

                    AppData.Context.Shipment.Add(_shipment);
                    AppData.Context.SaveChanges();
                    AppData.Message.Info($"Товар успешно отправлен по адресу {_shipment.Client.Address}\n, в {_shipment.Client.Name}.");
                    NavigationService.GoBack();
                }
            }
        }

        private void BtnShipmentClear_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.Question("Вы уверены?") == MessageBoxResult.Yes)
            {
                Update();
                CreateShipment();
            }
        }
        #endregion

        #region Data
        #region Product
        private void TbxProductCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            new HelperClass().InputOnlyDigit(e);
        }

        private void TbxProductCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tbx = sender as TextBox;

            if (string.IsNullOrWhiteSpace(tbx.Text))
            {
                tbx.Text = "0";
                return;
            }

            ShipmentOfProduct product = tbx.DataContext as ShipmentOfProduct;
            if (Convert.ToDecimal(tbx.Text) < product.TotalCount)
            {
                product.Count = Convert.ToDecimal(tbx.Text);
            }
            else
            {
                product.Count = product.TotalCount;
                ICProducts.ItemsSource = null;
                ICProducts.ItemsSource = _shipment.ShipmentOfProduct;
            }

            UpdateContext();
        }
        #endregion

        private void TbxPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text[0] == '.' && (sender as TextBox).Text.Contains('.'))
                e.Handled = true;
            else if (e.Text[0] != '.' && !Char.IsDigit(e.Text, 0))
                e.Handled = true;
        } 
        #endregion
    }
}
