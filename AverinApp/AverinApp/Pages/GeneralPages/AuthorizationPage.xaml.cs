using AverinApp.Entities;
using AverinApp.Pages.AdminPages;
using AverinApp.Pages.OperatorPages;
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

namespace AverinApp.Pages.GeneralPages
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.ChangeTracker.Entries<User>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<Operator>().ToList().ForEach(i => i.Reload());

            AppData.CurrentUser = null;
            Properties.Settings.Default.Login = Properties.Settings.Default.Password = "";
            Properties.Settings.Default.Save();

            if (string.IsNullOrWhiteSpace(TbxLogin.Text) || string.IsNullOrWhiteSpace(PbxPassword.Password))
            {
                AppData.Message.Error("Введите данные.");
                return;
            }

            User user = AppData.Context.User.ToList().FirstOrDefault(i => i.Login == TbxLogin.Text && i.Password == PbxPassword.Password);

            if (user == null)
            {
                AppData.Message.Error("Неверный логин или пароль.");
                return;
            }

            AppData.CurrentUser = user;

            if (ChkBxRememberMe.IsChecked == true)
            {
                Properties.Settings.Default.Login = TbxLogin.Text;
                Properties.Settings.Default.Password = PbxPassword.Password;
                Properties.Settings.Default.Save();
            }

            switch (user.Role.Name)
            {
                case "Оператор":
                    NavigationService.Navigate(new OperatorMenuPage());
                    break;
                case "Администратор":
                    NavigationService.Navigate(new AdminMenuPage());
                    break;
                default:
                    AppData.Message.Error("Функционал для данной роли не реализован. Обратитесь к системному администратору.");
                    break;
            }
        }
    }
}
