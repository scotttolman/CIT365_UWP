using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GlazerCalculation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            List<TintType> list = Enum.GetValues(typeof(TintType)).Cast<TintType>().ToList();
            tintBox.ItemsSource = list;
        }

        private void widthBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            float input;
            if (float.TryParse(widthBox.Text, out input))
            {
                if (input < Glass.MIN_WIDTH || input > Glass.MAX_WIDTH)
                {
                    valWidth.Visibility = Visibility.Visible;
                }
                else
                {
                    valWidth.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                valWidth.Visibility = Visibility.Visible;
            }
        }

        private void heightBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            float input;
            if (float.TryParse(heightBox.Text, out input))
            {
                if (input < Glass.MIN_HEIGHT || input > Glass.MAX_HEIGHT)
                {
                    valHeight.Visibility = Visibility.Visible;
                }
                else
                {
                    valHeight.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                valHeight.Visibility = Visibility.Visible;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Glass glass = new Glass(double.Parse(widthBox.Text), double.Parse(heightBox.Text), 
                (TintType)tintBox.SelectedValue, quantSlider.Value);
            string calculation = glass.display();

            showResults(calculation);
        }

        private async void showResults(string calculation)
        {
            ContentDialog results = new ContentDialog
            {
                Title = "Results",
                Content = calculation,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await results.ShowAsync();
        }
    }
}
