using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ShaderPlayground
{
    public class Gradient : ShaderEffect
    {
        private static readonly PixelShader pixelShader = new PixelShader();

        static Gradient()
        {
            pixelShader.UriSource = new Uri(Path.Combine(ShaderUtilities.AssemblyDirectory, "Shaders\\Gradient.ps"));
        }
        
        public Gradient()
        {
            this.PixelShader = pixelShader;
            Update();
        }

        public void Update()
        {
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(TopLeftColorProperty);
        }

        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(Gradient), 0, SamplingMode.NearestNeighbor);

        public Color TopLeftColor
        {
            get { return (Color)GetValue(TopLeftColorProperty); }
            set { SetValue(TopLeftColorProperty, value); }
        }

        public static readonly DependencyProperty TopLeftColorProperty =
            DependencyProperty.Register("TopLeftColor", typeof(Color), typeof(Gradient),
              new UIPropertyMetadata(new Color(), PixelShaderConstantCallback(0)));

        public Color TopRightColor
        {
            get { return (Color)GetValue(TopRightColorProperty); }
            set { SetValue(TopRightColorProperty, value); }
        }

        public static readonly DependencyProperty TopRightColorProperty =
            DependencyProperty.Register("TopRightColor", typeof(Color), typeof(Gradient),
              new UIPropertyMetadata(new Color(), PixelShaderConstantCallback(1)));

        public Color BottomLeftColor
        {
            get { return (Color)GetValue(BottomLeftColorProperty); }
            set { SetValue(BottomLeftColorProperty, value); }
        }

        public static readonly DependencyProperty BottomLeftColorProperty =
            DependencyProperty.Register("BottomLeftColor", typeof(Color), typeof(Gradient),
              new UIPropertyMetadata(new Color(), PixelShaderConstantCallback(2)));

        public Color BottomRightColor
        {
            get { return (Color)GetValue(BottomRightColorProperty); }
            set { SetValue(BottomRightColorProperty, value); }
        }

        public static readonly DependencyProperty BottomRightColorProperty =
            DependencyProperty.Register("BottomRightColor", typeof(Color), typeof(Gradient),
              new UIPropertyMetadata(new Color(), PixelShaderConstantCallback(3)));
    }
}
