using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace ShaderPlayground
{
    public class PhotoEdit : ShaderEffect
    {
        private static readonly PixelShader pixelShader = new PixelShader();

        static PhotoEdit()
        {
            pixelShader.UriSource = new Uri(Path.Combine(ShaderUtilities.AssemblyDirectory, "Shaders\\PhotoEdit.ps"));
        }
        
        public PhotoEdit()
        {
            this.PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(RedChannelProperty);
            UpdateShaderValue(GreenChannelProperty);
            UpdateShaderValue(BlueChannelProperty);
        }
        
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }

        public static readonly DependencyProperty InputProperty = RegisterPixelShaderSamplerProperty("Input", typeof(PhotoEdit), 0, SamplingMode.NearestNeighbor);

        public float RedChannel
        {
            get { return (float)GetValue(RedChannelProperty); }
            set { SetValue(RedChannelProperty, value); }
        }

        public static readonly DependencyProperty RedChannelProperty =
            DependencyProperty.Register("RedChannel", typeof(float), typeof(PhotoEdit),
                new UIPropertyMetadata(new float(), PixelShaderConstantCallback(0)));

        public float GreenChannel
        {
            get { return (float)GetValue(GreenChannelProperty); }
            set { SetValue(GreenChannelProperty, value); }
        }

        public static readonly DependencyProperty GreenChannelProperty =
            DependencyProperty.Register("GreenChannel", typeof(float), typeof(PhotoEdit),
                new UIPropertyMetadata(new float(), PixelShaderConstantCallback(1)));

        public float BlueChannel
        {
            get { return (float)GetValue(BlueChannelProperty); }
            set { SetValue(BlueChannelProperty, value); }
        }

        public static readonly DependencyProperty BlueChannelProperty =
            DependencyProperty.Register("BlueChannel", typeof(float), typeof(PhotoEdit),
                new UIPropertyMetadata(new float(), PixelShaderConstantCallback(2)));
    }
}
