using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ShaderPlayground
{
    public class ScrollingImages : ShaderEffect
    {
        private static readonly PixelShader pixelShader = new PixelShader();

        static ScrollingImages()
        {
            pixelShader.UriSource = new Uri(Path.Combine(ShaderUtilities.AssemblyDirectory, "Shaders\\ScrollingImages.ps"));
        }
        
        public ScrollingImages()
        {
            this.PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(ScrollingImageProperty);
        }
        
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public ImageSource ScrollingImage
        {
            get { return (ImageSource)GetValue(ScrollingImageProperty); }
            set { SetValue(ScrollingImageProperty, value); }
        }

        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(ScrollingImages), 0, SamplingMode.NearestNeighbor);

        public static readonly DependencyProperty ScrollingImageProperty = RegisterPixelShaderSamplerProperty("ScrollingImage", typeof(ScrollingImages), 0, SamplingMode.NearestNeighbor);

        public float VerticalScrollSpeed
        {
            get { return (float)GetValue(VerticalScrollSpeedProperty); }
            set { SetValue(VerticalScrollSpeedProperty, value); }
        }

        public static readonly DependencyProperty VerticalScrollSpeedProperty =
            DependencyProperty.Register("VerticalScrollSpeed", typeof(float), typeof(ScrollingImages), new UIPropertyMetadata(new float(), PixelShaderConstantCallback(0)));

        public float HorizontalScrollSpeed
        {
            get { return (float)GetValue(HorizontalScrollSpeedProperty); }
            set { SetValue(HorizontalScrollSpeedProperty, value); }
        }

        public static readonly DependencyProperty HorizontalScrollSpeedProperty =
            DependencyProperty.Register("HorizontalScrollSpeed", typeof(float), typeof(ScrollingImages), new UIPropertyMetadata(new float(), PixelShaderConstantCallback(1)));
    }
}
