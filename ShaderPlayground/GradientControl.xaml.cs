using System.Threading;
using System.Windows.Controls;
using System.Windows.Media;

namespace ShaderPlayground
{
    /// <summary>
    /// Interaction logic for GradientControl.xaml
    /// </summary>
    public partial class GradientControl : UserControl
    {
        private Timer timer1;
        private bool isAutoPhase = false;
        private float currentAutoPhaseValue = 0f;

        private const float AutoPhaseIncrementAmount = .1f;

        public double MaxPhaseValue { get; set; } = 15;
                
        public GradientControl()
        {
            InitializeComponent();
            UpdateCanvasColors();
        }

        private void OnPhaseUpdate(object state)
        {
            Dispatcher.Invoke(() =>
            {
                this.currentAutoPhaseValue += AutoPhaseIncrementAmount;
                this.Gradient.Phase = this.currentAutoPhaseValue;
            });
        }

        private void UpdateCanvasColors()
        {
            if (this.Gradient == null) return;

            this.Gradient.TopLeftColor = this.TopLeftColorPicker?.SelectedColor ?? default(Color);
            this.Gradient.TopRightColor = this.TopRightColorPicker?.SelectedColor ?? default(Color);
            this.Gradient.BottomLeftColor = this.BottomLeftColorPicker?.SelectedColor ?? default(Color);
            this.Gradient.BottomRightColor = this.BottomRightColorPicker?.SelectedColor ?? default(Color);
        }

        private void SelectedColorChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<Color?> e)
        {
            UpdateCanvasColors();
        }

        private void PhaseSliderValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            if (!isAutoPhase)
            {
                this.Gradient.Phase = (float)e.NewValue;
            }
        }

        private void FrequencySliderValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            this.Gradient.Frequency = (float)e.NewValue;
        }

        private void AmplitudeSliderValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            this.Gradient.Amplitude = (float)e.NewValue;
        }

        private void CheckBox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.isAutoPhase = this.AutoPhaseCheck?.IsChecked ?? false;

            if (this.isAutoPhase)
            {
                timer1 = new Timer(OnPhaseUpdate, null, 0, 10);
            }
            else
            {
                timer1.Dispose();
            }
        }
    }
}
