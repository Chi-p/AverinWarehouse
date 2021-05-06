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
    /// Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        private Client _client;
        public AddClientWindow(Client client)
        {
            InitializeComponent();
            _client = client;
            Load();
        }

        private void Load()
        {

            if (_client != null)
            {
                Title = "Окно редактирования. " + _client.Name;
                TbxName.Text = _client.Name;
                TbxAdress.Text = _client.Address;
                TbxPhone.Text = _client.Phone;
            }
            else
            {
                Title = "Окно добавления. Новый клиент";
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbxName.Text) || string.IsNullOrWhiteSpace(TbxAdress.Text) || string.IsNullOrWhiteSpace(TbxPhone.Text) )
            {
                string error = "Ошибки ввода:\n";

                if (string.IsNullOrWhiteSpace(TbxName.Text))
                    error += "Название клиента не может быть пустым\n";

                if (string.IsNullOrWhiteSpace(TbxAdress.Text))
                    error += "Адрес клиента не может быть пустым\n";

                if (string.IsNullOrWhiteSpace(TbxPhone.Text))
                    error += "Телефон клиента не может быть пустым\n";

                AppData.Message.Error(error);
            }
            else
            {
                if (AppData.Context.Client.ToList().FirstOrDefault(i => i.Address == TbxAdress.Text) != null)
                {
                    AppData.Message.Error("Клиент с указанным адресом уже существует");
                    return;
                }

                if (_client == null)
                {
                    _client = new Client
                    {

                        Name = TbxName.Text,
                        Address = TbxAdress.Text,
                        Phone = TbxPhone.Text,
                    };
                    AppData.Context.Client.Add(_client);
                }
                else
                {
                    if (AppData.Context.Client.ToList().FirstOrDefault(i => i.Name == TbxName.Text && i.Name != _client.Name) != null)
                    {
                        AppData.Message.Error("Клиент с таким названием уже существует");
                        return;
                    }
                    if (AppData.Context.Client.ToList().FirstOrDefault(i => i.Phone == TbxPhone.Text && i.Phone != _client.Address) != null)
                    {
                        AppData.Message.Error("Клиент с таким номером телефона уже существует");
                        return;
                    }

                    _client.Name = TbxName.Text;
                    _client.Address = TbxAdress.Text;
                    _client.Phone = TbxPhone.Text;
                }
                AppData.Context.SaveChanges();
                AppData.Message.Info("Клиент успешно сохранён!");
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
