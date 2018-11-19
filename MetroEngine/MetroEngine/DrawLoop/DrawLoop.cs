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

        //TESTAUSTA
        int frames;

        public DrawLoop(ref GameData data, ref MainWindow outImage)
        {
            frames = 0;
            this.data = data;
            this.mainWindow = outImage;
            //image = new BitmapImage(new Uri("C:/Users/Kauri/Desktop/Testi.png"));
        }

        //Drawing controlled from LogicLoop

        //public void Infinite(ref Stopwatch timer, float interval, CancellationToken cancellationToken)
        //{
        //    Console.WriteLine("Infinite draw loop started");
        //    while (!cancellationToken.IsCancellationRequested)
        //    {
        //        Draw();
        //        //pitäisi saada tämä hoitamaan ajoitus
        //        Thread.Sleep(1 + (int)(interval - ((timer.Elapsed.TotalMilliseconds - 1000) % interval)));
        //        //Thread.Sleep(1);
        //    }
        //}

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
            int width = 300, height = 168, bytesperpixel = 3;
            int stride = width * bytesperpixel;
            byte[] imgdata = new byte[stride * height];

            void SetPixel(DrawPixel drawPixel)
            {
                imgdata[drawPixel.viewPos.Y * stride + bytesperpixel * drawPixel.viewPos.X + 0] = drawPixel.color[0];
                imgdata[drawPixel.viewPos.Y * stride + bytesperpixel * drawPixel.viewPos.X + 1] = drawPixel.color[1];
                imgdata[drawPixel.viewPos.Y * stride + bytesperpixel * drawPixel.viewPos.X + 2] = drawPixel.color[2];
            }
            
            foreach (DrawComponent component in data.GetDrawComponents())
            {
                foreach(DrawPixel drawPixel in component.GetDraw())
                {
                    SetPixel(drawPixel);
                }
            }

            //Actually drawing the image on screen
            Console.WriteLine("Drawn!");
            BitmapSource image = BitmapSource.Create(width, height, 96, 96, PixelFormats.Bgr24, null, imgdata, stride);
            image.Freeze();
            mainWindow.Dispatcher.Invoke(() => mainWindow.UpdateImage(image));
        }

        public struct DrawPixel
        {
            public byte[] color;
            public Vector2Int viewPos;
            
            public DrawPixel(byte[] color, Vector2Int viewPos)
            {
                this.color = color;
                this.viewPos = viewPos;
            }
        }
    }
}
