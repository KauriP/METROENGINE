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

        public MainWindow()
        {
            InitializeComponent();
            //bitmap = new WriteableBitmap(300, 168, 96, 96, PixelFormats.Bgra32, null);
            RenderOptions.SetBitmapScalingMode(outImage, BitmapScalingMode.NearestNeighbor);
            engine = new Engine(this);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Key KeyCode = e.Key;
            var instance = new InputManager();
            instance.ReactDown();

            if (e.Key == Key.F)
            {
                if (WindowStyle == WindowStyle.None)
                {
                    WindowStyle = WindowStyle.SingleBorderWindow;
                }
                else
                {
                    WindowStyle = WindowStyle.None;
                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            Key KeyCode = e.Key;
            var instance = new InputManager();
            instance.ReactUp();
        }
        

        public void UpdateImage(BitmapSource bitmap)
        {
            outImage.Source = bitmap;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            engine.ShutDown();
        }
    }
}
