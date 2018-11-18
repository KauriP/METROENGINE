using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace MetroEngine
{
    class DrawLoop
    {
        GameData data;

        public DrawLoop(ref GameData data)
        {
            this.data = data;
        }

        public void Infinite(ref Stopwatch timer, float interval)
        {
            Console.WriteLine("Infinite draw loop started");
            while (true)
            {
                //vähäsen huono tapa ehkä
                //while (0.01f < timer.Elapsed.TotalMilliseconds % interval && timer.Elapsed.TotalMilliseconds % interval < interval-0.01f);

                //pitäisi saada tämä hoitamaan ajoitus
                Thread.Sleep(1 + (int)(interval - ((timer.Elapsed.TotalMilliseconds - 1000) % interval)));
                //Thread.Sleep(1);
            }
        }

        private void Draw()
        {
            foreach (DrawComponent component in data.GetDrawComponents())
            {
                //component.Draw();
            }
        }
    }
}
