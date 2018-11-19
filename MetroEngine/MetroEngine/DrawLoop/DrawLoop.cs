using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace MetroEngine
{
    class DrawLoop
    {
        GameData data;

        MainWindow mainWindow;

        int frames;

        public DrawLoop(ref GameData data, ref MainWindow outImage)
        {
            frames = 0;
            this.data = data;
            this.mainWindow = outImage;
            //image = new BitmapImage(new Uri("C:/Users/Kauri/Desktop/Testi.png"));
        }

        public void Infinite(ref Stopwatch timer, float interval, CancellationToken cancellationToken)
        {
            Console.WriteLine("Infinite draw loop started");
            while (!cancellationToken.IsCancellationRequested)
            {
                Draw();
                //pitäisi saada tämä hoitamaan ajoitus
                Thread.Sleep(1 + (int)(interval - ((timer.Elapsed.TotalMilliseconds - 1000) % interval)));
                //Thread.Sleep(1);
            }
        }

        public void TriggerDraw()
        {
            Draw();
        }

        private void Draw()
        {
            Console.WriteLine("Drawing...");


            //TESTAUSTA
            frames++;
            // draw using byte array
            int width = 300, height = 168, bytesperpixel = 4;
            int stride = width * bytesperpixel;
            byte[] imgdata = new byte[width * height * bytesperpixel];
            
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    // BGRA
                    imgdata[row * stride + col * 4 + 0] = Convert.ToByte(byte.MaxValue * (row % 2));
                    imgdata[row * stride + col * 4 + 1] = Convert.ToByte(frames%byte.MaxValue);
                    imgdata[row * stride + col * 4 + 2] = Convert.ToByte(col%byte.MaxValue);
                    imgdata[row * stride + col * 4 + 3] = byte.MaxValue;
                }
            }
            
            foreach (DrawComponent component in data.GetDrawComponents())
            {
                //component.Draw();
            }

            //Actually drawing the image on screen
            Console.WriteLine("Drawn!");
            BitmapSource image = BitmapSource.Create(width, height, 96, 96, PixelFormats.Bgra32, null, imgdata, stride);
            image.Freeze();
            mainWindow.Dispatcher.Invoke(() => mainWindow.UpdateImage(image));
        }
    }
}
