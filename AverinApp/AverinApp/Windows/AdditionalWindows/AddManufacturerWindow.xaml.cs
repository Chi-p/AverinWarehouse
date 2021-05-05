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
using System.Windows.Shapes;

namespace AverinApp.Windows.AdditionalWindows
{
    /// <summary>
    /// Interaction logic for AddManufacturerWindow.xaml
    /// </summary>
    public partial class AddManufacturerWindow : Window
    {
        private Manufacturer _manufacturer;

        public AddManufacturerWindow(Manufacturer manufacturer)
        {
            InitializeComponent();
            _manufacturer = manufacturer;
            Load();
        }

        private void Load()
        {
            CbxCountry.ItemsSource = AppData.Context.Country.ToList();

            if (_manufacturer != null)
            {
                Title = "Окно редактирования. " + _manufacturer.Name;
                TbxName.Text = _manufacturer.Name;
                TbxAdress.Text = _manufacturer.Address;
                TbxPhone.Text = _manufacturer.Phone;
                CbxCountry.SelectedItem = _manufacturer.Country;
            }
            else
            {
                Title = "Окно добавления. Новый производитель";
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbxName.Text) || string.IsNullOrWhiteSpace(TbxAdress.Text) 
                || string.IsNullOrWhiteSpace(TbxPhone.Text) || CbxCountry.SelectedItem == null)
            {
                string error = "Ошибки ввода:\n";

                if (string.IsNullOrWhiteSpace(TbxName.Text))
                    error += "Название производителя не может быть пустым\n";

                if (string.IsNullOrWhiteSpace(TbxAdress.Text))
                    error += "Адрес производителя не может быть пустым\n";

                if (string.IsNullOrWhiteSpace(TbxPhone.Text))
                    error += "Телефон производителя не может быть пустым\n";

                AppData.Message.Error(error);
            }
            else
            {
                if (AppData.Context.Manufacturer.ToList().FirstOrDefault(i => i.Name == TbxName.Text) != null)
                {
                    AppData.Message.Error("Производитель с таким названием уже сущуствует");
                    return;
                }
                if (AppData.Context.Manufacturer.ToList().FirstOrDefault(i => i.Phone == TbxPhone.Text) != null)
                {
                    AppData.Message.Error("Производитель с таким номером телефона уже сущуствует");
                    return;
                }

                if (_manufacturer == null)
                {
                    _manufacturer = new Manufacturer
                    {

                        Name = TbxName.Text,
                        Address = TbxAdress.Text,
                        Phone = TbxPhone.Text,
                        Country = CbxCountry.SelectedItem as Country
                    };
                    AppData.Context.Manufacturer.Add(_manufacturer);
                }
                else
                {
                    if (AppData.Context.Manufacturer.ToList().FirstOrDefault(i => i.Name == TbxName.Text && i.Name != _manufacturer.Name) != null)
                    {
                        AppData.Message.Error("Производитель с таким названием уже сущуствует");
                        return;
                    }
                    if (AppData.Context.Manufacturer.ToList().FirstOrDefault(i => i.Phone == TbxPhone.Text && i.Phone != _manufacturer.Phone) != null)
                    {
                        AppData.Message.Error("Производитель с таким номером телефона уже сущуствует");
                        return;
                    }

                    _manufacturer.Name = TbxName.Text;
                    _manufacturer.Address = TbxAdress.Text;
                    _manufacturer.Phone = TbxPhone.Text;
                    _manufacturer.Country = CbxCountry.SelectedItem as Country;
                }
                AppData.Context.SaveChanges();
                AppData.Message.Info("Производитель успешно сохранён!");
                AddCertificateWindow._manufacturer = _manufacturer;
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
