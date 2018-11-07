using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace MetroEngine
{
    class LogicLoop
    {
        public LogicLoop ()
        {

        }

        //tuo ref pitäisi olla in, mutta ei jonkin takia toimi (ref, in, out)
        public void Infinite(ref Stopwatch timer, float interval)
        {
            Console.WriteLine("Infinite logic loop started");
            while(true)
            {
                //vähäsen huono tapa ehkä
                while (0.01f < timer.Elapsed.TotalMilliseconds % interval && timer.Elapsed.TotalMilliseconds % interval < interval-0.01f);
                DoUpdate1();
                Console.WriteLine(timer.Elapsed.TotalMilliseconds % interval);
                //pitäisi saada tämä hoitamaan ajoitus
                Thread.Sleep((int)(interval - (timer.Elapsed.TotalMilliseconds % interval)));
                //Thread.Sleep(10);
            }
        }

        private void DoUpdate1()
        {
            Console.WriteLine("Done update1. Interval was {0}.", Program.nosing.CheckElapsedTime1());
        }
    }
}
