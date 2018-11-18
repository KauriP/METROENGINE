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

        BitmapSource image;

        int frames;

        public DrawLoop(ref GameData data, ref MainWindow outImage)
        {
            frames = 0;
            this.data = data;
            this.mainWindow = outImage;
            image = new BitmapImage(new Uri("C:/Users/Kauri/Desktop/Testi.png"));
        }

        public void Infinite(ref Stopwatch timer, float interval)
        {
            Console.WriteLine("Infinite draw loop started");
            while (true)
            {
                //vähäsen huono tapa ehkä
                //while (0.01f < timer.Elapsed.TotalMilliseconds % interval && timer.Elapsed.TotalMilliseconds % interval < interval-0.01f);
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
            frames++;

            Console.WriteLine("Drawn!");
            //mainWindow.Dispatcher.Invoke(() => mainWindow.UpdateImage(image));

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
                    imgdata[row * stride + col * 4 + 1] = Convert.ToByte(frames);
                    imgdata[row * stride + col * 4 + 2] = Convert.ToByte(240);
                    imgdata[row * stride + col * 4 + 3] = Convert.ToByte(70);
                }
            }
            //image = BitmapSource.Create(width, height, 96, 96, PixelFormats.Bgra32, null, imgdata, stride);
            mainWindow.Dispatcher.Invoke(() => mainWindow.UpdateImage());


            foreach (DrawComponent component in data.GetDrawComponents())
            {
                //component.Draw();
            }
        }
    }
}
