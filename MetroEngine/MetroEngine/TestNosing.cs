﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Drawing;

namespace MetroEngine
{

    /// <summary>
    /// Class to test and diagnose stuff
    /// </summary>
    class TestNosing
    {
        private Stopwatch timingTimer1;
        public TestNosing()
        {
            timingTimer1 = new Stopwatch();
            timingTimer1.Start();
        }
        public float CheckElapsedTime1()
        {
            float elapsed = (float) timingTimer1.Elapsed.TotalMilliseconds;
            timingTimer1.Restart();
            return elapsed;
        }
        public void TestDraw()
        {
            //form.DebugDraw(image);
        }
    }
}
