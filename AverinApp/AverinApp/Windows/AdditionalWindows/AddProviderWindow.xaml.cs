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
    /// Interaction logic for AddProviderWindow.xaml
    /// </summary>
    public partial class AddProviderWindow : Window
    {
        private Provider _provider;

        public AddProviderWindow(Provider Provider)
        {
            InitializeComponent();
            _provider = Provider;
            Load();
        }

        private void Load()
        {
            CbxCountry.ItemsSource = AppData.Context.Country.ToList();

            if (_provider != null)
            {
                Title = "Окно редактирования. " + _provider.Name;
                TbxName.Text = _provider.Name;
                TbxAdress.Text = _provider.Address;
                TbxPhone.Text = _provider.Phone;
                CbxCountry.SelectedItem = _provider.Country;
            }
            else
            {
                Title = "Окно добавления. Новый поставщик";
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbxName.Text) || string.IsNullOrWhiteSpace(TbxAdress.Text)
                || string.IsNullOrWhiteSpace(TbxPhone.Text) || CbxCountry.SelectedItem == null)
            {
                string error = "Ошибки ввода:\n";

                if (string.IsNullOrWhiteSpace(TbxName.Text))
                    error += "Название поставщика не может быть пустым\n";

                if (string.IsNullOrWhiteSpace(TbxAdress.Text))
                    error += "Адрес поставщика не может быть пустым\n";

                if (string.IsNullOrWhiteSpace(TbxPhone.Text))
                    error += "Телефон поставщика не может быть пустым\n";

                AppData.Message.Error(error);
            }
            else
            {
                if (AppData.Context.Provider.ToList().FirstOrDefault(i => i.Name == TbxName.Text) != null)
                {
                    AppData.Message.Error("Поставщик с таким названием уже существует");
                    return;
                }
                if (AppData.Context.Provider.ToList().FirstOrDefault(i => i.Phone == TbxPhone.Text) != null)
                {
                    AppData.Message.Error("Поставщик с таким номером телефона уже существует");
                    return;
                }

                if (_provider == null)
                {
                    _provider = new Provider
                    {

                        Name = TbxName.Text,
                        Address = TbxAdress.Text,
                        Phone = TbxPhone.Text,
                        Country = CbxCountry.SelectedItem as Country
                    };
                    AppData.Context.Provider.Add(_provider);
                }
                else
                {
                    if (AppData.Context.Provider.ToList().FirstOrDefault(i => i.Name == TbxName.Text && i.Name != _provider.Name) != null)
                    {
                        AppData.Message.Error("Поставщик с таким названием уже существует");
                        return;
                    }
                    if (AppData.Context.Provider.ToList().FirstOrDefault(i => i.Phone == TbxPhone.Text && i.Phone != _provider.Phone) != null)
                    {
                        AppData.Message.Error("Поставщик с таким номером телефона уже существует");
                        return;
                    }

                    _provider.Name = TbxName.Text;
                    _provider.Address = TbxAdress.Text;
                    _provider.Phone = TbxPhone.Text;
                    _provider.Country = CbxCountry.SelectedItem as Country;
                }
                AppData.Context.SaveChanges();
                AppData.Message.Info("Поставщик успешно сохранён!");
                Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.Question("Вы уверены? Не сохранённые данные будут утеряны.") == MessageBoxResult.Yes)
                Close();
        }
    }
}
