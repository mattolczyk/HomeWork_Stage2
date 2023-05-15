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



using InventoryManagement;
using InventoryManagement.EntityFramework;
using InventoryManagement.Migrations;
using Microsoft.Extensions.Options;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Net;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Security.Policy;
using System.Diagnostics;

namespace InventoryManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var productsRepository = new ProductsRepository();
            var suppliersRepository = new SuppliersRepository();

            var productRecord = new Products
            {
                //Id = Int32.Parse(txtId.Text),
                Name = txtName.Text,
                Description = txtDescription.Text,
                Category = "blank",
                Quantity = 1,
                Price = 1,
                SupplierId = 1

            };

            try
            {
            productsRepository.Add(productRecord);
                MessageBox.Show("Product Added to database! ", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (DbException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {

            var productsRepository = new ProductsRepository();
            var products = await productsRepository.GetAll();

            try
            {
                foreach (var product in products)
                {
                    txtViewer.Text += $"{product.Id} {product.Name} \n";
                }
            }

            catch (Exception)
            {
                MessageBox.Show("We cannot process your data - cannot find city probably ! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }
        private void Button_Click4(object sender, RoutedEventArgs e)
        {

        }

    }
}
