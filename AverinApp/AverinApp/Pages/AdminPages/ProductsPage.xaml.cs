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
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage()
        {
            InitializeComponent();
            Update();
        }

        private void Update()
        {
            AppData.Context.ChangeTracker.Entries<Product>().ToList().ForEach(i => i.Reload());
            AppData.Context.ChangeTracker.Entries<Certificate>().ToList().ForEach(i => i.Reload());

            List<Product> products = AppData.Context.Product.ToList();

            if (!string.IsNullOrWhiteSpace(TbxSearch.Text))
                products = products.Where(i =>
                i.Name.ToLower().Contains(TbxSearch.Text.ToLower()) ||
                i.Weight.ToString().ToLower().Contains(TbxSearch.Text.ToLower()) ||
                i.CertificateNumber.ToString().ToLower().Contains(TbxSearch.Text.ToLower()) ||
                i.Price.ToString().ToLower().Contains(TbxSearch.Text.ToLower()) ||
                i.Number.ToLower().Contains(TbxSearch.Text.ToLower()) ||
                i.Description.ToLower().Contains(TbxSearch.Text.ToLower())).ToList();

            if (DpStartDate.SelectedDate != null)
                products = products.Where(i => i.Certificate.DateStart >= DpStartDate.SelectedDate).ToList();

            if (DpEndDate.SelectedDate != null)
                products = products.Where(i => i.Certificate.DateEnd <= DpEndDate.SelectedDate).ToList();

            DGProducts.ItemsSource = null;
            DGProducts.ItemsSource = products;
        }

        private void BtnCertificate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            TbxSearch.Text = "";
            DpStartDate.SelectedDate = DpEndDate.SelectedDate = null;
            Update();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow window = new AddProductWindow(null, "new")
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
            Update();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = (sender as Button).DataContext as Product;
                if (AppData.Message.Question($"Вы уверены что хотите удалить {product.Name}?") == MessageBoxResult.Yes)
                {
                    AppData.Context.Product.Remove(product);
                    AppData.Context.SaveChanges();
                    Update();
                }
            }
            catch 
            {
                AppData.Message.Error("Невозможно удалить продукт, т.к. он фигурирует в других записях.");
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow window = new AddProductWindow((sender as Button).DataContext as Product, "edit")
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
            Update();
        }
    }
}
