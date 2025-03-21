using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MakersMarkt.Classes;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MakersMarkt.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductsPage : Page
    {
        private static Product SelectedProduct;
        public ProductsPage()
        {
            this.InitializeComponent();

            using (var connection = new AppDbContext())
            {
                var Products = connection.Products;

                AllProdGridView.ItemsSource = Products;
            }
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }

        private void go2CreateViewButton_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(CreateProductPage));
        }

        private void go2EditViewButton_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(EditProductPage), SelectedProduct);
        }

        private async void deleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProduct != null)
            {
                var deleteDialog = new ContentDialog
                {
                    Title = "Bevestig Verwijdering",
                    Content = "Verwijderen in permanent en is niet ongedaan te maken (Permanent dus).",
                    PrimaryButtonText = "Verwijder",
                    CloseButtonText = "Annuleer",
                    DefaultButton = ContentDialogButton.Close,
                    XamlRoot = this.Content.XamlRoot
                };

                var result = await deleteDialog.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {
                    using (var connection = new AppDbContext())
                    {
                        var product2BeRemoved = connection.Products.Single(p => p.Id == SelectedProduct.Id);
                        connection.Products.Remove(product2BeRemoved);
                        connection.SaveChanges();

                        var products = connection.Products;

                        AllProdGridView.ItemsSource = products;
                    }
                }
                else
                {

                }
            }
        }

 

        private void Go2CreateViewButton_Click(object sender, RoutedEventArgs e)
        {
          //  Frame.Navigate(typeof(CreateProductPage));
        }

        private void Go2EditViewButton_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(EditProductPage), SelectedProduct);
        }

        private async void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProduct != null)
            {
                var DeleteDialog = new ContentDialog
                {
                    Title = "Bevestig Verwijdering",
                    Content = "Verwijderen in permanent en is niet ongedaan te maken (Permanent dus).",
                    PrimaryButtonText = "Verwijder",
                    CloseButtonText = "Annuleer",
                    DefaultButton = ContentDialogButton.Close,
                    XamlRoot = this.Content.XamlRoot
                };

                var Result = await DeleteDialog.ShowAsync();

                if (Result == ContentDialogResult.Primary)
                {
                    using (var Connection = new AppDbContext())
                    {
                        var Product2BeRemoved = Connection.Products.Single(p => p.Id == SelectedProduct.Id);
                        Connection.Products.Remove(Product2BeRemoved);
                        Connection.SaveChanges();

                        var Products = Connection.Products;

                        AllProdGridView.ItemsSource = Products;
                    }
                }
            }
        }
    }
}
