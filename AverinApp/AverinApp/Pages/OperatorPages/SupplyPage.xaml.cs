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
    /// Interaction logic for SupplyPage.xaml
    /// </summary>
    public partial class SupplyPage : Page
    {
        private List<Supply> _supplies = new List<Supply>();
        private readonly Warehouse _warehouse;

        public SupplyPage(Warehouse warehouse)
        {
            InitializeComponent();
            _warehouse = warehouse;
            Title = "Оператор. Отгрузка товаров на " + _warehouse.Name.ToLower();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void Update()
        {
            AppData.Context.ChangeTracker.Entries<Supply>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<SupplyContract>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<SupplyOfProduct>().ToList().ForEach(i => i.Reload());

            _supplies = AppData.Context.Supply.ToList().Where(i => i.Warehouse == _warehouse).ToList();

            foreach (var item in _supplies.Where(i => i.Status.Name == "В пути"))
            {
                if (item.SupplyContract.Date < DateTime.Now)
                {
                    item.StatusId = 1;
                    AppData.Context.SaveChanges();
                }
            }

            int waited = _supplies.Count(i => i.Status.Name == "Ожидает");
            int completed = _supplies.Count(i => i.Status.Name == "Отгружен");
            int transist = _supplies.Count(i => i.Status.Name == "В пути");
            int canceled = _supplies.Count(i => i.Status.Name == "Отменён");

            TbkWaited.Text = $"Ожидают ({waited})";
            TbkCompleted.Text = $"Отгруженные ({completed})";
            TbkTransist.Text = $"В пути ({transist})";
            TbkCanceled.Text = $"Отменённые ({canceled})";

            ICTransist.ItemsSource = null;
            ICTransist.ItemsSource = _supplies.Where(i => i.Status.Name == "В пути");
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
