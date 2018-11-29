using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ShaderPlayground
{
    public class Transparency : ShaderEffect
    {
        private static readonly PixelShader pixelShader = new PixelShader();

        static Transparency()
        {
            pixelShader.UriSource = new Uri(Path.Combine(ShaderUtilities.AssemblyDirectory, "Shaders\\Transparency.ps"));
        }
        
        public Transparency()
        {
            this.PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(OpacityProperty);
        }

        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(Transparency), 0);

        public double Opacity
        {
            get { return (double)GetValue(OpacityProperty); }
            set { SetValue(OpacityProperty, value); }
        }

        public static readonly DependencyProperty OpacityProperty =
            DependencyProperty.Register("Opacity", typeof(double), typeof(Transparency),
              new UIPropertyMetadata(1.0d, PixelShaderConstantCallback(0)));
    }
}
