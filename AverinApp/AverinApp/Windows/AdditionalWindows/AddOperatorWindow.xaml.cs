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
    /// Interaction logic for AddOperatorWindow.xaml
    /// </summary>
    public partial class AddOperatorWindow : Window
    {
        private User _user;
        private readonly string _parent;

        public AddOperatorWindow(User user, string parent)
        {
            InitializeComponent();
            _parent = parent;
            _user = user;
            Load();
        }

        private void Load()
        {
            if (_user != null)
            {
                Title = "Окно редактирования. " + _user.Operator.FullName;
                TbxFirstName.Text = _user.Operator.FirstName;
                TbxLastName.Text = _user.Operator.LastName;
                TbxPatronymic.Text = _user.Operator.Patronymic;
                TbxLogin.Text = _user.Login;
            }
            else
            {
                Title = "Окно добавления. Новый оператор";
            }
        }

        private void LoadWarehouses()
        {
            AppData.Context.ChangeTracker.Entries<Warehouse>().ToList().ForEach(i => i.Reload());
            CbxWarehouse.ItemsSource = AppData.Context.Warehouse.ToList();
            if (_user != null)
            {
                if (_user.Operator.Warehouse.Count() != 0)
                    CbxWarehouse.SelectedItem = _user.Operator.Warehouse.First();

                BtnIgnore.Content = "Не менять";
            }
        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.Question("Вы уверены? Не сохранённые данные будут утеряны.") == MessageBoxResult.Yes)
                Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string error = "Ошибки ввода:\n";
            if (string.IsNullOrWhiteSpace(TbxLastName.Text) || string.IsNullOrWhiteSpace(TbxFirstName.Text) || string.IsNullOrWhiteSpace(TbxLogin.Text)
                || AppData.Context.User.ToList().FirstOrDefault(i => i.Login == TbxLogin.Text) != null)
            {

                if (string.IsNullOrWhiteSpace(TbxLastName.Text))
                    error += "Фамилия не может быть пустой\n";

                if (string.IsNullOrWhiteSpace(TbxFirstName.Text))
                    error += "Имя не может быть пустым\n";

                if (string.IsNullOrWhiteSpace(TbxLogin.Text))
                    error += "Логин не может быть пустым\n";
                else if (AppData.Context.User.ToList().FirstOrDefault(i => i.Login == TbxLogin.Text) != null)
                    error += "Оператор с таким логином уже сущуствует\n";

                AppData.Message.Error(error);
            }
            else
            {
                if (_user == null)
                {
                    if (string.IsNullOrWhiteSpace(PbxPassword.Password))
                        error += "Пароль не может быть пустым";
                    else if (PbxPassword.Password != PbxRePassword.Password)
                        error += "Пароли не совпадают";

                }
                else if (_user != null)
                {
                    if (AppData.Context.User.ToList().FirstOrDefault(i => i.Login == TbxLogin.Text && i.Login != _user.Login) != null)
                        error += "Оператор с таким логином уже сущуствует";

                    if (_user.Password == PbxPassword.Password)
                        error += "Новый пароль совпадает с вашим старым паролем.\nP.S. - Если вы не хотите менять пароль, оставьте поле пустым.";
                    else if (PbxPassword.Password != PbxRePassword.Password)
                        error += "Пароли не совпадают";

                }

                if (error != "Ошибки ввода:\n")
                {
                    AppData.Message.Error(error);
                }
                else
                {
                    if (_user == null)
                    {
                        _user = new User
                        {
                            Login = TbxLogin.Text,
                            Password = PbxPassword.Password,
                            RoleId = 1,
                            Operator = new Operator
                            {
                                FirstName = TbxFirstName.Text,
                                LastName = TbxLastName.Text,
                                Patronymic = TbxPatronymic.Text,
                            },
                        };

                    }
                    else
                    {
                        _user.Login = TbxLogin.Text;
                        if (!string.IsNullOrWhiteSpace(PbxPassword.Password))
                            _user.Password = PbxPassword.Password;
                        _user.Operator.FirstName = TbxFirstName.Text;
                        _user.Operator.LastName = TbxLastName.Text;
                        _user.Operator.Patronymic = TbxPatronymic.Text;
                    }

                    if (_parent == "Operator")
                    {
                        BdrWarehouse.Visibility = Visibility.Visible;
                        LoadWarehouses();
                    }
                    else if (_parent == "Warehouse")
                    {
                        if (_user.Id == 0)
                            AppData.Context.User.Add(_user);

                        AppData.Context.SaveChanges();
                        AddWarehouseWindow._newOperator = _user.Operator;
                        Close();
                    }
                }
            }
        }

        private void BtnSetWarehouse_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = AppData.Context.User.ToList().Where(i => i.Operator != null).Where(i => i.Operator.Warehouse.Count() != 0).ToList();

            if (_user == null)
            {
                if (users.FirstOrDefault(i => i.Operator.Warehouse.First() == CbxWarehouse.SelectedItem as Warehouse) != null)
                {
                    AppData.Message.Error("На указанный склад уже назначен другой оператор.");
                    return;
                }
            }
            else if (_user != null)
            {
                if (_user.Operator.Warehouse.Count != 0)
                {
                    if (users.FirstOrDefault(i => i.Operator.Warehouse.First() == CbxWarehouse.SelectedItem as Warehouse
                        && i.Operator.Warehouse.First() != _user.Operator.Warehouse.First()) != null)
                    {
                        AppData.Message.Error("На указанный склад уже назначен другой оператор.");
                        return;
                    }
                }
                else if (users.FirstOrDefault(i => i.Operator.Warehouse.First() == CbxWarehouse.SelectedItem as Warehouse) != null)
                {
                    AppData.Message.Error("На указанный склад уже назначен другой оператор.");
                    return;
                }
            }

            if (CbxWarehouse.SelectedItem != null)
            {
                _user.Operator.Warehouse.Clear();
                _user.Operator.Warehouse.Add(CbxWarehouse.SelectedItem as Warehouse);
            }
            AppData.Context.SaveChanges();
            AppData.Message.Info("Оператор успешно сохранён!");
            Close();
        }

        private void BtnIgnore_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.SaveChanges();
            AppData.Message.Info("Оператор успешно сохранён!");
            Close();
        }
    }
}
