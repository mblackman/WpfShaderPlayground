using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace ShaderPlayground
{
    /// <summary>
    /// Interaction logic for PhotoEditor.xaml
    /// </summary>
    public partial class PhotoEditor : UserControl
    {
        public PhotoEditor()
        {
            InitializeComponent();
        }
        
        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenImage();
        }

        private void OpenImage()
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                var fileUri = new Uri(dlg.FileName, UriKind.Absolute);
                image.UriSource = fileUri;
                image.EndInit();

                this.CurrentImage.Source = image;
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenImage();
        }

        private void RedValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            this.EditEffect.RedChannel = (float)e.NewValue;
        }

        private void GreenValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            this.EditEffect.GreenChannel = (float)e.NewValue;
        }

        private void BlueValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            this.EditEffect.BlueChannel = (float)e.NewValue;
        }
    }
}
