using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace MetroEngine
{

    /// <summary>
    /// Class to test and diagnose stuff
    /// </summary>
    class TestNosing
    {
        private Stopwatch timingTimer1;
        public GameForm form;
        Bitmap image;
        public TestNosing()
        {
            timingTimer1 = new Stopwatch();
            timingTimer1.Start();
            image = new Bitmap(26, 26);
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
