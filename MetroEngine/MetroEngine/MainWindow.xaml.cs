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

namespace MetroEngine
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Engine engine;

        public WriteableBitmap bitmap;

        public MainWindow()
        {
            InitializeComponent();
            bitmap = new WriteableBitmap(300, 168, 96, 96, PixelFormats.Bgra32, null);
            RenderOptions.SetBitmapScalingMode(outImage, BitmapScalingMode.NearestNeighbor);
            engine = new Engine(this);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Testi");
            // draw using byte array
            int width = 300, height = 168, bytesperpixel = 4;
            int stride = width * bytesperpixel;
            byte[] imgdata = new byte[width * height * bytesperpixel];

            // draw a gradient from red to green from top to bottom (R00 -> ff; Gff -> 00)
            // draw a gradient of alpha from left to right
            // Blue constant at 00
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    // BGRA
                    imgdata[row * stride + col * 4 + 0] = 0;
                    imgdata[row * stride + col * 4 + 1] = Convert.ToByte(1);
                    imgdata[row * stride + col * 4 + 2] = Convert.ToByte(240);
                    imgdata[row * stride + col * 4 + 3] = Convert.ToByte(70);
                }
            }
            UpdateImage();
            //outImage.Source = bitmap;
        }

        public void UpdateImage()
        {
            outImage.Source = bitmap;
            //outImage.Source = image;
        }
    }
}
