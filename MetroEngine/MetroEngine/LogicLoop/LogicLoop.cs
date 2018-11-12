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
        Dictionary<String, GameObject> gameObjects;
        List<UpdateComponent> updateComponents;

        public LogicLoop (ref Dictionary<String, GameObject> tempGameObjects, ref List<UpdateComponent> tempUpdateComponents)
        {
            gameObjects = tempGameObjects;
            updateComponents = tempUpdateComponents;
        }

        //tuo ref pitäisi olla in, mutta ei jonkin takia toimi (ref, in, out)
        public void Infinite(ref Stopwatch timer, float interval)
        {
            Console.WriteLine("Infinite logic loop started");
            while(true)
            {
                //vähäsen huono tapa ehkä
                //while (0.01f < timer.Elapsed.TotalMilliseconds % interval && timer.Elapsed.TotalMilliseconds % interval < interval-0.01f);
                DoUpdate1();

                //pitäisi saada tämä hoitamaan ajoitus
                Thread.Sleep(1+(int)(interval - ((timer.Elapsed.TotalMilliseconds-1000) % interval)));
                //Thread.Sleep(1);
            }
        }

        private void DoUpdate1()
        {
            foreach(UpdateComponent component in updateComponents)
            {
                component.Update1();
            }
            Console.WriteLine("Done update1. Interval was {0}.", Program.nosing.CheckElapsedTime1());
        }

        private void DoUpdate2()
        {
            foreach (UpdateComponent component in updateComponents)
            {
                component.Update2();
            }
        }

        private void DoUpdate3()
        {
            foreach (UpdateComponent component in updateComponents)
            {
                component.Update3();
            }
        }
    }
}
