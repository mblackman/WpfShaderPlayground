using System.Windows.Controls;
using System.Windows.Media;

namespace ShaderPlayground
{
    /// <summary>
    /// Interaction logic for GradientControl.xaml
    /// </summary>
    public partial class GradientControl : UserControl
    {
        public GradientControl()
        {
            InitializeComponent();
            UpdateCanvasColors();
        }

        private void UpdateCanvasColors()
        {
            if (this.Gradient == null) return;

            this.Gradient.TopLeftColor = this.TopLeftColorPicker?.SelectedColor ?? default(Color);
            this.Gradient.TopRightColor = this.TopRightColorPicker?.SelectedColor ?? default(Color);
            this.Gradient.BottomLeftColor = this.BottomLeftColorPicker?.SelectedColor ?? default(Color);
            this.Gradient.BottomRightColor = this.BottomRightColorPicker?.SelectedColor ?? default(Color);
            this.Gradient.Update();
        }

        private void SelectedColorChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<Color?> e)
        {
            UpdateCanvasColors();
        }
    }
}
