using AverinApp.Classes;
using AverinApp.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for AddCertificateWindow.xaml
    /// </summary>
    public partial class AddCertificateWindow : Window
    {
        private static Product _product;
        public static Manufacturer _manufacturer;

        public AddCertificateWindow(Product product)
        {
            InitializeComponent();
            _product = product;
            Load();
        }

        private void Load()
        {
            LoadManufacturers();

            if (_product.Certificate != null)
            {
                Title = "Окно просмотра. Сертификат номер: " + _product.Certificate.Number;
                CbxManufacturer.SelectedItem = _product.Certificate.Manufacturer;
                DpStartDate.SelectedDate = _product.Certificate.DateStart;
                DpEndDate.SelectedDate = _product.Certificate.DateEnd;
                TbxNumber.Text = _product.Certificate.Number;
                TbxRequirements.Text = _product.Certificate.Requirements;

                TbxNumber.IsReadOnly = true;
            }
            else
            {
                Title = "Окно добавления. Новый сертификат";
            }

            TbkProductNumber.Text = _product.Number;
            TbkProduct.Text = _product.Info;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (AppData.Message.Question("Вы уверены? Не сохранённые данные будут утеряны.") == MessageBoxResult.Yes)
                Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbxNumber.Text) || string.IsNullOrWhiteSpace(TbxRequirements.Text) ||
                DpStartDate.SelectedDate == null || DpEndDate.SelectedDate == null || CbxManufacturer.SelectedItem == null)
            {
                AppData.Message.Error("Заполните все поля.");
            }
            else
            {
                if (_product.Certificate == null)
                {
                    _product.Certificate = new Certificate
                    {
                        Number = TbxNumber.Text,
                        DateStart = DpStartDate.SelectedDate.Value,
                        DateEnd = DpEndDate.SelectedDate.Value,
                        Manufacturer = CbxManufacturer.SelectedItem as Manufacturer,
                        Requirements = TbxRequirements.Text
                    };
                }
                else
                {
                    _product.Certificate.DateStart = DpStartDate.SelectedDate.Value;
                    _product.Certificate.DateEnd = DpEndDate.SelectedDate.Value;
                    _product.Certificate.Manufacturer = CbxManufacturer.SelectedItem as Manufacturer;
                    _product.Certificate.Requirements = TbxRequirements.Text;
                }

                if (AppData.Message.Question("Вы хотите сохранить сертификат в формате PNG?") == MessageBoxResult.Yes)
                {
                    SaveFileDialog sfd = new SaveFileDialog
                    {
                        FileName = $"Сертификат{_product.Certificate.Number}_{DateTime.Now:dd-MM-yyyy}",
                        DefaultExt = ".png",
                        Filter = "Изображение (*.png)|*.png"
                    };

                    if (sfd.ShowDialog() == true)
                    {
                        RenderTargetBitmap rtb = new RenderTargetBitmap((int)CnsCertificate.ActualWidth,
                             (int)CnsCertificate.ActualHeight, 96d, 96d, PixelFormats.Default);
                        rtb.Render(CnsCertificate);

                        var encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(BitmapFrame.Create(rtb));

                        using (var stream = sfd.OpenFile())
                        {
                            encoder.Save(stream);
                        }
                        System.Diagnostics.Process.Start(sfd.FileName);
                        _product.Certificate.Photo = File.ReadAllBytes(sfd.FileName);
                    }
                }

                AddProductWindow._certificate = _product.Certificate;
                Close();
            }
        }

        private void TbxNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            TbkNumber.Text = TbxNumber.Text;

        }

        private void DpStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TbkDateStart.Text = $"{DpStartDate.SelectedDate:dd.MM.yyyy}";
        }

        private void DpEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            TbkDateEnd.Text = $"{DpEndDate.SelectedDate:dd.MM.yyyy}";

        }

        private void CbxManufacturer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbxManufacturer.SelectedItem != null)
            {
                BtnEditManufacturer.IsEnabled = true;
                TbkManufacturer.Text = TbkIssued.Text = (CbxManufacturer.SelectedItem as Manufacturer).Info;
            }
            else
            {
                BtnEditManufacturer.IsEnabled = false;
                TbkManufacturer.Text = TbkIssued.Text = "";
            }
        }

        private void BtnAddManufacturer_Click(object sender, RoutedEventArgs e)
        {
            AddManufacturerWindow window = new AddManufacturerWindow(null)
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
            LoadManufacturers();
        }

        private void LoadManufacturers()
        {
            AppData.Context.ChangeTracker.Entries<Manufacturer>().ToList().ForEach(i => i.Reload());
            var _manufacturers = AppData.Context.Manufacturer.ToList();
            CbxManufacturer.ItemsSource = null;
            CbxManufacturer.ItemsSource = _manufacturers;
            if (_manufacturer != null)
                CbxManufacturer.SelectedItem = _manufacturers.FirstOrDefault(i => i.Name == _manufacturer.Name);
        }

        private void TbxRequirements_TextChanged(object sender, TextChangedEventArgs e)
        {
            TbkRequirements.Text = TbxRequirements.Text;
        }

        private void BtnEditManufacturer_Click(object sender, RoutedEventArgs e)
        {
            AddManufacturerWindow window = new AddManufacturerWindow(CbxManufacturer.SelectedItem as Manufacturer)
            {
                Owner = Window.GetWindow(this)
            };
            window.ShowDialog();
            LoadManufacturers();
        }

        private void TbxNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            new HelperClass().InputOnlyDigit(e);
        }
    }
}
