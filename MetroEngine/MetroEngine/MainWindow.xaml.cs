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
            RenderOptions.SetBitmapScalingMode(outImage, BitmapScalingMode.NearestNeighbor);
            InitializeEngine();
        }

        private void InitializeEngine()
        {
            engine = new Engine(this);
            //Input reactions
            KeyDown += new KeyEventHandler(engine.input.ReactDown);
            KeyUp += new KeyEventHandler(engine.input.ReactUp);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(!e.IsRepeat && e.Key == Key.F)
            {
                if(WindowStyle == WindowStyle.None)
                {
                    WindowStyle = WindowStyle.SingleBorderWindow;
                } else
                {
                    WindowStyle = WindowStyle.None;
                }
            }
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
