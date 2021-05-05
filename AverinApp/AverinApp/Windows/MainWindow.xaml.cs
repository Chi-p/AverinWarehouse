using AverinApp.Entities;
using AverinApp.Pages;
using AverinApp.Pages.AdminPages;
using AverinApp.Pages.GeneralPages;
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
using System.Windows.Threading;

namespace AverinApp.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Properties.Settings _settings = Properties.Settings.Default;
        private readonly DateTime _timeStart = DateTime.Now;
        private TimeSpan _timeLeft = new TimeSpan();
        private readonly DispatcherTimer _workTimer = new DispatcherTimer();
        private readonly DispatcherTimer _operatorTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new AuthorizationPage());

            _workTimer.Interval = new TimeSpan(0, 0, 1);
            _workTimer.Tick += WorkTimer_Tick;
            _workTimer.Start();
            _operatorTimer.Interval = new TimeSpan(0, 0, 10);
            _operatorTimer.Tick += OperatorTimer_Tick;
        }

        private void OperatorTimer_Tick(object sender, EventArgs e)
        {
            if (AppData.CurrentUser != null)
            {
                AppData.Context.ChangeTracker.Entries<Warehouse>().ToList().ForEach(i => i.Reload());
                AppData.Context.ChangeTracker.Entries<Operator>().ToList().ForEach(i => i.Reload());

                if (AppData.CurrentUser.Operator.Warehouse.Count == 0 && Title != "Оператор. Главное меню")
                    MainFrame.Navigate(new OperatorMenuPage());
            }
        }

        private void WorkTimer_Tick(object sender, EventArgs e)
        {
            _timeLeft = DateTime.Now - _timeStart;
            TbkTime.Text = $"Время работы в приложении: {_timeLeft.Hours} часов, {_timeLeft.Minutes} минут, {_timeLeft.Seconds} секунд";
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (Title == "Авторизация")
            {
                _operatorTimer.Stop();
                BtnLogout.Visibility = Visibility.Collapsed;
            }
            else
            {
                BtnLogout.Visibility = Visibility.Visible;
            }

            if (Title == "Авторизация" || Title == "Оператор. Главное меню" || Title == "Администратор. Главное меню")
                BtnBack.Visibility = Visibility.Collapsed;
            else
                BtnBack.Visibility = Visibility.Visible;
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.Question("Вы уверены, что хотите выйти из аккаунта?") == MessageBoxResult.Yes)
            {
                AppData.CurrentUser = null;
                _settings.Login = _settings.Password = "";
                _settings.Save();

                MainFrame.Navigate(new AuthorizationPage());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_settings.Login) && !string.IsNullOrWhiteSpace(_settings.Password))
            {
                User user = AppData.Context.User.ToList().FirstOrDefault(i => i.Login == _settings.Login && i.Password == _settings.Password);

                if (user == null)
                    return;

                AppData.CurrentUser = user;

                switch (user.Role.Name)
                {
                    case "Оператор":
                        _operatorTimer.Start();
                        MainFrame.Navigate(new OperatorMenuPage());
                        break;
                    case "Администратор":
                        MainFrame.Navigate(new AdminMenuPage());
                        break;
                    default:
                        AppData.Message.Error("Функционал для данной роли не реализован. Обратитесь к системному администратору.");
                        break;
                }
            }
        }
    }
}
