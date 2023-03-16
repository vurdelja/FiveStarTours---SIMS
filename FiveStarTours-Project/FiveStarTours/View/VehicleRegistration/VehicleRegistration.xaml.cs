using FiveStarTours.Model;
using Microsoft.Win32;
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

namespace FiveStarTours.View.VehicleRegistration
{
    /// <summary>
    /// Interaction logic for VehicleRegistration.xaml
    /// </summary>
    public partial class VehicleRegistration : Window
    {
        private object myImageControl;
        private object myComboBox;

        public VehicleRegistration()
        {
            InitializeComponent();
        }


        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";

            if (openFileDialog.ShowDialog() == true)
            {
                // User selected a file. You can get the file path using the FileName property of the OpenFileDialog.
                string filePath = openFileDialog.FileName;

                // You can now load the image and display it in your user interface.
                // For example, you can create a BitmapImage object and set its UriSource property to the file path.
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(filePath);
                image.EndInit();

                // Display the image in an Image control in your user interface.
                myImageControl = image;
            }

        }


        private void LoactionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
